using System.Collections.Generic;

namespace Game.View.Trigger
{
    public class ViewTriggerTriggerTrigger:ViewTrigger
    {
        private bool and = false;
        
        public List<int> andRemaindList = new List<int>();
        protected override void OnInit()
        {
            if (config.triggerTriggerConfig.andTriggerIdList.Length > 0)
            {
                andRemaindList.AddRange(config.triggerTriggerConfig.andTriggerIdList);
                and = true;
            }

            if (config.triggerTriggerConfig.orTriggerIdList.Length > 0)
            {
                andRemaindList.AddRange(config.triggerTriggerConfig.andTriggerIdList);
                and = false;
            }
        }

        protected override void OnStart()
        {
            manager.notification.AddObserver(this,OnEvent,(int)ViewCodeEventId.TriggerTrigger);
        }
        
        
        protected override void OnDestroy()
        {
            manager.notification.RemoveObserver(this);
        }

        
        private void OnEvent(Notification notification)
        {
            var id = (int)notification.info;
            if (and)
            {
                andRemaindList.Remove(id);
                if (andRemaindList.Count == 0)
                {
                    Trigger();
                }
            }
            else
            {
                if (andRemaindList.Contains(id))
                {
                    Trigger();
                }
            }
        }

      
    }
}