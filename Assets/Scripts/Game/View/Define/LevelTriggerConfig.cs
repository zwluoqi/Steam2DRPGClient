using System.Collections.Generic;
using UnityEngine;

namespace Game.View
{
    
    [CreateAssetMenu(fileName = "level_trigger_config_", menuName = "ScriptableObjects/LevelTrigger", order = 1)]

    public class LevelTriggerConfig:ScriptableObject
    {
        [Header("触发器或事件ID")]
        public int triggerId = -1;
        
        [Header("触发类型")]
        public SceneTriggerType sceneTriggerType;
        
        [Header("触发结果")]
        public SceneTriggerResultType sceneTriggerResultType;

        [Header("触发结果延迟")]
        public float triggerResultDelay = 0;
        
        [Header("触发结果重复次数")]
        public int repeatedCounter = 1;

        [Header("范围触发数据")]
        public RangeTriggerConfig rangeTriggerConfig;

        [Header("事件触发数据")]
        public EventTriggerConfig eventTriggerConfig;
        
        [Header("触发器触发数据")]
        public TriggerTriggerConfig triggerTriggerConfig;

        [Header("关卡怪死亡触发数据")]
        public LevelHeroDeadTriggerConfig levelHeroDeadTrigger;
        
        [Header("关卡怪组死亡触发数据")]
        public LevelGroupHeroDeadTriggerConfig levelGroupHeroDeadTriggerConfig;

        [Header("时间循环触发")]
        public TimeLoopTriggerConfig timeLoopTriggerConfig;
        
        [Header("触发剧情数据")]
        public TriggerResultStoryConfig triggerResultStoryConfig;

        [Header("触发出生数据")]
        public TriggerResultBornConfig triggerResultBornConfig;
        
        [Header("触发屏蔽触发器数据")]
        public TriggerResultForbideTriggerConfig triggerResultForbideTriggerConfig;
    }

    [System.Serializable]
    public class TimeLoopTriggerConfig
    {
        public float spaceTime = 5;
    }

    [System.Serializable]
    public class TriggerResultForbideTriggerConfig
    {
        public int trigger = -1;
    }


    [System.Serializable]
    public class LevelGroupHeroDeadTriggerConfig
    {
        public int levelGroupHeroId = -1;
    }

    [System.Serializable]
    public class LevelHeroDeadTriggerConfig
    {
        public int levelHeroId = -1;
    }


    [System.Serializable]
    public class TriggerResultBornConfig
    {
        
    }

    [System.Serializable]
    public class TriggerResultStoryConfig
    {
        [Header("故事ID")]
        public string storyId = "";
    }


    [System.Serializable]
    public class EventTriggerConfig
    {
        [Header("与事件列表")]
        public int[] andEventIdList;
        
        [Header("或事件列表")]
        public int[] orEventIdList;
    }
    
    [System.Serializable]
    public class TriggerTriggerConfig
    {
        [Header("与事件列表")]
        public int[] andTriggerIdList;
        
        [Header("或事件列表")]
        public int[] orTriggerIdList;
    }
    

    [System.Serializable]
    public class RangeTriggerConfig
    {
        [Header("触发范围")]
        public float range = 6;
    }


    public enum SceneTriggerResultType
    {
        HeroBorn,
        LevelStory,
        ForbideTrigger,
        HeroDead,
        HeroGroupDead,
    }

    public enum SceneTriggerType
    {
        LevelStartTriggerType,
        RangeTriggerType,
        EventTriggerType,
        TriggerTriggerType,
        LevelHeroDeadTriggerType,
        LevelGroupHeroDeadTriggerType,
        TimeLoopTriggerType,
    }
}