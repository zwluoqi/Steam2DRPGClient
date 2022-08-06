using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace CustomUI
{


    internal class CustomRenderImp : ICustom3DImage
    {
        public GameObject gameObject;
        public CustomMeshRender customMeshRenderer;

        public CustomRenderImp(Custom3DImage go)
        {
            gameObject = go.gameObject;
            CreateRender();
        }

        private void CreateRender()
        {
            customMeshRenderer = gameObject.GetComponent<CustomMeshRender>();
#if UNITY_EDITOR
            if (this.customMeshRenderer == null)
            {
                this.customMeshRenderer = gameObject.AddComponent<CustomMeshRender>();
            }
#endif
            //customMeshRenderer.Refresh();
        }

        public void SetFillAmount(float value)
        {
            customMeshRenderer.fillAmount = value;
        }

        public void SetSprite(Sprite value)
        {
            customMeshRenderer.sprite = value;
        }

        public Sprite GetSprite()
        {
            return this.customMeshRenderer.sprite;
        }

        public float GetFillAmount()
        {
            return this.customMeshRenderer.fillAmount;
        }
    }
}
