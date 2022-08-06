using UnityEngine;

namespace Game.Scene
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ScenePlayerBornItem:SceneItem
    {
        public override SceneItemType sceneItemType
        {
            get
            {
                return SceneItemType.PlayerBornCollide;
            }
        }
    }
}