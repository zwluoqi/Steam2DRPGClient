using Game.View.Effect;
using Game.View.Hero.Skill;
using UnityEngine;

namespace Game.View.Manager
{
    public class EffectManager:ABViewBindNodeManager<EffectEntity>
    {
        protected override void IFPoolDeathToPool(ref EffectEntity p)
        {
            DisplayPoolUtil.displayPool.UnSpwan (ref p);
        }
        
        public EffectEntity CreateProjector(EffectConfig effectConfig)
        {
            EffectEntity effectEntity = DisplayPoolUtil.displayPool.Spwan<EffectEntity>();
            effectEntity.Init(effectConfig);
            projectors.Add(effectEntity);
            return effectEntity;
        }
        
        public EffectEntity CreateProjector(Transform parent,string uri,float duration)
        {
            EffectEntity effectEntity = DisplayPoolUtil.displayPool.Spwan<EffectEntity>();
            effectEntity.Init(parent,uri,duration);
            projectors.Add(effectEntity);
            return effectEntity;
        }
    }
}