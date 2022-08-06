using Game.View.Effect;
using Game.View.Hero.Skill;
using UnityEngine;

namespace Game.View.Manager
{
    public class EffectUtil:ViewBindRoot
    {
        public EffectEntity CreateEffect(EffectManager effectManager,Transform parent,string collideUri, float collideDuration)
        {
            var effect = effectManager.CreateProjector(parent,collideUri, collideDuration);
            AddNode(effect);
            return effect;
        }
    }
}