Shader "Learning/Unlit/FirstShader"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _AlbedoA("Albedo", 2D) = "white" {}
        _AlbedoB("Albedo", 2D) = "black" {}
        _AlbedoC("Albedo", 2D) = "black" {}
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

            sampler2D _AlbedoA;
            sampler2D _AlbedoB;
            sampler2D _AlbedoC;
            float _LerpAlpha;
			
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
                return lerp(tex2D(_AlbedoA, i.uv), tex2D(_AlbedoB, i.uv), tex2D(_AlbedoC, i.uv).r); //RGBA
            }
            
            ENDHLSL
        }
    }
}
