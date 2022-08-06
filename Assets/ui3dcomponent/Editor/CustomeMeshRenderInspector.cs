using System;
using UnityEngine;

using UnityEditor;

using System.Collections;



namespace CustomUI
{

    [CanEditMultipleObjects]
    [CustomEditor(typeof(CustomMeshRender))]
    public class CustomMeshRenderInspector : CustomMeshBaseInspector
    {
        public override void OnInspectorGUI()
        {
            SetDefaultMaterial(target as CustomMeshBase,"ui3d_vertxfrag_mat");
            base.OnInspectorGUI();

            var sprite3D = target as CustomMeshBase;
            SerializedProperty sp;
            sp = serializedObject.FindProperty("mSpaceVal");
            var newSpaceVal = EditorGUILayout.Slider("SpaceVal", sp.floatValue, 0, 200.0f);
            if (newSpaceVal != sp.floatValue)
            {
                sprite3D.spaceVal = newSpaceVal;
            }
            
            var meshRenderer = sprite3D.GetComponent<MeshRenderer>();

            if (meshRenderer.sharedMaterial == null)
            {
                
            }
            else if (meshRenderer.sharedMaterial != null && !meshRenderer.sharedMaterial.name.StartsWith("ui3d_vertxfrag_mat"))
            {
                sprite3D.Refresh();
            }
        }

    }

}
