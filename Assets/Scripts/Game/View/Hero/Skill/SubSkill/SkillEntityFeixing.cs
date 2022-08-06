namespace Game.View.Hero.Skill
{
    public class SkillEntityFeixing:SkillEntity
    {
        protected override bool OnOnOrderSkill()
        {
            ///飞行技能在插入时间处理
            hero.heroAnimUtil.PlayAnim(this.skillconfig.animName);
            var btning = hero.heroInputUtil.skillBtnings[this.skillGroup.skillBtnIndex];
            if (!btning)
            {
                Interrupt();
                return false;
            }

            return true;
        }

        protected override void OnPostEndSkill()
        {
            hero.CheckHeroPosInValid();
        }
    }
}