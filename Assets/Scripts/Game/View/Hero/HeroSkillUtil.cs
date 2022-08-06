using System;
using Game.View.Hero.FSM;
using Game.View.Hero.Skill;

namespace Game.View.Hero
{
    public class HeroSkillUtil
    {
        public SkillGroupEntiry[] _skillGroups;
        private ViewHero hero;

        public SkillGroupEntiry curSkillGroup = null;

        public void Init(ViewHero viewHero)
        {
            this.hero = viewHero;
            this._skillGroups = new SkillGroupEntiry[this.hero.heroConfig.skillGroupConfigs.Length];
            for (int i = 0; i < _skillGroups.Length; i++)
            {
                _skillGroups[i] = new SkillGroupEntiry();
                _skillGroups[i].Init(this.hero, this.hero.heroConfig.skillGroupConfigs[i], i);
            }
        }

        public void Destory()
        {
            for (int i = 0; i < _skillGroups.Length; i++)
            {
                _skillGroups[i].Destroy();
                _skillGroups[i] = null;
            }
        }
        
        /// <summary>
        /// 插入技能
        /// </summary>
        /// <param name="skillGroupIndex"></param>
        public void InsertSkill(int skillGroupIndex)
        {
            this.curSkillGroup.Interrupt();
            this.curSkillGroup = _skillGroups[skillGroupIndex];
            this.curSkillGroup.StartSkill();
            hero.viewHeroController.Goto(ViewHeroT.ATTACK);
        }
        
        /// <summary>
        /// 释放技能
        /// </summary>
        /// <param name="attackIndex"></param>
        /// <returns></returns>
        public bool BeginAttack(int skillGroupIndex)
        {
            // this._mCurSkillGroupIndex = attackIndex;
            this.curSkillGroup = _skillGroups[skillGroupIndex];
            var skillGroup = this.curSkillGroup;
            skillGroup.StartSkill();
            hero.viewHeroController.Goto(ViewHeroT.ATTACK);
            return true;
            //TODO
        }

        /// <summary>
        /// 技能结束
        /// </summary>
        public void EndAttack()
        {
            hero.viewHeroController.Goto(ViewHeroT.IDLE);
            this.curSkillGroup = null;
            // this._mCurSkillGroupIndex = -1;
        }

        public int CheckAttack()
        {
            for (int i = 0; i < hero.heroInputUtil.skillBtns.Length; i++)
            {
                if (!hero.heroInputUtil.skillBtns[i])
                {
                   continue;
                }

                if (!hero.heroSkillUtil._skillGroups[i].curSkill.IsReady())
                {
                    continue;
                }
                return i;
            }
            return -1;
        }
        
        public bool CheckAutoAttack(out ViewHero moveTarget,out int moveAttackIndex)
        {
            moveTarget = null;
            ViewHero nearTarget = null;
            moveAttackIndex = -1;
            for (int i = 0; i < hero.heroSkillUtil._skillGroups.Length; i++)
            {
                var curSkill = hero.heroSkillUtil._skillGroups[i].curSkill;
                if (!curSkill.IsReady())
                {
                    continue;
                }
                var hasSkillRange = hero.GetNearestEnemyInSkillRange(hero.GetPosition(), curSkill,out nearTarget);
                if (hasSkillRange)
                {
                    moveTarget = nearTarget;
                    moveAttackIndex = i;
                    return true;
                }
                else
                {
                    if (moveAttackIndex == -1)
                    {
                        moveTarget = nearTarget;
                        moveAttackIndex = i;
                    }
                }
            }
            return false;
        }

        public int CheckInsertAttack(out int skillIndex)
        {
            if (curSkillGroup == null)
            {
                skillIndex = -1;
                return -1;
            }
            var curSkill = curSkillGroup.curSkill;
            if (!curSkill.CouldInsertOtherSkill())
            {
                skillIndex = -1;
                return -1;
            }
            for (int i = 0; i < hero.heroInputUtil.skillBtns.Length; i++)
            {
                if (!hero.heroInputUtil.skillBtns[i])
                {
                    continue;
                }

                if (i == curSkillGroup.skillBtnIndex)
                {
                    if (curSkillGroup.nextSkill.IsReady())
                    {
                        skillIndex = curSkillGroup.nextIndex;
                        return i;
                    }
                }
                else
                {
                    if (curSkillGroup.curSkill.IsReady())
                    {
                        skillIndex = curSkillGroup.curIndex;
                        return i;
                    }
                }
            }
            skillIndex = -1;
            return -1;
        }

        public void TriggerPassiveSkill(SkillGroupEntiry passiveSkill)
        {
            if (this.curSkillGroup != null)
            {
                this.curSkillGroup.Interrupt();
            }
            this.curSkillGroup = passiveSkill;
            passiveSkill.StartSkill();
            hero.viewHeroController.Goto(ViewHeroT.ATTACK);
        }
    }
}