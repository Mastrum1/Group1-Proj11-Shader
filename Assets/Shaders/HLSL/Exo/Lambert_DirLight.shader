Shader "Learning/Lit/Lambert_DirLight"
{
    Properties
    {
		_Albedo("Albedo",  2D) = "white"{}
	}

		SubShader
	{
		Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }
		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _Albedo;
			float3 _WorldSpaceLightDir;

			// Récupérez les data depuis le script LightData, attaché sur votre Directional Light
			
			struct vertexInput
			{
				float4 vertex : POSITION;	
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldSpaceNormal : TEXCOORD0;
				// normal en world space
			};

			v2f vert(vertexInput v)
			{
				v2f o;

				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.worldSpaceNormal = normalize(mul(unity_ObjectToWorld, float4(v.normal,0).xyz));
				
				// To do
				
				return o; 
			}

			float4 frag(v2f i) : SV_Target
			{
				// To do => NdotL 
				i.worldSpaceNormal = normalize(i.worldSpaceNormal);
				float NdotV = dot(-_WorldSpaceLightDir, i.worldSpaceNormal);
				// N & L dans le même espace et normalisés
				// L => direction reçue depuis le script C#. Forward de la DirLight
				// A inverser car côté shader, le vecteur de la lumière part depuis le fragment
				NdotV = clamp(NdotV, -1, 1);
				// dot retourne des valeurs entre -1 et 1, => clamp à utiliser
				
				return tex2D(_Albedo, NdotV);
			}
			
            ENDHLSL
        }
    }
}
