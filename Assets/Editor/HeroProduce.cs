using System;
using System.Collections.Generic;
using System.IO;
using Game.View;
using Game.View.Hero;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.U2D;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.U2D;

public class HeroProduce:Editor
{
    public static ViewHeroMono viwHeroMono;
    public static GameObject animHero;
    public static GameObject rootHero;
    public static string heroName;
    public static string heroPath;
    public static AnimatorController animatorController;
    [MenuItem("Assets/生成英雄")]
    static void CreateHero()
    {
        heroPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        Debug.LogWarning(heroPath);
        if (!AssetDatabase.IsValidFolder(heroPath))
        {
            Debug.LogError("请选择目录而不是文件:"+heroPath);
            return;
        }

        x = 0;
        y = 0;
        
        heroName = Selection.activeObject.name;
        rootHero = new GameObject("hero");
        
        viwHeroMono = rootHero.AddComponent<ViewHeroMono>();
        viwHeroMono.RB2D = rootHero.AddComponent<Rigidbody2D>();
        viwHeroMono.RB2D.freezeRotation = true;
        viwHeroMono.RB2D.gravityScale = 0;
        
        animHero = new GameObject("anim");
        UnityTools.SetParent(animHero.transform, rootHero.transform);
        animHero.transform.localPosition = new Vector3(0, -0.5f, 0);
        viwHeroMono.spriteRenderer =  animHero.AddComponent<SpriteRenderer>();

        viwHeroMono.animator = animHero.AddComponent<Animator>();
        animatorController =
            AnimatorController.CreateAnimatorControllerAtPath(
                heroPath + "/anims/" + heroName + "_anim_controller.controller");
        animatorController.AddLayer("Base Layer");
        if (!AssetDatabase.IsValidFolder(heroPath + "/anims"))
        {
            AssetDatabase.CreateFolder(heroPath , "anims");
        }
        Debug.LogWarning(Application.dataPath);
        foreach (var directory in AssetDatabase.GetSubFolders(heroPath+"/sprites"))
        {
            ProcessAction(directory);
        }
        // AssetDatabase.CreateAsset (animatorController, heroPath + "/anims/" + heroName+"_anim_controller.controller");
        AssetDatabase.SaveAssets();
        viwHeroMono.animator.runtimeAnimatorController = animatorController;

        var hppart = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Res/Prefab/hppart.prefab");
        var collide = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Res/Prefab/collide.prefab");
        viwHeroMono.hpPart = (GameObject)PrefabUtility.InstantiatePrefab(hppart);
        viwHeroMono.collidePart = (GameObject)PrefabUtility.InstantiatePrefab(collide);
        UnityTools.SetParent(viwHeroMono.hpPart.transform,animHero.transform);
        UnityTools.SetParent(viwHeroMono.collidePart.transform,animHero.transform);
        UnityTools.SetLayer((int)UnityLayer.Hero,rootHero.transform);
        PrefabUtility.SaveAsPrefabAssetAndConnect(rootHero, "Assets/Resources/hero/"+heroName+".prefab", InteractionMode.AutomatedAction);
    }

    private static void ProcessAction(string directory)
    {
        foreach (var directoryInfo in AssetDatabase.GetSubFolders(directory))
        {
            ProcessDirAction(directoryInfo);
        }
    }

    private static void ProcessDirAction(string directoryInfo)
    {
        DirectoryInfo direction = new DirectoryInfo(directoryInfo);
        var dirName = direction.Name;
        
        AnimationClip animationClip = new AnimationClip();
        animationClip.frameRate = 12;
        animationClip.wrapMode= WrapMode.Loop;

        float frameTimer = 0;
        
        EditorCurveBinding editorCurveBinding = new EditorCurveBinding();
        editorCurveBinding.path = "";
        editorCurveBinding.type = typeof(SpriteRenderer);
        editorCurveBinding.propertyName = "m_Sprite";
        
        List<ObjectReferenceKeyframe> keyframeList = new List<ObjectReferenceKeyframe>(); 
        
        SpriteAtlas spriteAtlas = new SpriteAtlas();
        List<Sprite> sprites = new List<Sprite>();
        foreach (var file in direction.GetFiles())
        {
            if (file.Name.EndsWith(".meta"))
            {
                continue;
            }

            if (file.Name.StartsWith("."))
            {
                continue;
            }

            if (!file.Name.EndsWith(".png"))
            {
                continue;
            }
            var filePath = directoryInfo + "/" + file.Name;
            Debug.LogWarning(filePath);
            
            
            // string pathName = binding.path + "/" + binding.propertyName;
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
            sprites.Add(sprite);
            var keyframes = new ObjectReferenceKeyframe ();
            keyframes.time = frameTimer;
            keyframes.value = sprite;
            keyframeList.Add(keyframes);
            
            frameTimer += 0.083333336f;

            viwHeroMono.spriteRenderer.sprite = sprite;
        }
        spriteAtlas.Add(sprites.ToArray());
        if (!AssetDatabase.IsValidFolder(heroPath + "/atlas"))
        {
            AssetDatabase.CreateFolder(heroPath , "atlas");
        }
        AssetDatabase.CreateAsset(spriteAtlas,heroPath+"/atlas/"+heroName+"_"+dirName+".spriteatlas");
        
        AnimationUtility.SetObjectReferenceCurve (animationClip, editorCurveBinding, keyframeList.ToArray());
        AnimationClipSettings animationClipSettings = AnimationUtility.GetAnimationClipSettings(animationClip);
        animationClipSettings.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(animationClip,animationClipSettings);
        if (!AssetDatabase.IsValidFolder(heroPath + "/anims"))
        {
            AssetDatabase.CreateFolder(heroPath , "anims");
        }
        AssetDatabase.CreateAsset (animationClip, heroPath+"/anims/"+heroName+"_" + dirName + ".anim");
        
        
        // get base machine in base layer
        var baseLayerMachine = animatorController.layers[0].stateMachine;
        // animatorController.AddLayer("CrouchLayer");
        // var animatorController = viwHeroMono.animator.runtimeAnimatorController as AnimatorController;
        // var addMotion =  animatorController.AddMotion(animationClip);
        CreateBaseLayerState(animationClip,dirName);
        // addMotion.name = dirName;
    }
    
    
    
    /// <summary>
    /// 获取组件的值引用
    /// </summary>
    /// <returns>The object renference value.</returns>
    /// <param name="trans">Trans.</param>
    /// <param name="propertyName">Property name.</param>
    static UnityEngine.Object GetObjectRenferenceValue(Transform trans, string propertyName)
    {
        if (propertyName == "m_Sprite") {
            return trans.GetComponent<SpriteRenderer> ().sprite;
        } else {
            Debug.LogError (propertyName + " have not doing");
            return null;
        }
    }
    
    //
    // private void CreateAnimStates()
    // {
    //     // Create base layer states
    //     CreateBaseLayerState();
    //     // Create crouch layer states
    //     // CreateCrouchLayerState();
    // }


    private static int x = 0;
    private static  int y = 0;
    private static void CreateBaseLayerState(AnimationClip clip,string stateName)
    {
        // CreateIdle();
        // CreateMove();
        // CreateJump();
        // CreateDeath();
        var baseLayerMachine = animatorController.layers[0].stateMachine;
        // add tree state & set state motion
        var stateIdle = baseLayerMachine.AddState(clip.name, new Vector3(x*250, y*250));
        stateIdle.motion = clip;
        stateIdle.name = stateName;
        x++;
        if (x > 10)
        {
            x = 0;
            y++;
        }

        // Add behaviour to state
        // stateIdle.AddStateMachineBehaviour<CharacterIdleState>();

        // set to default state
        if (stateName == "idle_r")
        {
            baseLayerMachine.defaultState = stateIdle;
        }

        // SetBaseLayerTransition();
    }

    // private void CreateCrouchLayerState()
    // {
    //     // Load Animation
    //     string fbxPath = AnimationPath + "Crouch.FBX";
    //     CreateCrouchIdle(fbxPath);
    //     CreateCrouchWalk(fbxPath);
    // }
}