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
// * Filename:DictMenpaiMenpaiZhuanzhiTask.cs
// * Created:2020/3/5
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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Xor;

public partial class DictMenpaiMenpaiZhuanzhiTask
{
    
	public Dictionary<int,List<Model>> dictIndexCaches;
	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModels(int indexID){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		if (dictIndexCaches.ContainsKey (indexID)) {
			return dictIndexCaches [indexID];
		} else {
			return defaultVal;
		}
	}

	public void InitDictIndexCaches(){

		dictIndexCaches = new Dictionary<int, List<Model>> ();

		foreach (var d in Dict) {
			if (!dictIndexCaches.ContainsKey (d.Value.menpai_id)) {
				dictIndexCaches.Add (d.Value.menpai_id, new List<Model> ());
			}
			dictIndexCaches [d.Value.menpai_id].Add (d.Value);
		}

//		foreach (var kv in dictIndexCaches) {
//			kv.Value.Sort (delegate(Model x, Model y) {
//				return x.order.CompareTo(y.order);	
//			});
//		}
	}


}

