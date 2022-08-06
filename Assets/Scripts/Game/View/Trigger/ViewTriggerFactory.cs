namespace Game.View.Trigger
{
    public class ViewTriggerFactory
    {
        public static ViewTrigger GetTrigger(SceneTriggerType sceneTriggerType)
        {
            switch (sceneTriggerType)
            {
                case SceneTriggerType.RangeTriggerType:
                    return new ViewRangeTrigger();
                case SceneTriggerType.EventTriggerType:
                    return new ViewEventTrigger();
                case SceneTriggerType.LevelStartTriggerType:
                    return new ViewLevelStartTrigger();
                case SceneTriggerType.LevelHeroDeadTriggerType:
                    return new ViewLevelHeroDeadTrigger();
                case SceneTriggerType.LevelGroupHeroDeadTriggerType:
                    return new ViewLevelGroupHeroDeadTrigger();
                case SceneTriggerType.TriggerTriggerType:
                    return new ViewTriggerTriggerTrigger();
                case SceneTriggerType.TimeLoopTriggerType:
                    return new ViewTimeLoopTriger();
                default:
                    return null;
                    ;
            }
        }
    }
}