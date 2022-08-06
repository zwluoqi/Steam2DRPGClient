using System;
using System.Collections.Generic;

public partial class DictHeroHero
{
	public Dictionary<string ,List<DictHeroSkill.Model>> heroSkills = new Dictionary<string, List<DictHeroSkill.Model>> ();

	private List<Model> playerHeros;
	private List<Model> playerGirls;
	private List<Model> initSelectHeros;

	void InitCache(){
		if (playerHeros != null) {
			return;
		}

		playerHeros = new List<Model> ();
		playerGirls = new List<Model> ();
		initSelectHeros = new List<Model> ();

		foreach (var model in Dict) {
			if (model.Value.can_has != 1) {
				continue;
			}
			if (model.Value.hero_class == (int)DictHeroHeroClassEnum.hero) {
				playerHeros.Add (model.Value);
			}
			if (model.Value.hero_class == (int)DictHeroHeroClassEnum.girl) {
				playerGirls.Add (model.Value);
			}
			if (model.Value.init_select > 0) {
				initSelectHeros.Add (model.Value);
			}

		}
	}


	public List<DictHeroSkill.Model> GerHeroSKillModels (string heroID)
	{
		if (heroSkills.ContainsKey (heroID)) {
			return heroSkills [heroID];
		} else {
			var tmp = new List<DictHeroSkill.Model> ();
			heroSkills.Add (heroID, tmp);
			var heroModel = DictDataManager.Instance.dictHeroHero.GetModel (heroID);
			foreach (var skill in heroModel.default_skill) {
				tmp.Add (DictDataManager.Instance.dictHeroSkill.GetModel (skill));
			}
			return tmp;
		}
	}

	public List<Model> GetPlayerHeros(){
		InitCache ();
		return playerHeros;
	}

	public List<Model> GetInistSelectHeros ()
	{
		InitCache ();
		return initSelectHeros;
	}

	// public List<Model> GetPlayerSortGirls ()
	// {
	// 	InitCache ();
	// 	List<Model> sortedHero = new List<Model> ();
	// 	sortedHero.AddRange (playerGirls);
	// 	Grow.GrowFun.Ins.SortGirls (sortedHero);
	// 	return sortedHero;
	// }
}
