using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Game.View.Hero.Skill
{
    public class SkillProjectorCollideTarget:DisplayPoolObject
    {
        public UnityProjectorTrigger source;
        public ViewHero target=null;
        public float timer=0;
        public int hitCount=0;
        public float collideSpeed;
        /// <summary>
        /// 失效
        /// </summary>
        public bool isInValid = false;

        public override void OnDeathToPool()
        {
            
        }

        public override void OnActiveFromPool()
        {
            
        }


        
        public static RaycastHit2D zero;
        public Vector3 RayCast(out Vector3 normal)
        {
            //var z = source.transform.eulerAngles.z;
            //var forward = MathUtil2D.EulerTVector(z);
            var forward = (target.GetPosition() - source.transform.position).normalized;
            
            var hits = Physics2D.RaycastAll(source.transform.position, forward);
            RaycastHit2D hit = zero;
            foreach (var backHit in hits)
            {
                if (backHit.collider != source.collider2D)
                {
                    hit = backHit;
                    break;
                }
            }

            Vector3 hitPos = target.GetPosition();
            normal = -forward;
            if (hit.collider != null)
            {
                hitPos = hit.point;
                normal = hit.normal;
            }

            return hitPos;
        }

        public void Init( UnityProjectorTrigger source,ViewHero target, float collideSpeed)
        {
            this.source = source;
            this.target = target;
            this.collideSpeed = collideSpeed;
            this.isInValid = false;
        }
    }
}