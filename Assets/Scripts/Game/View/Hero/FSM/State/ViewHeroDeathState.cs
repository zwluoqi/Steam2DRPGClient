using FSM;

namespace Game.View.Hero.FSM.State
{
    public class ViewHeroDeathState : ViewHeroS
    {
        protected override void Enter(FSMParam<ViewHeroT> enterParam)
        {
            
        }

        protected override void Tick(float delta)
        {
            
        }


        public ViewHeroDeathState(ViewHeroT stateType, ViewHeroController controller) : base(stateType, controller)
        {
        }
    }
}