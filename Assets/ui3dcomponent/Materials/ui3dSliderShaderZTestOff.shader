// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "ui3d/ui3dSliderZtestOffShader"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
    	_Color ("Main Color", Color) = (1,1,1,1)
    	_FillAmount("FillAmount",Range(0.0,1.0)) = 1.0
    	_FillAmount2("FillAmount2",Range(0.0,1.0)) = 1.0
    	_SpaceCount("SpaceCount",float) = 0
    	_SpacePercent("SpacePercent",Range(0.0,0.2)) = 0.1
    	_W2H("W2H",Range(0.0,10.0)) = 1
    	_Angle("Angle",Range(0.0,90.0)) = 15
    	_SampleTex("SampleTex",Range(0.0,1.0)) = 0
    	_FillOrigin("FillOrigin",int) = 0
        _SpriteCenterSize ("SpriteCenterSize", Vector) = (0.5,0.5,1,1)
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
        ZClip On
        ZTest Off

        
        Blend One OneMinusSrcAlpha
        

        Pass 
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
            //#pragma exclude_renderers d3d11 gles
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #pragma multi_compile_instancing

            #define HPSLIDER
            #include "UnityCG.cginc"
            #include "Unity3DUI.cginc"           
            
            ENDCG
        }
    }
    FallBack "Hidden/InternalErrorShader"
}

