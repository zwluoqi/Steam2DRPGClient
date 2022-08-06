using System;
using System.Collections.Generic;

public partial class DictHeroSkillCalculate
{
	public Dictionary<string,List<Model>> dictIndexCaches;
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
			if (!dictIndexCaches.ContainsKey (d.Value.gongshi)) {
				dictIndexCaches.Add (d.Value.gongshi, new List<Model> ());
			}
			dictIndexCaches [d.Value.gongshi].Add (d.Value);
		}

		foreach (var kv in dictIndexCaches) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.order.CompareTo(y.order);	
			});
		}
	}
}