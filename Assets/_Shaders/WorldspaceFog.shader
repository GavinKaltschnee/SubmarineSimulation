Shader "Cg shading in world space" {
    Properties{
       _Point("a point in world space", Vector) = (0., 0., 0., 1.0)
       _DistanceNear("threshold distance", Float) = 5.0
       _Color("Main Color", Color) = (1,1,1,0)
        _Strength("Fog_Strength", Float) = 0.0025
   }
   
   SubShader {
            Tags {"RenderType" = "Transparent" "Queue" = "Transparent"}
      Pass {

         Cull Front 
         ZWrite Off 

         Blend SrcAlpha OneMinusSrcAlpha
         CGPROGRAM

         
         #pragma vertex vert  
         #pragma fragment frag 

 
         #include "UnityCG.cginc" 

         uniform float4 _Point;
         uniform float _DistanceNear, _Strength;
         uniform float4 _Color;
         struct vertexInput {
            float4 vertex : POSITION;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 position_in_world_space : TEXCOORD0;
         };

         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output; 
 
            output.pos =  UnityObjectToClipPos(input.vertex);
            output.position_in_world_space = 
               mul(unity_ObjectToWorld, input.vertex);

            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR 
         {
             float dist = distance(input.position_in_world_space.y, 
               _Point.y);
             float J = clamp(dist * _Strength, 0, 1);
             return float4(0.1, 0.1, 0.1, J) * _Color;
         }
 
         ENDCG  
      }
   }
}
