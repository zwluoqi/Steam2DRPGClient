using System;
using System.Collections.Generic;
using Battle.Logic;
using UnityEngine;


namespace Game.View.Hero
{
    public class HeroBehaviour
    {

        public bool Active { get; protected set; }
        public bool WillFinish { get; protected set; }

        public bool IsFinished { get; protected set; }

        public virtual bool Interruptable { get; protected set; }

        public int Priority
        {
            get
            {
                if (modelData != null)
                {
                    return modelData.priority;
                }
                else
                {
                    return dynamicPriority;
                }
            }
        }

        protected HeroBehaviourConfig modelData;

        protected Dictionary<string, string> beParams = new Dictionary<string, string>();

        //是否是动态添加的一次性行为
        public bool IsDynamicBehaviour = false;

        public int dynamicPriority = -1;

        public ViewHero owner;

        public virtual bool Check()
        {
            return false;
        }

        public virtual void Init(ViewHero hero,HeroBehaviourConfig data)
        {
            Active = false;
            WillFinish = false;
            IsFinished = true;
            Interruptable = true;
            owner = hero;
            modelData = data;
            if (modelData != null)
            {
                // beParams = CommonUtil.GetDynamicParams(data.beParams);
            }
        }

        public virtual void Ready()
        {

        }

        public virtual void Clear()
        {

        }

        public void Start()
        {
            Active = true;
            WillFinish = false;
            IsFinished = false;
            Debug.LogWarning("Behaviour Start:" + this.GetType().Name);
            OnStart();
        }

        protected virtual void OnStart()
        {
            
        }

        public void Finish()
        {
            OnFinish();
            Debug.LogWarning("Behaviour Finish:" + this.GetType().Name);  

            Active = false;
            WillFinish = false;
            IsFinished = true;
        }

        protected virtual void OnFinish()
        {
            
        }
        
        public virtual void OrderUpdate()
        {

        }

    }
}
