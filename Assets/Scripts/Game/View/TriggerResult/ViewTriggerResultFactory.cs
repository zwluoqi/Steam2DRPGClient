namespace Game.View.TriggerResult
{
    public class ViewTriggerResultFactory
    {
        public static ViewTriggerResult CreateTriggerResult(SceneTriggerResultType configSceneTriggerResultType)
        {
            switch (configSceneTriggerResultType)
            {
                case SceneTriggerResultType.LevelStory:
                    return new ViewTriggerResultLevelStory();
                case SceneTriggerResultType.HeroBorn:
                    return new ViewTriggerResultHeroBorn();
                case SceneTriggerResultType.ForbideTrigger:
                    return new ViewTriggerResultForbideTrigger();
                case SceneTriggerResultType.HeroDead:
                    return new ViewTriggerResultHeroDead();
                case SceneTriggerResultType.HeroGroupDead:
                    return new ViewTriggerResultHeroGroupDead();
                default:
                    return null;
            }
        }
    }
}