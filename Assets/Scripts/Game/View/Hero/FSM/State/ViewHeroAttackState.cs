using FSM;

namespace Game.View.Hero.FSM.State
{
    public class ViewHeroAttackState : ViewHeroS
    {
        protected override void Enter(FSMParam<ViewHeroT> enterParam)
        {
            
        }

        
        protected override void Tick(float delta)
        {
            if (this._ctrl.viewHero.heroSkillUtil.curSkillGroup.curSkill.skillconfig.couldMove)
            {
                this._ctrl.viewHero.MoveLogic();
            }

            int skillIndex = -1;
            var skillGroupIndex = this._ctrl.viewHero.heroSkillUtil.CheckInsertAttack(out skillIndex);
            if(skillGroupIndex>=0)
            {
                this._ctrl.viewHero.heroSkillUtil.InsertSkill(skillGroupIndex);
            }
        }


        public ViewHeroAttackState(ViewHeroT stateType, ViewHeroController controller) : base(stateType, controller)
        {
        }
    }
}