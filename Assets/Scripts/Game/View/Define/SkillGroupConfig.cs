using UnityEngine;

namespace Game.View
{
    [CreateAssetMenu(fileName = "skill_group_config_", menuName = "ScriptableObjects/SkillGroupConfig", order = 1)]
    public class SkillGroupConfig : ScriptableObject
    {
        [Header("技能类型")] public SkillGroupType skillGroupType;
        [Header("可插入技能类型")] 
        public SkillGroupType insertSkillGroupType;
        [Header("技能队列")]
        public SkillConfig[] skillConfigs;
    }

    public enum SkillGroupType
    {
        Normal,
        Attack,
        Dazhao,
    }
}