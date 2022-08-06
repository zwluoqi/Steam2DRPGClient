using FSM;
using Game.View.Hero.FSM.State;
using UnityEngine;

namespace Game.View.Hero.FSM
{
    public class ViewHeroController:FSMBaseCtrl<ViewHeroT,ViewHeroS>
    {
        public ViewHero viewHero;
        public ViewHeroController(ViewHero ViewHero) : base()
        {
            this.viewHero = ViewHero;
            if (this.viewHero.isMainHero)
            {
                AddState0(new ViewHeroIdleState(ViewHeroT.IDLE, this));
                AddState0(new ViewHeroWalkState(ViewHeroT.WALK, this));
                AddState0(new ViewHeroAttackState(ViewHeroT.ATTACK, this));
                AddState0(new ViewHeroBehitState(ViewHeroT.BEHIT, this));
                AddState0(new ViewHeroDeathState(ViewHeroT.DEATH, this));
                // AddState0(new ViewHeroCatupState(ViewHeroT.Catup, this));
            }
            else
            {
                AddState0(new ViewHeroEmptyState(ViewHeroT.IDLE, this));
                AddState0(new ViewHeroEmptyState(ViewHeroT.WALK, this));
                AddState0(new ViewHeroEmptyState(ViewHeroT.ATTACK, this));
                AddState0(new ViewHeroEmptyState(ViewHeroT.BEHIT, this));
                AddState0(new ViewHeroEmptyState(ViewHeroT.DEATH, this));
                // AddState0(new ViewHeroEmptyState(ViewHeroT.Catup, this));
            }

            SetDefaultState(ViewHeroT.IDLE);
        }

        private void AddState0(ViewHeroS s)
        {
            this.AddState(s);
        }

        public override void Goto(ViewHeroT nextStateType, object enterParam = null, bool allowSameState = false)
        {
            base.Goto(nextStateType, enterParam, allowSameState);
        }
    }




    public abstract  class ViewHeroS:FSMBaseState<ViewHeroT,ViewHeroController>
    {
        protected ViewHeroS(ViewHeroT stateType, ViewHeroController controller) : base(stateType, controller)
        {
        }
    }
    
    public  class ViewHeroEmptyState:ViewHeroS
    {
        public ViewHeroEmptyState(ViewHeroT stateType, ViewHeroController controller) : base(stateType, controller)
        {
        }
    }


    public enum ViewHeroT
    {
        IDLE,
        WALK,
        ATTACK,
        BEHIT,
        DEATH,
        // Catup,//追赶敌人
    }
}