using System.Collections;
using System.Collections.Generic;
using Game.View;
using Game.View.Define;
using UnityEngine;

public class SceneHeroItem : SceneItem
{
    public HeroConfig heroConfig;
    public int levelGroupHeroId = -1;
    public int levelHeroId = -1;
    
    public override SceneItemType sceneItemType
    {
        get
        {
            return SceneItemType.Hero;
        }
    }

    public HeroCamp heroCamp = HeroCamp.Enemy;
}
