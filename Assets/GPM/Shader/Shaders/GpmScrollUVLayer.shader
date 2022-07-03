Shader "GPM/GpmScrollUVLayer"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _RearTex("Rear Texture", 2D) = "white" {}
        _XSpeed("XSpeed", Float) = 1
        _YSpeed("YSpeed", Float) = 0
        _RearXSpeed("Rear XSpeed", Float) = 1
        _RearYSpeed("Rear YSpeed", Float) = 0
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
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _RearTex;
            float4 _RearTex_ST;

            float _XSpeed;
            float _YSpeed;
            float _RearXSpeed;
            float _RearYSpeed;
            float _CurrentTime;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv1 = TRANSFORM_TEX(v.uv, _MainTex) + (float2(_XSpeed, _YSpeed) * _CurrentTime);
                o.uv2 = TRANSFORM_TEX(v.uv, _RearTex) + (float2(_RearXSpeed, _RearYSpeed) * _CurrentTime);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, frac(i.uv1));
                fixed4 d = tex2D(_RearTex, frac(i.uv2));
                fixed4 o = lerp(d, c, c.a);
                return o;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
