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
// * Filename:DictDongfuBuildProduce.cs
// * Created:2019/8/11
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

public partial class DictDongfuBuildProduce
{

	public List<Model> GetModels(int buildId){
		if (groupDictCaches == null ) {
			InitDictIndexCaches ();
		}
		if (groupDictCaches.ContainsKey (buildId)) {
			return groupDictCaches [buildId];
		} else {
			return defaultVal;
		}
	}

	private Dictionary<int,List<Model>> groupDictCaches;

	private List<Model> defaultVal = new List<Model>();


	public void InitDictIndexCaches(){

		groupDictCaches = new Dictionary<int, List<Model>> ();
		foreach (var d in Dict) {
			if (!groupDictCaches.ContainsKey (d.Value.build_id)) {
				groupDictCaches.Add (d.Value.build_id, new List<Model> ());
			}
			groupDictCaches [d.Value.build_id].Add (d.Value);
		}
	}
}
