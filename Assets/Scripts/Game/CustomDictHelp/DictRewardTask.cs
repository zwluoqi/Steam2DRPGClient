using System;
using System.Collections.Generic;


public partial class DictRewardTask
{

	private Dictionary<string,List<Model>> dictIndexCaches;

	private Dictionary<string,Dictionary<string,List<Model>>> show_taggles = new Dictionary<string, Dictionary<string, List<Model>>>();

	private Dictionary<string,List<Model>> defaultCaches = new Dictionary<string, List<Model>> ();


	public List<Model> GetTasksByGroup(string groupId){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		return dictIndexCaches [groupId];
	}

	public Dictionary<string,List<Model>> GetShowTaggle(string taggle){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		Dictionary<string,List<Model>> ret;
		if (show_taggles.TryGetValue (taggle, out ret)) {
			return ret;
		}
		return defaultCaches;
	}

	public Dictionary<string,List<Model>> TaskDict{
		get{
			if (dictIndexCaches == null) {
				InitDictIndexCaches ();
			}
			return dictIndexCaches;
		}
	}


	public void InitDictIndexCaches(){

		dictIndexCaches = new Dictionary<string, List<Model>> ();

		foreach (var d in Dict) {
			var key = d.Value.group;

			if (!dictIndexCaches.ContainsKey (key)) {
				dictIndexCaches.Add (key, new List<Model> ());
			}
			dictIndexCaches [key].Add (d.Value);
		}

		foreach (var kv in dictIndexCaches) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.order.CompareTo(y.order);	
			});
		}

		foreach (var kv in dictIndexCaches) {
			var val = kv.Value [0];

			if (val.trigger_enum == (int)DictRewardTaskTriggerEnum.reward_check
				|| val.trigger_enum == (int)DictRewardTaskTriggerEnum.reward_random_check) {
				Dictionary<string,List<Model>> taggle_group;
				if (!show_taggles.TryGetValue (val.show_toggle,out taggle_group)) {
					taggle_group = new Dictionary<string, List<Model>> ();
					show_taggles [val.show_toggle] = taggle_group;
				}
				taggle_group.Add (kv.Key, kv.Value);
			}

		}
	}
}