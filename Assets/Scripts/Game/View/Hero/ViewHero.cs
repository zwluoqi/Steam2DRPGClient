using System;
using System.Collections;
using System.Collections.Generic;
using Battle.Logic;
using Game.View;
using Game.View.Define;
using Game.View.Hero.FSM;
using Game.View.Hero.Skill;
using Game.View.Manager;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Game.View.Hero
{
    public class ViewHero
    {
        public long guid;
        public bool isMainHero;
        public int levelHeroId;
        public int levelGroupHeroId;
        
        public GameObject gameObject;
        Transform transform;
        public ViewHeroMono viewHeroMono;

        public HeroCamp heroCamp;
        public int enemyCampMask;
        public ViewHeroController viewHeroController;
        public HeroBehaviourUtil HeroBehaviourUtil = new HeroBehaviourUtil();
        public ProjectorUtil projectorUtil = new ProjectorUtil();
        public EffectUtil effectUtil = new EffectUtil();
        public PowerUtil powerUtil = new PowerUtil();
        
        public HeroViewUtil heroViewUtil = new HeroViewUtil();
        public HeroBattleDataUtil heroBattleDataUtil = new HeroBattleDataUtil();
        public HeroAnimUtil heroAnimUtil = new HeroAnimUtil();
        public HeroCollideUtil heroCollideUtil = new HeroCollideUtil();
        public HeroInputUtil heroInputUtil = new HeroInputUtil();
        public HeroSkillUtil heroSkillUtil = new HeroSkillUtil();
        
        public ViewManager viewManager;

        public const int skillCount = 20;

        public HeroConfig heroConfig;


        public bool isDead;
        /// <summary>
        /// 废弃的，即将被删除
        /// </summary>
        public bool isInValid;

        
        public bool isAuto = false;

        public Vector3 initPos;



        public bool CheckWhatTODO()
        {
            return ManualCheckWhatTodo();
        }

        
        private bool ManualCheckWhatTodo()
        {
            
            int attackIndex = heroSkillUtil.CheckAttack();
            if (attackIndex >= 0)
            {
                return heroSkillUtil.BeginAttack(attackIndex);
            }
            else
            {
                if (heroSkillUtil.curSkillGroup != null)
                {
                    return false;
                }
                else if (heroInputUtil._moveDir != Vector3.zero)
                {
                    return BegintMove();
                }
                else
                {
                    return BeginIdle();
                }
            }
        }

        private bool BegintMove()
        {
            viewHeroController.Goto(ViewHeroT.WALK);
            return true;
        }

        public bool BeginIdle()
        {
            viewHeroController.Goto(ViewHeroT.IDLE);
            return false;
        }


        public bool IsEnemyCamp(HeroCamp targetCamp)
        {
            return (this.enemyCampMask & (1 << (int) targetCamp) )>0;
        }
        
        int GetEnemyCampMask()
        {
            if (heroCamp == HeroCamp.Player)
            {
                return (1<<(int)HeroCamp.Enemy) | (1<<(int)HeroCamp.Hunluan);
            }
            else if (heroCamp == HeroCamp.Enemy)
            {
                return (1<<(int)HeroCamp.Player) | (1<<(int)HeroCamp.Hunluan);
            }
            else if (heroCamp == HeroCamp.Npc)
            {
                return 1<<(int)HeroCamp.None;
            }
            else if (heroCamp == HeroCamp.Hunluan)
            {
                return (1<<(int)HeroCamp.Enemy) | (1<<(int)HeroCamp.Player);
            }
            else
            {
                throw new Exception("暂不支持");
            }
        }


        public void Init(ViewManager viewManager, GameObject gameObject, HeroInstanceData heroInstanceData,
            Vector3 initPos,HeroConfig heroConfig)
        {
            this.viewHeroMono = gameObject.GetComponent<ViewHeroMono>();
            this.initPos = initPos;
            this.heroConfig = heroConfig;
            this.levelHeroId = heroInstanceData.levelHeroId;
            this.levelGroupHeroId = heroInstanceData.levelGroupHeroId;
            this.guid = DisplayPool.GET_GUID;
            this.heroCamp = heroInstanceData.heroCamp;
            this.enemyCampMask = GetEnemyCampMask();
            this.viewManager = viewManager;
            this.gameObject = gameObject;
            this.transform = gameObject.transform;
            this.transform.localPosition = initPos;
            this.heroAnimUtil.Init(this);
            this.heroBattleDataUtil.Init(this);
            this.heroViewUtil.Init(this);
            this.heroCollideUtil.Init(this);
            this.heroSkillUtil.Init(this);
            this.heroInputUtil.Init(this);
            
           
            this.isMainHero = heroInstanceData.mainHero;
            if (!this.isMainHero)
            {
                this.isAuto = true;
            }
            this.isDead = false;
            
            this.viewHeroController = new ViewHeroController(this);
            this.HeroBehaviourUtil.Init(this,heroConfig.heroBehaviourConfigs);
            this.gameObject.name = heroConfig.name+"_"+heroConfig.heroName+"_" + this.guid.ToString();
        }

        public void SetInitPos(Vector3 pos)
        {
            initPos = pos;
        }

        public void Destroy()
        {

            heroSkillUtil.Destory();
            projectorUtil.DestroyItems();
            effectUtil.DestroyItems();
            powerUtil.DestroyItems();
        }

        public void Tick()
        {
            if (this.viewHeroController.CurrStateType == ViewHeroT.DEATH)
            {
                return;
            }

            if (isMainHero)
            {
                InputOperaiton();
            }
            else
            {
                AIOperation();
            }

            viewHeroController.Tick(Time.deltaTime);
            HeroBehaviourUtil.Tick();
        }

        private void AIOperation()
        {

        }

        private void InputOperaiton()
        {
            heroInputUtil.InputOperaiton();
        }

        public void MoveLogic()
        {
            SetPosition(GetPosition() + heroInputUtil._moveDir * heroBattleDataUtil.moveSpeed * Time.deltaTime);

            if (heroSkillUtil.curSkillGroup == null)
            {
                this.heroAnimUtil.PlayAnim("walk");
            }
        }

        public bool GetNearestEnemy(Vector3 pos, out ViewHero nearTarget,
            List<ViewHero> ignoreList = null)
        {
            var list = viewManager.GetHerosByCampMask(this.GetEnemyCampMask());
            float dis = 0;
            nearTarget = viewManager.targetUtil.GetNearest(list, pos, out dis, ignoreList);
            return nearTarget != null;
        }
        
        public bool GetNearestEnemyInSkillRange(Vector3 transformLocalPosition, SkillEntity skill, out ViewHero target)
        {
            if (GetNearestEnemy(transformLocalPosition, out target))
            {
                return skill.InSkillAttackRange(transformLocalPosition, target.transform.localPosition);
            }
            else
            {
                return false;
            }
        }
        
        public bool GetNearestEnemyInRange(Vector3 transformLocalPosition, float searchRadius, out ViewHero target)
        {
            if (GetNearestEnemy(transformLocalPosition, out target))
            {
                var sqrt = MathUtil2D.SqrtDistanceNoZ(transformLocalPosition, target.transform.localPosition);
                return sqrt <= searchRadius * searchRadius;
            }
            else
            {
                return false;
            }
        }

        public void OnBeTreat(ViewHero buffSource, double value, ref BattleLogicExportProp exProp)
        {
            
        }

        public void OnBeDMG(ViewHero buffSource, double d, ref BattleLogicExportProp exProp)
        {
            
        }
        
        private TimeEventHandler behitHandler;
        private TimeEventHandler inValidHandler;
        public void BeAttacked(SkillEntity skill, int i)
        {
            this.heroBattleDataUtil.hp += i;
            this.heroViewUtil.SetHpVal((float)(this.heroBattleDataUtil.hp*1.0f/this.heroBattleDataUtil.maxHP.value));
            if (this.heroBattleDataUtil.hp <= 0)
            {
                HeroDead(skill.hero);
            }
            else
            {
                this.viewHeroController.Goto(ViewHeroT.BEHIT);
                this.heroAnimUtil.PlayAnim("hit1");
                TimeEventManager.Delete(ref behitHandler);
                behitHandler = this.viewManager.timeEventManager.CreateEvent(OnBehitDone, 0.2f);
            }
        }

        private void OnBehitDone()
        {
            this.viewHeroController.Goto(ViewHeroT.IDLE);
        }

        public void HeroDead(ViewHero skillHero)
        {
            this.viewHeroController.Goto(ViewHeroT.DEATH);
            this.heroAnimUtil.PlayAnim("death");
            TimeEventManager.Delete(ref inValidHandler);
            inValidHandler = this.viewManager.timeEventManager.CreateEvent(OnDeadDone, 0.5f);
            if (skillHero != null)
            {
                Debug.LogError(this.gameObject.name + " is dead by " + skillHero.gameObject.name);
            }

            this.isDead = true;
            viewManager.notification.PostNotification((int)ViewCodeEventId.HeroDead,this.levelHeroId);
            viewManager.OnDead(this);
        }

        private void OnDeadDone()
        {
            this.isInValid = true;
        }


        public int skillMovingCount = 0;

        public void DesSkillMoving()
        {
            skillMovingCount--;
            if (skillMovingCount < 0)
            {
                skillMovingCount = 0;
            }

            FreshBoxCollider();
        }
        public void AddSkillMoving()
        {
            skillMovingCount++;
            FreshBoxCollider();
        }


        private void FreshBoxCollider()
        {
            if (skillMovingCount > 0)
            {
                heroCollideUtil.SetMoveTrigger(true);
            }
            else
            {
                heroCollideUtil.SetMoveTrigger(false);
            }
        }


        public void CheckHeroPosInValid()
        {
            
        }

        public void CheckHeroPosInDeadArea()
        {
            if (heroCollideUtil.CheckCurInRange(UnityCollide2DType.AirArea))
            {
                Debug.LogError("在空中，拉回出生点");
                SetPosition( viewManager.bornPos);
            }

            if (viewManager.CheckCurInLayer(GetPosition(),UnityLayer.AirAreaCollide))
            {
                Debug.LogError("在空中，拉回出生点");
                SetPosition(viewManager.bornPos);
            }
        }

        public Vector3 GetPosition()
        {
            return transform.localPosition;
        }

        public void SetPosition(Vector3 pos)
        {
            transform.localPosition = pos;
            if (isMainHero)
            {
                viewManager.notification.PostNotification((int)ViewCodeEventId.MainHeroMove);
            }
        }

        public Transform GetTrans()
        {
            return transform;
        }
    }

}


public class HeroInstanceData
{
    public bool mainHero;
    public HeroCamp heroCamp;
    public int levelGroupHeroId;
    public int levelHeroId;
}

public enum MouseType
{
    Nagative = -1,
    None = 0,
    Positive= 1,
}

public struct ViewDir
{
    public MouseType x;
    public MouseType y;

    public ViewDir(MouseType x, MouseType y)
    {
        this.x = x;
        this.y = y;
    }
}
