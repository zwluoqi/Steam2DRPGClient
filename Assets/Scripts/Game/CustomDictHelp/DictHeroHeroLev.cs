using System;
using System.Collections.Generic;

public partial class DictHeroHeroLev
{
	public Dictionary<string,Model> qulityLevs;

	public Model GetModelByHeroQulityAndLevel(int qulity,int level){
		if (qulityLevs == null) {
			InitCache ();
		}
		string key = "q:" + qulity + "l:" + level;
		if (qulityLevs.ContainsKey (key)) {
			return qulityLevs [key];
		} else {
			return null;
		}

	}

	public void InitCache(){
		qulityLevs = new Dictionary<string, Model> ();
		foreach (var model in Dict) {
			qulityLevs.Add ("q:"+model.Value.quality +"l:"+ model.Value.level, model.Value);
		}
	}

}

