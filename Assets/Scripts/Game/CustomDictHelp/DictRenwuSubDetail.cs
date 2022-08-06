using System;
using System.Collections.Generic;

public partial class DictRenwuSubDetail
{

	public Dictionary<string,List<Model>> dictIndexCaches;
	public List<Model> GetModels(string indexID){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}

		return dictIndexCaches [indexID];
	}

	public void InitDictIndexCaches(){

		dictIndexCaches = new Dictionary<string, List<Model>> ();

		foreach (var d in Dict) {
			if (!dictIndexCaches.ContainsKey (d.Value.sub_id)) {
				dictIndexCaches.Add (d.Value.sub_id, new List<Model> ());
			}
			dictIndexCaches [d.Value.sub_id].Add (d.Value);
		}

		foreach (var kv in dictIndexCaches) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.order.CompareTo(y.order);	
			});
		}
	}

}