using Game.View.Hero;
using Game.View.Power;
using UnityEngine;

namespace Game.View.Manager
{
    public class PowerManager:ABViewBindNodeManager<PowerEntity>
    {
        protected override void IFPoolDeathToPool(ref PowerEntity p)
        {
            DisplayPoolUtil.displayPool.UnSpwan (ref p);
        }

        public PowerEntity CreateProjector(Vector3 normal,float duration,float speed,ViewHero target)
        {
            PowerEntity skillProjector = DisplayPoolUtil.displayPool.Spwan<PowerEntity>();
            skillProjector.Init(normal, duration,speed,target);
            skillProjector.StartProjector();
            projectors.Add(skillProjector);
            return skillProjector;
        }
    }
}