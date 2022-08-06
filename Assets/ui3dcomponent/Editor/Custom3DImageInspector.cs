using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace CustomUI
{


    [CustomEditor(typeof(Custom3DImage))]
    public class Custom3DImageInspector : UnityEditor.Editor
    {

        // protected override void OnEnable () {
        //     base.OnEnable();
        //     mecanimTranslator = serializedObject.FindProperty("translator");
        // }



        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Custom3DImage t = (Custom3DImage) target;
            t.CheckForInspector();

            SerializedProperty sp = serializedObject.FindProperty("mCustom3DImageType");

            Custom3DImage.CustomImageType oldImageType = (Custom3DImage.CustomImageType) sp.intValue;
            var newCustom3DImageType = (Custom3DImage.CustomImageType) EditorGUILayout.EnumPopup("Type", oldImageType);
            if (newCustom3DImageType != oldImageType)
            {
                t.ChangeType(newCustom3DImageType);
                if (newCustom3DImageType != Custom3DImage.CustomImageType.Image)
                {
                    BatchRepleace2DUI.RemoveRectTransform(t.gameObject);
                }
            }
            //
            // sp = serializedObject.FindProperty("mSprite");
            // Sprite oldSprite = (Sprite)sp.objectReferenceValue;
            // var newSprite = (Sprite)EditorGUILayout.ObjectField("Sprite", oldSprite, typeof(Sprite), false);
            // if (newSprite != oldSprite)
            // {
            //     t.sprite = newSprite;
            // }
            //
            //
            // sp = serializedObject.FindProperty("mFillCount");
            // float oldFill = sp.floatValue;
            // var newFill = EditorGUILayout.Slider("FillVal", oldFill, 0, 1);
            // if (newFill != oldFill)
            // {
            //     t.fillAmount = newFill;
            // }

            // sp = serializedObject.FindProperty("mFillMethod");
            // Image.FillMethod oldFillMethod = (Image.FillMethod)sp.intValue;
            // var newFillMethod = (Image.FillMethod)EditorGUILayout.EnumPopup("FillMethod", oldFillMethod);
            // if (newFillMethod != oldFillMethod)
            // {
            //     t.fillMethod = newFillMethod;
            // }
        }
    }
}