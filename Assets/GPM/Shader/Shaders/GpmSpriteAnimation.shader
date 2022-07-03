Shader "GPM/GpmSpriteAnimation"
{
	Properties
	{
		_MainTex("Sprite Animation", 2D) = "white" {}
		_HorizontalAmount("Horizontal Amount", Float) = 2
		_VerticalAmount("Vertical Amount", Float) = 2
		_Speed("Speed", Range(1, 100)) = 10
		_CurrentTime("Current Time", Float) = 0

		[HideInInspector] _StencilComp("Stencil Comparison", Float) = 8
		[HideInInspector] _Stencil("Stencil ID", Float) = 0
		[HideInInspector] _StencilOp("Stencil Operation", Float) = 0
		[HideInInspector] _StencilWriteMask("Stencil Write Mask", Float) = 255
		[HideInInspector] _StencilReadMask("Stencil Read Mask", Float) = 255
		[HideInInspector] _ColorMask("Color Mask", Float) = 15
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		LOD 100

		Stencil
		{
			Ref[_Stencil]
			Comp[_StencilComp]
			Pass[_StencilOp]
			ReadMask[_StencilReadMask]
			WriteMask[_StencilWriteMask]
		}
		ColorMask[_ColorMask]
		ZTest[unity_GUIZTestMode]

		Cull Off
		Lighting Off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			float _HorizontalAmount;
			float _VerticalAmount;
			float _Speed;
			float _CurrentTime;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				float time = _CurrentTime * _Speed;

				float row = floor(time / _HorizontalAmount);
				row = fmod(row, _HorizontalAmount);

				float column = floor(time - row * _HorizontalAmount);
				column = fmod(column, _VerticalAmount);

				row = _VerticalAmount - 1 - row;

				float2 uv = TRANSFORM_TEX(v.uv, _MainTex);
				uv.x = lerp(column / _HorizontalAmount, (column + 1) / _HorizontalAmount, uv.x);
				uv.y = lerp(row / _VerticalAmount, (row + 1) / _VerticalAmount, uv.y);
				o.uv = uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				return col;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
