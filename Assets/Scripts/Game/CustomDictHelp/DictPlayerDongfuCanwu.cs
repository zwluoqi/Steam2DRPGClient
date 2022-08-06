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
// * Filename:DictPlayerDongfuCanwu.cs
// * Created:2018/3/18
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;
// using Grow;


public partial class DictPlayerDongfuCanwu
{
	public Dictionary<string,List<Model>> caches;
	public List<Model> getListByCanwuType(string canwuType){
		InitCaches ();
		return caches [canwuType];
	}

	void InitCaches(){
		if (caches != null) {
			return;
		}
		caches = new Dictionary<string, List<Model>> ();
		foreach (var kv in getList()) {
			if (!caches.ContainsKey(kv.dongfu_type)) {
				caches.Add (kv.dongfu_type, new List<Model> ());
			}
			caches [kv.dongfu_type].Add (kv);
		}
	}

	// public void SortTypeModels (List<DictPlayerDongfuCanwu.Model> models)
	// {
	// 	var hadCanwuIdList = GrowFun.Ins.growFullPlayer.canwuIds;
	//
	// 	models.Sort (delegate(DictPlayerDongfuCanwu.Model x, DictPlayerDongfuCanwu.Model y) {
	// 		var hadCanwux = hadCanwuIdList.Contains(x.id);
	// 		var hadCanwuy = hadCanwuIdList.Contains(y.id);
	//
	// 		var hadGoodx = Grow.GrowFun.Ins.growFullPlayer.GetGrowNum ("good", "", x.canwu_need_goodId)>0;
	// 		var hadGoody = Grow.GrowFun.Ins.growFullPlayer.GetGrowNum ("good", "", y.canwu_need_goodId)>0;
	//
	// 		if(hadCanwux != hadCanwuy){
	// 			return -hadCanwux.CompareTo(hadCanwuy);
	// 		}else if(!hadCanwux && !hadCanwuy){
	// 			if(hadGoodx != hadGoody){
	// 				return -hadGoodx.CompareTo(hadGoody);
	// 			}
	// 			else if(!hadGoodx && !hadGoody){
	// 				return x.order.CompareTo(y.order);
	// 			}
	// 			else{
	// 				return -x.order.CompareTo(y.order);
	// 			}
	// 		}else {
	// 			return -x.order.CompareTo(y.order);
	// 		}
	// 	});
	// }
}
