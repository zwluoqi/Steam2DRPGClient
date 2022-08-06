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
// * Filename:DictChapterActivityDamageReward.cs
// * Created:2020/2/15
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


public partial class DictChapterActivityDamageReward
{
	public Dictionary<string,List<Model>> dictIndexCaches;

	public List<Model> GetModels (string indexID)
	{
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}

		if (dictIndexCaches.ContainsKey (indexID)) {
			return dictIndexCaches [indexID];
		}
		return new List<Model> ();
	}

	public void InitDictIndexCaches ()
	{

		dictIndexCaches = new Dictionary<string, List<Model>> ();

		foreach (var d in Dict) {
			if (!dictIndexCaches.ContainsKey (d.Value.aActiviryId)) {
				dictIndexCaches.Add (d.Value.aActiviryId, new List<Model> ());
			}
			dictIndexCaches [d.Value.aActiviryId].Add (d.Value);
		}

		foreach (var kv in dictIndexCaches) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.order.CompareTo(y.order);
			});
		}
	}
}
