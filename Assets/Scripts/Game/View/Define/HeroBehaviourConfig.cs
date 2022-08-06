using UnityEngine;

namespace Game.View
{
    [CreateAssetMenu(fileName = "hero_behaviour_config_", menuName = "ScriptableObjects/HeroBehaviourConfig", order = 1)]

    public class HeroBehaviourConfig:ScriptableObject
    {
        [Header("行为类型")]
        public HeroBehaviourType behaviorName;
        [Header("优先级")]
        public int priority;

        public AttackBehaviourConfig attackBehaviourConfig;
        public MoveBackConfig moveBackConfig;
    }

    [System.Serializable]
    public class MoveBackConfig
    {
        [Header("超过范围就要返回")]
        public float moveBackRange = 10;
    }

    [System.Serializable]
    public class AttackBehaviourConfig
    {
        [Header("追逐时间限制")]
        public float catchUpDuration = 5;
        [Header("在出生地范围内才能追逐攻击")]
        public float catchUpRange = 10;
    }

    public enum HeroBehaviourType
    {
        NormalAttack,
        StandAttack,
        Idle,
        MoveBackToInit,
    }
}