using UnityEngine;

namespace Game.View.Hero
{
    public class HeroViewUtil
    {

        public Transform hpslider;
        public void Init(ViewHero viewHero)
        {
            hpslider = viewHero.viewHeroMono.hpPart.transform.Find("hp/hpslider");
        }

        public void SetHpVal(float v)
        {
            hpslider.transform.localScale = new Vector3(v, 1, 1);
        }
    }
}