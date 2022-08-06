//using System;
//using System.Collections.Generic;

//public partial class DictPlayerLevelProp
//{
   
//    public Dictionary<string, List<Model>> dictIndexCaches;
//    public List<Model> GetModels(string indexID)
//    {
//        if (dictIndexCaches == null)
//        {
//            InitDictIndexCaches();
//        }

//        return dictIndexCaches[indexID];
//    }

//    public void InitDictIndexCaches()
//    {

//        dictIndexCaches = new Dictionary<string, List<Model>>();

//        foreach (var d in Dict)
//        {
//            if (!dictIndexCaches.ContainsKey(d.Value.propName))
//            {
//                dictIndexCaches.Add(d.Value.propName, new List<Model>());
//            }
//            dictIndexCaches[d.Value.propName].Add(d.Value);
//        }

//        foreach (var kv in dictIndexCaches)
//        {
//            kv.Value.Sort(delegate (Model x, Model y) {
//                return x.level.CompareTo(y.level);
//            });
//        }
//    }


//}