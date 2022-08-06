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
// * Filename:GetModelsByType.cs
// * Created:2019/3/17
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

public partial  class DictZhaomuZhaomuDropItem
{

	public Dictionary<int ,List<Model>> dictIndexCaches ;

	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModelsByType(int indexID){
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
			if (!dictIndexCaches.ContainsKey (d.Value.zhaomu_type)) {
				dictIndexCaches.Add (d.Value.zhaomu_type, new List<Model> ());
			}
			dictIndexCaches [d.Value.zhaomu_type].Add (d.Value);
		}
	}

}