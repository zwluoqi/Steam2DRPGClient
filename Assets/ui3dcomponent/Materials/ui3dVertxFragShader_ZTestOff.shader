// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "ui3d/ui3dVertxFragZTestOffShader"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
    	_Color ("Main Color", Color) = (1,1,1,1)
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
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA

            #define CUSTOM3DUI
            #include "UnityCG.cginc"
            #include "Unity3DUI.cginc"    

            ENDCG
        }
    }
}

