Shader "Rim Lighting Diffuse"
{

  Properties
  {
  
   _ColorTint("Color Tint", Color) = (0.4,0.4,0.4,1.0) //search for Unity color type
    _MainTex("Texture", 2D) = "white"{}
    _RimColor("Rim Color", Color) = (0.8,0.8,0.8,1)
    _RimPower("Rim Power", Range(0.5, 8.0)) = 3.0
  }

SubShader
{
   Tags { "RenderType" = "Opaque"}
   CGPROGRAM
   #pragma surface surf Lambert
   struct Input
   {
   float4 color:COLOR;
   float2 uv_MainTex;
   float3 worldPos;
   float3 viewDir;     //XYZ view direction provided by Unity
   };
   float4 _ColorTint;
   sampler2D _MainTex; //sampler2D is a 2d texture
   float4 _RimColor;
   float _RimPower;

   void surf (Input IN, inout SurfaceOutput o)
   {
   IN.color = _ColorTint;
      fixed4 tex = tex2D(_MainTex,IN.uv_MainTex);

   o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * IN.color; //.rgb leaves out alpha
 
  
   half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));               //half precision float, saturate clips values between -1 and 1
   
  o.Emission = (_RimColor.rgb * pow(rim, _RimPower));
   
   }
   ENDCG
}
FallBack "Diffuse"
}