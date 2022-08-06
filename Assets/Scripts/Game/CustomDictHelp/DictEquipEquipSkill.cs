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
// * Filename:DictEquipEquipSkill.cs
// * Created:2018/5/6
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictEquipEquipSkill
{

	public List<Model> GetModels(string equipId){
		if (equips == null ) {
			InitDictIndexCaches ();
		}
		if (equips.ContainsKey (equipId)) {
			return equips [equipId];
		} else {
			return null;
		}
	}

	private Dictionary<string,List<Model>> equips;



	public void InitDictIndexCaches(){

		equips = new Dictionary<string, List<Model>> ();
		foreach (var d in Dict) {
			if (!equips.ContainsKey (d.Value.main_equip)) {
				equips.Add (d.Value.main_equip, new List<Model> ());
			}
			equips [d.Value.main_equip].Add (d.Value);
		}

//		foreach (var kv in qulitys) {
//			kv.Value.Sort (delegate(Model x, Model y) {
//				return x.level.CompareTo(y.level);	
//			});
//		}
	}

}

