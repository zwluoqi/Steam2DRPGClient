//// /*
////                #########
////               ############
////               #############
////              ##  ###########
////             ###  ###### #####
////             ### #######   ####
////            ###  ########## ####
////           ####  ########### ####
////          ####   ###########  #####
////         #####   ### ########   #####
////        #####   ###   ########   ######
////       ######   ###  ###########   ######
////      ######   #### ##############  ######
////     #######  #####################  ######
////     #######  ######################  ######
////    #######  ###### #################  ######
////    #######  ###### ###### #########   ######
////    #######    ##  ######   ######     ######
////    #######        ######    #####     #####
////     ######        #####     #####     ####
////      #####        ####      #####     ###
////       #####       ###        ###      #
////         ###       ###        ###
////          ##       ###        ###
//// __________#_______####_______####______________
////
////                 我们的未来没有BUG
//// * ==============================================================================
//// * Filename:DictPlayerXiuweiLevCondition.cs
//// * Created:2018/3/19
//// * Author:  lucy.yijian
//// * Purpose:
//// * ==============================================================================
//// */
////
//using System;
//using System.Collections.Generic;
//
//public partial class DictPlayerXiuweiLevCondition
//{
//
//	public Dictionary<int, List<Model>> dictIndexCaches;
//	public List<Model> GetModels(int indexID)
//	{
//		if (dictIndexCaches == null)
//		{
//			InitDictIndexCaches();
//		}
//		if (dictIndexCaches.ContainsKey (indexID)) {
//			return dictIndexCaches [indexID];
//		} else {
//			UnityEngine.Debug.LogError ("DictRenwuStory indexId:" + indexID);
//			return new List<Model> ();
//		}
//	}
//
//	public void InitDictIndexCaches()
//	{
//
//		dictIndexCaches = new Dictionary<int, List<Model>>();
//
//		foreach (var d in Dict)
//		{
//			if (!dictIndexCaches.ContainsKey(d.Value.level))
//			{
//				dictIndexCaches.Add(d.Value.level, new List<Model>());
//			}
//			dictIndexCaches[d.Value.level].Add(d.Value);
//		}
//
//		foreach (var kv in dictIndexCaches)
//		{
////			kv.Value.Sort(delegate (Model x, Model y) {
////				return x.orderId.CompareTo(y.orderId);
////			});
//		}
//	}
//}