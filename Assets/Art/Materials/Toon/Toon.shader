
//Adapted from Example 5.3 in The CG Tutorial by Fernando & Kilgard
Shader "Custom/Toon"
{
	Properties
	{
		_Color("Color", Color) = (1, 1, 1, 1) //The color of our object
		[HDR]
		_Shininess("Shininess", Float) = 10 //Shininess
		_DiffuseAmount("Diffuse Amount", Range(0,1)) = 0.5
		_SpecColor("Specular Color", Color) = (1, 1, 1, 1) //Specular highlights color
		[HDR]
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimAmount("Rim Amount", Range(0, 1)) = 0.716
		_RimThreshold("Rim Threshold", Range(0, 1)) = 0.1
	}

		SubShader
	{
		Pass {
			Tags { "LightMode" = "ForwardAdd" } //Important! In Unity, point lights are calculated in the the ForwardAdd pass
			//Blend One One //Turn on additive blending if you have more than one point light


			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


			uniform float4 _LightColor0; //From UnityCG
			uniform float4 _Color;
			uniform float4 _SpecColor;
			uniform float _Shininess;
			uniform float _DiffuseAmount;
			uniform float4 _RimColor;
			uniform float _RimAmount;
			uniform float _RimThreshold;

			struct appdata
			{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
			};

			struct v2f
			{
					float4 vertex : SV_POSITION;
					float3 normal : NORMAL;
					float3 vertexInWorldCoords : TEXCOORD1;
			};


		   v2f vert(appdata v)
		   {
				v2f o;
				o.vertexInWorldCoords = mul(unity_ObjectToWorld, v.vertex); //Vertex position in WORLD coords
				o.normal = v.normal; //Normal 
				o.vertex = UnityObjectToClipPos(v.vertex);



				return o;
		   }

		   fixed4 frag(v2f i) : SV_Target
		   {

				float3 P = i.vertexInWorldCoords.xyz;
				float3 N = normalize(i.normal);
				float3 V = normalize(_WorldSpaceCameraPos - P);
				float3 L = normalize(_WorldSpaceLightPos0.xyz - P);
				float3 H = normalize(L + V);

				float3 Kd = _Color.rgb; //Color of object
				//float3 Ka = UNITY_LIGHTMODEL_AMBIENT.rgb; //Ambient light
				float3 Ka = float3(0,0,0); //UNITY_LIGHTMODEL_AMBIENT.rgb; //Ambient light
				float3 Ks = _SpecColor.rgb; //Color of specular highlighting
				float3 Kl = _LightColor0.rgb; //Color of light


				//AMBIENT LIGHT 
				float3 ambient = Ka;


				//DIFFUSE LIGHT
				float diffuseVal = dot(N, L) + _DiffuseAmount;
				float diffuseValSmooth = smoothstep(0, 0.01, diffuseVal);
				float3 diffuse = Kd * Kl * diffuseValSmooth;


				//SPECULAR LIGHT
				float specularVal = pow(max(dot(N,H), 0), _Shininess);

				if (diffuseVal <= 0) {
					specularVal = 0;
				}
				float specularIntensitySmooth = smoothstep(0.005, 0.01, specularVal);

				float3 specular = Ks * Kl * specularIntensitySmooth;

				//RIM LIGHT
				float4 rimDot = 1 - dot(V, N);
				float rimVal = rimDot * pow(dot(N,L), _RimThreshold);
				rimVal = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimVal);
				float rim = rimVal * _RimColor;

				//FINAL COLOR OF FRAGMENT
				return float4(ambient + diffuse + specular, 1.0);
			}

			ENDCG


		}

	}
}

/*
//DIFFUSE
				float NdotL = max(dot(N, L), 0);
				float lightIntensity = smoothstep(0, 0.01, NdotL);
				float3 light = lightIntensity * Kl * Kd;

				//float3 viewDir = normalize(i.viewDir);

				// SPECULAR
				float NdotH = max(dot(N, H), 0);

				float specularIntensity = pow(NdotH, _Glossiness);
				float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
				float3 specular = specularIntensitySmooth * Ks * Kl;

				float4 sample = tex2D(_MainTex, i.uv);

				return float4(_Color * sample * (light + _AmbientColor + specularIntensity), 1);
*/