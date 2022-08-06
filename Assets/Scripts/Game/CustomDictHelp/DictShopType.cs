﻿// /*
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
// * Filename:DictShopType.cs
// * Created:2018/3/29
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictShopType
{
  
	List<Model>  _defaultShowList = new List<Model>();
	public List<Model> getDefaultShowList(){
		if (_defaultShowList.Count == 0) {
			InitCache ();
		}
		return _defaultShowList;
	}

	void InitCache ()
	{
		_defaultShowList.Clear ();
		foreach (var item in getList()) {
			if (item.default_show != 0) {
				_defaultShowList.Add (item);
			}
		}
	}
}
