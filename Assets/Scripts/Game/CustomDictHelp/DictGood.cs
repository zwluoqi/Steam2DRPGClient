using System;
using System.Collections;
using System.Collections.Generic;

public partial class DictGood
{
	Dictionary<string,List<Model>> typeGoods;
	List<string> allTypes;


	public List<Model> GetGoodsByType(string type){
		if (typeGoods == null) {
			InitCache ();
		}
		return typeGoods [type];
	}

	public List<string> GetAllGoodTypes(){
		if (typeGoods == null) {
			InitCache ();
		}
		return allTypes;
	}

	public void InitCache(){
		typeGoods = new Dictionary<string, List<Model>> ();
		allTypes = new List<string> ();
		foreach (var kv in Dict) {
			if (!typeGoods.ContainsKey (kv.Value.good_type)) {
				typeGoods.Add (kv.Value.good_type, new List<Model> ());
				allTypes.Add (kv.Value.good_type);
			}
			typeGoods [kv.Value.good_type].Add (kv.Value);
		}
		foreach (var kv in typeGoods) {
			kv.Value.Sort (delegate(Model x, Model y) {
				if(x.qulity != y.qulity){
					return -x.qulity.CompareTo(y.qulity);	
				}else if(x.start != y.start){
					return -x.start.CompareTo(y.start);
				}else{
					return x.id.CompareTo(y.id);
				}
			});
		}


	}

}