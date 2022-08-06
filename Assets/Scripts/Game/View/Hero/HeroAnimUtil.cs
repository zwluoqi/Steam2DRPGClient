using UnityEngine;

namespace Game.View.Hero
{
    public class HeroAnimUtil
    {
        public Animator animator;
        public ViewHero hero;
        
         public void PlayIdle()
        {
            PlayAnim0("idle");
        }

         private string curAnim = "";
         private MouseType curAnimX;
         private MouseType curAnimY;
         
        public void PlayAnim(string walk)
        {
            if (curAnim == walk
                && curAnimX == hero.heroInputUtil.lastStayViewDir.x
                && curAnimY == hero.heroInputUtil.lastStayViewDir.y)
            {
                return;
            }
            PlayAnim0(walk);
        }


        public readonly Vector3 reverseBack = new Vector3(-1, 1, 1);


        void PlayAnim0(string walk)
        {
            curAnim = walk;
            curAnimX = hero.heroInputUtil.lastStayViewDir.x;
            curAnimY = hero.heroInputUtil.lastStayViewDir.y;
            var xInput = curAnimX;
            var yInput = curAnimY;
            
            Debug.LogWarning(this.hero.gameObject.name+" PlayAnim0 "+walk+" xInput:"+xInput
            +" yInput:"+yInput);
            if (xInput == MouseType.Positive
                && yInput == MouseType.Positive)
            {
                animator.transform.localScale = Vector3.one;
                animator.Play(walk + "_rt",0,0);
            }
            else if (xInput == MouseType.Positive
                     && yInput == MouseType.None)
            {
                animator.transform.localScale = Vector3.one;
                animator.Play(walk + "_r",0,0);
            }
            else if (xInput == MouseType.Positive
                     && yInput == MouseType.Nagative)
            {
                animator.transform.localScale = Vector3.one;
                animator.Play(walk + "_rd",0,0);
            }
            else if (xInput == MouseType.None
                     && yInput == MouseType.Positive)
            {
                animator.transform.localScale = Vector3.one;
                animator.Play(walk + "_t",0,0);
            }
            else if (xInput == MouseType.None
                     && yInput == MouseType.None)
            {
                animator.transform.localScale = Vector3.one;
                //理论上不可能，因为一直都有值
                animator.Play(walk + "",0,0);
            }
            else if (xInput == MouseType.None
                     && yInput == MouseType.Nagative)
            {
                animator.transform.localScale = Vector3.one;
                animator.Play(walk + "_d",0,0);
            }
            else if (xInput == MouseType.Nagative
                     && yInput == MouseType.Positive)
            {
                animator.transform.localScale = reverseBack;
                animator.Play(walk + "_rt",0,0);
            }
            else if (xInput == MouseType.Nagative
                     && yInput == MouseType.None)
            {
                animator.transform.localScale = reverseBack;
                animator.Play(walk + "_r",0,0);
            }
            else if (xInput == MouseType.Nagative
                     && yInput == MouseType.Nagative)
            {
                animator.transform.localScale = reverseBack;
                animator.Play(walk + "_rd",0,0);
            }
        }
        
        public void Init(ViewHero viewHero)
        {
            this.hero = viewHero;
            this.animator = this.hero.gameObject.GetComponentInChildren<Animator>();
        }
    }
}