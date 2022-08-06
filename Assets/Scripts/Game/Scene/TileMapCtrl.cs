using System.Collections;
using System.Collections.Generic;
using Game.View.Hero;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapCtrl : MonoBehaviour
{
    public Tilemap back;
    public Tilemap front;
    
    public ViewHero ViewHero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var intVec3 = Vector3Int.CeilToInt(ViewHero.transform.localPosition);
        // var sprite = GetSprite(intVec3);
        // var tile = GetTile(intVec3);
        // var color = GetColor(intVec3);
        // Debug.LogWarning("sprite:"+sprite.name);
        // Debug.LogWarning("tile:"+tile.name);
        // Debug.LogWarning("color:"+color.ToString());
    }

    private Color GetColor(Vector3Int intVec3)
    {
        var sprite = front.GetColor(intVec3);
        if (sprite == null)
        {
            return back.GetColor(intVec3);
        }
        else
        {
            return sprite;
        }
    }

    private TileBase GetTile(Vector3Int intVec3)
    {
        var sprite = front.GetTile(intVec3);
        if (sprite == null)
        {
            return back.GetTile(intVec3);
        }
        else
        {
            return sprite;
        }
    }

    private Sprite GetSprite(Vector3Int intVec3)
    {
        var sprite = front.GetSprite(intVec3);
        if (sprite == null)
        {
            return back.GetSprite(intVec3);
        }
        else
        {
            return sprite;
        }

        UnityEngine.UI.ToggleGroup s;
        UnityEngine.UI.Toggle m;
        m.group = s;
    }
}
