using System;
using System.Collections.Generic;
using UnityEngine;



namespace Game.View.Hero
{
    public class HeroBehaviourUtil
    {
        protected List<HeroBehaviour> behaviours = new List<HeroBehaviour>();
        
        protected double checkTimer = 0;
        public const double checkInterval = 0.2f;
        protected HeroBehaviour currentBehaviour;
        
        
        // public HeroBehaviourCollectionConfig modelData;

        public ViewHero owner;

        public void Init(ViewHero hero,HeroBehaviourConfig[] resData)
        {
            owner = hero;
            // HeroBehaviourCollectionConfig dbcData = resData;
            // this.modelData = dbcData;


            foreach (var dcb in resData)
            {
                // DictCommoneBehaviour.Model beData = DictDataManager.Instance.dictCommoneBehaviour.GetModel(dcbID);
                HeroBehaviour behaviour = HeroBehaviourFactory.GetBehaviour(dcb.behaviorName);
                behaviour.Init(hero, dcb);
                AddSortBehaviour(behaviour);
            }
        }

        protected void AddSortBehaviour(HeroBehaviour behaviour)
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                if (behaviour.Priority > behaviours[0].Priority)
                {
                    behaviours.Insert(i, behaviour);
                    return;
                }
            }
            behaviours.Add(behaviour);
        }

        //检查所有已注册的行为，找到一个可以执行的行为，并且新的行为可以中断当前行为
        //优先级->正在执行
        public HeroBehaviour CheckBehavior()
        {
            //如果正在执行的行为不可以被中断，就没有没必要检查其它行为了
            if (currentBehaviour != null && !currentBehaviour.Interruptable)
            {
                return null;
            }

            //找到当前可以执行、优先级最高的行为
            HeroBehaviour most_bhv = null;
            foreach (HeroBehaviour bhv in behaviours)
            {
                if (currentBehaviour == bhv)
                    continue;
                if (currentBehaviour != null && bhv.Priority < currentBehaviour.Priority)
                    break;
                if (bhv.Check())
                {
                    most_bhv = bhv;
                    break;
                }
            }

            //如果最高优先级比当前正在执行的行为低，就直接返回吧
            if (most_bhv != null)
            {
                if (currentBehaviour != null)
                {
                    if (most_bhv.Priority >= currentBehaviour.Priority)
                    {
                        return most_bhv;
                    }
                }
                else
                {
                    return most_bhv;
                }
            }

            return null;
        }
        
        public void Tick()
        {
            if (behaviours.Count == 0)
            {
                return;
            }
            checkTimer += owner.viewManager.deltaTime;

            HeroBehaviour newbhv = null;

            if (checkTimer > checkInterval || currentBehaviour == null)
            {
                checkTimer = 0f;
                newbhv = CheckBehavior();
            }

            if (newbhv != null)
            {
                if (currentBehaviour != null && !currentBehaviour.IsFinished)
                {
                    FinishCurrentBehaviour();
                }
                currentBehaviour = newbhv;
                currentBehaviour.Start();
            }

            if (currentBehaviour != null)
            {
                if (currentBehaviour.WillFinish)
                {
                    FinishCurrentBehaviour();
                }
                else
                {
                    currentBehaviour.OrderUpdate();
                    if (currentBehaviour.WillFinish)
                    {
                        FinishCurrentBehaviour();
                    }
                }
            }
            else
            {
                // Debug.Log("没有合适的行为可供选择，请检查配置数据是否合适？"+owner.viewHeroMono.name);
            }
        }

        protected void FinishCurrentBehaviour()
        {
            currentBehaviour.Finish();
            currentBehaviour = null;
        }
        
    }
}
