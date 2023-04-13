Shader "Learning/Unlit/FirstShader"
{
    Properties
    {
        _Albedo("Albedo",  2D) = "white"{}
        _Amplitude("Amplitude", Float) = 0.1
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
            float _Amplitude;
			
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
            // éxécuté pour chaque vertex à chaque frames
            // Fonction qui calcule la position finale du vertex dans l'espace écran
            v2f vert (vertexInput v)
            {
                v2f o;

                v.vertex.y += sin(_Time.y) * _Amplitude;

	            o.vertex = UnityObjectToClipPos(v.vertex); // ligne obligatoire


                o.uv = v.uv;
                tex2Dlod(_Albedo, float4(o.uv.xy,0,0));
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            // FRAGMENT / PIXEL shader
            // Pour chaque pixel couvert par vos triangles / polynomes
            float4 frag(v2f i) : SV_Target
            {
                float t = clamp(i.worldSpacePos.y, 0, 1);

                return tex2D(_Albedo, i.uv); //RGBA
            }
            
            ENDHLSL
        }
    }
}
