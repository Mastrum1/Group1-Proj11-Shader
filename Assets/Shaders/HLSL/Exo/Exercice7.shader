Shader "Learning/Unlit/TO RENAME"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue   
        _AlbedoA("Albedo", 2D) = "black" {}
        _AlbedoB("Albedo", 2D) = "black" {}
        _Speed("Speed", Float) = 1
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _AlbedoA;
            sampler2D _AlbedoB;
            float _Speed;
			
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

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 disp = tex2D(_AlbedoB, i.uv + _Time);
                float2 d = i.uv + disp.xy * _Speed;
                float4 distortion = tex2D(_AlbedoA, d);
                return distortion;
            }
            
            ENDHLSL
        }
    }
}
