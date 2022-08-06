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
// * Filename:DictEquipEquipStar.cs
// * Created:2018/4/6
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictEquipEquipStar
{


	public Model GetModelByQulityStar(int qulity,int star){
		if (qulitys == null ) {
			InitDictIndexCaches ();
		}
		if (qulitys.ContainsKey (qulity)) {
			if (qulitys [qulity].Count >= star && star > 0) {
				return qulitys [qulity] [star - 1];
			} else {
				return null;
			}
		} else {
			return null;
		}
	}

	private Dictionary<int,List<Model>> qulitys;



	public void InitDictIndexCaches(){

		qulitys = new Dictionary<int, List<Model>> ();
		foreach (var d in Dict) {
			if (!qulitys.ContainsKey (d.Value.qulity)) {
				qulitys.Add (d.Value.qulity, new List<Model> ());
			}
			qulitys [d.Value.qulity].Add (d.Value);
		}

		foreach (var kv in qulitys) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.level.CompareTo(y.level);	
			});
		}
	}



}