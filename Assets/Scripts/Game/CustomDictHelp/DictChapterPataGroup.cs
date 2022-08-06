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
// * Filename:DictChapterPataGroup.cs
// * Created:2018/4/1
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictChapterPataGroup
{

	public List<Model> GetListByDays(int day){
//		if (dayDictCaches == null ) {
//			InitDictIndexCaches ();
//		}
//		if (dayDictCaches.ContainsKey (day)) {
//			return dayDictCaches [day];
//		} else {
//			return defaultVal;
//		}
		List<Model> items = new List<Model>();
		foreach (var model in getList()) {
			if (model.open_days.Contains (day)) {
				items.Add (model);
			}
		}
		return items;
	}
//
//	public Dictionary<int,List<Model>> dayDictCaches;
//
//	public List<Model> defaultVal = new List<Model>();
//
//
//	public void InitDictIndexCaches(){
//
//		dayDictCaches = new Dictionary<int, List<Model>> ();
//		foreach (var d in Dict) {
//			if (!dayDictCaches.ContainsKey (d.Value.open_day)) {
//				dayDictCaches.Add (d.Value.open_day, new List<Model> ());
//			}
//			dayDictCaches [d.Value.open_day].Add (d.Value);
//		}
//	}
}