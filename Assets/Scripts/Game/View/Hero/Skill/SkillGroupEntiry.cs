using System.Collections.Generic;
using UnityEngine;

namespace Game.View.Hero.Skill
{
    public class SkillGroupEntiry
    {
        
        
        public SkillEntity[] skillEntities;
        /// <summary>
        /// 当前准备或正在释放的技能
        /// </summary>
        public int curIndex = 0;
        
        private SkillGroupConfig _skillGroupConfig;


        public ViewHero hero;
        
        public int skillBtnIndex;

        public SkillEntity curSkill
        {
            get
            {
                return  skillEntities[curIndex];
            }
        }

        public SkillEntity nextSkill
        {
            get
            {
                return  skillEntities[nextIndex];
            }
        }

        public int nextIndex
        {
            get
            {
                return (curIndex + 1) % skillEntities.Length;
            }
        }
        
        
        
        public void Init(ViewHero hero  ,SkillGroupConfig skillGroupId,int skillBtnIndex)
        {
            this.skillBtnIndex = skillBtnIndex;
            this.hero = hero;
            //TODO
            this._skillGroupConfig = skillGroupId;
            skillEntities = new SkillEntity[_skillGroupConfig.skillConfigs.Length];
            int i = 0;
            foreach (var skillConfig in _skillGroupConfig.skillConfigs)
            {
                if (skillConfig.skillType == SkillType.Shanbi)
                {
                    skillEntities[i] = new SkillEntityShanbi();
                }else if (skillConfig.skillType == SkillType.Feixing)
                {
                    skillEntities[i] = new SkillEntityFeixing();   
                }
                else
                {
                    skillEntities[i] = new SkillEntity();
                }

                skillEntities[i].Init(this,skillConfig);
                i++;
            }
        }

        public void StartSkill()
        {
            ViewHero target;
            hero.GetNearestEnemyInSkillRange(hero.GetPosition(),curSkill,out target);
            curSkill.StartSkill(target);
        }

        public void OnEndSkill(SkillEntity skillEntity)
        {
            curIndex++;
            curIndex = curIndex % skillEntities.Length;
            this.hero.heroSkillUtil.EndAttack();
        }

        public void Interrupt()
        {
            curSkill.Interrupt();
        }

        public void Destroy()
        {
            foreach (var skillEntity in skillEntities)
            {
                skillEntity.Destroy();
            }

            skillEntities = null;
            curIndex = 0;
        }

    }
}