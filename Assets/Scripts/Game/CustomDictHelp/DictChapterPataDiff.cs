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
// * Filename:DictChapterPataDiff.cs
// * Created:2018/4/1
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictChapterPataDiff
{

	public List<Model> GetListByGroup(int group){
		if (groupDictCaches == null ) {
			InitDictIndexCaches ();
		}
		if (groupDictCaches.ContainsKey (group)) {
			return groupDictCaches [group];
		} else {
			return defaultVal;
		}
	}

	private Dictionary<int,List<Model>> groupDictCaches;

	private List<Model> defaultVal = new List<Model>();


	public void InitDictIndexCaches(){

		groupDictCaches = new Dictionary<int, List<Model>> ();
		foreach (var d in Dict) {
			if (!groupDictCaches.ContainsKey (d.Value.group)) {
				groupDictCaches.Add (d.Value.group, new List<Model> ());
			}
			groupDictCaches [d.Value.group].Add (d.Value);
		}
	}


}