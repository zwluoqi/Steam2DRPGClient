namespace Game.View.Trigger
{
    public class ViewLevelHeroDeadTrigger:ViewTrigger
    {
        protected override void OnStart()
        {
            manager.notification.AddObserver(this,OnHeroDead,(int)ViewCodeEventId.HeroDead);
        }


        private void OnHeroDead(Notification notification)
        {
            var levelHeroId = (int) notification.info;
            if (levelHeroId == config.levelHeroDeadTrigger.levelHeroId)
            {
                Trigger();
            }
        }
    }
}