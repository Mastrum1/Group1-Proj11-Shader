Shader "Learning/Unlit/Fresnel"
{
    Properties
    {
        // Fresnel Exponent : float entre 0.1 & 20
        _Exp("Exponent", Range(0.1,20)) = 5
        _ColorA("ColorA", Color) = (1,0,0,1)
        _ColorB("ColorB", Color) = (0,1,0,1)
        // 2 couleurs : une BaseColor (celle du mesh) et une pour l'effet outline du fresnel       
    }
        SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
            float4 _ColorA;
            float4 _ColorB;
            float _Exp;
			
            
            // Variables du bloc Properties
            
            struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldSpacePos : TEXCOORD1;
                // + 
                // Transf�rer la position & la normale en WORLD SPACE
            };

            v2f vert (vertexInput v)
            {
                v2f o;
               
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
               
                // TO DO 
                // position en float4 => w = 1
                
                // direction en float4 => w = 0
                o.vertex = float4(o.uv.xy, 0, 1);
                // matrice: unity_ObjectToWorld
                
                // la normale en worldspace de la struct v2f doit �tre normalis�e
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex);
                
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                // TO DO: Une ligne � coder apr�s chaque commentaire
                // Calculer le vecteur FragmentToCamera puis le normaliser
	            
                // Normaliser de nouveau la normale de la struct v2f
                
                // Calcul du produit scalaire entre le vecteur PixelToCamera (View vector) & la normale
	            
                // Visualiser le r�sultat de NdotV  => ligne temporaire, juste pour comprendre l'effet � cette �tape
                
                // "Ajuster" le r�sultat obtenu
                
                // Utiliser la fonction pow(valueToRaise, FresnelExponent)
	            
                // lerp entre BaseColor, FresnelColor et le rim calcul� ci-dessus.
	            return float4(0.9, 0.3, 0.2, 1.0);
            }
            ENDHLSL
        }
    }
}
