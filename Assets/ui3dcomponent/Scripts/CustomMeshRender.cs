using System;
using UnityEngine;
using System.Collections.Generic;
// using System.Linq;
using System.Text;
using Game;
using UnityEngine.Profiling;
namespace CustomUI
{


    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class CustomMeshRender : CustomMeshBase
    {


        protected static Dictionary<long, Material> cacheMaterials = new Dictionary<long, Material>();
        protected static Dictionary<long, int> cacheMaterialRef = new Dictionary<long, int>();


        private long oldKey;

        protected override void SetShareMesh()
        {
            if (meshFilter.sharedMesh != null)
            {
                meshFilter.sharedMesh = GenerateMesh(meshFilter.sharedMesh);
            }
            else
            {
                meshFilter.sharedMesh = GenerateMesh(null);
            }
        }

        protected override  void SetSharedMaterial()
        {
            // if (customShareMaterial == null)
            {
                var texId = this.mTexture2D.GetInstanceID();
                var matId = this.userMaterial.GetInstanceID();
                var lTexId = (long) texId;
                var lMatId = (long)(matId);
                var materialKey = (lTexId << 32) + (lMatId);
                Material material = null;
                if (cacheMaterials.TryGetValue(materialKey, out material) && material != null)
                {
                    meshRenderer.sharedMaterials = new Material[1];
                    meshRenderer.sharedMaterial = cacheMaterials[materialKey];
                    meshRenderer.sharedMaterials[0] = meshRenderer.sharedMaterial;
                }
                else
                {
                    material = Material.Instantiate(userMaterial);
                    material.SetTexture("_MainTex", this.mTexture2D);
                    cacheMaterials[materialKey] = material;
                    meshRenderer.sharedMaterials = new Material[1];
                    meshRenderer.sharedMaterial = material;
                    meshRenderer.sharedMaterials[0] = meshRenderer.sharedMaterial;
                }
            }
            // else
            // {
            //     customShareMaterial.SetTexture("_MainTex", this.mTexture2D);
            //     meshRenderer.sharedMaterial = customShareMaterial;
            // }
        }

        protected override Mesh GenerateMesh(Mesh source)
        {
            return GenerateNormalSpriteMesh(source);
        }

        private static float scaleFactor;
        static readonly Vector3[] s_Xy = new Vector3[4];
        static readonly Vector3[] s_Uv = new Vector3[4];
        static readonly float[] s_XSave = new float[4];

        public Mesh GenerateNormalSpriteMesh(Mesh source)
        {
            Profiler.BeginSample("Render GenerateMesh");
            Mesh mesh = source;

            if (mesh == null)
            {
                mesh = new Mesh();
            }

            scaleFactor = mScale * 0.01f;
            toFill.Clear();

            if (mType == Type.Simple)
            {
                GenerateSimpleSprite(toFill);
            }
            else if (mType == Type.Filled)
            {
                GenerateFilledSprite(toFill);

            }
            else
            {
                Debug.LogError("还未支持:使用" + mType);
                GenerateSimpleSprite(toFill);
            }

            toFill.FillMesh(mesh);
            Profiler.EndSample();

            return mesh;
        }

        private void GenerateSprite(CustomVertexHelper vh)
        {
            var spriteSize = new Vector2(activeSprite.rect.width, activeSprite.rect.height);

            // Covert sprite pivot into normalized space.
            var spritePivot = activeSprite.pivot / spriteSize;

            var rectPivot = new Vector2(0.5f, 0.5f);
            Rect r = activeSprite.rect;

            var drawingSize = new Vector2(r.width, r.height) * 0.01f;
            var spriteBoundSize = activeSprite.bounds.size;

            // Calculate the drawing offset based on the difference between the two pivots.
            var drawOffset = (rectPivot - spritePivot) * drawingSize;

            var color32 = color;
            vh.Clear();

            Vector2[] vertices = activeSprite.vertices;
            Vector2[] uvs = activeSprite.uv;
            for (int i = 0; i < vertices.Length; ++i)
            {
                vh.AddVert(
                    new Vector3((vertices[i].x / spriteBoundSize.x) * drawingSize.x - drawOffset.x,
                        (vertices[i].y / spriteBoundSize.y) * drawingSize.y - drawOffset.y), color32,
                    new Vector2(uvs[i].x, uvs[i].y));
            }

            UInt16[] triangles = activeSprite.triangles;
            for (int i = 0; i < triangles.Length; i += 3)
            {
                vh.AddTriangle(triangles[i + 0], triangles[i + 1], triangles[i + 2]);
            }
        }




        /// <summary>
        /// Generate vertices for a simple Image.
        /// </summary>
        Vector4 GenerateSimpleSprite(CustomVertexHelper vh)
        {
            var size = activeSprite == null
                ? Vector2.zero
                : new Vector2(activeSprite.rect.width, activeSprite.rect.height);
            int spriteW = Mathf.RoundToInt(size.x);
            int spriteH = Mathf.RoundToInt(size.y);

            Vector4 v = GetDrawingDimensions();

            Rect r = activeSprite.rect;
            var offsetVertext = new Vector3(r.x + (spriteW >> 1), r.y + (spriteH >> 1), 0) * scaleFactor;

            var uv = (activeSprite != null) ? UnityEngine.Sprites.DataUtility.GetOuterUV(activeSprite) : Vector4.zero;

            var color32 = color;
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



        /// <summary>
        /// Generate vertices for a filled Image.
        /// </summary>
        void GenerateFilledSprite(CustomVertexHelper toFill)
        {
            toFill.Clear();

            if (mFillAmount < 0.001f)
                return;

            Vector4 v = GetDrawingDimensions();
            Vector4 outer = activeSprite != null
                ? UnityEngine.Sprites.DataUtility.GetOuterUV(activeSprite)
                : Vector4.zero;
            // UIVertex uiv = UIVertex.simpleVert;
            // uiv.color = color;

            var size = activeSprite == null
                ? Vector2.zero
                : new Vector2(activeSprite.rect.width, activeSprite.rect.height);
            int spriteW = Mathf.RoundToInt(size.x);
            int spriteH = Mathf.RoundToInt(size.y);
            Rect r = activeSprite.rect;
            var offsetVertext = new Vector3(r.x + (spriteW >> 1), r.y + (spriteH >> 1), 0) * scaleFactor;

            float tx0 = outer.x;
            float ty0 = outer.y;
            float tx1 = outer.z;
            float ty1 = outer.w;

            // Horizontal and vertical filled sprites are simple -- just end the Image prematurely
            if ((mFillMethod == FillMethod.Horizontal || mFillMethod == FillMethod.Vertical) && mSpaceCount == 0)
            {
                if (fillMethod == FillMethod.Horizontal)
                {
                    float fill = (tx1 - tx0) * mFillAmount;

                    if (m_FillOrigin == 1)
                    {
                        v.x = v.z - (v.z - v.x) * mFillAmount;
                        tx0 = tx1 - fill;
                    }
                    else
                    {
                        v.z = v.x + (v.z - v.x) * mFillAmount;
                        tx1 = tx0 + fill;
                    }
                }
                else if (fillMethod == FillMethod.Vertical)
                {
                    float fill = (ty1 - ty0) * mFillAmount;

                    if (m_FillOrigin == 1)
                    {
                        v.y = v.w - (v.w - v.y) * mFillAmount;
                        ty0 = ty1 - fill;
                    }
                    else
                    {
                        v.w = v.y + (v.w - v.y) * mFillAmount;
                        ty1 = ty0 + fill;
                    }
                }
            }

            s_Xy[0] = new Vector2(v.x, v.y);
            s_Xy[1] = new Vector2(v.x, v.w);
            s_Xy[2] = new Vector2(v.z, v.w);
            s_Xy[3] = new Vector2(v.z, v.y);

            s_Uv[0] = new Vector2(tx0, ty0);
            s_Uv[1] = new Vector2(tx0, ty1);
            s_Uv[2] = new Vector2(tx1, ty1);
            s_Uv[3] = new Vector2(tx1, ty0);

            {
                if (mFillAmount < 1f && mFillMethod != FillMethod.Horizontal && mFillMethod != FillMethod.Vertical)
                {
                    if (fillMethod == FillMethod.Radial90)
                    {
                        if (RadialCut(s_Xy, s_Uv, mFillAmount, m_FillClockwise, m_FillOrigin))
                            AddQuad(toFill, s_Xy, color, s_Uv, offsetVertext);
                    }
                    else if (fillMethod == FillMethod.Radial180)
                    {
                        for (int side = 0; side < 2; ++side)
                        {
                            float fx0, fx1, fy0, fy1;
                            int even = m_FillOrigin > 1 ? 1 : 0;

                            if (m_FillOrigin == 0 || m_FillOrigin == 2)
                            {
                                fy0 = 0f;
                                fy1 = 1f;
                                if (side == even)
                                {
                                    fx0 = 0f;
                                    fx1 = 0.5f;
                                }
                                else
                                {
                                    fx0 = 0.5f;
                                    fx1 = 1f;
                                }
                            }
                            else
                            {
                                fx0 = 0f;
                                fx1 = 1f;
                                if (side == even)
                                {
                                    fy0 = 0.5f;
                                    fy1 = 1f;
                                }
                                else
                                {
                                    fy0 = 0f;
                                    fy1 = 0.5f;
                                }
                            }

                            s_Xy[0].x = Mathf.Lerp(v.x, v.z, fx0);
                            s_Xy[1].x = s_Xy[0].x;
                            s_Xy[2].x = Mathf.Lerp(v.x, v.z, fx1);
                            s_Xy[3].x = s_Xy[2].x;

                            s_Xy[0].y = Mathf.Lerp(v.y, v.w, fy0);
                            s_Xy[1].y = Mathf.Lerp(v.y, v.w, fy1);
                            s_Xy[2].y = s_Xy[1].y;
                            s_Xy[3].y = s_Xy[0].y;

                            s_Uv[0].x = Mathf.Lerp(tx0, tx1, fx0);
                            s_Uv[1].x = s_Uv[0].x;
                            s_Uv[2].x = Mathf.Lerp(tx0, tx1, fx1);
                            s_Uv[3].x = s_Uv[2].x;

                            s_Uv[0].y = Mathf.Lerp(ty0, ty1, fy0);
                            s_Uv[1].y = Mathf.Lerp(ty0, ty1, fy1);
                            s_Uv[2].y = s_Uv[1].y;
                            s_Uv[3].y = s_Uv[0].y;

                            float val = m_FillClockwise ? fillAmount * 2f - side : mFillAmount * 2f - (1 - side);

                            if (RadialCut(s_Xy, s_Uv, Mathf.Clamp01(val), m_FillClockwise,
                                ((side + m_FillOrigin + 3) % 4)))
                            {
                                AddQuad(toFill, s_Xy, color, s_Uv, offsetVertext);
                            }
                        }
                    }
                    else if (fillMethod == FillMethod.Radial360)
                    {
                        for (int corner = 0; corner < 4; ++corner)
                        {
                            float fx0, fx1, fy0, fy1;

                            if (corner < 2)
                            {
                                fx0 = 0f;
                                fx1 = 0.5f;
                            }
                            else
                            {
                                fx0 = 0.5f;
                                fx1 = 1f;
                            }

                            if (corner == 0 || corner == 3)
                            {
                                fy0 = 0f;
                                fy1 = 0.5f;
                            }
                            else
                            {
                                fy0 = 0.5f;
                                fy1 = 1f;
                            }

                            s_Xy[0].x = Mathf.Lerp(v.x, v.z, fx0);
                            s_Xy[1].x = s_Xy[0].x;
                            s_Xy[2].x = Mathf.Lerp(v.x, v.z, fx1);
                            s_Xy[3].x = s_Xy[2].x;

                            s_Xy[0].y = Mathf.Lerp(v.y, v.w, fy0);
                            s_Xy[1].y = Mathf.Lerp(v.y, v.w, fy1);
                            s_Xy[2].y = s_Xy[1].y;
                            s_Xy[3].y = s_Xy[0].y;

                            s_Uv[0].x = Mathf.Lerp(tx0, tx1, fx0);
                            s_Uv[1].x = s_Uv[0].x;
                            s_Uv[2].x = Mathf.Lerp(tx0, tx1, fx1);
                            s_Uv[3].x = s_Uv[2].x;

                            s_Uv[0].y = Mathf.Lerp(ty0, ty1, fy0);
                            s_Uv[1].y = Mathf.Lerp(ty0, ty1, fy1);
                            s_Uv[2].y = s_Uv[1].y;
                            s_Uv[3].y = s_Uv[0].y;

                            float val = m_FillClockwise
                                ? mFillAmount * 4f - ((corner + m_FillOrigin) % 4)
                                : mFillAmount * 4f - (3 - ((corner + m_FillOrigin) % 4));

                            if (RadialCut(s_Xy, s_Uv, Mathf.Clamp01(val), m_FillClockwise, ((corner + 2) % 4)))
                                AddQuad(toFill, s_Xy, color, s_Uv, offsetVertext);
                        }
                    }
                }
                else
                {
                    if ((mFillMethod == FillMethod.Horizontal || mFillMethod == FillMethod.Vertical) && mSpaceCount > 0)
                    {
                        if (mFillMethod == FillMethod.Horizontal)
                        {
                            s_Xy[0] = new Vector2(0, 0);
                            s_Xy[1] = new Vector2(0, spriteH);
                            s_Xy[2] = new Vector2(spriteW, spriteH);
                            s_Xy[3] = new Vector2(spriteW, 0);


                            s_Uv[0] = new Vector2(tx0, ty0);
                            s_Uv[1] = new Vector2(tx0, ty1);
                            s_Uv[2] = new Vector2(tx1, ty1);
                            s_Uv[3] = new Vector2(tx1, ty0);

                            var totalLength = (spriteW * (mSpaceCount + 1) + mSpaceVal * mSpaceCount);

                            if (mPivot == Pivot.Left)
                            {
                                offsetVertext.x = -totalLength * 0.5f * scaleFactor;
                                offsetVertext.y = (spriteH >> 1) * scaleFactor;
                            }
                            else
                            {
                                offsetVertext.x = 0;
                                offsetVertext.y = (spriteH >> 1) * scaleFactor;
                            }

                            var startOffset = new Vector3(-totalLength * 0.5f, 0);
                            var cellf = (mSpaceCount + 1) * mFillAmount;
                            var cell = Mathf.FloorToInt(cellf);
                            var fillPosEndX = startOffset.x + cellf * spriteW + cell * mSpaceVal;

                            var cellStartf = (mSpaceCount + 1) * mFillAmount2;
                            var cellStart = Mathf.FloorToInt(cellStartf);
                            if (m_FillOrigin != 2)
                            {
                                cellStartf = 0;
                                cellStart = 0;
                            }

                            var fillPosStartX = startOffset.x + cellStartf * spriteW + cellStart * mSpaceVal;
                            int limitedCount = 0;

                            for (int i = 0; i < 4; i++)
                            {
                                s_Xy[i] += startOffset;

                                s_XSave[i] = s_Xy[i].x;
                                if (s_Xy[i].x < fillPosStartX)
                                {
                                    s_Uv[i].x = (fillPosStartX - s_Xy[i].x) / spriteW * (tx1 - tx0) + tx0;
                                    s_Xy[i].x = fillPosStartX;
                                }

                                if (s_Xy[i].x > fillPosEndX)
                                {
                                    s_Uv[i].x = (1 - (s_Xy[i].x - fillPosEndX) / spriteW) * (tx1 - tx0) + tx0;
                                    s_Xy[i].x = fillPosEndX;
                                    limitedCount++;
                                }
                            }

                            FillOrginReserve(tx1);
                            AddQuad(toFill, s_Xy, color, s_Uv, offsetVertext);
                            FillOrginReserve(tx1);



                            if (limitedCount == 0)
                            {
                                s_Uv[0].x = tx0;
                                s_Uv[1].x = tx0;
                                s_Uv[2].x = tx1;
                                s_Uv[3].x = tx1;
                                s_Xy[0].x = s_XSave[0];
                                s_Xy[1].x = s_XSave[1];
                                s_Xy[2].x = s_XSave[2];
                                s_Xy[3].x = s_XSave[3];

                                var spaceOffset = new Vector3(spriteW + mSpaceVal, 0);
                                for (int couter = 0; couter < mSpaceCount; couter++)
                                {
                                    limitedCount = 0;
                                    for (int i = 0; i < 4; i++)
                                    {
                                        s_Xy[i] += spaceOffset;
                                        s_XSave[i] = s_Xy[i].x;

                                        if (s_Xy[i].x < fillPosStartX)
                                        {
                                            s_Uv[i].x = (fillPosStartX - s_Xy[i].x) / spriteW * (tx1 - tx0) + tx0;
                                            s_Xy[i].x = fillPosStartX;
                                        }

                                        if (s_Xy[i].x > fillPosEndX)
                                        {
                                            s_Uv[i].x = (1 - (s_Xy[i].x - fillPosEndX) / spriteW) * (tx1 - tx0) + tx0;
                                            s_Xy[i].x = fillPosEndX;
                                            limitedCount++;
                                        }
                                    }


                                    FillOrginReserve(tx1);
                                    AddQuad(toFill, s_Xy, color, s_Uv, offsetVertext);
                                    FillOrginReserve(tx1);


                                    if (limitedCount >= 2)
                                    {
                                        break;
                                    }

                                    s_Uv[0].x = tx0;
                                    s_Uv[1].x = tx0;
                                    s_Uv[2].x = tx1;
                                    s_Uv[3].x = tx1;

                                    s_Xy[0].x = s_XSave[0];
                                    s_Xy[1].x = s_XSave[1];
                                    s_Xy[2].x = s_XSave[2];
                                    s_Xy[3].x = s_XSave[3];
                                }
                            }
                        }
                        else if (fillMethod == FillMethod.Vertical)
                        {
                            //TODO
                            AddQuad(toFill, s_Xy, color, s_Uv, offsetVertext);
                        }
                    }
                    else
                    {
                        AddQuad(toFill, s_Xy, color, s_Uv, offsetVertext);
                    }
                }
            }
        }


        void FillOrginReserve(float tx1)
        {
            if (m_FillOrigin == 1)
            {
                s_Xy[0].x = -s_Xy[0].x;
                s_Xy[1].x = -s_Xy[1].x;
                s_Xy[2].x = -s_Xy[2].x;
                s_Xy[3].x = -s_Xy[3].x;

                s_Uv[0].x = tx1 - s_Uv[0].x;
                s_Uv[1].x = tx1 - s_Uv[1].x;
                s_Uv[2].x = tx1 - s_Uv[2].x;
                s_Uv[3].x = tx1 - s_Uv[3].x;
            }
        }

        /// <summary>
        /// Adjust the specified quad, making it be radially filled instead.
        /// </summary>

        static bool RadialCut(Vector3[] xy, Vector3[] uv, float fill, bool invert, int corner)
        {
            // Nothing to fill
            if (fill < 0.001f) return false;

            // Even corners invert the fill direction
            if ((corner & 1) == 1) invert = !invert;

            // Nothing to adjust
            if (!invert && fill > 0.999f) return true;

            // Convert 0-1 value into 0 to 90 degrees angle in radians
            float angle = Mathf.Clamp01(fill);
            if (invert) angle = 1f - angle;
            angle *= 90f * Mathf.Deg2Rad;

            // Calculate the effective X and Y factors
            float cos = Mathf.Cos(angle);
            float sin = Mathf.Sin(angle);

            RadialCut(xy, cos, sin, invert, corner);
            RadialCut(uv, cos, sin, invert, corner);
            return true;
        }

        /// <summary>
        /// Adjust the specified quad, making it be radially filled instead.
        /// </summary>

        static void RadialCut(Vector3[] xy, float cos, float sin, bool invert, int corner)
        {
            int i0 = corner;
            int i1 = ((corner + 1) % 4);
            int i2 = ((corner + 2) % 4);
            int i3 = ((corner + 3) % 4);

            if ((corner & 1) == 1)
            {
                if (sin > cos)
                {
                    cos /= sin;
                    sin = 1f;

                    if (invert)
                    {
                        xy[i1].x = Mathf.Lerp(xy[i0].x, xy[i2].x, cos);
                        xy[i2].x = xy[i1].x;
                    }
                }
                else if (cos > sin)
                {
                    sin /= cos;
                    cos = 1f;

                    if (!invert)
                    {
                        xy[i2].y = Mathf.Lerp(xy[i0].y, xy[i2].y, sin);
                        xy[i3].y = xy[i2].y;
                    }
                }
                else
                {
                    cos = 1f;
                    sin = 1f;
                }

                if (!invert) xy[i3].x = Mathf.Lerp(xy[i0].x, xy[i2].x, cos);
                else xy[i1].y = Mathf.Lerp(xy[i0].y, xy[i2].y, sin);
            }
            else
            {
                if (cos > sin)
                {
                    sin /= cos;
                    cos = 1f;

                    if (!invert)
                    {
                        xy[i1].y = Mathf.Lerp(xy[i0].y, xy[i2].y, sin);
                        xy[i2].y = xy[i1].y;
                    }
                }
                else if (sin > cos)
                {
                    cos /= sin;
                    sin = 1f;

                    if (invert)
                    {
                        xy[i2].x = Mathf.Lerp(xy[i0].x, xy[i2].x, cos);
                        xy[i3].x = xy[i2].x;
                    }
                }
                else
                {
                    cos = 1f;
                    sin = 1f;
                }

                if (invert) xy[i3].y = Mathf.Lerp(xy[i0].y, xy[i2].y, sin);
                else xy[i1].x = Mathf.Lerp(xy[i0].x, xy[i2].x, cos);
            }
        }

        static void AddQuad(CustomVertexHelper vertexHelper, Vector3[] quadPositions, Color32 color, Vector3[] quadUVs,
            Vector3 offsetVertext)
        {
            int startIndex = vertexHelper.currentVertCount;

            for (int i = 0; i < 4; ++i)
                vertexHelper.AddVert(quadPositions[i] * scaleFactor - offsetVertext, color, quadUVs[i]);

            vertexHelper.AddTriangle(startIndex, startIndex + 1, startIndex + 2);
            vertexHelper.AddTriangle(startIndex + 2, startIndex + 3, startIndex);
        }


    }
}
