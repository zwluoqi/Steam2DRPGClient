using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;


namespace CustomUI
{


    public class Custom3DImage : MonoBehaviour
    {
        public enum CustomImageType
        {
            Image,
            CustomRender,
        }

        [SerializeField] [HideInInspector] private CustomImageType mCustom3DImageType;

        // [SerializeField]
        // [HideInInspector]
        // private  Sprite mSprite;
        //
        // [SerializeField]
        // [HideInInspector]
        // private  float mFillCount = 1;
        //

        private bool m_inited = false;
        ICustom3DImage iCustom3DImage;


        private void Awake()
        {
            if (!m_inited)
            {
                CreateNewCustom3DImage();
                m_inited = true;
            }
        }


        private void CreateNewCustom3DImage()
        {
            if (this.mCustom3DImageType == CustomImageType.Image)
            {
                iCustom3DImage = new ImageImp(this);
            }
            else if (CustomImageType.CustomRender == this.mCustom3DImageType)
            {
                iCustom3DImage = new CustomRenderImp(this);
            }
        }

        public Sprite sprite
        {
            get
            {
                Awake();
                return this.iCustom3DImage.GetSprite();
            }
            set
            {
                Awake();
                // this.mSprite = value;
                iCustom3DImage.SetSprite(value);
            }
        }

        public float fillAmount
        {
            get
            {
                Awake();
                return iCustom3DImage.GetFillAmount();
            }
            set
            {
                Awake();
                // this.mFillCount = value;
                iCustom3DImage.SetFillAmount(value);
            }
        }


#if UNITY_EDITOR
        public void CheckForInspector()
        {
            if (iCustom3DImage == null)
            {
                DestroyComponent();
                CreateNewCustom3DImage();
            }
        }


        public void ChangeType(CustomImageType newCustomImageType)
        {
            if (this.mCustom3DImageType == newCustomImageType)
            {
                return;
            }

            Sprite o_sprite = null;
            var o_fillAmount = 1.0f;
            var o_type = Image.Type.Simple;
            var o_fillMethod = Image.FillMethod.Horizontal;
            GetSourceData(out o_sprite, out o_fillAmount, out o_type, out o_fillMethod);

            this.mCustom3DImageType = newCustomImageType;

            DestroyComponent();
            CreateNewCustom3DImage();

            this.iCustom3DImage.SetSprite(o_sprite);
            this.iCustom3DImage.SetFillAmount(o_fillAmount);
        }

        public void GetSourceData(out Sprite o_sprite, out float o_fillAmount, out Image.Type o_type,
            out Image.FillMethod o_fillMethod)
        {
            o_sprite = null;
            o_fillAmount = 1;
            o_type = Image.Type.Simple;
            o_fillMethod = Image.FillMethod.Horizontal;
            var image = this.GetComponent<Image>();
            if (image != null)
            {
                o_sprite = image.sprite;
                o_fillAmount = image.fillAmount;
                o_type = image.type;
                o_fillMethod = image.fillMethod;
            }

            var customMeshRender = this.GetComponent<CustomMeshRender>();
            if (customMeshRender != null)
            {
                o_sprite = customMeshRender.sprite;
                o_fillAmount = customMeshRender.fillAmount;
                o_type = (Image.Type) customMeshRender.type;
                o_fillMethod = (Image.FillMethod) customMeshRender.fillMethod;
            }

        }


        // private void DirtyComponent()
        // {
        //     // var image = this.GetComponent<Image>();
        //     // if (image != null)
        //     // {
        //     //     this.mSprite = image.sprite;
        //     //     this.mFillCount = image.fillAmount;
        //     // }
        //     //
        //     // var customMeshRenderer = this.GetComponent<CustomMeshRender>();
        //     // if (customMeshRenderer != null)
        //     // {
        //     //     this.mSprite = customMeshRenderer.sprite;
        //     //     this.mFillCount = customMeshRenderer.fillAmount;
        //     // }
        //
        //     DestroyComponent();
        // }

        private void DestroyComponent()
        {
            if (this.mCustom3DImageType != CustomImageType.Image)
            {
                UnityEngine.Object.DestroyImmediate(this.GetComponent<Image>(), true);
                UnityEngine.Object.DestroyImmediate(this.GetComponent<CanvasRenderer>(), true);
            }

            if (mCustom3DImageType != CustomImageType.CustomRender)
            {
                UnityEngine.Object.DestroyImmediate(this.GetComponent<CustomMeshRender>(), true);
                UnityEngine.Object.DestroyImmediate(this.GetComponent<MeshRenderer>(), true);
                UnityEngine.Object.DestroyImmediate(this.GetComponent<MeshFilter>(), true);
            }
        }
#endif
    }




    public interface ICustom3DImage
    {
        void SetFillAmount(float value);
        void SetSprite(Sprite value);
        Sprite GetSprite();
        float GetFillAmount();
    }
}