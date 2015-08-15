Shader "Custom/LightEmissionShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Base Texture", 2D) = "white" {}
		_EmissionTex ("Emission Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		//#pragma surface surf Standard fullforwardshadows
		#pragma surface surf Lambert


		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		fixed4 _Color;	
		sampler2D _MainTex;
		sampler2D _EmissionTex;
		
		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			float k = ((2.0f * _SinTime.w * _CosTime.w ) + 3.0f ) / 4.0;
			o.Emission = _Color * tex2D(_EmissionTex, IN.uv_MainTex).a * k;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
