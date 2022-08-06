using System;
using UnityEngine;

[ExecuteAlways]
public class UnityMoveCollide : UnityBaseCollide2D
{
    
    public Action<UnityCollide2D> OnTriggerEnter2DEvent;
    public Action<UnityCollide2D> OnTriggerExit2DEvent;

    public override UnityCollide2DType collideType
    {
        get
        {
            return UnityCollide2DType.None;
        }
    }
    
    protected override void OnAwake()
    {
      
    }
    
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.LogWarning("OnTriggerEnter2D:"+other.gameObject.name);
    //     var gamer = other.GetComponent<UnityCollide2D>();
    //     if ( gamer == null)
    //     {
    //         return;
    //     }
    //
    //     if (OnTriggerEnter2DEvent != null)
    //     {
    //         Debug.LogWarning("OnTriggerEnter2D:"+other.name);
    //         var tmp = OnTriggerEnter2DEvent;
    //         tmp(gamer);
    //     }
    // }
    //
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     Debug.LogWarning("OnTriggerExit2D:"+other.gameObject.name);
    //     var gamer = other.GetComponent<UnityCollide2D>();
    //     if ( gamer == null)
    //     {
    //         return;
    //     }
    //
    //     if (OnTriggerExit2DEvent != null)
    //     {
    //         Debug.LogWarning("OnTriggerExit2D:"+other.name);
    //         var tmp = OnTriggerExit2DEvent;
    //         tmp(gamer);
    //     }
    // }
    
}