using UnityEngine;

[ExecuteAlways]
public abstract class UnityCollide2D:MonoBehaviour
{
    public Collider2D collider2D;
    public long guid = -1;

    private void Awake()
    {
        collider2D = this.GetComponent<Collider2D>();
        OnAwake();
    }

    protected abstract void OnAwake();

    public abstract UnityCollide2DType collideType {
        get;
    }
}

public enum UnityCollide2DType
{
    None,
    Projector,
    Hero,
    Wall,
    AirArea,
}


public enum UnityLayer
{
    Scene = 8,
    Hero = 12,
    Effect = 16,
    WallCollide = 20,
    AirAreaCollide = 21,
}