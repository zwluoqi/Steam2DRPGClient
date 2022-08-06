//using System;
//using System.Collections.Generic;
//
//public partial class DictHeroSkill
//{
//	public Dictionary<string,List<Model>> dictIndexCaches;
//	public List<Model> defaultVal = new List<Model>();
//	public List<Model> GetModels(string indexID){
//		if (dictIndexCaches == null) {
//			InitDictIndexCaches ();
//		}
//		if (dictIndexCaches.ContainsKey (indexID)) {
//			return dictIndexCaches [indexID];
//		} else {
//			return defaultVal;
//		}
//	}
//
//	public void InitDictIndexCaches(){
//		
//		dictIndexCaches = new Dictionary<string, List<Model>> ();
//
//		foreach (var d in Dict) {
//			if (!dictIndexCaches.ContainsKey (d.Value.hero_id)) {
//				dictIndexCaches.Add (d.Value.hero_id, new List<Model> ());
//			}
//			dictIndexCaches [d.Value.hero_id].Add (d.Value);
//		}
//	}
//}