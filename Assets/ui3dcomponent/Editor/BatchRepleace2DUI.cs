using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using  CustomUI;

/// <summary>
/// 一次性代码，用完即删的工具代码
/// </summary>
public class BatchRepleace2DUI : Editor
{

    private delegate bool DelegateExecuteMenuItemWithTemporaryContext(string menuItemPath, UnityEngine.Object[] objects);
    private static DelegateExecuteMenuItemWithTemporaryContext ExecuteMenuItemWithTemporaryContext;

    public static void RemoveRectTransform(GameObject gameObject)
    {
        var rectTransform = gameObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            if (ExecuteMenuItemWithTemporaryContext == null)
            {
                ExecuteMenuItemWithTemporaryContext = typeof(EditorApplication).GetMethod("ExecuteMenuItemWithTemporaryContext", BindingFlags.Static | BindingFlags.NonPublic)
                    .CreateDelegate(typeof(DelegateExecuteMenuItemWithTemporaryContext)) as DelegateExecuteMenuItemWithTemporaryContext;
            }
            ExecuteMenuItemWithTemporaryContext("CONTEXT/Component/Remove Component", new UnityEngine.Object[] { rectTransform });
        }
    }

    [MenuItem("Assets/Tmp/批处理UI到3D")]
    public static void Batch3DUI()
    {
        BatchAddCustom3DImage();
        BatchRepleaceImage2Sprite();
    }

    [MenuItem("Assets/Tmp/批处理删除Custom3DImage")]
    public static void RemoveCustom3DImage()
    {
        var objs = Selection.gameObjects;

        int imageCount = 0;
        foreach (var source in objs)
        {
            var assetPath = AssetDatabase.GetAssetPath(source);

            var newObj = GameObject.Instantiate(source) as GameObject;

            var images = newObj.GetComponentsInChildren<Custom3DImage>(true);
            foreach (var image in images)
            {
                // AddImage(image);
                // imageCount++;
                Object.DestroyImmediate(image);
            }

            PrefabUtility.SaveAsPrefabAsset(newObj, assetPath);
            GameObject.DestroyImmediate(newObj,true);
        }


        AssetDatabase.Refresh();
        Debug.LogWarning("添加完成 Image数量:"+imageCount);
    }

    [MenuItem("Assets/Tmp/3D UI功能第1步批处理(添加组件)")]
    public static void BatchAddCustom3DImage()
    {

        var objs = Selection.gameObjects;

        int imageCount = 0;
        foreach (var source in objs)
        {
            var assetPath = AssetDatabase.GetAssetPath(source);

            var newObj = GameObject.Instantiate(source) as GameObject;

            var images = newObj.GetComponentsInChildren<Image>(true);
            foreach (var image in images)
            {
                AddImage(image);
                imageCount++;
            }

            PrefabUtility.SaveAsPrefabAsset(newObj, assetPath);
            GameObject.DestroyImmediate(newObj,true);
        }


        AssetDatabase.Refresh();
        Debug.LogWarning("添加完成 Image数量:"+imageCount);
    }

    [MenuItem("Assets/Tmp/3D UI功能第1步批处理(Image切SpriteRender)")]
    public static void BatchRepleaceImage2Sprite()
    {

        var objs = Selection.gameObjects;

        int imageCount = 0;
        int TMPCount = 0;
        int LayoutGroupCount = 0;
        foreach (var source in objs)
        {
            var assetPath = AssetDatabase.GetAssetPath(source);
            var newObj = GameObject.Instantiate(source) as GameObject;

            var images = newObj.GetComponentsInChildren<Custom3DImage>(true);
            foreach (var image in images)
            {
                ChangeImage2Sprite(image);
                imageCount++;
            }

            var texts = newObj.GetComponentsInChildren<TextMeshProUGUI>(true);
            foreach (var text in texts)
            {
                RepleaceText(text.gameObject);
                TMPCount++;
            }

            var groups = newObj.GetComponentsInChildren<HorizontalLayoutGroup>(true);
            foreach (var group in groups)
            {
                RepleaceLayoutGroup(group.gameObject);
                LayoutGroupCount++;
            }

            //除了Text，删除所有RectTransform，并按比例转换
            Vector3 scale = new Vector3(0.01f,0.01f,1.0f);
            var rects = newObj.GetComponentsInChildren<RectTransform>(true);

            //更新位置
            foreach (var rect in rects)
            {
                var go = rect.gameObject;
                rect.anchoredPosition3D = new Vector3(rect.anchoredPosition3D.x*scale.x,
                    rect.anchoredPosition3D.y*scale.y,
                    rect.anchoredPosition3D.z*scale.z);

                if (rect.parent != null)
                {
                    var parentRect = (rect.parent.GetComponent<RectTransform>());
                    if (parentRect != null)
                    {
                        var xoffset = (rect.anchorMin.x + rect.anchorMax.x - 1) * 0.5f * parentRect.sizeDelta.x;
                        var yoffset = (rect.anchorMin.y + rect.anchorMax.y - 1) * 0.5f * parentRect.sizeDelta.y;
                        rect.anchoredPosition3D += new Vector3(xoffset * scale.x, yoffset * scale.y, 0);
                    }
                }

            }

            //更新字体缩放并删除Rect
            foreach (var rect in rects)
            {
                var go = rect.gameObject;

                var text = go.GetComponent<TextMeshPro>();
                if (text == null)
                {
                    RemoveRectTransform(go);
                }
                else
                {
                    go.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);
                }
            }

            newObj.transform.localScale = Vector3.one;
            PrefabUtility.SaveAsPrefabAsset(newObj, assetPath);
            GameObject.DestroyImmediate(newObj,true);
        }
        AssetDatabase.Refresh();
        Debug.LogWarning("替换Image数量:"+imageCount+",替换Text数量："+TMPCount+",替换LayoutGroup:"+LayoutGroupCount);
    }

    private static void RepleaceLayoutGroup(GameObject groupGameObject)
    {
        var layoutGroup = groupGameObject.GetComponent<LayoutGroup>();
        if (layoutGroup == null)
        {
            return;
        }
        GameObject.DestroyImmediate(layoutGroup);
        var grid =  groupGameObject.AddComponent<Custom3DGrid>();

    }

    private static void ChangeImage2Sprite(Custom3DImage image)
    {
        var imageComponent = image.GetComponent<Image>();
        var type = imageComponent.type;
        var fillMethod = imageComponent.fillMethod;

        image.CheckForInspector();
        image.ChangeType(Custom3DImage.CustomImageType.CustomRender);

        var  customMeshRender = image.GetComponent<CustomMeshRender>();
        customMeshRender.type = (Type)type;
        customMeshRender.fillMethod = (FillMethod)fillMethod;
    }

    private static void AddImage(Image image)
    {
        var custom3DImage =  image.GetComponent<Custom3DImage>();
        if (custom3DImage != null)
        {
            return;
        }

        image.gameObject.AddComponent<Custom3DImage>();
    }


    public static void RepleaceText(GameObject t)
    {
        // var tmpUGUI = t.GetComponent<TextMeshProUGUI>();
        // var i18 = t.GetComponent<TMTextI18N>();
        // if (tmpUGUI == null)
        // {
        //     return;
        // }
        //
        // var tmpCanvasRender = t.GetComponent<CanvasRenderer>();
        //
        // var go = new GameObject("tmp");
        // var copyTmp = CopyComponent<TextMeshProUGUI>(tmpUGUI,go);
        // var copyI18 = CopyComponent<TMTextI18N>(i18,go);
        //
        // GameObject.DestroyImmediate(i18,true);
        // GameObject.DestroyImmediate(tmpUGUI,true);
        // GameObject.DestroyImmediate(tmpCanvasRender,true);
        // var newTMP = CopyComponent<TextMeshPro>(copyTmp,t.gameObject);
        // var newI18 = CopyComponent<TMTextI18N>(copyI18,t.gameObject);
        //
        //
        // GameObject.DestroyImmediate(go,true);
        //
        // t.gameObject.SetActive(false);
        // t.gameObject.SetActive(true);
    }


    static T CopyComponent<T>(Component original, GameObject destination) where T : Component
    {
        if (original == null)
        {
            return null;
        }
        System.Type type = original.GetType();
        T copy = destination.GetComponent<T>();
        if (copy == null)
        {
            copy = destination.AddComponent<T>();
        }

        var newType = copy.GetType();
        int depthCount = 0;
        while (type != null)
        {
            System.Reflection.FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (System.Reflection.FieldInfo field in fields)
            {
                var newTypeField = newType.GetField(field.Name, BindingFlags.Instance | BindingFlags.NonPublic);
                if (newTypeField == null)
                {
                    continue;
                }

                if (newTypeField.FieldType != field.FieldType)
                {
                    continue;
                }

                if ((newTypeField.Attributes & FieldAttributes.NotSerialized) != 0)
                {
                    continue;
                }

                if (newTypeField.IsNotSerialized)
                {
                    continue;
                }

                if (newTypeField.Name == "m_isOrthographic")
                {
                    continue;
                }

                if (newTypeField.Name == "m_firstOverflowCharacterIndex")
                {
                    continue;
                }

                //Debug.LogWarning("copy field:"+newTypeField.Name);
                newTypeField.SetValue(copy, field.GetValue(original));
            }

            type = type.BaseType;
            newType = newType.BaseType;
            depthCount++;
            if (depthCount > 2)
            {
                break;
                ;
            }
        }

        return copy;
    }

}
