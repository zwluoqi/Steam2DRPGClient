using System;
using System.Collections.Generic;

public partial class DictChapterChapter
{
	private Dictionary<string, List<Model>> typeChpaters;
	private Dictionary<string, List<Model>> sceneChpaters;
	private List<Model> shilianChapters;

	public List<Model> GetSortChaptersByType(string chapaterType){
		if (typeChpaters == null) {
			Init ();
		}

		return typeChpaters[chapaterType];
	}

	public List<Model> GetSortShiLianChapters(){
		if (shilianChapters == null) {
			Init ();
		}
		return shilianChapters;
	}


	public List<Model> GetSortChaptersByScene(string sceneId){
		if (sceneChpaters == null) {
			Init ();
		}

		return sceneChpaters[sceneId];
	}

	void Init(){
		typeChpaters = new Dictionary<string, List<Model>> ();
		sceneChpaters = new Dictionary<string, List<Model>> ();
		shilianChapters = new List<Model> ();

		foreach (var kv in Dict) {
			if (!typeChpaters.ContainsKey (kv.Value.chapter_type)) {
				typeChpaters.Add (kv.Value.chapter_type, new List<Model> ());
			}
			typeChpaters[kv.Value.chapter_type].Add (kv.Value);

			if (!sceneChpaters.ContainsKey (kv.Value.map)) {
				sceneChpaters.Add (kv.Value.map, new List<Model> ());
			}
			sceneChpaters [kv.Value.map].Add (kv.Value);

			if (kv.Value.is_shilianChapter != 0) {
				shilianChapters.Add (kv.Value);
			}
		}
		foreach (var kv in typeChpaters) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.order.CompareTo(y.order);	
			});
		}

		foreach (var kv in sceneChpaters) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.order.CompareTo(y.order);	
			});
		}
		shilianChapters.Sort (delegate(Model x, Model y) {
			return x.is_shilianChapter.CompareTo(y.is_shilianChapter);
		});
	}
}

