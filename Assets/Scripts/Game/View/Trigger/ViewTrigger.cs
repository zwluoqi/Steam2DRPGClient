using Battle.Logic;
using Game.Scene;
using Game.View.Hero;
using Game.View.TriggerResult;
using UnityEngine;

namespace Game.View.Trigger
{
    public abstract class ViewTrigger
    {
        protected ViewManager manager;
        protected LevelTriggerConfig config;
        protected ViewTriggerResult viewTriggerResult;
        protected Vector3 initPos;
        bool trigger = false;
        public void Init(ViewManager manager,SceneTriggerItem triggerItem)
        {
            this.manager = manager;
            this.config = triggerItem.levelTriggerConfig;
            this.viewTriggerResult = ViewTriggerResultFactory.CreateTriggerResult(config.sceneTriggerResultType);
            this.viewTriggerResult.Init(manager, triggerItem);
            this.OnInit();
        }

        public void Start()
        {
            OnStart();
        }


        public void Destroy()
        {
            OnDestroy();
            manager.notification.RemoveObserver(this);
            this.viewTriggerResult.Destroy();
        }

        protected virtual  void OnDestroy()
        {
            
        }

        protected virtual void OnStart()
        {
            
        }

        protected virtual void OnInit()
        {
            
        }

        protected int repeatedCounter;

        public void Trigger()
        {
            repeatedCounter++;
            //重复次数过
            if (repeatedCounter > this.config.repeatedCounter)
            {
                return;
            }

            //最后一次，直接取消事件监听
            if (repeatedCounter == this.config.repeatedCounter)
            {
                manager.notification.RemoveObserver(this);
            }

            viewTriggerResult.Trigger();
        }
    }
}