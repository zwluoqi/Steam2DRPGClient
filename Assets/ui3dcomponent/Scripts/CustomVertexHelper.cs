
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomVertexHelper:IDisposable
{
    private List<Vector3> m_Positions;
    private List<Color32> m_Colors;
    private List<Vector2> m_Uv0S;
    private List<int> m_Indices;

    private bool m_ListsInitalized = false;

    
    
    
    /// <summary>
    /// Current number of vertices in the buffer.
    /// </summary>
    public int currentVertCount
    {
        get { return m_Positions != null ? m_Positions.Count : 0; }
    }
    
    private void InitializeListIfRequired()
    {
        if (!m_ListsInitalized)
        {
            m_Positions = new List<Vector3>();
            m_Colors = new List<Color32>();
            m_Uv0S = new List<Vector2>();
            m_Indices = new List<int>();
            m_ListsInitalized = true;
        }
    }
    
    /// <summary>
    /// Cleanup allocated memory.
    /// </summary>
    public void Dispose()
    {
        if (m_ListsInitalized)
        {
            m_Positions.Clear();
            m_Colors.Clear();
            m_Uv0S.Clear();
            m_Indices.Clear();
            // ListPool<Vector3>.Release(m_Positions);
            // ListPool<Color32>.Release(m_Colors);
            // ListPool<Vector2>.Release(m_Uv0S);
            // ListPool<int>.Release(m_Indices);

            m_Positions = null;
            m_Colors = null;
            m_Uv0S = null;
            m_Indices = null;

            m_ListsInitalized = false;
        }
    }
    
    /// <summary>
    /// Add a single vertex to the stream.
    /// </summary>
    /// <param name="position">Position of the vert</param>
    /// <param name="color">Color of the vert</param>
    /// <param name="uv0">UV of the vert</param>
    public void AddVert(Vector3 position, Color32 color, Vector2 uv0)
    {
        // AddVert(position, color, uv0, Vector2.zero, s_DefaultNormal, s_DefaultTangent);
        
        InitializeListIfRequired();

        m_Positions.Add(position);
        m_Colors.Add(color);
        m_Uv0S.Add(uv0);
    }
    
    /// <summary>
    /// Add a triangle to the buffer.
    /// </summary>
    /// <param name="idx0">index 0</param>
    /// <param name="idx1">index 1</param>
    /// <param name="idx2">index 2</param>
    public void AddTriangle(int idx0, int idx1, int idx2)
    {
        InitializeListIfRequired();

        m_Indices.Add(idx0);
        m_Indices.Add(idx1);
        m_Indices.Add(idx2);
    }
    
    
    /// <summary>
    /// Clear all vertices from the stream.
    /// </summary>
    public void Clear()
    {
        // Only clear if we have our lists created.
        if (m_ListsInitalized)
        {
            m_Positions.Clear();
            m_Colors.Clear();
            m_Uv0S.Clear();
            m_Indices.Clear();
        }
    }
    
    
    /// <summary>
    /// Fill the given mesh with the stream data.
    /// </summary>
    public void FillMesh(Mesh mesh)
    {
        InitializeListIfRequired();

        mesh.Clear();

        if (m_Positions.Count >= 65000)
            throw new ArgumentException("Mesh can not have more than 65000 vertices");

        mesh.SetVertices(m_Positions);
        mesh.SetColors(m_Colors);
        mesh.SetUVs(0, m_Uv0S);
        mesh.SetTriangles(m_Indices, 0);
        mesh.RecalculateBounds();
    }
}