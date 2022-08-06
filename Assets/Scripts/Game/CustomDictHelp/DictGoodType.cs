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
// * Filename:DictGoodType.cs
// * Created:2019/6/13
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

public partial class DictGoodType
{
	public Dictionary<string,List<string>> topMenuGoodTypes;

	void InitCache ()
	{
		topMenuGoodTypes = new Dictionary<string, List<string>> ();
		foreach (var item in getList()) {
			if (!topMenuGoodTypes.ContainsKey (item.top_meun)) {
				topMenuGoodTypes [item.top_meun] = new List<string> ();
			}
			var goodType = DictDataManager.Instance.dictGoodType.GetModel (item.classId);
			topMenuGoodTypes [item.top_meun].Add (goodType.typeName);
		}
	}

	public List<string> GetSubGoodTypes(string topMenu){
		if (topMenuGoodTypes == null) {
			InitCache ();
		}
		return topMenuGoodTypes [topMenu];
	}

	public List<string> GetTopMenus(){
		if (topMenuGoodTypes == null) {
			InitCache ();
		}
		var s = new List<string> ();
		s.AddRange (topMenuGoodTypes.Keys);
		return  s;

	}

}
