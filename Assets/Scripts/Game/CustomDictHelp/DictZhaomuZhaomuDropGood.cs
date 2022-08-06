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
// * Filename:DictZhaomuZhaomuDropGood.cs
// * Created:2019/3/26
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

public partial class DictZhaomuZhaomuDropGood
{

	public Dictionary<int,List<Model>> caches;

	public List<Model> GetModelListContainType(int type_id){
		InitCache ();
		return caches [type_id];
	}

	void InitCache ()
	{
		if (caches != null) {
			return;
		}
		caches = new Dictionary<int, List<Model>> ();
		foreach (var item in getList()) {
			foreach (var type_id in item.zhaomu_types) {
				List<Model> sim = new List<Model> ();
				if (!caches.TryGetValue (type_id, out sim)) {
					sim = new List<Model> ();
					caches [type_id] = sim;
				}
				sim.Add (item);
			}
		}
	}
}
