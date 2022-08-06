using UnityEngine;

namespace Game.View.Hero.Skill
{
    public class SkillEntityShanbi:SkillEntity
    {


        public bool checkPos = true;

        protected override void OnStart()
        {
            checkPos = true;
        }


        protected override bool OnOnOrderSkill()
        {
            ///飞行技能在插入时间处理
            if (couldInsert)
            {
                var btning = hero.heroInputUtil.skillBtnings[this.skillGroup.skillBtnIndex];
                if (btning)
                {
                    Debug.LogWarning("触发飞行技能");
                    hero.heroSkillUtil.TriggerPassiveSkill(this.triggerPassiveSkill);
                    checkPos = false;
                    return false;
                }
            }

            return true;
        }

        protected override void OnPostEndSkill()
        {
            if (checkPos)
            {
                hero.CheckHeroPosInDeadArea();
            }
        }
    }
}