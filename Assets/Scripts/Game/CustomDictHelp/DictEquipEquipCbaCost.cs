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
// * Filename:DictEquipEquipCbaCost.cs
// * Created:2017/11/18
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictEquipEquipCbaCost
{

	public Dictionary<string,List<Model>> dictIndexCaches;
	public Dictionary<string,List<Model>> goodIndexCaches;
	public Dictionary<string,List<Model>> equipIndexCaches;


	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModelsByTargetEquipId(string targetEuqipId){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		if (dictIndexCaches.ContainsKey (targetEuqipId)) {
			return dictIndexCaches [targetEuqipId];
		} else {
			return defaultVal;
		}
	}


	public List<Model> GetTargetEquipsFormGoodId(string goodId){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		if (goodIndexCaches.ContainsKey (goodId)) {
			return goodIndexCaches [goodId];
		} else {
			return defaultVal;
		}
	}

	public List<Model> GetTargetEquipsFormEquipId(string equipId){
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		if (equipIndexCaches.ContainsKey (equipId)) {
			return equipIndexCaches [equipId];
		} else {
			return defaultVal;
		}
	}

	public void InitDictIndexCaches(){

		dictIndexCaches = new Dictionary<string, List<Model>> ();
		goodIndexCaches = new Dictionary<string, List<Model>> ();
		equipIndexCaches = new Dictionary<string, List<Model>> ();

		foreach (var d in Dict) {
			if (!dictIndexCaches.ContainsKey (d.Value.equip_id)) {
				dictIndexCaches.Add (d.Value.equip_id, new List<Model> ());
			}
			dictIndexCaches [d.Value.equip_id].Add (d.Value);

			if (d.Value.cost_classId == "equip") {
				if (!equipIndexCaches.ContainsKey (d.Value.cost_objId)) {
					equipIndexCaches.Add (d.Value.cost_objId, new List<Model> ());
				}
				equipIndexCaches [d.Value.cost_objId].Add (d.Value);
			} else if (d.Value.cost_classId == "good") {
				if (!goodIndexCaches.ContainsKey (d.Value.cost_objId)) {
					goodIndexCaches.Add (d.Value.cost_objId, new List<Model> ());
				}
				goodIndexCaches [d.Value.cost_objId].Add (d.Value);
			} else {

			}
		}
	}

}