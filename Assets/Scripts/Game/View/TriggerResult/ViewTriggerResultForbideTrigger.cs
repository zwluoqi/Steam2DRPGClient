namespace Game.View.TriggerResult
{
    public class ViewTriggerResultForbideTrigger:ViewTriggerResult
    {
        protected override void OnTrigger()
        {
            manager.ForbideTrigger(this.config.triggerResultForbideTriggerConfig.trigger);
        }
    }
}