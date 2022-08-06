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
// * Filename:DictEquipEquipLevel.cs
// * Created:2019/6/8
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

public partial class DictEquipEquipLevel
{

	List<Model> GetModels(int qulity){
		if (qulityModels == null ) {
			InitDictIndexCaches ();
		}
		if (qulityModels.ContainsKey (qulity)) {
			return qulityModels [qulity];
		} else {
			return null;
		}
	}

	private Dictionary<int,List<Model>> qulityModels;


	public void InitDictIndexCaches(){

		qulityModels = new Dictionary<int, List<Model>> ();
		foreach (var d in Dict) {
			var v = d.Value;
			if (!qulityModels.ContainsKey (v.qulity)) {
				qulityModels.Add (v.qulity, new List<Model> ());
			}
			qulityModels [v.qulity].Add (v);
		}
	}

	public int GetMaxLev(int qulity){
		var models = GetModels (qulity);
		if (models == null) {
			return 1;
		} else {
			return models.Count - 1;
		}
	}


	public Model GetLevUpCost(int qulity,int lev){
		var models = GetModels (qulity);
		if (models == null) {
			return null;
		} else {
			return models [lev];
		}
	}
}

