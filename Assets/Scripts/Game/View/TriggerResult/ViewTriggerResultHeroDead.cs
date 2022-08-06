namespace Game.View.TriggerResult
{
    public class ViewTriggerResultHeroDead:ViewTriggerResult
    {
        protected override void OnTrigger()
        {
            manager.ForbideDeadHero(this.config.levelHeroDeadTrigger.levelHeroId);
        }
    }
}