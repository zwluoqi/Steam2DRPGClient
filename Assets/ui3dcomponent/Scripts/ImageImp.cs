using UnityEngine;
using UnityEngine.UI;

namespace CustomUI
{


    internal class ImageImp : ICustom3DImage
    {
        GameObject m_go;
        private Image m_image;

        public ImageImp(Custom3DImage go)
        {
            this.m_go = go.gameObject;
            this.m_image = m_go.GetComponent<Image>();

#if UNITY_EDITOR
            if (this.m_image == null)
            {
                this.m_image = m_go.AddComponent<Image>();
            }
#endif

            // this.m_image.sprite = go.sprite;
            // this.m_image.fillAmount = go.fillAmount;
        }

        public void SetFillAmount(float value)
        {
            m_image.fillAmount = value;
        }

        public void DestroyComponent()
        {

        }

        public void SetSprite(Sprite value)
        {
            m_image.sprite = value;
        }

        public Sprite GetSprite()
        {
            return this.m_image.sprite;
        }

        public float GetFillAmount()
        {
            return this.m_image.fillAmount;
        }

    }
}