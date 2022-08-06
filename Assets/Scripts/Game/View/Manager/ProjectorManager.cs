using Game.View.Hero;
using Game.View.Hero.Skill;

namespace Game.View.Manager
{
    public class ProjectorManager:ABViewBindNodeManager<SkillProjector>
    {
        protected override void IFPoolDeathToPool(ref SkillProjector p)
        {
            DisplayPoolUtil.displayPool.UnSpwan (ref p);
        }

        public SkillProjector CreateProjector(SkillEntity skill,SkillProjectorConfig skillProjectorConfig,ViewHero target)
        {
            SkillProjector skillProjector = DisplayPoolUtil.displayPool.Spwan<SkillProjector>();
            skillProjector.Init(skill, skillProjectorConfig,target);
            skillProjector.StartProjector();
            projectors.Add(skillProjector);
            return skillProjector;
        }
    }
}