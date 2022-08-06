using UnityEngine;

namespace Game.View.Hero
{
    public class HB_RequestAttack:HeroBehaviour
    {

        public bool catching = false;
        public ViewHero target;
        private int targetAttackIndex;
        private float timer = 0;
        public override bool Check()
        {
            //1.有技能可以释放,
            //1.1在施法范围内，直接释放技能
            //1.2在施法范围外，向目标移动
            //2.没有技能可以释放，待机
        
            
            ViewHero nearTarget;
            int attackIndex;
            bool skillInRange = owner.heroSkillUtil.CheckAutoAttack(out nearTarget,out attackIndex);
            targetAttackIndex = attackIndex;
            if (skillInRange)
            {
                target = nearTarget;
                catching = false;
                return true;
            }
            else
            {
                if (nearTarget != null)
                {
                    var sqrt = MathUtil2D.SqrtDistanceNoZ(nearTarget.GetPosition(),
                        owner.GetPosition());
                    if (sqrt > modelData.attackBehaviourConfig.catchUpRange *
                        modelData.attackBehaviourConfig.catchUpRange)
                    {
                        return false;
                    }
                    else
                    {
                        target = nearTarget;
                        catching = true;
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        protected override void OnStart()
        {
            timer = 0;
            if (catching)
            {
                owner.heroInputUtil.AutoSetMoveTarget(target.GetPosition());
                owner.MoveLogic();
            }
            else
            {
                owner.heroSkillUtil.BeginAttack(targetAttackIndex);
            }
        }


        public override void OrderUpdate()
        {
            if (catching)
            {
                timer += Time.deltaTime;
                if (timer > modelData.attackBehaviourConfig.catchUpDuration)
                {
                    WillFinish = true;
                }
                else
                {
                    Interruptable = true;
                    var skillGroup = owner.heroSkillUtil._skillGroups[targetAttackIndex];
                    var skillInrange = skillGroup.curSkill.InSkillAttackRange(owner.GetPosition(),target.GetPosition());
                    if (skillInrange)
                    {
                        catching = false;
                        owner.heroSkillUtil.BeginAttack(targetAttackIndex);
                    }
                    else
                    {
                        owner.heroInputUtil.AutoSetMoveTarget(target.GetPosition());
                        owner.MoveLogic();
                    }
                }
            }
            else
            {
                Interruptable = false;
                //技能放完了,结束行为
                if (owner.heroSkillUtil.curSkillGroup == null)
                {
                    WillFinish = true;
                }
            }
        }
    }
}