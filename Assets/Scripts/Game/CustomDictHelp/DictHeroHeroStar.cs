using System;
using System.Collections.Generic;

public partial class DictHeroHeroStar
{
	public Dictionary<string,Model> qulityLevs;

	public Model GetModelByHeroQulityAndStar(int qulity,int star){
		if (qulityLevs == null) {
			InitCache ();
		}
		string key = "q:" + qulity + "s:" + star;
		if (qulityLevs.ContainsKey (key)) {
			return qulityLevs [key];
		} else {
			UnityEngine.Debug.LogError (key+" not exist");
			return null;
		}

	}

	public void InitCache(){
		qulityLevs = new Dictionary<string, Model> ();
		foreach (var model in Dict) {
			qulityLevs.Add ("q:"+model.Value.quality +"s:"+ model.Value.star, model.Value);
		}
	}

}

