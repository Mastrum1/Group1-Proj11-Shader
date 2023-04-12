Shader "Learning/Unlit/DisturbedUvs"   // Exercice 9 du google doc
{
    Properties
    {      
		_MainTex("Albedo", 2D) = "black" {}
        _NoiseMap("Noise map", 2D) = "black" {}
		_Speed("Scrolling Speed", Vector) = (0, 0, 0, 0)
        _DisturbedFactor("Disturbed Factor", Range(0,0.2)) = 0.1
    }
    SubShader
    {
		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
			sampler2D _MainTex;
			sampler2D _NoiseMap;
            float2 _Speed;
            float _DisturbedFactor;
			
			struct appdata
            {
                float4 vertex : POSITION;
				float2 uv : TEXCOORD0;						
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;  
                float2 uv : TEXCOORD0;  
            };

            v2f vert (appdata v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
	            float2 offset = _Speed * _Time.x;
                
                float2 disturbedOffset = tex2D(_NoiseMap, i.uv + offset).rg;
	            disturbedOffset *= _DisturbedFactor;
                
                return tex2D(_MainTex, i.uv + disturbedOffset); 
            }

            ENDHLSL
        }
    }
}
