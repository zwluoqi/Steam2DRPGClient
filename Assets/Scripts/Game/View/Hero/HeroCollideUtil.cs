using UnityEngine;

namespace Game.View.Hero
{
    public class HeroCollideUtil
    {
        private UnityMoveCollide _collider2D;
        private UnityHeroTrigger _rigiBody;

        private ViewHero hero;
        public void Init(ViewHero viewHero)
        {
            hero = viewHero;
            _rigiBody = viewHero.gameObject.GetComponentInChildren<UnityHeroTrigger>();
            _rigiBody.guid = viewHero.guid;
            
            _collider2D = viewHero.gameObject.GetComponentInChildren<UnityMoveCollide>();
            _collider2D.OnTriggerEnter2DEvent = OnTriggerEnter2DEvent;
            _collider2D.OnTriggerExit2DEvent = OnTriggerExit2DEvent;
        }

        private void OnTriggerExit2DEvent(UnityCollide2D obj)
        {
            curInRange = UnityCollide2DType.None;
        }

        private UnityCollide2DType curInRange;

        private void OnTriggerEnter2DEvent(UnityCollide2D unityCollide2D)
        {
            curInRange = unityCollide2D.collideType;
        }

        public bool CheckCurInRange(UnityCollide2DType checkedCollide)
        {
            return checkedCollide == curInRange;
        }

        /// <summary>
        /// 移动碰撞器转为触发器，可以穿墙等
        /// </summary>
        /// <param name="trigger"></param>
        public void SetMoveTrigger(bool trigger)
        {
            Debug.LogWarning("穿透性:" + trigger);
            if (trigger)
            {
                //代表不与Area发生碰撞，只能够穿透该区域，而不能穿透墙壁
                // var heroCollideMask = Physics2D.GetLayerCollisionMask( (int)UnityLayer.Hero);
                // Physics2D.SetLayerCollisionMask((int)UnityLayer.Hero,heroCollideMask&~(1 << (int)UnityLayer.AirAreaCollide));
                foreach (var airCollider2D in hero.viewManager.airCollider2Ds)
                {
                    airCollider2D.isTrigger = true;
                    airCollider2D.GetComponent<CompositeCollider2D>().isTrigger = true;
                }
            }
            else
            {
                // var heroCollideMask = Physics2D.GetLayerCollisionMask( (int)UnityLayer.Hero);
                // Physics2D.SetLayerCollisionMask((int)UnityLayer.Hero,heroCollideMask|(1 << (int)UnityLayer.AirAreaCollide));
                foreach (var airCollider2D in hero.viewManager.airCollider2Ds)
                {
                    airCollider2D.GetComponent<CompositeCollider2D>().isTrigger = false;
                    airCollider2D.isTrigger = false;
                }
            }
        }
    }
}