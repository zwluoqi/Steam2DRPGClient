//------------------------------------------------------------------------------
// Copyright (c) 2018-2019 Beijing Bytedance Technology Co., Ltd.
// All Right Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
//------------------------------------------------------------------------------

#ifndef UNITY_3DUI_INCLUDED
#define UNITY_3DUI_INCLUDED


#ifdef HPSLIDER

//#ifdef UNITY_INSTANCING_ENABLED

    UNITY_INSTANCING_BUFFER_START(Props)

        UNITY_DEFINE_INSTANCED_PROP(float4, _SpriteCenterSize)
        UNITY_DEFINE_INSTANCED_PROP(float, _FillAmount)
        UNITY_DEFINE_INSTANCED_PROP(float, _FillAmount2)
        UNITY_DEFINE_INSTANCED_PROP(float, _SpaceCount)
        UNITY_DEFINE_INSTANCED_PROP(float, _SpacePercent)
        UNITY_DEFINE_INSTANCED_PROP(float, _W2H)
        UNITY_DEFINE_INSTANCED_PROP(float, _Angle)
        UNITY_DEFINE_INSTANCED_PROP(float, _FillOrigin)
        UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
        UNITY_DEFINE_INSTANCED_PROP(float, _SampleTex)

    UNITY_INSTANCING_BUFFER_END(Props)


//#endif // instancing

/*
CBUFFER_START(PerDrawSprite)
#ifndef UNITY_INSTANCING_ENABLED
    float4 _SpriteCenterSize;
    float _FillAmount;
    float _SpaceCount;
    float _SpacePercent;
#endif
    //float _EnableExternalAlpha;
CBUFFER_END
*/            

//float4 _Color;

struct appdata
{
    float4 vertex : POSITION;
    float4 color : COLOR;
    float2 uv : TEXCOORD0;
                    UNITY_VERTEX_INPUT_INSTANCE_ID

};

struct v2f
{
    float4 vertexColor : TEXCOORD0;
    float4 vertex : SV_POSITION;
    float2 uv : TEXCOORD1;
    
                    //UNITY_VERTEX_OUTPUT_STEREO
                    UNITY_VERTEX_INPUT_INSTANCE_ID

};


sampler2D _MainTex;
float4 _MainTex_ST;

//float _FillAmount;

float4 SampleSpriteTexture (float2 uv)
{
    float4 color = tex2D (_MainTex, uv);


//#if ETC1_EXTERNAL_ALPHA
  //  float4 alpha = tex2D (_AlphaTex, uv);
    //color.a = lerp (color.a, alpha.r, _EnableExternalAlpha);
//#endif

    return color;
}

v2f vert (appdata IN)
{
    v2f OUT;
    
    UNITY_SETUP_INSTANCE_ID (IN);
    UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
    //UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
    
    OUT.vertex = UnityObjectToClipPos(IN.vertex);
    OUT.vertexColor = IN.color;
    OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
    return OUT;
}

float getCorrectFill(float fill_per,float fill_width,float valid_delta,float space_per){
    float correct_fill = fill_per*fill_width;  
    float fill_grid_count = correct_fill/valid_delta;
    float floor_grid_count = floor(fill_grid_count);
    float fmod_fill = correct_fill - valid_delta*floor_grid_count;
    correct_fill = valid_delta*floor_grid_count+fmod_fill*(1-space_per);
    return correct_fill;
}


float getChannel0Valid(float2 uv){
        float4 centersize = UNITY_ACCESS_INSTANCED_PROP(Props, _SpriteCenterSize);
        float grid_count = UNITY_ACCESS_INSTANCED_PROP(Props, _SpaceCount)+1;
        float space_per = UNITY_ACCESS_INSTANCED_PROP(Props, _SpacePercent);
        float mesh_w2h = UNITY_ACCESS_INSTANCED_PROP(Props, _W2H);
        float angle_channel0 = UNITY_ACCESS_INSTANCED_PROP(Props, _Angle);
        float fill_origin = UNITY_ACCESS_INSTANCED_PROP(Props, _FillOrigin);
        
        float fill = UNITY_ACCESS_INSTANCED_PROP(Props, _FillAmount);
        float fill2 = UNITY_ACCESS_INSTANCED_PROP(Props, _FillAmount2);

        float2 center = centersize.xy;
        float2 size = centersize.zw;
        float2 leftDown = center - size*0.5f;

        //float angle_channel0 = 15;
        float angle_tan = tan(angle_channel0/57.3)*mesh_w2h;
        float u = angle_tan*(uv.y-leftDown.y);
        float remove_width = angle_tan*size.y;
        float correct_u = uv.x - u;
        float valid_channel0 = 0;
        float valid_near0 = 0;
        //-1为默认切割区域
        //-2为Fill左侧隐藏区域
        //-3为Fill右侧隐藏区域
        //-4为百分比区域
        if(correct_u<leftDown.x){
             valid_channel0 = -1;
             valid_near0 = (leftDown.x) - correct_u;
        }
        else{      
            valid_channel0 = -3;
            float fill_width = (size.x - remove_width);              
            
            float relative_u =  correct_u - leftDown.x;
            if(relative_u > fill_width){
                valid_channel0 = -1;
                valid_near0 = abs(relative_u - fill_width);
            }  
            else{                              
                                                       
                float valid_delta = fill_width/grid_count;
                float space_detal = valid_delta*space_per;
                
                float2 valid_area = float2(0,valid_delta);
                
                
                
                float u_grid_count = relative_u/valid_delta;
                float u_floor_grid_count = floor(u_grid_count);
                valid_area += u_floor_grid_count*valid_delta;
                
                //如果当前u坐标在这个范围内,则显示                                               
                if(relative_u<valid_area.y - space_detal){
                    if(fill_origin == 2){
                        float fill_start_channel = getCorrectFill(1-fill2,fill_width,valid_delta,space_per) - ( fill_width - space_detal - relative_u);
                        float fill_end_channel = getCorrectFill(fill,fill_width,valid_delta,space_per) - ( relative_u);
                        
                        valid_channel0 = fill_start_channel*fill_end_channel;
                        //if(fill_start_channel<0){
                        //    valid_channel0 = -2;
                        //}else if(fill_end_channel <0){
                        //    valid_channel0 = -3;
                        //}
                    }else if(fill_origin == 1){
                        valid_channel0 = getCorrectFill(fill,fill_width,valid_delta,space_per) - ( fill_width - space_detal - relative_u);
                        //if(valid_channel0<0){
                        //    valid_channel0 = -2;
                        //}
                    }else{
                        valid_channel0 = getCorrectFill(fill,fill_width,valid_delta,space_per) - ( relative_u);
                        //if(valid_channel0<0){
                        //    valid_channel0 = -3;
                        //}
                    }
                }else{
                    valid_channel0 = -4;
                    valid_near0 = (relative_u - (valid_area.y - space_detal));                         
                }
            }
        }
        
        return float2(valid_channel0,valid_near0);
}

float4 frag (v2f i) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(i);
    
    
    
    float distance = 0.01 * 0.0625f;
    float2 uv = i.uv;
    float valid_channel0 = getChannel0Valid(uv);
    //float leftColor = getChannel0Valid(float2(uv.x - distance,uv.y));
    //float rightColor = getChannel0Valid(float2(uv.x + distance,uv.y));
    //float topColor = getChannel0Valid(float2(uv.x,uv.y + distance));
    //float bottomColor = getChannel0Valid(float2(uv.x,uv.y - distance));


    
    //valid_channel0 += leftColor;
    //valid_channel0 += rightColor;
    //valid_channel0 += topColor;
    //valid_channel0 += bottomColor;
    //valid_channel0 /=5;
    
      if(valid_channel0<0 || valid_channel0>1){
        discard;
      } 
      //else{
        /*
        if(valid_channel0>-2){
            return float4(0,1,0,0);
        }
        else if(valid_channel0>-4){
            return float4(0.5*0.2,0,0,0.2);//背景
        }
        else if(valid_channel0>-5){
            return float4(0,0,0,0);
        }                    
        else{
            return float4(0.5,0.5,0,1);
        }
        */
        
      //}
        float4 color = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
        
        float sampleTex = UNITY_ACCESS_INSTANCED_PROP(Props, _SampleTex);

        //*i.vertexColor
        //float4 sampleColor = SampleSpriteTexture (i.uv);
// lerp(1,sampleColor,sampleTex)*
        float4 c =color*i.vertexColor;
        c.rgb *= c.a;
        return c;
        //return c ;
}
#endif

#ifdef CUSTOM3DUI

            fixed4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                fixed4 vertexColor : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD1;
            };


            sampler2D _MainTex;
			float4 _MainTex_ST;

            fixed4 SampleSpriteTexture (float2 uv)
            {
                fixed4 color = tex2D (_MainTex, uv);


            //#if ETC1_EXTERNAL_ALPHA
              //  fixed4 alpha = tex2D (_AlphaTex, uv);
                //color.a = lerp (color.a, alpha.r, _EnableExternalAlpha);
            //#endif

                return color;
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.vertexColor = v.color;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 sampleColor = SampleSpriteTexture (i.uv);
            	fixed4 c = sampleColor*i.vertexColor*_Color;
            	c.rgb *= c.a;
            	return c ;
            }
#endif

#endif

