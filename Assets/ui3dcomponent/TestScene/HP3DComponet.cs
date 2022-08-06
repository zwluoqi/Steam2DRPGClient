using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HP3DComponet : MonoBehaviour
{

    static MaterialPropertyBlock materialPropertyBlock;
    public Renderer renderer;
    
    public float _fillCount;
    public Color _color;

    private static int ColorId = Shader.PropertyToID("_Color");
    private static int FillCountId = Shader.PropertyToID("_fillCount");
    
    // Start is called before the first frame update
    void Start()
    {
        if (materialPropertyBlock == null)
        {
            materialPropertyBlock = new MaterialPropertyBlock();    
        }
        
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer == null || materialPropertyBlock == null)
        {
            Start();
        }
        //Material Property Blocks will still break batches - You're changing the data being sent to the GPU after all.

        //The benefit of using property blocks is to organize the data in a way that does not require creating new material instances for small changes.
            
        renderer.GetPropertyBlock (materialPropertyBlock);
        materialPropertyBlock.SetColor(ColorId, _color);
        materialPropertyBlock.SetFloat(FillCountId, _fillCount);
        renderer.SetPropertyBlock (materialPropertyBlock);
    }
}
