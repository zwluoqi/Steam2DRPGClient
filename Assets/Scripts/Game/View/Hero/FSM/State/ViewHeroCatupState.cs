// using FSM;
//
// namespace Game.View.Hero.FSM.State
// {
//     public class ViewHeroCatupState:ViewHeroS
//     {
//         public ViewHeroCatupState(ViewHeroT stateType, ViewHeroController controller) : base(stateType, controller)
//         {
//         }
//
//         public ViewHero catupTarget;
//         protected override void Enter(FSMParam<ViewHeroT> enterParam)
//         {
//             catupTarget = enterParam.param as ViewHero;
//             this._ctrl.viewHero.heroAnimUtil.PlayAnim("walk");
//         }
//
//         protected override void Tick(float delta)
//         {
//             if (catupTarget.isDead)
//             {
//                 Goto(ViewHeroT.IDLE);
//             }
//             this._ctrl.viewHero.heroInputUtil.AutoSetMoveTarget(catupTarget);
//             this._ctrl.viewHero.MoveLogic();
//             this._ctrl.viewHero.CheckWhatTODO();
//         }
//     }
// }