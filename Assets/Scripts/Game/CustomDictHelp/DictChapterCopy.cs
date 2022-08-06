using System;
using System.Collections.Generic;
// using Grow;

public partial class DictChapterCopy
{

	private Dictionary<string,List<Model>> dictIndexCaches;

	public Dictionary<string,List<Model>> chapterCaches {
		get {
			if (dictIndexCaches == null) {
				InitDictIndexCaches ();
			}
			return dictIndexCaches;
		}
	}

	public List<Model> GetModels (string indexID)
	{
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
	
		return dictIndexCaches [indexID];
	}

	public void InitDictIndexCaches ()
	{
			
		dictIndexCaches = new Dictionary<string, List<Model>> ();
	
		foreach (var d in Dict) {
			if (!dictIndexCaches.ContainsKey (d.Value.chapter_id)) {
				dictIndexCaches.Add (d.Value.chapter_id, new List<Model> ());
			}
//			UnityEngine.Debug.LogError (d.Value.chapter_id);
			dictIndexCaches [d.Value.chapter_id].Add (d.Value);
		}

		foreach (var kv in dictIndexCaches) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.order.CompareTo (y.order);	
			});
		}

	}
//
// 	public Grow.UpdateData GetCopyUpdateData (string copyId, List<string> heroIds,float rewardRadio){
// //		double offline_beilv = 1;
// //		if (offline) {
// //			offline_beilv = offline_shouyi;
// //		}else{
// //			offline_beilv = 1;
// //		}
// 		var modelData = this.GetModel (copyId);
//
// 		double hero_add_reward_factors = rewardRadio;
// 		foreach (var heroId in heroIds) {
// 			if (modelData.add_reward_heros.Contains (heroId)) {
// 				var heroModel = DictDataManager.Instance.dictHeroHero.GetModel (heroId);
// 				var qulityModel = DictDataManager.Instance.dictSystemQulity.GetModel (heroModel.qulity);
// 				hero_add_reward_factors += qulityModel.copy_reward_add_factor;
// 			}
// 		}
// 		Grow.UpdateData copyUpdateData = new Grow.UpdateData ();
// 		copyUpdateData.AddPlayerPropVal (DictPlayerPropEnumString.coin, (long)(modelData.coin ));
// 		copyUpdateData.AddPlayerPropVal (DictPlayerPropEnumString.ruby, (long)(modelData.ruby ));
// 		copyUpdateData.AddPlayerExp((int)(modelData.exp * GrowFun.Ins.growFullPlayer.expMultiplying));
//
// 		foreach (var reward in modelData.rewards) {
// 			var rewardModel = DictDataManager.Instance.dictReward.GetModel (reward);
// 			if (rewardModel != null) {
// 				copyUpdateData.Add (rewardModel.class_id, rewardModel.prop_id, rewardModel.obj_id, (int)(rewardModel.obj_num * hero_add_reward_factors));
// 			}
// 		}
//
// 		foreach (var heroId in heroIds) {
// 			copyUpdateData.AddHeroExp(heroId, (int)(modelData.hero_exp * GrowFun.Ins.growFullPlayer.expMultiplying));
//
// 			if (GrowFun.Ins.randomUtil.value < modelData.xinlai_add_radio) {
// 				copyUpdateData.AddHeroXinlaiVal (heroId, 1);
// 			}
// 		}
//
//
// 		List<string> dropEquips = new List<string> ();
// 		List<string> dropGoods = new List<string> ();
// 		List<int> dropGoodNums = new List<int> ();
//
// 		foreach (var guajiDropGroup in modelData.guaji_rewardlist) {
// 			if (!string.IsNullOrEmpty (guajiDropGroup)) {
// 				GrowFun.Ins.GetCopyDrop (guajiDropGroup, ref dropEquips, ref dropGoods, ref dropGoodNums);
// 			}
// 		}
//
//
// 		GrowFun.Ins.GetCopyDrop (modelData.id, ref dropEquips, ref dropGoods, ref dropGoodNums);
//
// 		foreach (var dropEquip in dropEquips) {
// 			copyUpdateData.Add ("equip", "", dropEquip, 1);
// 		}
//
// 		for (int i = 0; i < dropGoods.Count; i++) {
// 			copyUpdateData.Add ("good", "", dropGoods [i], dropGoodNums [i]);
// 		}
//
// 		if (modelData.check_menpai_data > 0) {
// 			var list = Grow.GrowMenPai.CheckJiyuanList (modelData.check_menpai_data);
// 			copyUpdateData.AddMenpaiJiyuan(list);
// 		}
//
// 		return copyUpdateData;
// 	}
//
//     public Grow.UpdateData GetCopyUpdateData (string copyId, List<string> heroIds)
// 	{
// 		return GetCopyUpdateData (copyId, heroIds,1);	
// 	}
//
// 	public Grow.UpdateData GetOfflineBaseData (string chapterId, List<string> heroId, int battleCount)
// 	{
// //        var offline_shouyi = GrowFun.Ins.growFullPlayer.growSimplePlayer.currentVipModel.offline_shouyi;
// 		Grow.UpdateData copyUpdateData = new UpdateData ();
//
// 		List<DictChapterCopy.Model> copys = DictDataManager.Instance.dictChapterCopy.GetModels (chapterId);
//
// 		for (int i = 0; i < battleCount; i++) {
// 			int indexId = Grow.GrowFun.Ins.randomUtil.Range (0, copys.Count - 1);	
//
//             var oneCopyUpdateData = GetCopyUpdateData (copys [indexId].id, heroId,1);
// 			copyUpdateData.Add (oneCopyUpdateData);
// 		}
//
// //		copyUpdateData.EquipCost (offline_shouyi);
// //		copyUpdateData.GoodShouyi (offline_shouyi);
//
// 		return copyUpdateData;
// 	}
//
// 	public Grow.UpdateData OfflineMultiple(Grow.UpdateData copyUpdateData,double offline_shouyi){
// 		Grow.UpdateData ret = new UpdateData ();
// 		ret.Add (copyUpdateData);
//
// 		ret.EquipCost (offline_shouyi);
// 		ret.GoodShouyi (offline_shouyi);
// 		ret.PropShoyi (DictPlayerPropEnumString.coin, offline_shouyi);
// 		ret.PropShoyi (DictPlayerPropEnumString.ruby, offline_shouyi);
// 		ret.PropShoyi (DictPlayerPropEnumString.skill_point, offline_shouyi);
// 		ret.PlayerExpShouyi (offline_shouyi);
// 		ret.AddHeroExpShouyi (offline_shouyi);
// //		ret.PropShoyi(DictPlayerPropEnumString.exp, offline_shouyi);
// 		return ret;
// 	}

}