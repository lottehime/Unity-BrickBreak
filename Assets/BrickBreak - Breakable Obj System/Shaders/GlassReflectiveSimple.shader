Shader "lottehime/Glass Reflective Simple" {
	Properties {
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_Cube ("Reflection Cubemap", Cube) = "" 
	}
	SubShader {
		Tags {
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
		}
		LOD 300
		
		CGPROGRAM
			#pragma surface surf BlinnPhong decal:add nolightmap
			#include "UnityCG.cginc"

			struct v2f {
				float4 pos : SV_POSITION;
				float3 uv : TEXCOORD0;
			};

			v2f vert(float4 v : POSITION, float3 n : NORMAL)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v);
				float3 viewDir = normalize(ObjSpaceViewDir(v));
				o.uv = reflect(-viewDir, n);
				o.uv = mul(UNITY_MATRIX_MV, float4(o.uv, 0));
				return o;
			}

			samplerCUBE _Cube;
			half4 frag(v2f i) : SV_Target
			{
				return texCUBE(_Cube, i.uv);
			}
			
			fixed4 _ReflectColor;
			half _Shininess;
			
			struct Input {
				float3 worldRefl;
			};
			
			void surf (Input IN, inout SurfaceOutput o) {
				o.Albedo = 0;
				o.Gloss = 1;
				o.Specular = _Shininess;
				
				fixed4 reflcol = texCUBE (_Cube, IN.worldRefl);
				o.Emission = reflcol.rgb * _ReflectColor.rgb;
				o.Alpha = reflcol.a * _ReflectColor.a;
			}
		ENDCG
	}

	FallBack "Transparent/VertexLit"
}