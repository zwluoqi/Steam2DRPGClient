namespace Game.View.Hero
{
    public class HB_StandAttack:HeroBehaviour
    {
        
        private int targetAttackIndex;

        public override bool Check()
        {
            ViewHero nearTarget;
            int attackIndex;
            bool skillInRange = owner.heroSkillUtil.CheckAutoAttack(out nearTarget,out attackIndex);
            targetAttackIndex = attackIndex;
            if (skillInRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnStart()
        {
            owner.heroSkillUtil.BeginAttack(targetAttackIndex);
        }

        public override void OrderUpdate()
        {
            //技能放完了,结束行为
            if (owner.heroSkillUtil.curSkillGroup == null)
            {
                WillFinish = true;
            }
        }
    }
}