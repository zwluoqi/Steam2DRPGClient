using UnityEngine;
using UnityEngine.UI;

namespace CustomUI
{


    internal class SpriteRenderImp : ICustom3DImage
    {
        GameObject m_go;
        SpriteRenderer m_spriteRender;
        MaterialPropertyBlock materialPropertyBlock;
        float m_fillCount = 1;

        public SpriteRenderImp(Custom3DImage go)
        {
            this.m_go = go.gameObject;
            this.m_spriteRender = go.GetComponent<SpriteRenderer>();
#if UNITY_EDITOR
            if (this.m_spriteRender == null)
            {
                this.m_spriteRender = m_go.AddComponent<SpriteRenderer>();
            }
#endif
            // this.m_spriteRender.sprite = go.hSprite;
            this.materialPropertyBlock = new MaterialPropertyBlock();

        }

        public Sprite GetSprite()
        {
            return this.m_spriteRender.sprite;
        }

        public float GetFillAmount()
        {
            return m_fillCount;
        }

        public void SetFillAmount(float value)
        {
            m_fillCount = value;
            m_spriteRender.color =
                new Color(m_spriteRender.color.r, m_spriteRender.color.g, m_spriteRender.color.b, value);

        }

        public void SetSprite(Sprite value)
        {
            m_spriteRender.sprite = value;
            if (value == null)
            {
                return;
                ;
            }

            var centerx = m_spriteRender.sprite.rect.center.x / m_spriteRender.sprite.texture.width;
            var centery = m_spriteRender.sprite.rect.center.y / m_spriteRender.sprite.texture.height;

            var sizex = m_spriteRender.sprite.rect.size.x / m_spriteRender.sprite.texture.width;
            var sizey = m_spriteRender.sprite.rect.size.x / m_spriteRender.sprite.texture.width;

            m_spriteRender.GetPropertyBlock(materialPropertyBlock);
            materialPropertyBlock.SetVector("_SpriteCenterSize", new Vector4(centerx,
                centery,
                sizex,
                sizey));
            m_spriteRender.SetPropertyBlock(materialPropertyBlock);
        }

        public void SetFillMethod(Image.FillMethod mFillMethod)
        {

        }
    }
}