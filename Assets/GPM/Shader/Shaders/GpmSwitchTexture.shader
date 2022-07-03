Shader "GPM/GpmSwitchTexture"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _SwitchTex("Switch Texture", 2D) = "white" {}
        _SwitchAmount("Switch Amount", Range(0, 1)) = 0

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

        CGINCLUDE
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
        sampler2D _SwitchTex;
        float4 _SwitchTex_ST;

        float _SwitchAmount;

        v2f vertMain(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX(v.uv, _MainTex);
            return o;
        }

        v2f vertSwitch(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX(v.uv, _SwitchTex);
            return o;
        }

        fixed4 fragMain(v2f i) : SV_Target
        {
            fixed4 o = tex2D(_MainTex, i.uv);
            o.a = lerp(o.a, 0, _SwitchAmount);
            return o;
        }

        fixed4 fragSwitch(v2f i) : SV_Target
        {
            fixed4 o = tex2D(_SwitchTex, i.uv);
            o.a = lerp(0, o.a, _SwitchAmount);
            return o;
        }
        ENDCG

        Pass
        {
            CGPROGRAM
            #pragma vertex vertMain
            #pragma fragment fragMain
            ENDCG
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vertSwitch
            #pragma fragment fragSwitch
            ENDCG
        }
    }
    FallBack "Diffuse"
}
