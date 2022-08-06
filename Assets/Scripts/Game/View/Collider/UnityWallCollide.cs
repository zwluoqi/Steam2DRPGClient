using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class UnityWallCollide : UnityBaseCollide2D
{
    public override UnityCollide2DType collideType
    {
        get
        {
            return UnityCollide2DType.Wall;
        }
    }
    
    protected override void OnAwake()
    {
        this.gameObject.layer = (int)UnityLayer.WallCollide;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var gamer = other.gameObject.GetComponent<UnityProjectorTrigger>();
        if ( gamer == null)
        {
            return;
        }
    }
}
