using System;
using System.Collections;
using System.Collections.Generic;
using CustomUI;
using UnityEngine;

[ExecuteInEditMode]
public class CustomMeshRenderAnchor : MonoBehaviour
{

    public CustomMeshSlider customMeshRender;

    public void Update()
    {
        var length = customMeshRender.defaultLength * customMeshRender.transform.localScale.x;
        var start = -length* 0.5f;
        var end = -start;
        var v = customMeshRender.fillAmount * end + (1 - customMeshRender.fillAmount) * start;
        this.transform.localPosition = new Vector3(v+customMeshRender.transform.localPosition.x, customMeshRender.transform.localPosition.y, 0);
    }
}
