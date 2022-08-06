using System;
using System.Collections.Generic;
using Battle.Logic;
using Game.View.Buff;
using Game.View.Hero;
using Game.View.Hero.Skill;

namespace Game.View
{
	public class BattleLogicExport
	{
		public ViewManager logic;
		public List<BattleLogicOneRoundExport> roundExports = new List<BattleLogicOneRoundExport>();
		public bool isWin = false;

		public static BattleLogicExportProp CreateBattleLogicExportProp(SkillEntity skill,ViewHero target){
			BattleLogicExportProp prop = new BattleLogicExportProp ();
			prop.attackGUID = skill.hero.guid;
			prop.defenceGUID = target.guid;
			prop.sourceSkill = skill;

			return prop;
		}

		public static BattleLogicExportProp CreateBattleLogicExportProp(BattleLogicBuff buff,ViewHero target){
			BattleLogicExportProp prop = new BattleLogicExportProp ();
			prop.attackGUID = buff.buffSource.guid;
			prop.defenceGUID = target.guid;
			prop.sourceBuff = buff;

			return prop;
		}

		public static BattleLogicExportProp CreateBattleLogicExportProp(ViewHero source,ViewHero target){
			BattleLogicExportProp prop = new BattleLogicExportProp ();
			prop.attackGUID = source.guid;
			prop.defenceGUID = target.guid;

			return prop;
		}

	}

	public class BattleLogicOneRoundExport{
		public int roundNum = 0;
		public List<BattleLogicOneSkillExport> skillExports = new List<BattleLogicOneSkillExport>();

		public BattleLogicOneRoundExport(int num){
			this.roundNum = num;
		}
	}

	public class BattleLogicOneSkillExport{
		public float timer;
		public long attackGUID;

		public SkillEntity skill;
		public BattleLogicBuff buff;
		/// <summary>
		/// buff生效一次
		/// </summary>
		public List<long> buffTriggers = new List<long>();

		public List<long> skillHitTargets = new List<long>();

		public List<BattleLogicExportProp> props = new List<BattleLogicExportProp>();
		public List<BattleLogicExportBuff> loadBuffs = new List<BattleLogicExportBuff>();
		public List<long> unloadBuffs = new List<long>();
	}

	public class BattleLogicExportBuff{
		public long sourceGUID;
		public long targetGUID;
		public string buffId;
		public long buffGUID;
	}

	public class BattleLogicExportProp{
		public long attackGUID;
		public long defenceGUID;
		public List<long> totalDefenceGUIDs = new List<long>();
		public SkillEntity sourceSkill;
		public BattleLogicBuff sourceBuff;
		public double value;
		public DictHeroExportPropEnum propID;
        public string dictBuffPropId = "";
        public bool isCrit;
	}





}

