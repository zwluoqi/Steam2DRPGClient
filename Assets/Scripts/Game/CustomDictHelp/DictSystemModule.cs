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
// * Filename:DictSystemModule.cs
// * Created:2020/3/29
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

public partial class DictSystemModule
{
	 Dictionary<string,List<Model>> pages = new Dictionary<string, List<Model>>();

	List<Model> sortLists = new List<Model>();
	public List<Model> GetSortModelByPage(string page){
		InitCache ();
		return pages [page];
	}
	public List<Model> GetSortModels(){
		InitCache ();
		return sortLists;
	}

	void InitCache ()
	{
		if (pages.Count != 0) {
			return;
		}
		sortLists.AddRange (getList ());
		foreach (var item in getList()) {
			if (string.IsNullOrEmpty (item.fun_page)) {
				continue;
			}
			if (!pages.ContainsKey (item.fun_page)) {
				pages [item.fun_page] = new List<Model> ();
			}
			pages [item.fun_page].Add (item);
		}
		foreach (var kv in pages) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.open_lev.CompareTo(y.open_lev);	
			});
		}

		sortLists.Sort (delegate(Model x, Model y) {
			return x.open_lev.CompareTo(y.open_lev);	
		});
	}
}