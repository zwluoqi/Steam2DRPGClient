// /*
//                #########
//               ############
//               #############
//              ##  ###########
//             ###  ###### #####
//             ### #######   ####
//            ###  ########## ####
//           ####  ########### ####
//          ####   ###########  #####
//         #####   ### ########   #####
//        #####   ###   ########   ######
//       ######   ###  ###########   ######
//      ######   #### ##############  ######
//     #######  #####################  ######
//     #######  ######################  ######
//    #######  ###### #################  ######
//    #######  ###### ###### #########   ######
//    #######    ##  ######   ######     ######
//    #######        ######    #####     #####
//     ######        #####     #####     ####
//      #####        ####      #####     ###
//       #####       ###        ###      #
//         ###       ###        ###
//          ##       ###        ###
// __________#_______####_______####______________
//
//                 我们的未来没有BUG
// * ==============================================================================
// * Filename:DictRecharge.cs
// * Created:2019/4/14
// * Author:  lucy.yijian
// * Alert:
// * 代码千万行
// * 注释第一行
// * 命名不规范
// * 同事两行泪
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictRecharge
{
// 	Dictionary<int, List<Model>> dictIndexCaches;
// //	List<Model> others = new List<Model> ();
// 	public Dictionary<RechargeRubyPage.RechargeType ,List<Model>> typeModels;
//
// 	public List<Model> GetModels(RechargeRubyPage.RechargeType normal){
// 		if (dictIndexCaches == null)
// 		{
// 			InitDictIndexCaches();
// 		}
// 		return typeModels [normal];
// //		if (normal) {
// //			return GetModels ((int)DictRechargeTypeEnum.normal);
// //		} else {
// //			return others;
// //		}
// 	}
//
// 	List<Model> GetModels(int indexID)
// 	{
// 		if (dictIndexCaches == null)
// 		{
// 			InitDictIndexCaches();
// 		}
// 		if (dictIndexCaches.ContainsKey (indexID)) {
// 			return dictIndexCaches [indexID];
// 		} else {
// 			UnityEngine.Debug.LogError ("DictRenwuStory indexId:" + indexID);
// 			return new List<Model> ();
// 		}
// 	}
//
// 	public void InitDictIndexCaches()
// 	{
//
// 		dictIndexCaches = new Dictionary<int, List<Model>>();
// //		others = new List<Model> ();
// 		typeModels = new Dictionary<RechargeRubyPage.RechargeType, List<Model>>();
// 		typeModels [RechargeRubyPage.RechargeType.Normal] = new List<Model> ();
// 		typeModels [RechargeRubyPage.RechargeType.Gift] = new List<Model> ();
// 		typeModels [RechargeRubyPage.RechargeType.Limited] = new List<Model> ();
//
// 		foreach (var d in getList())
// 		{
// 			if (!dictIndexCaches.ContainsKey(d.recharge_type))
// 			{
// 				dictIndexCaches.Add(d.recharge_type, new List<Model>());
// 			}
// 			dictIndexCaches[d.recharge_type].Add(d);
// 			if (d.recharge_type == (int)DictRechargeTypeEnum.normal) {
// 				typeModels [RechargeRubyPage.RechargeType.Normal].Add (d);
// 			} else if (d.recharge_type == (int)DictRechargeTypeEnum.chixulibao) {
// 				typeModels [RechargeRubyPage.RechargeType.Gift].Add (d);
// 			} 
// 			else if (d.recharge_type == (int)DictRechargeTypeEnum.yueka) {
// //				typeModels [RechargeRubyPage.RechargeType.Gift].Add (d);
// 			} 
// 			else {
// 				typeModels [RechargeRubyPage.RechargeType.Limited].Add (d);
// 			}
// 		}
//
// //		foreach (var kv in dictIndexCaches)
// //		{
// //			kv.Value.Sort(delegate (Model x, Model y) {
// //				return x.orderId.CompareTo(y.orderId);
// //			});
// //		}
// 	}


}

