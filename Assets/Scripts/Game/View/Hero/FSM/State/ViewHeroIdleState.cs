using FSM;

namespace Game.View.Hero.FSM.State
{
    public class ViewHeroIdleState : ViewHeroS
    {
        protected override void Enter(FSMParam<ViewHeroT> enterParam)
        {
            this._ctrl.viewHero.heroAnimUtil.PlayIdle();
        }

        protected override void Tick(float delta)
        {
            this._ctrl.viewHero.CheckWhatTODO();
        }


        public ViewHeroIdleState(ViewHeroT stateType, ViewHeroController controller) : base(stateType, controller)
        {
        }
    }
}