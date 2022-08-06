using System.Collections;
using System.Collections.Generic;
using CustomUI;

using UnityEngine;

public class RandomeFillVal : MonoBehaviour
{

    public CustomMeshBase customMeshRender;
    // Start is called before the first frame update
    void Start()
    {
        customMeshRender = GetComponent<CustomMeshBase>();
    }

    // Update is called once per frame
    void Update()
    {
        customMeshRender.fillAmount = UnityEngine.Random.Range(0.0f, 1.0f);
        customMeshRender.fillAmount2 = UnityEngine.Random.Range(0.0f, customMeshRender.fillAmount);
    }
}
