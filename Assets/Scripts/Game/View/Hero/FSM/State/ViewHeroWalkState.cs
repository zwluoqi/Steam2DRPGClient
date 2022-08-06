using FSM;

namespace Game.View.Hero.FSM.State
{
    public class ViewHeroWalkState: ViewHeroS
    {
        public ViewHeroWalkState(ViewHeroT stateType, ViewHeroController controller) : base(stateType, controller)
        {
        }

        protected override void Enter(FSMParam<ViewHeroT> enterParam)
        {
            this._ctrl.viewHero.heroAnimUtil.PlayAnim("walk");
        }

        protected override void Tick(float delta)
        {
            this._ctrl.viewHero.MoveLogic();
            this._ctrl.viewHero.CheckWhatTODO();
        }

    }
}