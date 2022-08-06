 
// X 射线效果
Shader "Custom/Xray"
{
 
	Properties 
	{
		// 主贴图
		_MainTex ("Base (RGB)", 2D) = "white" {}
 
		// 主颜色
		_GhostColor ("Ghost Color", Color) = (0, 1, 0, 1)
 
		// x-ray 强度调整参数
		_Pow ("Pow Factor", float) = 1
	}
	
	SubShader 
	{
		// 设置为透明渲染和队列
		Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
		LOD 200
		
		Zwrite Off
        Ztest Always
 
		// 混合模式
        Blend SrcAlpha One
 
 
		CGPROGRAM
		#pragma surface surf Unlit keepalpha
        
		// 参数声名
        sampler2D _MainTex;
		half4 _GhostColor;
		float _Pow;
 
		struct Input 
		{
		    float3 viewDir;		// 视野方向
		    float2 uv_MainTex;
		};
		
		fixed4 LightingUnlit(SurfaceOutput s, fixed3 lightDir, fixed atten)
		 {
		     fixed4 c;
		     c.rgb = s.Albedo; 
		     c.a = s.Alpha;
		     return c;
		 }
 
		void surf (Input IN, inout SurfaceOutput o) 
		{
		    half4 c = tex2D (_MainTex, IN.uv_MainTex);
 
			// 法线
		    float3 worldNormal = WorldNormalVector(IN, o.Normal);
 
			// 设置颜色
			o.Albedo = _GhostColor.rgb;
			
			// 把边沿置为 1
			half alpha_XRay = 1.0 - saturate(dot (normalize(IN.viewDir), worldNormal));
			// 调整 X-Ray 的效果
			alpha_XRay = pow(alpha_XRay, _Pow);
 
			// 前面两个 alpha 基本为 1，关键是 alpha_XRay
			o.Alpha = c.a * _GhostColor.a * alpha_XRay;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
 
 
 