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
// * Filename:DictSystemUiAutoLoad.cs
// * Created:2018/6/10
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictSystemUiAutoLoad
{
	public Dictionary<string,List<Model>> caches = new Dictionary<string, List<Model>>();

	public void InitCaches(){
		if (caches == null) {
			caches = new Dictionary<string, List<Model>> ();
		}
		foreach (var item in m_list) {
			var prefabName =  item.prefabName.ToLower();
			if (!caches.ContainsKey (prefabName)) {
				caches [prefabName] = new List<Model> ();
			}
			caches [prefabName] .Add (item);
		}
	}
	public List<Model> GetModels(string prefabNames){
		InitCaches ();
		List<Model> ret;
		caches.TryGetValue (prefabNames, out ret);
		return ret;
	}
}
