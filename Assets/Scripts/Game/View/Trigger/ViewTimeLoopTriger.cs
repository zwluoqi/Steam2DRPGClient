namespace Game.View.Trigger
{
    public class ViewTimeLoopTriger:ViewTrigger
    {
        private TimeEventHandler _handler;
        
        protected override void OnStart()
        {
            _handler = manager.timeEventManager.CreateEvent(OnStartTrigger,OnTimeTrigger, 0,
                this.config.timeLoopTriggerConfig.spaceTime,
                this.config.repeatedCounter);
        }

        protected override void OnDestroy()
        {
            TimeEventManager.Delete(ref _handler);
        }

        private void OnStartTrigger()
        {
            Trigger();
        }

        private void OnTimeTrigger()
        {
            Trigger();
        }

    }
}