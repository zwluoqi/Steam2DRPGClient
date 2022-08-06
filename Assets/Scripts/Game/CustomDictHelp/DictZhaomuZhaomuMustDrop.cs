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
// * Filename:DictZhaomuZhaomuMustDrop.cs
// * Created:2020/2/16
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

public partial  class DictZhaomuZhaomuMustDrop
{
	
	public Dictionary<int ,List<Model>> dictIndexCaches;

	public List<Model> defaultVal = new List<Model> ();

	public List<Model> GetModelsByType (int indexID)
	{
		if (dictIndexCaches == null) {
			InitDictIndexCaches ();
		}
		if (dictIndexCaches.ContainsKey (indexID)) {
			return dictIndexCaches [indexID];
		} else {
			return defaultVal;
		}
	}

	public void InitDictIndexCaches ()
	{

		dictIndexCaches = new Dictionary<int, List<Model>> ();

		foreach (var d in getList()) {
			if (!dictIndexCaches.ContainsKey (d.zhaomu_types)) {
				dictIndexCaches.Add (d.zhaomu_types, new List<Model> ());
			}
			dictIndexCaches [d.zhaomu_types].Add (d);
		}
	}
}


