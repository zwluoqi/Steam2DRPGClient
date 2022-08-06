using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.View
{


    [CreateAssetMenu(fileName = "hero_config_", menuName = "ScriptableObjects/HeroConfig", order = 1)]
    public class HeroConfig : ScriptableObject
    {
        public string heroName;
        public string heroUri = "hero/47";
        public Color color = Color.white;
        [Header("技能")]
        public SkillGroupConfig[] skillGroupConfigs;
        [Header("属性")]
        public HeroAttributeConfig heroAttributeConfig;
        [Header("行为")]
        public HeroBehaviourConfig[] heroBehaviourConfigs;
    }

    [System.Serializable]
    public class HeroAttributeConfig
    {
        public int maxHP = 1000;
        [Header("角色有最大能量值，每个普通攻击和技能消耗不同能量，能量能通过时间和其他方式恢复。")]
        public int maxMp = 100;
        [Header("攻击，连击可以储存终结技能量。上限初始为1。")]
        public int maxAngle = 100;
        [Header("在耐力降低为0之前，不会导致受击动作")]
        public int maxNaili = 100;
        [Header("移动速度")]
        public int curSpeed = 5;
        
        [Header("属性数组")]
        public HeroAttribute[] attributes = new HeroAttribute[0];
    }

    [System.Serializable]
    public class HeroAttribute
    {
        public DictHeroExportPropEnum prop;
        public double val;
    }
}