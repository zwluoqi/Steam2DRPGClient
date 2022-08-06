namespace Game.View.TriggerResult
{
    public class ViewTriggerResultHeroGroupDead:ViewTriggerResult
    {
        protected override void OnTrigger()
        {
            manager.ForbideDeadHeroGroup(this.config.levelGroupHeroDeadTriggerConfig.levelGroupHeroId);
        }
    }
}