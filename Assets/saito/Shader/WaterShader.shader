Shader "Custom/WaterShader" {
    Properties {
        _Color ("Water Color", Color) = (0.0, 0.5, 1.0, 1.0)
        _MainTex ("Main Texture", 2D) = "white" { }
        _Distortion ("Distortion", Range(0.01, 0.1)) = 0.02
        _Speed ("Speed", Range(0.1, 2.0)) = 0.5
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        fixed4 _Color;
        sampler2D _MainTex;
        float _Distortion;
        float _Speed;

        struct Input {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            // 波の影響を受けたUV座標を計算
            float2 uv = IN.uv_MainTex + _Distortion * sin(_Time.y * _Speed);

            // 波の高さによって水面の色を変える
            fixed4 c = _Color * tex2D(_MainTex, uv);

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}