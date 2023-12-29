Shader "Custom/OutlineGradientShader"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "white" { }
        _TopColor("Top Color", Color) = (1,1,1,1)
        _BottomColor("Bottom Color", Color) = (0,0,0,1)
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Overlay"
            "RenderType" = "Opaque"
        }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        fixed4 _TopColor;
        fixed4 _BottomColor;

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Interpolate color based on vertical position
            o.Albedo = lerp(_BottomColor.rgb, _TopColor.rgb, IN.uv_MainTex.y);
        }
        ENDCG
    }
        FallBack "Diffuse"
}
