using UnityEditor;
using UnityEngine;

namespace CustomUI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(CustomMeshBase))]
    public class CustomMeshBaseInspector:Editor
    {


        public static void SetDefaultMaterial(CustomMeshBase sprite3D, string matName)
        {

            bool isDirtuy = false;

            // var sprite3D = target as CustomMeshBase;
            if (sprite3D.defaultShareMaterial == null || sprite3D.defaultShareMaterial.name != matName)
            {
                isDirtuy = true;
                sprite3D.defaultShareMaterial =
                    AssetDatabase.LoadAssetAtPath<Material>(
                        "Assets/ui3dcomponent/Materials/"+matName+".mat");
            }

            if (sprite3D.defaultShareMaterial == null|| sprite3D.defaultShareMaterial.name != matName)
            {
                isDirtuy = true;
                sprite3D.defaultShareMaterial =
                    AssetDatabase.LoadAssetAtPath<Material>("Assets/_Art/Shaders/ui3dcomponent/"+matName+".mat");
            }

            if (sprite3D.defaultShareMaterial == null|| sprite3D.defaultShareMaterial.name != matName)
            {
                isDirtuy = true;
                sprite3D.defaultShareMaterial =
                    AssetDatabase.LoadAssetAtPath<Material>("Assets/Shaders/ui3dcomponent/"+matName+".mat");
            }

            if (isDirtuy)
            {
                EditorUtility.SetDirty(sprite3D);
            }
        }

        public override void OnInspectorGUI()
        {

            //base.OnInspectorGUI();

            var sprite3D = target as CustomMeshBase;

            SerializedProperty sp = serializedObject.FindProperty("mSprite");

            var newSprite = (Sprite) EditorGUILayout.ObjectField("Sprite", sp.objectReferenceValue, typeof(Sprite));
            if (newSprite != sp.objectReferenceValue)
            {
                sprite3D.sprite = newSprite;
            }



            sp = serializedObject.FindProperty("customShareMaterial");
            var newMaterial = (Material) EditorGUILayout.ObjectField("使用材质", sp.objectReferenceValue, typeof(Material));
            if (newMaterial != sp.objectReferenceValue)
            {
                sprite3D.customShareMaterial = newMaterial;
                sprite3D.Refresh();
            }


            // sp = serializedObject.FindProperty("mTexture2D");
            // if (newSprite != null)
            // {
            //     EditorGUILayout.ObjectField("Texture2D", newSprite.texture, typeof(Texture2D));
            // }


            sp = serializedObject.FindProperty("mScale");
            var newScale = EditorGUILayout.FloatField("Scale", sp.floatValue);
            if (newScale != sp.floatValue)
            {
                sprite3D.scale = newScale;
            }

            sp = serializedObject.FindProperty("mColor");
            var newColor = EditorGUILayout.ColorField("Color", sp.colorValue);
            if (newColor != sp.colorValue)
            {
                sprite3D.color = newColor;
            }


            sp = serializedObject.FindProperty("mType");
            var newType =
                (Type) EditorGUILayout.EnumPopup("Type", (Type) sp.intValue);
            if (newType != (Type) sp.intValue)
            {
                sprite3D.type = newType;
            }


            if (sprite3D.type == Type.Filled)
            {
                // sp = serializedObject.FindProperty("mFillImpShader");
                // var newmFillImpShader = EditorGUILayout.Toggle("Shader血条",sp.boolValue);
                // if (newmFillImpShader != sp.boolValue)
                // {
                //     sprite3D.fillImpShader = newmFillImpShader;
                // }


                sp = serializedObject.FindProperty("m_FillOrigin");
                var newFillOrigin = EditorGUILayout.IntSlider("FillOrigin", sp.intValue, 0, 2);
                if (newFillOrigin != sp.intValue)
                {
                    sprite3D.fillOrigin = newFillOrigin;
                }

                sp = serializedObject.FindProperty("mFillMethod");
                var newFillMethod =
                    (FillMethod) EditorGUILayout.EnumPopup("FillMethod",
                        (FillMethod) sp.intValue);
                if (newFillMethod != (FillMethod) sp.intValue)
                {
                    sprite3D.fillMethod = newFillMethod;
                }



                if (newFillOrigin == 2)
                {

                    sp = serializedObject.FindProperty("mFillAmount");
                    var newFillAmount = EditorGUILayout.Slider("EndAmount", sp.floatValue, 0, 1);
                    if (newFillAmount != sp.floatValue)
                    {
                        sprite3D.fillAmount = newFillAmount;
                    }

                    sp = serializedObject.FindProperty("mFillAmount2");
                    var newFillAmount2 = EditorGUILayout.Slider("StartAmount", sp.floatValue, 0, newFillAmount);
                    if (newFillAmount2 != sp.floatValue)
                    {
                        sprite3D.fillAmount2 = newFillAmount2;
                    }
                }
                else
                {
                    sp = serializedObject.FindProperty("mFillAmount");
                    var newFillAmount = EditorGUILayout.Slider("FillAmount", sp.floatValue, 0, 1);
                    if (newFillAmount != sp.floatValue)
                    {
                        sprite3D.fillAmount = newFillAmount;
                    }
                }

                if (newFillMethod == FillMethod.Horizontal ||
                    newFillMethod == FillMethod.Vertical)
                {
                    sp = serializedObject.FindProperty("mSpaceCount");
                    var newSpaceCount = EditorGUILayout.IntField("SpaceCount", sp.intValue);
                    if (newSpaceCount != sp.intValue)
                    {
                        sprite3D.spaceCount = newSpaceCount;
                    }

                    // if (sprite3D.customShareMaterial != null)
                    // {

                        // sp = serializedObject.FindProperty("mSpaceVal");
                        // var newSpaceVal = EditorGUILayout.Slider("SpaceVal", sp.floatValue, 0, 0.2f);
                        // if (newSpaceVal != sp.floatValue)
                        // {
                        //     sprite3D.spaceVal = newSpaceVal;
                        // }
                    // }
                    // else
                    // {
                    //
                    //     sp = serializedObject.FindProperty("mSpaceVal");
                    //     var newSpaceVal = EditorGUILayout.Slider("SpaceVal", sp.floatValue, 0, 200.0f);
                    //     if (newSpaceVal != sp.floatValue)
                    //     {
                    //         sprite3D.spaceVal = newSpaceVal;
                    //     }
                    // }



                    sp = serializedObject.FindProperty("mPivot");
                    var newPivot =
                        (Pivot) EditorGUILayout.EnumPopup("Pivot",
                            (Pivot) sp.intValue);
                    if (newPivot != (Pivot) sp.intValue)
                    {
                        sprite3D.pivot = newPivot;
                    }
                }

            }


        }
    }
}
