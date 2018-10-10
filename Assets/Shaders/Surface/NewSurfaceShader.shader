  Shader "Post/BasicSurface" {
    Properties {

      _MainTex ("Texture", 2D) = "white" {}
      _Amount ("Extrusion Amount", Range(-1,1)) = 0.5
      _Metallic ("Metallic", Range(0,1)) = 0.5
      _Smooth ("Smooth", Range(0,1)) = 0.5
       _BumpMap ("Bumpmap", 2D) = "bump" {}

    [Toggle(Enable16Struct)] _Struct16("16 Struct", Float) = 0
    [Toggle(Enable24Struct)] _Struct24("24 Struct", Float) = 0
    [Toggle(Enable36Struct)] _Struct36("36 Struct", Float) = 0
    }
    SubShader {
        Cull Off
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
         #pragma target 4.5
#include "UnityCG.cginc"
#include "../Chunks/hsv.cginc"
#include "../Chunks/StructIfDefs.cginc"
     #pragma vertex vert
      #pragma surface surf Standard addshadow
     
 				struct appdata{
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 tangent : TANGENT;
            float4 texcoord : TEXCOORD0;
            float4 texcoord1 : TEXCOORD1;
            float4 texcoord2 : TEXCOORD2;
 
            uint id : SV_VertexID;
         };
 
  
#if defined(SHADER_API_METAL) || defined(SHADER_API_D3D11)
			StructuredBuffer<Vert> _TransferBuffer;
#endif
       struct Input {
          float2 texcoord1;
          float3 tangent;
          float3 normal;
          float2 debug;
      };


       float _Amount;
       void vert (inout appdata v, out Input data ) {
      
 				UNITY_INITIALIZE_OUTPUT( Input , data );
        #if defined(SHADER_API_METAL) || defined(SHADER_API_D3D11)
		        float3 fPos =_TransferBuffer[v.id].pos;
		        float3 fNor =_TransferBuffer[v.id].nor;
		        float3 fTan =_TransferBuffer[v.id].tan;
		        float2 fUV =_TransferBuffer[v.id].uv;
		      
		            v.vertex = float4(fPos,1);// float4(v.vertex.xyz,1.0f);
		            v.normal = fNor; //float4(normalize(points[id].normal), 1.0f);
		            v.tangent = float4(0,1,0,1);//float4(fTan,1);//float4( normalize(cross(fNor,float3(0,1,0))),1);
		             //v.UV = fUV;
		           // v.texcoord1 = fUV;
		            data.texcoord1 = fUV;//float2(1,1);
		            data.tangent =fTan;
		            data.normal =fNor;
		            data.debug =  _TransferBuffer[v.id].debug;
            #endif
  
         }
 
 	sampler2D _MainTex;
 	sampler2D _BumpMap;
 	float _Metallic;
 	float _Smooth;
      void surf (Input IN, inout SurfaceOutputStandard o) {
         
          float3 mainCol = tex2D (_MainTex, IN.texcoord1.xy).rgb;
           o.Albedo = mainCol;//*3* hsv(IN.texcoord1.x * .2 + sin(IN.debug.x*1000) * .04 -.1,1,1);
        float3 nor = UnpackNormal(tex2D (_BumpMap, IN.texcoord1.xy ));
        o.Metallic = _Metallic;
        o.Smoothness = _Smooth;
          o.Normal = nor;
      }
      ENDCG
    } 
   // Fallback "Diffuse"
  }