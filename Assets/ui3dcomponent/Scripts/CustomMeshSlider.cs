using System.Collections;
using System.Collections.Generic;
using CustomUI;
using UnityEngine;
using UnityEngine.Profiling;


[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomMeshSlider : CustomMeshBase
{

    [HideInInspector] [SerializeField]  protected float m_angle = 15;
    [HideInInspector] [SerializeField]  protected Vector4 m_size = new Vector4(0,0,1,1);
    private static readonly float scaleFactor =0.01f;



    /// <summary>
    /// 同一张图共用一套mesh，可以使用GPU INSTANCE
    /// </summary>
    private static Dictionary<int,Mesh> shareMeshs = new Dictionary<int, Mesh>();
    private static Dictionary<int,Vector4> shareUVs = new Dictionary<int, Vector4>();
    private static Dictionary<int,Vector4> shareSizes = new Dictionary<int, Vector4>();

    private MaterialPropertyBlock materialPropertyBlock;
    private Vector4 m_UVRect;

    public float defaultLength
    {
        get
        {
            return (m_size.z - m_size.x)*scaleFactor;
        }
    }



    public float angle
    {
        get
        {
            return m_angle;
        }
        set
        {
            m_angle = value;
            OptimizeRefresh();
        }
    }


    protected override void SetShareMesh()
    {
        this.meshFilter.sharedMesh = GenerateMesh(null);
    }

    protected override void SetSharedMaterial()
    {
        this.meshRenderer.sharedMaterial = userMaterial;
    }


    protected override Mesh GenerateMesh(Mesh meshFilterSharedMesh)
    {
        Profiler.BeginSample("Slider GenerateMesh");
        if (materialPropertyBlock == null)
        {
            materialPropertyBlock = new MaterialPropertyBlock();
        }
        Mesh shareMesh = null;
        var meshKey = 0;//activeSprite.GetInstanceID();
        if (!shareMeshs.TryGetValue(meshKey,out shareMesh) || shareMesh == null)
        {
            shareMesh = new Mesh();
            shareMesh.name = shareMesh.GetInstanceID()+"";
            toFill.Clear();
            var UVRect = GenerateNormalizeSprite(toFill,out m_size);
            toFill.FillMesh(shareMesh);
            shareMeshs[meshKey] = shareMesh;
            shareUVs[meshKey] = UVRect;
            shareSizes[meshKey] = m_size;
        }

        m_UVRect = shareUVs[meshKey];
        m_size = shareSizes[meshKey];
        Profiler.EndSample();

        return shareMesh;
    }

    protected override void DoRefresh()
    {
        Profiler.BeginSample("Slider DoRefresh");
        meshRenderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetVector("_SpriteCenterSize", new Vector4((m_UVRect.z + m_UVRect.x) * 0.5f,
            (m_UVRect.w + m_UVRect.y) * 0.5f,
            (m_UVRect.z - m_UVRect.x),
            (m_UVRect.w - m_UVRect.y)));
        materialPropertyBlock.SetFloat("_FillAmount", fillAmount);
        materialPropertyBlock.SetFloat("_FillAmount2", fillAmount2);
        materialPropertyBlock.SetFloat("_SpaceCount", spaceCount);
        materialPropertyBlock.SetFloat("_SpacePercent", spaceVal);
        float uvRadio = (m_UVRect.z - m_UVRect.x) / (m_UVRect.w - m_UVRect.y);
        float transRadio = transform.localScale.x / transform.localScale.y;
        materialPropertyBlock.SetFloat("_W2H",
            uvRadio / transRadio);
        materialPropertyBlock.SetFloat("_Angle",
            angle );
        materialPropertyBlock.SetInt("_FillOrigin",
            m_FillOrigin );
        materialPropertyBlock.SetColor("_Color",this.mColor);
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
        Profiler.EndSample();
    }


    Vector4 GenerateNormalizeSprite(CustomVertexHelper vh, out Vector4 t_size)
    {
        int spriteW = 100;
        int spriteH = 100;
        Vector4 v = new Vector4(-5, -7, 5, 7);
        t_size = v;

        Vector4 uv = new Vector4(0, 0, 1, 1);

        var color32 = Color.white;//不再使用定点颜色
        vh.Clear();
        vh.AddVert(new Vector3(v.x, v.y) * scaleFactor , color32, new Vector2(uv.x, uv.y));
        vh.AddVert(new Vector3(v.x, v.w) * scaleFactor , color32, new Vector2(uv.x, uv.w));
        vh.AddVert(new Vector3(v.z, v.w) * scaleFactor , color32, new Vector2(uv.z, uv.w));
        vh.AddVert(new Vector3(v.z, v.y) * scaleFactor , color32, new Vector2(uv.z, uv.y));

        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
        return uv;
    }

    /// <summary>
    /// Generate vertices for a simple Image.
    /// </summary>
    Vector4 GenerateSimpleSprite(CustomVertexHelper vh,out Vector4 t_size)
    {
        var size = activeSprite == null
            ? Vector2.zero
            : new Vector2(activeSprite.rect.width, activeSprite.rect.height);
        int spriteW = Mathf.RoundToInt(size.x);
        int spriteH = Mathf.RoundToInt(size.y);

        Vector4 v = GetDrawingDimensions();
        t_size = v;

        Rect r = activeSprite.rect;
        var offsetVertext = new Vector3(r.x + (spriteW >> 1), r.y + (spriteH >> 1), 0) * scaleFactor;

        var uv = (activeSprite != null) ? UnityEngine.Sprites.DataUtility.GetOuterUV(activeSprite) : Vector4.zero;

        var color32 = Color.white;//不再使用定点颜色
        vh.Clear();
        vh.AddVert(new Vector3(v.x, v.y) * scaleFactor - offsetVertext, color32, new Vector2(uv.x, uv.y));
        vh.AddVert(new Vector3(v.x, v.w) * scaleFactor - offsetVertext, color32, new Vector2(uv.x, uv.w));
        vh.AddVert(new Vector3(v.z, v.w) * scaleFactor - offsetVertext, color32, new Vector2(uv.z, uv.w));
        vh.AddVert(new Vector3(v.z, v.y) * scaleFactor - offsetVertext, color32, new Vector2(uv.z, uv.y));

        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
        return uv;
    }

    /// Image's dimensions used for drawing. X = left, Y = bottom, Z = right, W = top.
    private Vector4 GetDrawingDimensions()
    {
        var padding = activeSprite == null
            ? Vector4.zero
            : UnityEngine.Sprites.DataUtility.GetPadding(activeSprite);
        var size = activeSprite == null
            ? Vector2.zero
            : new Vector2(activeSprite.rect.width, activeSprite.rect.height);

        Rect r = activeSprite.rect;
        // Debug.Log(string.Format("r:{2}, size:{0}, padding:{1}", size, padding, r));

        int spriteW = Mathf.RoundToInt(size.x);
        int spriteH = Mathf.RoundToInt(size.y);

        var v = new Vector4(
            padding.x / spriteW,
            padding.y / spriteH,
            (spriteW - padding.z) / spriteW,
            (spriteH - padding.w) / spriteH);

        // if (shouldPreserveAspect && size.sqrMagnitude > 0.0f)
        // {
        //     PreserveSpriteAspectRatio(ref r, size);
        // }

        v = new Vector4(
            r.x + r.width * v.x,
            r.y + r.height * v.y,
            r.x + r.width * v.z,
            r.y + r.height * v.w
        );


        return v;
    }
}
