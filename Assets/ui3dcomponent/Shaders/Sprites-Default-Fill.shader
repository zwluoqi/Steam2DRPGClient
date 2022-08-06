// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "ui3d/Default_Fill"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
        [HideInInspector] _SpriteCenterSize ("SpriteCenterSize", Vector) = (0.5,0.5,1,1)
        [HideInInspector] _SpriteFillMethod ("SpriteFillMethod", Vector) = (1,0,0,0)
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex SpriteVert
            #pragma fragment SpriteFrag
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            //#include "UnitySprites.cginc"

            #ifndef UNITY_SPRITES_INCLUDED
            #define UNITY_SPRITES_INCLUDED


            #include "UnityCG.cginc"

            #ifdef UNITY_INSTANCING_ENABLED

                UNITY_INSTANCING_BUFFER_START(PerDrawSprite)
                    // SpriteRenderer.Color while Non-Batched/Instanced.
                    UNITY_DEFINE_INSTANCED_PROP(fixed4, unity_SpriteRendererColorArray)
                    // this could be smaller but that's how bit each entry is regardless of type
                    UNITY_DEFINE_INSTANCED_PROP(fixed2, unity_SpriteFlipArray)

                    UNITY_DEFINE_INSTANCED_PROP(fixed4, _SpriteCenterSize)

                    UNITY_DEFINE_INSTANCED_PROP(fixed4, _SpriteFillMethod)
                UNITY_INSTANCING_BUFFER_END(PerDrawSprite)

                #define _RendererColor  UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, unity_SpriteRendererColorArray)
                #define _Flip           UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, unity_SpriteFlipArray)
                //#define _fillCount           UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, _fillCount)




            #endif // instancing

            CBUFFER_START(UnityPerDrawSprite)
            #ifndef UNITY_INSTANCING_ENABLED
                fixed4 _RendererColor;
                fixed2 _Flip;//修改定义为fill模式,00=横切，01竖切,10=180度旋转，11=360度旋转。
                fixed4 _SpriteCenterSize;
                fixed4 _SpriteFillMethod;
            #endif
                float _EnableExternalAlpha;
            CBUFFER_END


            // Material Color.
            fixed4 _Color;

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float4 texcoord : TEXCOORD0;

                UNITY_VERTEX_OUTPUT_STEREO
            };

            inline float4 UnityFlipSprite(in float3 pos, in fixed2 flip)
            {
                return float4(pos.xy * flip, pos.z, 1.0);
            }

            v2f SpriteVert(appdata_t IN)
            {
                v2f OUT;

                UNITY_SETUP_INSTANCE_ID (IN);
                //UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

            //不需要这个翻转功能，替换为进度条模式功能
                //OUT.vertex = UnityFlipSprite(IN.vertex, _Flip);
                //OUT.vertex = UnityObjectToClipPos(OUT.vertex);
                OUT.vertex = UnityObjectToClipPos(IN.vertex);

                OUT.texcoord = fixed4(IN.texcoord,1,1);
                OUT.color = IN.color * _Color * fixed4(_RendererColor.xyz,1);
                OUT.texcoord.z = _RendererColor.a;//alpha值当做进度条值
                OUT.texcoord.w = _Flip.x;//flipx当做360标识

                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif

                return OUT;
            }

            sampler2D _MainTex;
            sampler2D _AlphaTex;

            fixed4 SampleSpriteTexture (float2 uv)
            {
                fixed4 color = tex2D (_MainTex, uv);

            #if ETC1_EXTERNAL_ALPHA
                fixed4 alpha = tex2D (_AlphaTex, uv);
                color.a = lerp (color.a, alpha.r, _EnableExternalAlpha);
            #endif

                return color;
            }

            fixed getChannel0Valid(fixed2 uv,fixed fill){
                    fixed4 centersize = UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, _SpriteCenterSize);

                    fixed2 center = centersize.xy;
                    fixed2 size = centersize.zw;



                    fixed angle_channel0 =0;
                    fixed u = tan(angle_channel0/57.3)*(uv.y-center.y);
                    fixed valid_channel0 = (u+center.x)-uv.x + fill*size.x-center.x;
                    return valid_channel0;
            }

            fixed getChannel1Valid(fixed2 uv,fixed fill){
                    fixed4 centersize = UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, _SpriteCenterSize);

                    fixed2 center = centersize.xy;
                    fixed2 size = centersize.zw;

                    fixed angle_channel1 = (1-fill)*360;
                    fixed2 uvdir = fixed2(uv.x-center.x,uv.y-center.y);
                    fixed2 defaultdir = fixed2(0,-0.5);
                    fixed dotval = dot(defaultdir,uvdir);
                    fixed calculateAngle = 57.3*acos(dotval/(length(defaultdir)*length(uvdir)));
                    fixed uleft = step(uv.x-center.x,0);
                    calculateAngle = lerp(calculateAngle,360-calculateAngle,uleft);
                    fixed valid_channel1 = calculateAngle-angle_channel1;
                    return valid_channel1;
            }

            fixed4 SpriteFrag(v2f IN) : SV_Target
            {
                fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
                c.rgb *= c.a;

                fixed fill = IN.texcoord.z;
                fixed rotation = IN.texcoord.w;


                if(rotation > 0){
                    fixed valid_channel0 =getChannel0Valid(IN.texcoord,fill);
                    clip ( valid_channel0 );
                }else{
                    fixed valid_channel1 = getChannel1Valid(IN.texcoord,fill);
                    clip(valid_channel1);
                }

                //return fixed4(rotation,0,0,1);

                //fixed valid_channel0 =getChannel0Valid(IN.texcoord,fill);

                //fixed valid_channel1 = getChannel1Valid(IN.texcoord,fill);

                //fixed valid = lerp(valid_channel1,valid_channel0,rotation);
                //clip(valid);

                return c;
            }

            #endif // UNITY_SPRITES_INCLUDED

        ENDCG
        }
    }
}
