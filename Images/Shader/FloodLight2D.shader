Shader "MyShader/FloodLight2D"
{
    Properties
    {
        [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1, 1, 1, 1)
        _Blur("Blur", Range(0, 0.1)) = 0.005
        _Border("Border",Range(0, 0.1)) = 0.01
        _BorderColor("BorderColor",Color) = (1, 1, 1, 1)
        _OutLightSize("OutLightSize", Range(0, 3)) = 0.1
        _Light("Light", Range(0, 1)) = 0.1
    }
    SubShader
    {
        Tags{ "queue" = "transparent" }
        LOD 100

        Pass
        {
            blend srcalpha oneminussrcalpha
            CGPROGRAM

            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag

            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Border;
            fixed _Blur;
            float4 _BorderColor;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                fixed4 Color0;
                float2 uv2 = i.uv;
                Color0 = tex2D(_MainTex, uv2);
                fixed4 Color5 = fixed4(0, 0, 0, 0);
                fixed4 Color1 = tex2D(_MainTex, uv2 + fixed2(_Border, 0));
                fixed4 Color2 = tex2D(_MainTex, uv2 + fixed2(-_Border, 0));
                fixed4 Color3 = tex2D(_MainTex, uv2 + fixed2(0, _Border));
                fixed4 Color4 = tex2D(_MainTex, uv2 + fixed2(0, -_Border));

                Color5 = Color1 + Color2 + Color3 + Color4;

                if (Color5.a > 3.8 || Color5.a < 0.3) {
                    Color5 = fixed4(0, 0, 0, 0);
                }
                else {
                    Color5 += fixed4(0.5, 0.5, 0.5, 0.5);
                }

                return Color5 / 4 * _BorderColor;
            }

            ENDCG
        }

        Pass
        {
            blend srcalpha oneminussrcalpha
            CGPROGRAM

            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag

            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Border;
            fixed _Blur;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                fixed4 Color0;
                float2 uv2 = i.uv;
                Color0 = tex2D(_MainTex, uv2);

                fixed4 Color1;
                for (int i = 0; i < 5; i++) {
                    for (int u = 0; u < 5; u++) {
                        float d = 5 - (abs(i - 2) + abs(u - 2));
                        Color1 += pow(fixed4(1, 1, 1, tex2D(_MainTex, uv2 + fixed2(_Blur * (i - 2) * d,
                            _Blur * (u - 2) * d)).a) * d / 3, 0.5);
                    }
                }
                if (Color1.r < 1 && Color1.a > 1) {
                    Color1.r *= Color1.a;
                    if (Color1.r > 1) {
                        Color1 = fixed4(1, 1, 1, 1);
                    }
                }

                fixed luminance = (0.2125 * Color0.r + 0.7154 * Color0.g + 0.0721 * Color0.b) * Color0.a;

                if (Color0.a < 0.1) {
                    Color0 = fixed4(0, 0, 0, 0);
                }

                fixed4 Color2 = _Color * luminance * 0.8 + Color1 / 25 * 0.6;

                if (0.2125 * Color0.r + 0.7154 * Color0.g + 0.0721 * Color0.b > 0.8) {
                    Color2 = Color2 * 0.8;
                }

                return Color2;
            }

            ENDCG
        }

        Pass
        {
            blend srcalpha oneminussrcalpha
            CGPROGRAM

            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag

                fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Border;
            fixed _Blur;
            fixed _Light;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                fixed4 Color0;
                float2 uv2 = i.uv;
                Color0 = tex2D(_MainTex, uv2);

                fixed4 Color1;
                for (int i = 0; i < 5; i++) {
                    for (int u = 0; u < 5; u++) {
                        float a = tex2D(_MainTex, uv2 + fixed2(_Blur * (i - 2), _Blur * (u - 2))).a;
                        Color1 += fixed4(1, 1, 1, a * (1 - a) * 1.2);
                    }
                }
                Color1 /= 25;

                if (Color0.a < 0.05) {
                    Color0 = fixed4(0, 0, 0, 0);
                }

                fixed4 Color2 = Color0 * 1 + Color1 * 1.5 * _Light;

                if ((0.2125 * Color2.r + 0.7154 * Color2.g + 0.0721 * Color2.b) * Color2.a > 0.5) {
                    Color2 = Color2 * 0.5;
                }
                Color2 = pow(Color2, 2);

                return Color2;
            }
            ENDCG
        }
    }
}
