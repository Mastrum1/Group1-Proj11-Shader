Shader "Learning/Unlit/FirstShader"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _mainColorA("Main Color", Color) = (1,0,0,1)
        _mainColorB("Main Color", Color) = (0,0,1,1)
        _LerpAlpha("Lerp", Range(0,1)) = 0.5  // slider
    }

        SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _mainColorA;
            float4 _mainColorB;
            float _LerpAlpha;
			
			struct vertexInput
            {
                float4 vertex : POSITION;						
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;    
            };


            // Vertex shader
            // éxécuté pour chaque vertex à chaque frames
            // Fonction qui calcule la position finale du vertex dans l'espace écran
            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex); // ligne obligatoire
                return o;
            }

            // FRAGMENT / PIXEL shader
            // Pour chaque pixel couvert par vos triangles / polynomes
            float4 frag(v2f i) : SV_Target
            {
                return lerp(_mainColorA, _mainColorB, _LerpAlpha); //RGBA
            }
            
            ENDHLSL
        }
    }
}
