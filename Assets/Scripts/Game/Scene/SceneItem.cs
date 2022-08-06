using System.Collections;
using System.Collections.Generic;
using Game.View;
using UnityEngine;


public abstract class SceneItem : MonoBehaviour
{
    public enum  SceneItemType
    {
        None,
        PlayerBornCollide,
        PlayerNextCollide,
        Hero,
        HeroCollection,
    }
    
    public abstract SceneItemType sceneItemType { get; }

}
