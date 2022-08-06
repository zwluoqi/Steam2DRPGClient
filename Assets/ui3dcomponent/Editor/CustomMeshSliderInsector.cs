using UnityEditor;

namespace CustomUI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(CustomMeshSlider))]
    public class CustomMeshSliderInsector:CustomMeshBaseInspector
    {
        // private bool first = true;
        public float transW2H = 1;
        public override void OnInspectorGUI()
        {
            SetDefaultMaterial(target as CustomMeshBase,"ui3d_ui3dSliderShader");
            base.OnInspectorGUI();
            var sprite3D = target as CustomMeshSlider;

            SerializedProperty sp;

            sp = serializedObject.FindProperty("m_angle");
            var newFillAmount = EditorGUILayout.Slider("倾斜角度", sp.floatValue, 0, 90);
            if (newFillAmount != sp.floatValue)
            {
                sprite3D.angle = newFillAmount;
            }

            sp = serializedObject.FindProperty("mSpaceVal");
            var newSpaceVal = EditorGUILayout.Slider("SpaceVal", sp.floatValue, 0, 0.2f);
            if (newSpaceVal != sp.floatValue)
            {
                sprite3D.spaceVal = newSpaceVal;
            }

            EditorGUILayout.LabelField("当前实际3D长度:"+ sprite3D.transform.localScale.x*sprite3D.defaultLength);

            var newTransW2H = sprite3D.transform.localScale.x / sprite3D.transform.localScale.y;
            if ( newTransW2H!= transW2H )
            {
                // first = false;
                transW2H = newTransW2H;
                sprite3D.Refresh();
            }
        }

    }
}
