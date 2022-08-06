using Battle.Logic;
using Game.Scene;
using UnityEngine.UI;

namespace Game.View.TriggerResult
{
    public abstract class ViewTriggerResult
    {
        protected ViewManager manager;
        protected SceneItem[] sceneItems;
        protected LevelTriggerConfig config;

        private TimeEventHandler _handler;

        public void Init(ViewManager manager, SceneTriggerItem sceneTriggerItem)
        {
            this.manager = manager;
            this.config = sceneTriggerItem.levelTriggerConfig;
            this.sceneItems = sceneTriggerItem.triggerItems;
        }

        public void Destroy()
        {
            TimeEventManager.Delete(ref _handler);
        }
        
        public void Trigger()
        {
            if (config.triggerResultDelay > 0)
            {
                _handler = manager.timeEventManager.CreateEvent(TODOTrigger, config.triggerResultDelay);
            }
            else
            {
                TODOTrigger();
            }
        }

        private void TODOTrigger()
        {
            OnTrigger();
            manager.notification.PostNotification((int)ViewCodeEventId.TriggerTrigger,this.config.triggerId);
        }

        protected virtual void OnTrigger()
        {
            
        }
        
    }
}