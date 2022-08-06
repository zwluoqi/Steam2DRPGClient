using UnityEngine;

namespace Game.Scene
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ScenePlayerNextItem:SceneItem
    {
        public override SceneItemType sceneItemType
        {
            get
            {
                return SceneItemType.PlayerNextCollide;
            }
        }
    }
}