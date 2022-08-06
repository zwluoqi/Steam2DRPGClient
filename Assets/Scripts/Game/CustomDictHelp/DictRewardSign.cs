using System;
using System.Collections.Generic;

public partial  class DictRewardSign
{
	public Dictionary<int ,List<Model>> dictIndexCaches ;

	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModels(int indexID){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		if (dictIndexCaches.ContainsKey (indexID)) {
			return dictIndexCaches [indexID];
		} else {
			return defaultVal;
		}
	}

	public void InitDictIndexCaches(){

		dictIndexCaches = new Dictionary<int, List<Model>> ();

		foreach (var d in Dict) {
			if (!dictIndexCaches.ContainsKey (d.Value.month)) {
				dictIndexCaches.Add (d.Value.month, new List<Model> ());
			}
			dictIndexCaches [d.Value.month].Add (d.Value);
		}
	}
}