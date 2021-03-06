
      #pragma multi_compile __ Enable9Struct
      #pragma multi_compile __ Enable12Struct
      #pragma multi_compile __ Enable16Struct
      #pragma multi_compile __ Enable24Struct
      #pragma multi_compile __ Enable36Struct

       #ifdef SHADER_API_D3D11
      #if defined(Enable9Struct) || defined(Enable12Struct) || defined(Enable16Struct) || defined(Enable24Struct) || defined(Enable36Struct) 

        #ifdef Enable9Struct
        struct Vert{
          float3 pos;
          float3 nor;
          float2 uv;
          float debug;
        };
        
        #endif
        #ifdef Enable12Struct
        struct Vert{
          float3 pos;
          float3 nor;
          float3 tan;
          float2 uv;
          float debug;
        };
        #endif
        #ifdef Enable16Struct
        struct Vert{
          float3 pos;
          float3 vel;
          float3 nor;
          float3 tan;
          float2 uv;
          float2 debug;
        };
        #endif

        #ifdef Enable24Struct
        struct Vert{
          float3 pos;
          float3 vel;
          float3 nor;
          float3 tang;
          float2 uv;
          float used;
          float3 triIDs;
          float3 triWeights;
          float3 debug;
        };
        #endif

        #ifdef Enable36Struct
        struct Vert{

          float3 pos;
          float3 vel;
          float3 nor;
          float3 tang;
          float2 uv;
        
          float used;
        
         
          float3 targetPos;
          float3 bindPos;
          float3 bindNor;
          float3 bindTan;

          float4 boneWeights;
          float4 boneIDs;

          float debug;

        };
        #endif

      #else
        struct Vert{

          float3 pos;
          float3 vel;
          float3 nor;
          float3 tan;
          float2 uv;
          float2 debug;
        };
      #endif
      #endif
