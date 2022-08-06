using System;
using UnityEngine;

[ExecuteInEditMode]
public class ForwardMainCamera:MonoBehaviour
{

    private void Update()
    {
        var dir = Camera.main.transform.position - this.transform.position;
        dir.y = 0;
        if (dir.x + dir.y == 0)
        {

        }
        else
        {
            this.transform.forward = dir.normalized;
        }
    }
}
