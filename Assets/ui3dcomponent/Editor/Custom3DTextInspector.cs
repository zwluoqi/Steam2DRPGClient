using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Custom3DText))]
public class Custom3DTextInspector:UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        
        Custom3DText t = (Custom3DText)target;
        BatchRepleace2DUI.RepleaceText(t.gameObject);
        
        t.gameObject.SendMessage("Awake");
        t.gameObject.SendMessage("OnEnable");
        
        // var tmpUGUI = t.GetComponent<TextMeshProUGUI>();
        // if (tmpUGUI == null)
        // {
        //     return;
        // }
        // var tmpCanvasRender = t.GetComponent<CanvasRenderer>();
        //
        // var go = new GameObject("tmp");
        // var copyTmp = CopyComponent<TextMeshProUGUI>(tmpUGUI,go);
        //
        // GameObject.DestroyImmediate(tmpUGUI);
        // GameObject.DestroyImmediate(tmpCanvasRender);
        // var Tmp = CopyComponent<TextMeshPro>(copyTmp,t.gameObject);
        // GameObject.DestroyImmediate(go);
        //
        // t.gameObject.SetActive(false);
        // t.gameObject.SetActive(true);
    }
    //
    // T CopyComponent<T>(Component original, GameObject destination) where T : Component
    // {
    //     System.Type type = original.GetType();
    //     T copy = destination.AddComponent<T>();
    //
    //     var newType = copy.GetType();
    //     System.Reflection.FieldInfo[] fields = type.GetFields(BindingFlags.Instance|BindingFlags.NonPublic);
    //
    //     foreach (System.Reflection.FieldInfo field in fields)
    //     {
    //         var newTypeField = newType.GetField(field.Name,BindingFlags.Instance|BindingFlags.NonPublic);
    //         if (newTypeField == null)
    //         {
    //             continue;
    //         }
    //
    //         if (newTypeField.FieldType != field.FieldType)
    //         {
    //             continue;
    //         }
    //
    //         if ((newTypeField.Attributes & FieldAttributes.NotSerialized) != 0)
    //         {
    //             continue;
    //         }
    //
    //         if (newTypeField.IsNotSerialized)
    //         {
    //             continue;
    //         }
    //
    //         if (newTypeField.Name == "m_isOrthographic")
    //         {
    //             continue;
    //         }
    //         if (newTypeField.Name == "m_firstOverflowCharacterIndex")
    //         {
    //             continue;
    //         }
    //         //Debug.LogWarning("copy field:"+newTypeField.Name);
    //         newTypeField.SetValue(copy, field.GetValue(original));
    //     }
    //
    //     
    //     copy.SendMessage("Awake");
    //     copy.SendMessage("OnEnable");
    //     return copy;
    // }
}