using UnityEngine.UI;

namespace Game.View.Hero
{
    public class HB_Idle:HeroBehaviour
    {
        public override bool Check()
        {
            return true;
        }

        protected override void OnStart()
        {
            owner.heroAnimUtil.PlayIdle();
        }
    }
}