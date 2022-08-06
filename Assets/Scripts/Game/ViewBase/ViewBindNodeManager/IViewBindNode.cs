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
// * Filename:IViewBindNode.cs
// * Created:2018/9/14
// * Author:  zhouwei
// * Purpose:
// * ==============================================================================
// */
//
using System;

namespace Game.View
{
	/// <summary>
	/// 与root绑定使用的一个接口
	/// </summary>
	public interface IViewBindNode:IViewObject
    {
		// void SetRoot (IViewBindRoot root);

		IViewBindRoot root { get; set; }

		void ForceDestroy ();

		bool beDestroyed{ get; set; }
    }


}

