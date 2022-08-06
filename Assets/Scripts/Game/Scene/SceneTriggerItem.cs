using Game.View;
using UnityEngine;

namespace Game.Scene
{
    public class SceneTriggerItem:MonoBehaviour
    {

        public LevelTriggerConfig levelTriggerConfig;
        // [Header("触发器或事件ID")]
        // public int triggerId = -1;
        //
        // [Header("触发类型")]
        // public SceneTriggerType sceneTriggerType;
        //
        // [Header("触发结果")]
        // public SceneTriggerResultType sceneTriggerResultType;
        //
        // [Header("触发结果延迟")]
        // public float triggerResultDelay = 0;
        //
        // [Header("触发结果重复次数")]
        // public int repeatedCounter = 1;
        //
        // [Header("范围触发数据")]
        // public RangeTriggerConfig rangeTriggerConfig;
        //
        // [Header("事件触发数据")]
        // public EventTriggerConfig eventTriggerConfig;
        //
        // [Header("触发器触发数据")]
        // public TriggerTriggerConfig triggerTriggerConfig;
        //
        // [Header("关卡怪死亡触发数据")]
        // public LevelHeroDeadTriggerConfig levelHeroDeadTrigger;
        //
        // [Header("关卡怪组死亡触发数据")]
        // public LevelGroupHeroDeadTriggerConfig levelGroupHeroDeadTriggerConfig;
        //
        // [Header("时间循环触发")]
        // public TimeLoopTriggerConfig timeLoopTriggerConfig;
        //
        // [Header("触发剧情数据")]
        // public TriggerResultStoryConfig triggerResultStoryConfig;
        //
        // [Header("触发出生数据")]
        // public TriggerResultBornConfig triggerResultBornConfig;
        //
        // [Header("触发屏蔽触发器数据")]
        // public TriggerResultForbideTriggerConfig triggerResultForbideTriggerConfig;
        //
        /// <summary>
        /// 触发对象
        /// </summary>
        public SceneItem[] triggerItems;
    }


}