namespace Game.View.Trigger
{
    public class ViewRangeTrigger:ViewTrigger
    {
        protected override void OnStart()
        {
            manager.notification.AddObserver(this,OnHeroMove,(int)ViewCodeEventId.MainHeroMove);
        }
        

        private void OnHeroMove(Notification notification)
        {
            var sqrt = MathUtil2D.SqrtDistanceNoZ(initPos, manager.mainHero.GetPosition());
            if (sqrt <= config.rangeTriggerConfig.range * config.rangeTriggerConfig.range)
            {
                Trigger();
            }
        }
    }
}