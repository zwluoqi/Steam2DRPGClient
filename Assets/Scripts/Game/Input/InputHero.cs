using System;
using System.Collections.Generic;
// using Grow;

namespace Battle.Input
{
	

	public class InputHero
	{

		public DictHeroHero.Model modelData;
		public int starLev;

        public NormalAttributeData inputAttribute;
		public double hpPercent = 1;
		public double mpPercent = 1;
		/// <summary>
		/// 被攻击类型
		/// </summary>
		public int beAtkTypeMask;
		/// <summary>
		/// 攻击类型加持
		/// </summary>
		public int atkTypeMask;

		public string Name;

		public string teamStand;

		public int level;

		public List<InputSkill> skillInfos = new List<InputSkill>();
		public int pos = 0;

		public int actionCountRound = 1;

		// public InputHero (DictChapterEnemy.Model enmeyModel, int pos)
		// {
		// 	this.pos = pos;
		// 	this.modelData = DictDataManager.Instance.dictHeroHero.GetModel (enmeyModel.hero_id);
		// 	this.starLev = enmeyModel.star_lev;
  //
  //           this.inputAttribute = new NormalAttributeData ();
  //           this.inputAttribute.phy_attack = enmeyModel.attack;
  //           this.inputAttribute.pyh_def = enmeyModel.defence;
  //           this.inputAttribute.add_maxhp = enmeyModel.hp;
  //           this.inputAttribute.add_maxmp = enmeyModel.mp;
		// 	this.inputAttribute.shenfa = enmeyModel.shenfa;
  //           this.inputAttribute.jinggu = enmeyModel.jingu;
		// 	this.inputAttribute.neili = enmeyModel.neili;
		// 	this.inputAttribute.weaponFactor = enmeyModel.weapon_factor;
		// 	this.inputAttribute.attack_speed = enmeyModel.attack_speed;
  //
		// 	this.inputAttribute.xixue_factor_radio = enmeyModel.xixue_factor;
		// 	this.inputAttribute.hit_radio = enmeyModel.hit_radio;
		// 	this.inputAttribute.miss_radio = enmeyModel.miss_radio;
		// 	this.inputAttribute.pofang_radio = enmeyModel.pofang_radio;
		// 	this.inputAttribute.crit_radio = enmeyModel.crit_radio;
		// 	this.inputAttribute.crit_dmg_percent = enmeyModel.crit_dmg_percent;
		// 	this.inputAttribute.unxuanyun = enmeyModel.unxuanyun;
		// 	this.inputAttribute.unjinggu = enmeyModel.unjinggu;
		// 	this.inputAttribute.unhunshui = enmeyModel.unhunshui;
		// 	this.inputAttribute.unfengyin = enmeyModel.unfengyin;
		// 	this.inputAttribute.unjinfa = enmeyModel.unjinfa;
		// 	this.inputAttribute.unmeihuo = enmeyModel.unmeihuo;
		// 	this.inputAttribute.unxuruo = enmeyModel.unxuruo;
  //
		// 	this.atkTypeMask = 1 << enmeyModel.atkShuxingType | 1;
		// 	this.beAtkTypeMask = 1<<enmeyModel.beAtkShuxingType;
  //
		// 	this.inputAttribute.dmg_add_per = enmeyModel.dmg_add_per;
		// 	this.inputAttribute.dmg_des_per = enmeyModel.dmg_des_per;
		// 	this.inputAttribute.dmg_fantan_radio = enmeyModel.dmg_fantan;
		// 	this.inputAttribute.kang_crit_radio = enmeyModel.kang_crit_radio;
		// 	this.inputAttribute.kang_crit_dmg_radio = enmeyModel.kang_crit_dmg_radio;
		// 	this.inputAttribute.kang_xixue_radio = enmeyModel.kang_xixue;
  //
		// 	this.level = enmeyModel.level;
  //
		// 	this.Name = enmeyModel.name;
  //
		// 	this.teamStand = modelData.name_abc;
  //
		// 	this.actionCountRound = enmeyModel.action_count_round;
  //
  //
		// 	var skills = DictDataManager.Instance.dictHeroHero.GerHeroSKillModels (this.modelData.id);
		// 	foreach (var skill in skills) {
		// 		if (skill.hero_star <= this.starLev) {
		// 			InputSkill inputSkill = new InputSkill ();
		// 			inputSkill.skillId = skill.id;
		// 			inputSkill.skillLev = this.level;
		// 			inputSkill.skillOrder = skill.weigth;
		// 			skillInfos.Add (inputSkill);
		// 		}
		// 	}
		// 	skillInfos.Sort (delegate(InputSkill x, InputSkill y) {
		// 		return x.skillOrder.CompareTo(y.skillOrder);	
		// 	});
		// }
  //
		// public InputHero (Grow.GrowHero hero, int pos,int playerAtkMask, List<string> tuandui_skills = null)
		// {
		// 	this.pos = pos;
		// 	this.modelData = hero.modelData;
		// 	this.starLev = hero.instHero.starLev;
  //
  //           this.inputAttribute = hero.normalAttribute;
		// 	this.inputAttribute.shenfa = hero.shenfa;
		// 	this.inputAttribute.jinggu = hero.jingu;
		// 	this.inputAttribute.neili = hero.neili;
  //
		// 	this.atkTypeMask = hero.weaponAtkMask |playerAtkMask;
		// 	this.beAtkTypeMask = 1;
  //
		// 	this.Name = hero.modelData.name;
		// 	this.teamStand = hero.modelData.name_abc;
		// 	this.level = hero.instHero.level;
  //
		// 	this.actionCountRound = hero.actionAttackRound;
  //
  //
		// 	foreach (var gs in hero.skillGSs) {
		// 		var skill = gs.Value;
		// 		if (skill.UnLocked ()) {
		// 			InputSkill inputSkill = new InputSkill ();
		// 			if (tuandui_skills == null || !hero.isMain) {
		// 				inputSkill.skillId = skill.instSkill.skillId;
		// 			} else {
		// 				var skillIndex = hero.modelData.default_skill.IndexOf (skill.instSkill.skillId);
		// 				if (skillIndex >= 0) {
		// 					inputSkill.skillId = tuandui_skills [skillIndex];
		// 				} else {
		// 					inputSkill.skillId = skill.instSkill.skillId;
		// 				}
		// 			}
  //
		// 			inputSkill.skillLev = skill.instSkill.level;
		// 			inputSkill.skillOrder = skill.order;
		// 			skillInfos.Add (inputSkill);
		// 		}
		// 	}
		// 	
  //
		// 	foreach (var kv in hero.GetEquipSkills()) {
		// 		if (kv.UnLocked ()) {
		// 			InputSkill inputSkill = new InputSkill ();
		// 			inputSkill.skillId = kv.instSkill.skillId;
		// 			inputSkill.skillLev = kv.instSkill.level;
		// 			if (hero.fullPlayer.growSimplePlayer.instPlayer.robot > 0) {
		// 				inputSkill.skillOrder = kv.modelData.weigth;
		// 			} else {
		// 				inputSkill.skillOrder = kv.order;
		// 			}
		// 			skillInfos.Add (inputSkill);
		// 		}
		// 	}
  //
		// 	skillInfos.Sort (delegate(InputSkill x, InputSkill y) {
		// 		return x.skillOrder.CompareTo(y.skillOrder);	
		// 	});
		// }

	}
}

