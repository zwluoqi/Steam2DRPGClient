using System;
using System.Collections.Generic;
// using Grow;

namespace Battle.Input
{
	public class BattleInput
	{
		public List<InputHero> attacks = new List<InputHero> ();
		public List<InputHero> defences = new List<InputHero> ();
		public long seed;
		public Dictionary<int,double> xxoo = new Dictionary<int, double> ();
		public int maxOrder = 20;

		// public void Init ()
		// {
		// 	
		// }
		//
		//
		// public List<string> attackHeroIds {
		// 	get {
		// 		List<string> heroIds = new List<string> ();
		// 		foreach (var ih in attacks) {
		// 			heroIds.Add (ih.modelData.id);
		// 		}
		// 		return heroIds;
		// 	}
		// }
		//
		//
		// public void Init (RequestCopy requestCopy)
		// {
		// 	this.seed = System.DateTime.Now.Ticks;
		// 	this.maxOrder = int.Parse (requestCopy.chapterData.max_round);
		// 	DictChapterCopy.Model d = requestCopy.modelData;
		// 	DictChapterChapter.Model c = requestCopy.chapterData;
		// 	            
		//
		// 	if (requestCopy.teamPlayerList.Count > 0) {
		// 		SetTeamHeroData (requestCopy);
		// 	} else {
		// 		SetSelfPlayerHeroData (requestCopy);
		// 	}
		//
		//
		// 	RandomUtil randomUtil = new RandomUtil ();
		// 	randomUtil.SetSeed (this.seed);
		//
		// 	if (requestCopy.TargetIsPlayer) {
		// 		SetPlayerEnmey (requestCopy.playerUid);
		// 	} else {
		// 		SetCopyEnmey (d, c, requestCopy);
		// 	}
		// }
		//
		// void SetPlayerEnmey (long pid)
		// {
		// 	var player = Grow.GrowFun.Ins.players [pid];
		// 	NormalAttributeData girlAttribute = player.GetGirlAttributes ();
		// 	List<string> arrayHero = new List<string> ();
		// 	arrayHero.AddRange (player.growSimplePlayer.GetPlayerHeroArrays ());
		// 	for (int i = 0; i < arrayHero.Count; i++) {
		// 		if (string.IsNullOrEmpty (arrayHero [i])) {
		// 			continue;
		// 		}
		// 		var gh = player.heros [arrayHero [i]];
		// 		InputHero playerHero = new InputHero (gh, i, player.weaponAtkMask);
		// 		playerHero.inputAttribute.Add (girlAttribute);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.jingjieAttributeData);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.yueliAttributeData);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.chenghaoAttributeData);
		// 		defences.Add (playerHero);
		// 	}
		// }
		//
		// void SetSelfPlayerHeroData (RequestCopy requestCopy)
		// {
		// 	DictChapterCopy.Model d = requestCopy.modelData;
		// 	DictChapterChapter.Model c = requestCopy.chapterData;
		//
		// 	var player = Grow.GrowFun.Ins.growFullPlayer;
		//
		// 	NormalAttributeData girlAttribute = player.GetGirlAttributes ();
		//
		// 	List<string> arrayHero = new List<string> ();
		// 	if (c.chapter_type == DictChapterTypeEnumString.tianji_boss) {
		// 		arrayHero.AddRange (Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.tianji_hero_arrays);
		// 	} else if (c.chapter_type == DictChapterTypeEnumString.huodong) {
		// 		if (Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.activity_hero_arrays.Length == 0) {
		// 			arrayHero.AddRange (Grow.GrowFun.Ins.GetPlayerHeroArrays ());
		// 		} else {
		// 			arrayHero.AddRange (Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.activity_hero_arrays);
		// 		}
		// 	} else {
		// 		arrayHero.AddRange (Grow.GrowFun.Ins.GetPlayerHeroArrays ());
		// 	}
		//
		// 	for (int i = 0; i < arrayHero.Count; i++) {
		// 		if (string.IsNullOrEmpty (arrayHero [i])) {
		// 			continue;
		// 		}
		// 		InputHero playerHero = new InputHero (player.heros [arrayHero [i]], i, player.weaponAtkMask);
		// 		playerHero.inputAttribute.Add (girlAttribute);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.jingjieAttributeData);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.yueliAttributeData);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.chenghaoAttributeData);
		//
		// 		attacks.Add (playerHero);
		// 		if (c.chapter_type == DictChapterTypeEnumString.tianji_boss) {
		// 			if (Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.tianji_battle_boss_dict.ContainsKey ("player_hero_id" + playerHero.modelData.id)) {
		// 				playerHero.hpPercent = Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.tianji_battle_boss_dict ["player_hero_id" + playerHero.modelData.id];
		// 			}
		// 		} else {
		// 			double hpPercent = 0;
		// 			if (requestCopy.pataAttackHpPercents.TryGetValue (playerHero.modelData.id, out hpPercent)) {
		// 				playerHero.hpPercent = hpPercent;
		// 			}
		// 		}
		// 	}
		// }
		//
		// void SetTeamHeroData (RequestCopy requestCopy)
		// {
		// 	foreach (var kv in requestCopy.teamPlayerList) {
		// 		var pid = kv.Key;
		// 		var standPos = kv.Value;
		// 		if (pid <= 0) {
		// 			continue;
		// 		}
		// 		var player = Grow.GrowFun.Ins.battleplayers [pid];
		// 		NormalAttributeData girlAttribute = player.GetGirlAttributes ();
		// 		var gh = player.mainHero;
		// 		var attributeDictModel = DictDataManager.Instance.dictPlayerSelectHeroAttribute.GetModel ((int)player.GetLongPropValByPropEnum (DictPlayerPropEnumString.player_select_hero_attribute_id));
		//
		// 		InputHero playerHero = new InputHero (gh, standPos, player.weaponAtkMask,attributeDictModel.tuandui_skills);
		// 		playerHero.inputAttribute.Add (girlAttribute);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.jingjieAttributeData);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.yueliAttributeData);
		// 		playerHero.inputAttribute.Add (player.growSimplePlayer.chenghaoAttributeData);
		// 		attacks.Add (playerHero);
		// 	}
		// }
		//
		// void SetCopyEnmey (DictChapterCopy.Model d, DictChapterChapter.Model c, RequestCopy requestCopy)
		// {
		// 	int pos = 0;
		// 	foreach (var enemy_id in d.enemy_id) {
		// 		if (enemy_id == "null") {
		// 			pos++;
		// 			continue;
		// 		}
		// 		DictChapterEnemy.Model enmeyModel = DictDataManager.Instance.dictChapterEnemy.GetModel (enemy_id);
		// 		if (enmeyModel == null) {
		// 			pos++;
		// 			continue;
		// 		}
		// 		var defence = AddDefence (enmeyModel, pos);
		// 		if (requestCopy.enemyHpPercents.ContainsKey (pos)) {
		// 			defence.hpPercent = requestCopy.enemyHpPercents [pos];
		// 		}
		//
		// 		if (c.chapter_type == DictChapterTypeEnumString.tianji_boss) {
		// 			if (Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.tianji_battle_boss_dict.ContainsKey ("enemy_pos" + defence.pos)) {
		// 				defence.hpPercent = Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.tianji_battle_boss_dict ["enemy_pos" + defence.pos];
		// 			}
		// 		}
		//
		// 		pos++;
		//
		// 	}
		//
		// 	if (c.chapter_type == DictChapterTypeEnumString.world_boss) {
		// 		if (Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.daily_battle_boss_dict.ContainsKey (d.id)) {
		// 			defences [0].inputAttribute.add_maxhp = Grow.GrowFun.Ins.growFullPlayer.growSimplePlayer.daily_battle_boss_dict [d.id];
		// 		}
		// 	}
		// }
		//
		// public InputHero AddDefence (DictChapterEnemy.Model enmeyModel, int pos)
		// {
		// 	InputHero ih = new InputHero (enmeyModel, pos);
		//
		// 	defences.Add (ih);
		// 	return ih;
		// }

	}
}

