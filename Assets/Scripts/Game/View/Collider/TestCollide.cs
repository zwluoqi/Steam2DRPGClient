using System;
using UnityEngine;

namespace Game.View.Collider
{
    public class TestCollide:MonoBehaviour
    {
        private void Awake()
        {
            //代表不与Area发生碰撞，只能够穿透该区域，而不能穿透墙壁
            var heroCollideMask = Physics2D.GetLayerCollisionMask((int)UnityLayer.Hero);
            Physics2D.SetLayerCollisionMask((int)UnityLayer.Hero,heroCollideMask&~(1 << (int)UnityLayer.AirAreaCollide));
        }
    }
}