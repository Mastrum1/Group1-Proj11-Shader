Shader "Learning/Unlit/VertexColor"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
    }

        SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

			// Data contenues dans chaque vertex
			struct vertexInput
            {
                float4 vertex : POSITION;	
                float4 vertexColor : COLOR;
            };
			
            // v2f => vertex to fragment
            // Data calcul�es dans le vertex shader puis interpol�es et envoy�es au fragment shader
            struct v2f
            {
                float4 vertex : SV_POSITION;    
                float4 vertexColor : COLOR;
            };

            // Vertex shader
            // �x�cut� pour chaque vertex � chaque frames
            // Fonction qui calcule la position finale du vertex dans l'espace �cran
            v2f vert (vertexInput v)
            {
                v2f o; // o = output

	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex); // ligne obligatoire

                o.vertexColor = v.vertexColor;

                return o;
            }

            //RASTERIZER

            // FRAGMENT / PIXEL shader
            // Pour chaque pixel couvert par vos triangles / polynomes
            float4 frag(v2f i) : SV_Target
            {
                return i.vertexColor; //RGBA
            }
            
            ENDHLSL
        }
    }
}
