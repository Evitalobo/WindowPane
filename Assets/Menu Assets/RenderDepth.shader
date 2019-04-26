// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/RenderDepth"
{
	
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_DepthAmount("Depth Amount", FLoat) = 1.5
	}

	SubShader
	{
		Tags
		{
			"RenderType"="Opaque"
		}

		ZWrite On

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			# include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float depth : DEPTH;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.depth = -mul(UNITY_MATRIX_MV, v.vertex).z * _ProjectionParams.w;
				o.uv = v.uv;
				return o;
			}

			fixed4 _Color;
			float _DepthAmount;
			sampler _MainTex;

			fixed4 frag(v2f i) : SV_Target
			{
				float4 c = tex2D(_MainTex, i.uv);
				float4 tex = float4(1.0 - c.r, 1.0 - c.r, 1.0 - c.r, 1.0);
				float invert = 1 - i.depth*_DepthAmount;
				return fixed4(invert, invert, invert, 1) * _Color * tex;
			}
			ENDCG
		}
	}
}
