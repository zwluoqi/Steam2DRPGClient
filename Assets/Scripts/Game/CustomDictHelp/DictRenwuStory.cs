using System;
using System.Collections.Generic;

public partial class DictRenwuStory
{

    public Dictionary<string, List<Model>> dictIndexCaches;
    public List<Model> GetModels(string indexID)
    {
        if (dictIndexCaches == null)
        {
            InitDictIndexCaches();
        }
		if (dictIndexCaches.ContainsKey (indexID)) {
			return dictIndexCaches [indexID];
		} else {
			UnityEngine.Debug.LogError ("DictRenwuStory indexId:" + indexID);
			return new List<Model> ();
		}
    }

    public void InitDictIndexCaches()
    {

        dictIndexCaches = new Dictionary<string, List<Model>>();

        foreach (var d in Dict)
        {
			if (!dictIndexCaches.ContainsKey(d.Value.storyId))
            {
				dictIndexCaches.Add(d.Value.storyId, new List<Model>());
            }
			dictIndexCaches[d.Value.storyId].Add(d.Value);
        }

        foreach (var kv in dictIndexCaches)
        {
            kv.Value.Sort(delegate (Model x, Model y) {
				return x.orderId.CompareTo(y.orderId);
            });
        }
    }

}