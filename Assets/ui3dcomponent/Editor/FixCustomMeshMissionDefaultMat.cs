using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomUI
{
    public class FixCustomMeshMissionDefaultMat : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach (string str in importedAssets)
            {
                if (str.Contains("View3D") && Path.GetExtension(str) == ".prefab")
                {
                    var go = AssetDatabase.LoadAssetAtPath<GameObject>(str);
                    var customs = go.GetComponentsInChildren<CustomMeshRender>();
                    bool isChange = false;
                    foreach (var custom in customs)
                    {
                        if (custom.defaultShareMaterial == null)
                        {
                            CustomMeshBaseInspector.SetDefaultMaterial(custom,"ui3d_vertxfrag_mat");
                            isChange = true;
                        }
                    }

                    if (isChange)
                    {
                        PrefabUtility.SavePrefabAsset(go);
                    }
                }
            }
        }
    }
}