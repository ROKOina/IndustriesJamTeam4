Shader "Unlit/PostEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed GrayScale(fixed3 base)
            {
            	return base.r * 0.21 + 0.72 * base.g + 0.07 * base.b;
            }
            
            // カラーのオーバーレイ計算をした値を返す関数。
            fixed Overlay(fixed base,fixed mix_factor)
            {
            	float new_factor = 1.0;
            	if(base < 0.5)
            	{
            		new_factor = base * mix_factor * 2.0;
            	}
            	else
            	{
            		new_factor = 2.0 * (base + mix_factor - base * mix_factor) - 1.0;
            	}
            	return new_factor;
            }

            fixed3 ApplyBleachBypass(fixed3 base_color)
            {
            	// グレースケール値は輝度法で算出
            	float gray_scale_factor = GrayScale(base_color);
            	
            	float3 new_color;
            	new_color.r = Overlay(base_color.r, gray_scale_factor);
            	new_color.g = Overlay(base_color.g, gray_scale_factor);
            	new_color.b = Overlay(base_color.b, gray_scale_factor);
            	
            	return new_color;
            }

            fixed3 ApplyChromaticAberrationRG(v2f i, fixed deviation_width)
            {
	            fixed2 r_texcoord = (i.uv - 0.5) * (1.0 + deviation_width) + 0.5;
	            fixed2 g_texcoord = (i.uv - 0.5) * (1.0 - deviation_width) + 0.5;
            	
            	fixed col_r	= tex2D(_MainTex, r_texcoord).r;
            	fixed col_g	= tex2D(_MainTex, g_texcoord).g;
            	fixed col_b	= tex2D(_MainTex, i.uv).b;
            	
            	fixed3 color = fixed3(col_r, col_g, col_b);
            	return color;
            }

            fixed3 ExtractLuminance(fixed3 base_color, fixed th)
            {
                fixed col_sum = base_color.r + base_color.g + base_color.b;
                if(col_sum < th * 3.0)
                    return 0.0;
                else
                    return base_color;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                fixed3 post_effect_col = ApplyBleachBypass(col.rgb);

                return fixed4(post_effect_col, 1.0);
            }
            ENDCG
        }
    }
}
