Shader "Learning/Unlit/Fresnel"
{
    Properties
    {   
		// Fresnel Exponent : float entre 0.1 & 20
        // 2 couleurs : une BaseColor (celle du mesh) et une pour l'effet outline du fresnel
        _Exp("Exponent", Range(0.1,20)) = 2
        _Bands("Number of bands", Range(1,20)) = 2
    }
    SubShader
    {
		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
            float _Exp, _Bands;
            
            struct vertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldSpacePos : TEXCOORD0;
                float3 worldSpaceNormal : TEXCOORD1;
                
                // + 
                // Transférer la position & la normale en WORLD SPACE
            };

            v2f vert (vertexInput v)
            {
                v2f o;
               
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
               
                // TO DO 
                // position en float4 => w = 1
                // direction en float4 => w = 0
                // matrice: unity_ObjectToWorld
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                // la normale en worldspace de la struct v2f doit être normalisée
                o.worldSpaceNormal = mul(unity_ObjectToWorld,float4(v.normal,0)).xyz;
                o.worldSpaceNormal = normalize(o.worldSpaceNormal);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                // TO DO: Une ligne à coder après chaque commentaire
                // Calculer le vecteur FragmentToCamera puis le normaliser
                float3 FragmentToCamera = normalize(_WorldSpaceCameraPos - i.worldSpacePos);
	            
                // Normaliser de nouveau la normale de la struct v2f
                i.worldSpaceNormal = normalize(i.worldSpaceNormal);
                // Calcul du produit scalaire entre le vecteur PixelToCamera (View vector) & la normale
	            float NdotV = dot(FragmentToCamera, i.worldSpaceNormal);
                // Visualiser le résultat de NdotV  => ligne temporaire, juste pour comprendre l'effet à cette étape
                //return NdotV
                // "Ajuster" le résultat obtenu
                NdotV = 1- NdotV;
                // Utiliser la fonction pow(valueToRaise, FresnelExponent)
	            float rim = pow(NdotV, _Exp);
                // lerp entre BaseColor, FresnelColor et le rim calculé ci-dessus.
	            return float4(0.9, 0.3, 0.2, 1.0);
            }
            ENDHLSL
        }
    }
}
