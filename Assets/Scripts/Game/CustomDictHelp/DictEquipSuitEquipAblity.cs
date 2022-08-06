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
// * Filename:DictEquipSuitEquipAblity.cs
// * Created:2018/5/26
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;


public partial class DictEquipSuitEquipAblity
{
	public Dictionary<string,List<Model>> suits;

	void InitCaches ()
	{
		suits = new Dictionary<string, List<Model>> ();
		foreach (var kv in m_list) {
			if (!suits.ContainsKey (kv.suit_equip_id)) {
				suits.Add (kv.suit_equip_id, new List<Model> ());
			}
			suits [kv.suit_equip_id].Add (kv);
		}
	}

	public List<Model> GetModels(string suit_equip_type){
		if(suits == null){
			InitCaches();
		}
		if (suits.ContainsKey (suit_equip_type)) {
			return suits [suit_equip_type];
		}
		return null;
	}
}


