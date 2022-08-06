using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CustomUI
{
        public enum Pivot
        {
            TopLeft=0,
            Top,
            TopRight,
            Left,
            Center,
            Right,
            BottomLeft,
            Bottom,
            BottomRight,
        }

    /// <summary>
        /// Image fill type controls how to display the image.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Displays the full Image
            /// </summary>
            /// <remarks>
            /// This setting shows the entire image stretched across the Image's RectTransform
            /// </remarks>
            Simple,
            //
            /// <summary>
            /// Displays the Image as a 9-sliced graphic.
            /// </summary>
            /// <remarks>
            /// A 9-sliced image displays a central area stretched across the image surrounded by a border comprising of 4 corners and 4 stretched edges.
            ///
            /// This has the effect of creating a resizable skinned rectangular element suitable for dialog boxes, windows, and general UI elements.
            ///
            /// Note: For this method to work properly the Sprite assigned to Image.sprite needs to have Sprite.border defined.
            /// </remarks>
            Sliced,

            /// <summary>
            /// Displays a sliced Sprite with its resizable sections tiled instead of stretched.
            /// </summary>
            /// <remarks>
            /// A Tiled image behaves similarly to a UI.Image.Type.Sliced|Sliced image, except that the resizable sections of the image are repeated instead of being stretched. This can be useful for detailed UI graphics that do not look good when stretched.
            ///
            /// It uses the Sprite.border value to determine how each part (border and center) should be tiled.
            ///
            /// The Image sections will repeat the corresponding section in the Sprite until the whole section is filled. The corner sections will be unaffected and will draw in the same way as a Sliced Image. The edges will repeat along their lengths. The center section will repeat across the whole central part of the Image.
            ///
            /// The Image section will repeat the corresponding section in the Sprite until the whole section is filled.
            ///
            /// Be aware that if you are tiling a Sprite with borders or a packed sprite, a mesh will be generated to create the tiles. The size of the mesh will be limited to 16250 quads; if your tiling would require more tiles, the size of the tiles will be enlarged to ensure that the number of generated quads stays below this limit.
            ///
            /// For optimum efficiency, use a Sprite with no borders and with no packing, and make sure the Sprite.texture wrap mode is set to TextureWrapMode.Repeat.These settings will prevent the generation of additional geometry.If this is not possible, limit the number of tiles in your Image.
            /// </remarks>
            Tiled,

            /// <summary>
            /// Displays only a portion of the Image.
            /// </summary>
            /// <remarks>
            /// A Filled Image will display a section of the Sprite, with the rest of the RectTransform left transparent. The Image.fillAmount determines how much of the Image to show, and Image.fillMethod controls the shape in which the Image will be cut.
            ///
            /// This can be used for example to display circular or linear status information such as timers, health bars, and loading bars.
            /// </remarks>
            Filled,
        }

        /// <summary>
        /// The possible fill method types for a Filled Image.
        /// </summary>
        public enum FillMethod
        {
            /// <summary>
            /// The Image will be filled Horizontally.
            /// </summary>
            /// <remarks>
            /// The Image will be Cropped at either left or right size depending on Image.fillOriging at the Image.fillAmount
            /// </remarks>
            Horizontal,

            /// <summary>
            /// The Image will be filled Vertically.
            /// </summary>
            /// <remarks>
            /// The Image will be Cropped at either top or Bottom size depending on Image.fillOrigin at the Image.fillAmount
            /// </remarks>
            Vertical,

            /// <summary>
            /// The Image will be filled Radially with the radial center in one of the corners.
            /// </summary>
            /// <remarks>
            /// For this method the Image.fillAmount represents an angle between 0 and 90 degrees. The Image will be cut by a line passing at the Image.fillOrigin at the specified angle.
            /// </remarks>
            Radial90,

            /// <summary>
            /// The Image will be filled Radially with the radial center in one of the edges.
            /// </summary>
            /// <remarks>
            /// For this method the Image.fillAmount represents an angle between 0 and 180 degrees. The Image will be cut by a line passing at the Image.fillOrigin at the specified angle.
            /// </remarks>
            Radial180,

            /// <summary>
            /// The Image will be filled Radially with the radial center at the center.
            /// </summary>
            /// <remarks>
            /// or this method the Image.fillAmount represents an angle between 0 and 360 degrees. The Arc defined by the center of the Image, the Image.fillOrigin and the angle will be cut from the Image.
            /// </remarks>
            Radial360,

        }

        /// <summary>
        /// Origin for the Image.FillMethod.Horizontal.
        /// </summary>
        public enum OriginHorizontal
        {
            /// <summary>
            /// >Origin at the Left side.
            /// </summary>
            Left,

            /// <summary>
            /// >Origin at the Right side.
            /// </summary>
            Right,
        }


        /// <summary>
        /// Origin for the Image.FillMethod.Vertical.
        /// </summary>
        public enum OriginVertical
        {
            /// <summary>
            /// >Origin at the Bottom Edge.
            /// </summary>
            Bottom,

            /// <summary>
            /// >Origin at the Top Edge.
            /// </summary>
            Top,
        }

        /// <summary>
        /// Origin for the Image.FillMethod.Radial90.
        /// </summary>
        public enum Origin90
        {
            /// <summary>
            /// Radial starting at the Bottom Left corner.
            /// </summary>
            BottomLeft,

            /// <summary>
            /// Radial starting at the Top Left corner.
            /// </summary>
            TopLeft,

            /// <summary>
            /// Radial starting at the Top Right corner.
            /// </summary>
            TopRight,

            /// <summary>
            /// Radial starting at the Bottom Right corner.
            /// </summary>
            BottomRight,
        }

        /// <summary>
        /// Origin for the Image.FillMethod.Radial180.
        /// </summary>
        public enum Origin180
        {
            /// <summary>
            /// Center of the radial at the center of the Bottom edge.
            /// </summary>
            Bottom,

            /// <summary>
            /// Center of the radial at the center of the Left edge.
            /// </summary>
            Left,

            /// <summary>
            /// Center of the radial at the center of the Top edge.
            /// </summary>
            Top,

            /// <summary>
            /// Center of the radial at the center of the Right edge.
            /// </summary>
            Right,
        }

        /// <summary>
        /// One of the points of the Arc for the Image.FillMethod.Radial360.
        /// </summary>
        public enum Origin360
        {
            /// <summary>
            /// Arc starting at the center of the Bottom edge.
            /// </summary>
            Bottom,

            /// <summary>
            /// Arc starting at the center of the Right edge.
            /// </summary>
            Right,

            /// <summary>
            /// Arc starting at the center of the Top edge.
            /// </summary>
            Top,

            /// <summary>
            /// Arc starting at the center of the Left edge.
            /// </summary>
            Left,
        }


    public abstract class CustomMeshBase : MonoBehaviour
    {

        [HideInInspector] [SerializeField] protected Sprite mSprite;

        [HideInInspector] [SerializeField] protected float mFillAmount = 1.0f;

        [HideInInspector] [SerializeField] protected Color mColor = Color.white;

        /// How the Image is drawn.
        [HideInInspector] [SerializeField] protected Type mType = Type.Simple;

        /// How the Image is drawn.
        [HideInInspector] [SerializeField] protected FillMethod mFillMethod = FillMethod.Radial360;


        /// Controls the origin point of the Fill process. Value means different things with each fill method.
        [HideInInspector] [SerializeField] protected int m_FillOrigin;


        /// Whether the Image should be filled clockwise (true) or counter-clockwise (false).
        [HideInInspector] [SerializeField] protected bool m_FillClockwise = true;


        /// 进度条分段
        [HideInInspector] [SerializeField] protected int mSpaceCount;


        /// 进度条分段
        [HideInInspector] [SerializeField] protected float mSpaceVal = 0.2f;

        [HideInInspector] [SerializeField] protected float mScale = 1.0f;

        [HideInInspector] [SerializeField] protected Pivot mPivot = Pivot.Center;

        [HideInInspector] [SerializeField] protected float mFillAmount2 = 1.0f;

        // [HideInInspector][SerializeField] private bool mFillImpShader =false;

        [HideInInspector] [SerializeField] public Material defaultShareMaterial;

        [HideInInspector] [SerializeField] public  Material customShareMaterial;


        protected Material userMaterial
        {
            get
            {
                if (customShareMaterial != null)
                {
                    return customShareMaterial;
                }

                return defaultShareMaterial;
            }
        }


        public Sprite activeSprite
        {
            get { return sprite; }
        }


        private static Vector2[] pivotOffsets;


        public Sprite sprite
        {
            get { return mSprite; }
            set
            {
                mSprite = value;
                OptimizeRefresh();
            }
        }

        public float fillAmount
        {

            get { return mFillAmount; }
            set
            {
                if (this.mFillAmount == value)
                {
                    return;
                }

                mFillAmount = value;
                OptimizeRefresh();
            }
        }

        public float fillAmount2
        {

            get { return mFillAmount2; }
            set
            {
                if (this.mFillAmount2 == value)
                {
                    return;
                }

                mFillAmount2 = value;
                OptimizeRefresh();
            }
        }

        public Type type
        {

            get { return mType; }
            set
            {
                mType = value;
                //TODO 重新生成UV
                OptimizeRefresh();
            }
        }

        public FillMethod fillMethod
        {

            get { return mFillMethod; }
            set
            {
                mFillMethod = value;
                OptimizeRefresh();
            }
        }

        public int fillOrigin
        {
            get { return m_FillOrigin; }
            set
            {
                m_FillOrigin = value;
                OptimizeRefresh();
            }
        }

        public bool fillClockwise
        {
            get { return m_FillClockwise; }
            set
            {
                m_FillClockwise = value;
                OptimizeRefresh();
            }
        }

        public int spaceCount
        {
            get { return mSpaceCount; }
            set
            {
                if (this.mSpaceCount == value)
                {
                    return;
                }

                mSpaceCount = value;
                OptimizeRefresh();
            }
        }


        public float spaceVal
        {
            get { return mSpaceVal; }
            set
            {
                mSpaceVal = value;
                OptimizeRefresh();
            }
        }


        public float scale
        {
            get { return mScale; }
            set
            {
                mScale = value;
                OptimizeRefresh();
            }
        }


        public Pivot pivot
        {
            get { return mPivot; }
            set
            {
                if (this.mPivot == value)
                {
                    return;
                }

                mPivot = value;
                OptimizeRefresh();
            }
        }




        public Color color
        {
            get { return this.mColor; }
            set
            {
                this.mColor = value;
                OptimizeRefresh();
            }
        }



        public float width3D
        {
            get
            {
                if (sprite == null)
                {
                    return 0;
                }

                return ((sprite.rect.width * (mSpaceCount + 1) + mSpaceVal * mSpaceCount)) * innerScaleFactor;
            }
        }


        public float cellWidth3D
        {
            get
            {
                if (sprite == null)
                {
                    return 0;
                }

                return (sprite.rect.width + mSpaceVal) * innerScaleFactor;
            }
        }

        public float spaceVal3D
        {
            get
            {
                if (sprite == null)
                {
                    return 0;
                }

                return (mSpaceVal) * innerScaleFactor;
            }
        }

        public float spriteWidth3D
        {
            get
            {
                if (sprite == null)
                {
                    return 0;
                }

                return (sprite.rect.width) * innerScaleFactor;
            }
        }


        public float height3D
        {
            get
            {
                if (sprite == null)
                {
                    return 0;
                }

                return sprite.rect.height * innerScaleFactor;
            }
        }

        protected Texture mTexture2D
        {
            get { return sprite.texture; }
        }

        protected float innerScaleFactor
        {
            get { return scale * 0.01f; }
        }

        protected bool mIsDirty = false;

        private void Update()
        {
            if (mIsDirty)
            {
                if (this.mTexture2D != null)
                {
                    Refresh();
                }
            }
        }

        protected void OptimizeRefresh()
        {
            if (Application.isPlaying)
            {
                mIsDirty = true;
            }
            else
            {
                Refresh();
            }
        }


        protected MeshRenderer meshRenderer;
        protected  MeshFilter meshFilter;

        protected readonly CustomVertexHelper toFill = new CustomVertexHelper();


        // Use this for initialization
        void Awake()
        {
            Refresh();
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (mSprite == null)
            {
                var tex = Texture2D.whiteTexture;
                mSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            }

            if (this.userMaterial == null)
            {
                return;
            }

            if (meshRenderer == null)
            {
                meshRenderer = GetComponent<MeshRenderer>();
                meshFilter = GetComponent<MeshFilter>();
            }

            if (Application.isPlaying)
            {

                if (this.mTexture2D == null)
                {
                    mIsDirty = true;
                    Debug.LogError("sprite 没有 texture?" + sprite.name);
                    return;
                }

                mIsDirty = false;
                SetSharedMaterial();
                SetShareMesh();

            }
            else
            {
                mIsDirty = false;
                SetSharedMaterial();
                SetShareMesh();
            }
            DoRefresh();
        }

        protected abstract void SetShareMesh();

        protected abstract void SetSharedMaterial();

        protected abstract Mesh GenerateMesh(Mesh meshFilterSharedMesh);

        protected virtual void DoRefresh()
        {

        }


        private void OnDidApplyAnimationProperties()
        {
            this.OptimizeRefresh();
        }
    }
}

