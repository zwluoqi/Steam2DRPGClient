//using System;
//using System.Collections.Generic;
//
//
//public partial class DictRewardTaskDrop
//{
//
//	public Dictionary<string,List<Model>> dictIndexCaches;
//	public List<Model> GetModels(string indexID){
//		if (dictIndexCaches == null) {
//			InitDictIndexCaches ();
//		}
//
//		if (dictIndexCaches.ContainsKey (indexID)) {
//			return dictIndexCaches [indexID];
//		}
//		return new List<Model>();
//	}
//
//	public void InitDictIndexCaches(){
//
//		dictIndexCaches = new Dictionary<string, List<Model>> ();
//
//		foreach (var d in Dict) {
//			if (!dictIndexCaches.ContainsKey (d.Value.task_id)) {
//				dictIndexCaches.Add (d.Value.task_id, new List<Model> ());
//			}
//			dictIndexCaches [d.Value.task_id].Add (d.Value);
//		}
//	}
//
//}
