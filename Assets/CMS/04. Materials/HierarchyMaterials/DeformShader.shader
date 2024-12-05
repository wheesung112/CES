Shader "Custom/DeformShader"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "white" { }
        _IsDeforming("Is Deforming", Float) = 0.0
    }

        SubShader
        {
            Tags { "RenderType" = "Transparent" }
            LOD 100

            CGPROGRAM
            #pragma surface surf Lambert alpha

            struct Input
            {
                float2 uv_MainTex;
            };

            sampler2D _MainTex;
            float _IsDeforming;

            void surf(Input IN, inout SurfaceOutput o)
            {
                if (_IsDeforming > 0)
                {
                    // Deform the object based on collision
                    // Implement your own deformation logic here
                    fixed4 col = tex2D(_MainTex, IN.uv_MainTex);
                    o.Albedo = col.rgb;
                    o.Alpha = col.a; // 알파 값을 설정
                }
                else
                {
                    // Outside the collision, use regular texture
                    fixed4 col = tex2D(_MainTex, IN.uv_MainTex);
                    o.Albedo = col.rgb;
                    o.Alpha = col.a; // 알파 값을 설정
                }
            }
            ENDCG
        }
            FallBack "Diffuse"
}
