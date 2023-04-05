Shader "Learning/Unlit/FirstShader"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _AlbedoA("Albedo", 2D) = "white" {}
        _AlbedoB("Albedo", 2D) = "black" {}
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
                float3 worldSpacePos : TEXCOORD1;
            };


            // Vertex shader
            // �x�cut� pour chaque vertex � chaque frames
            // Fonction qui calcule la position finale du vertex dans l'espace �cran
            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = UnityObjectToClipPos(v.vertex); // ligne obligatoire
                o.uv = v.uv;
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            // FRAGMENT / PIXEL shader
            // Pour chaque pixel couvert par vos triangles / polynomes
            float4 frag(v2f i) : SV_Target
            {
                float d = distance(_WorldSpaceCameraPos, i.worldSpacePos);
                float t = clamp(d, 0, 1);

                return lerp(tex2D(_AlbedoA, i.uv), tex2D(_AlbedoB, i.uv), t); //RGBA
            }
            
            ENDHLSL
        }
    }
}