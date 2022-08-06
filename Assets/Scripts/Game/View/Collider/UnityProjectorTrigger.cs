using System;
using UnityEngine;

[ExecuteAlways]
public class UnityProjectorTrigger : UnityBaseTrigger2D
{
    public override UnityCollide2DType collideType
    {
        get
        {
            return UnityCollide2DType.Projector;
        }
    }
    
    public Action<UnityCollide2D> OnTriggerEnter2DEvent;
    public Action<UnityCollide2D> OnTriggerExit2DEvent;

    protected override void OnAwake()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var gamer = other.GetComponent<UnityCollide2D>();
        if ( gamer == null)
        {
            return;
        }
        if (OnTriggerEnter2DEvent != null)
        {
            Debug.LogWarning("OnTriggerEnter2D:"+other.name);
            var tmp = OnTriggerEnter2DEvent;
            tmp(gamer);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var gamer = other.GetComponent<UnityCollide2D>();
        if ( gamer == null)
        {
            return;
        }
        if (OnTriggerExit2DEvent != null)
        {
            Debug.LogWarning("OnTriggerExit2D:"+other.name);
            var tmp = OnTriggerExit2DEvent;
            tmp(gamer);
        }
    }
}