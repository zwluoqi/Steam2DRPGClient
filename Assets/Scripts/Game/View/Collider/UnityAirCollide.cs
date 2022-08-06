using UnityEngine;

[ExecuteAlways]
public class UnityAirCollide:UnityBaseCollide2D
{
    public override UnityCollide2DType collideType
    {
        get
        {
            return UnityCollide2DType.AirArea;
        }
    }

    protected override void OnAwake()
    {
        this.gameObject.layer = (int)UnityLayer.AirAreaCollide;
    }
}