// // /*
// //                #########
// //               ############
// //               #############
// //              ##  ###########
// //             ###  ###### #####
// //             ### #######   ####
// //            ###  ########## ####
// //           ####  ########### ####
// //          ####   ###########  #####
// //         #####   ### ########   #####
// //        #####   ###   ########   ######
// //       ######   ###  ###########   ######
// //      ######   #### ##############  ######
// //     #######  #####################  ######
// //     #######  ######################  ######
// //    #######  ###### #################  ######
// //    #######  ###### ###### #########   ######
// //    #######    ##  ######   ######     ######
// //    #######        ######    #####     #####
// //     ######        #####     #####     ####
// //      #####        ####      #####     ###
// //       #####       ###        ###      #
// //         ###       ###        ###
// //          ##       ###        ###
// // __________#_______####_______####______________
// //
// //                 我们的未来没有BUG
// // * ==============================================================================
// // * Filename:BattleInputModule.cs
// // * Created:2019/6/27
// // * Author:  zhouwei
// // * Alert:
// // * 代码千万行
// // * 注释第一行
// // * 命名不规范
// // * 同事两行泪
// // * Purpose:
// // * ==============================================================================
// // */
// //
// using System;
// using Battle.Display;
// using UnityEngine;
// using System.Collections.Generic;
//
// namespace Game.View
// {
// 	public class BattleInputModule
//     {
// 		public bool useKeyBoard = true;
//
//
// 		
//         /// <summary>
//         /// 控制区域正在移动
//         /// </summary>
//         public static bool moveCameraRotationArea = false;
//         public static Vector2 deltaPos;
//         public static bool useDeltaPos;
//
//         public static void Drag(Vector3 _deltaPos)
//         {
//             useDeltaPos = true;
//             deltaPos = _deltaPos;
//         }
//
// 		public void InputTick ()
// 		{
// 			if (!Application.isFocused) {
// 				return;
// 			}
//
// 			if (!useKeyBoard) {
// 				return;
// 			}
//
// 			bool operation = false;
// 			
// 			
//
//             if (useDeltaPos)
//             {
//                 useDeltaPos = false;
//             }
//             else
//             {
//                 deltaPos = Vector2.zero;
//             }
// 		}
//     }
// }
//
