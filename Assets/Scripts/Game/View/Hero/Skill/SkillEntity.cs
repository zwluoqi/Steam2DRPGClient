using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.View.Hero.Skill
{
    public class SkillEntity
    {
        public ViewHero hero;
        public SkillGroupEntiry skillGroup;
        
        protected  SkillConfig _skillConfig;
        public SkillConfig skillconfig
        {
            get
            {
                return _skillConfig;
            }
        }


        private TimeEventHandler skillHandler;
        private TimeEventHandler skillingHandler;
        private TimeEventHandler startIntertHandler;
        private TimeEventHandler endIntertHandler;
        
        
        private GameObject skillEffect;
        
        private TimeEventHandler skillEndEffectHandler;
        private TimeEventHandler coolDownHandler;

        private SkillMoveer[] _skillMoveers;
        protected  bool coolDown = true;
        protected bool skilling = false;
        protected bool couldInsert = false;
        protected double skillingTimer = 0;
        protected double costAttributeTimer = 0;
        public SkillGroupEntiry triggerPassiveSkill;

        public void Init(SkillGroupEntiry skillGroup, SkillConfig skillConfig)
        {
            this.skillGroup = skillGroup;
            this.hero = skillGroup.hero;
            this._skillConfig = skillConfig;
            this._skillMoveers = new SkillMoveer[skillconfig.skillMoveConfigs.Length];
            for(int i=0;i<skillconfig.skillMoveConfigs.Length;i++)
            {
                this._skillMoveers[i] = new SkillMoveer();
                this._skillMoveers[i].Init(this, skillconfig.skillMoveConfigs[i]);
            }

            if (skillconfig.triggerPassiveSkill != null)
            {
                this.triggerPassiveSkill = new SkillGroupEntiry();
                this.triggerPassiveSkill.Init(this.hero, skillconfig.triggerPassiveSkill, skillGroup.skillBtnIndex);
            }
        }
        


        public void StartSkill(ViewHero target)
        {
            Debug.LogWarning("start skill "+this.skillconfig.name);
            if (_skillConfig.costAttribute.Length > 0)
            {
                for (int i = 0; i < _skillConfig.costAttribute.Length; i++)
                {
                    var prop = _skillConfig.costAttribute[i];
                    hero.heroBattleDataUtil.ResumeVal(prop.prop,prop.val);
                }
            }
            if (!hero.isMainHero && target != null)
            {
                this.hero.heroInputUtil.ViewTarget(target.GetPosition());
            }
            this.hero.heroAnimUtil.PlayAnim(this.skillconfig.animName);

            skilling = true;
            skillingTimer = 0;
            costAttributeTimer = 0;
            if (skillconfig.insertStartTime > 0)
            {
                startIntertHandler =
                    hero.viewManager.timeEventManager.CreateEvent(DoStartInsertSkill, skillconfig.insertStartTime);
            }

            skillingHandler = hero.viewManager.timeEventManager.CreateEvent(DoOrderSkill, 0, 0);
            couldInsert = false;

            if (skillconfig.insertEndTime > 0)
            {
                endIntertHandler =
                    hero.viewManager.timeEventManager.CreateEvent(DoEndInsertSkill, skillconfig.insertEndTime);
            }

            if (skillconfig.coolDown > 0)
            {
                coolDown = false;
                coolDownHandler = hero.viewManager.timeEventManager.CreateEvent(CoolDown, skillconfig.coolDown);
            }
            skillHandler = hero.viewManager.timeEventManager.CreateEvent(DoEndSkill, skillconfig.duration);
            
            PlaySkillEffect(target);
            PlayProjectors(target);
            PlayMoves(target);
            OnStart();
        }

        protected virtual void OnStart()
        {
            
        }

        private void DoStartInsertSkill()
        {
            couldInsert = true;
        }

        private void DoEndInsertSkill()
        {
            couldInsert = false;
        }

        private void CoolDown()
        {
            coolDown = true;
        }

        private void PlayMoves(ViewHero target)
        {
            //if (target != null)
            {
                foreach (var _skillMoveer in _skillMoveers)
                {
                    _skillMoveer.StartMove(target);
                }
            }
        }

        private void PlayProjectors(ViewHero target)
        {
            foreach (var skillProjectorConfig in skillconfig.skillProjectorConfigs)
            {
                var item = hero.viewManager.projectorManager.CreateProjector(this,skillProjectorConfig,target);
                item.onCollide += OnCollide;
                hero.projectorUtil.AddNode(item);
            }
        }

        private void OnCollide(SkillProjector arg1, ViewHero arg2)
        {
            arg2.BeAttacked(this,-10);
        }

        private void PlaySkillEffect(ViewHero target)
        {
            if (!string.IsNullOrEmpty(skillconfig.skillEffectConfig.uri))
            {
                skillEffect =GameObjectPoolManager.Instance.GetGameObjectDirect(skillconfig.skillEffectConfig.uri);
                UnityTools.SetParent(skillEffect.transform, hero.viewManager.effectRoot);
                skillEndEffectHandler = hero.viewManager.timeEventManager.CreateEvent(OnEndSkillEffect, skillconfig.skillEffectConfig.duration);    
            }
            
        }

        private void OnEndSkillEffect()
        {
            GameObjectPoolManager.Instance.Unspawn(ref skillEffect);
        }

        void DoEndSkill()
        {
            OnPreEndSkill();
            Debug.LogWarning("end skill "+this.skillconfig.name);
            
            skilling = false;
            couldInsert = false;
            StopMove();
            GameObjectPoolManager.Instance.Unspawn(ref skillEffect);
            TimeEventManager.Delete(ref skillEndEffectHandler);

            TimeEventManager.Delete(ref skillHandler);
            TimeEventManager.Delete(ref skillingHandler);
            TimeEventManager.Delete(ref startIntertHandler);
            TimeEventManager.Delete(ref endIntertHandler);

            
            this.skillGroup.OnEndSkill(this);
            OnPostEndSkill();
        }

        protected virtual void OnPreEndSkill()
        {
            
        }
        
        protected virtual void OnPostEndSkill()
        {
            
        }


        public void Interrupt()
        {
            DoEndSkill();
        }
        
        public void Destroy()
        {
            skilling = false;
            couldInsert = false;
            StopMove();
            GameObjectPoolManager.Instance.Unspawn(ref skillEffect);
            TimeEventManager.Delete(ref skillEndEffectHandler);
            
            TimeEventManager.Delete(ref skillHandler);
            TimeEventManager.Delete(ref skillingHandler);
            TimeEventManager.Delete(ref startIntertHandler);
            TimeEventManager.Delete(ref endIntertHandler);
            
            TimeEventManager.Delete(ref coolDownHandler);
        }

        private void StopMove()
        {
            {
                foreach (var _skillMoveer in _skillMoveers)
                {
                    _skillMoveer.StopMove();
                }
            }
        }


        protected virtual bool OnOnOrderSkill()
        {
            return true;
        }
        
        void DoOrderSkill()
        {
            if (!skilling)
            {
                Debug.LogError("不可能出现技能已经停止了，tick还在执行");
                return;
            }

            costAttributeTimer += hero.viewManager.deltaTime;
            skillingTimer += hero.viewManager.deltaTime;
            
            foreach (var _skillMoveer in _skillMoveers)
            {
                _skillMoveer.OrderedUpdate(hero.viewManager.deltaTime);
            }

            bool validState = OnOnOrderSkill();
            if (!validState)
            {
                return;
            }

            if (_skillConfig.costAttributePerSecond.Length > 0)
            {
                //一秒检测一次
                if (costAttributeTimer > 1)
                {
                    costAttributeTimer -= 1;
                    var isattribtueok = CheckAttribute(_skillConfig.costAttributePerSecond);
                    if (!isattribtueok)
                    {
                        Interrupt();
                    }
                    else
                    {
                        Debug.Log("技能属性消耗");
                        for (int i = 0; i < _skillConfig.costAttributePerSecond.Length; i++)
                        {
                            var prop = _skillConfig.costAttributePerSecond[i];
                            hero.heroBattleDataUtil.ResumeVal(prop.prop, prop.val);
                        }
                    }
                }
                else
                {
                    
                }
            }
        }

        private bool CheckAttribute(HeroAttribute[] skillConfigCostAttributePerSecond)
        {
            if (skillConfigCostAttributePerSecond.Length > 0)
            {
                for (int i = 0; i < skillConfigCostAttributePerSecond.Length; i++)
                {
                    var prop = skillConfigCostAttributePerSecond[i];
                    var curVal = hero.heroBattleDataUtil.GetPropVal(prop.prop);
                    if (prop.val > curVal)
                    {
                        Debug.LogError(string.Format("{0}不足,只剩下{1}",prop.prop.ToString(),curVal));
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsReady()
        {
            var isattribtueok = CheckAttribute(_skillConfig.costAttributePerSecond);

            return isattribtueok && coolDown && !skilling;
        }

        public bool CouldInsertOtherSkill()
        {
            return couldInsert;
        }

        public bool InSkillAttackRange(Vector3 source,Vector3 pos)
        {
            var sqrt = MathUtil2D.SqrtDistanceNoZ(source, pos);
            if (sqrt <= skillconfig.searchRadius * skillconfig.searchRadius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}