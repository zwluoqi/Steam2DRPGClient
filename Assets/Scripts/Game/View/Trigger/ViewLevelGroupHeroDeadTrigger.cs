namespace Game.View.Trigger
{
    public class ViewLevelGroupHeroDeadTrigger:ViewTrigger
    {
        protected override void OnStart()
        {
            manager.notification.AddObserver(this,OnGroupHeroDead,(int)ViewCodeEventId.GroupHeroDead);
        }

        protected override void OnDestroy()
        {
            manager.notification.RemoveObserver(this);
        }


        private void OnGroupHeroDead(Notification notification)
        {
            var levelGroupHeroId = (int) notification.info;
            if (levelGroupHeroId == config.levelGroupHeroDeadTriggerConfig.levelGroupHeroId)
            {
                Trigger();
            }
        }
    }
}