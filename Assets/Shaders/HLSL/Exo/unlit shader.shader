Shader "Learning/Unlit/FirstShader"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Albedo("Albedo", 2D) = "white" {}
    }

        SubShader
    {
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _Albedo;
			
			struct vertexInput
            {
                float4 vertex : POSITION;		
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;    
                float2 uv : TEXCOORD0;
            };


            // Vertex shader
            // éxécuté pour chaque vertex à chaque frames
            // Fonction qui calcule la position finale du vertex dans l'espace écran
            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex); // ligne obligatoire
                o.uv = v.uv;
                return o;
            }

            // FRAGMENT / PIXEL shader
            // Pour chaque pixel couvert par vos triangles / polynomes
            float4 frag(v2f i) : SV_Target
            {
                return tex2D(_Albedo, i.uv); //RGBA
            }
            
            ENDHLSL
        }
    }
}
