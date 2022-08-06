using System;
using System.Collections.Generic;

public partial class DictGoodBaoxiang
{

	public Dictionary<string ,List<Model>> dictIndexCaches ;

	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModels(string indexID){
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

		dictIndexCaches = new Dictionary<string, List<Model>> ();

		foreach (var d in Dict) {
			if (!dictIndexCaches.ContainsKey (d.Value.good_id)) {
				dictIndexCaches.Add (d.Value.good_id, new List<Model> ());
			}
			dictIndexCaches [d.Value.good_id].Add (d.Value);
		}
	}
}