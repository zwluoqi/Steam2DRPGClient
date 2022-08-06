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
// // * Filename:ViewEffectManager.cs
// // * Created:2018/1/6
// // * Author:  zhouwei
// // * Purpose:
// // * ==============================================================================
// // */
// //
// using System;
// using Battle.Communication;
// using System.Collections.Generic;
// using UnityEngine;
//
//
// namespace Game.View
// {
// 	public class ViewEffectManager:ABViewBindNodeManager<ViewEffect>
//     {
// 		public static ViewEffectManager CreateOneVEManager(Transform parent, DisplayPoolUtil pool)
//         {
// 			var go = (new GameObject ("viewEffectManager"));
// 			var viewEffectManager = new ViewEffectManager ();
// 			viewEffectManager.effectTrans = go.transform;
//             viewEffectManager.displayPool = pool;
// 			UnityTools.SetParent (viewEffectManager.effectTrans, parent);
// 			return viewEffectManager;
// 		}
//
//         public DisplayPoolUtil displayPool;
//         public Transform effectTrans;
//
// 		#region implemented abstract members of ABViewBindNodeManager
//
//
// 		protected override void IFPoolDeathToPool (ref ViewEffect p)
// 		{
// 			displayPool.UnSpwan (ref p);
// 		}
//
//
// 		#endregion
//
// 		#region viewEffects
//
//
// 		/// <summary>
// 		/// 通用创建特效api
// 		/// </summary>
// 		/// <returns>The effect.</returns>
// 		/// <param name="display">Display.</param>
// 		/// <param name="uri">URI.</param>
// 		/// <param name="duration">Duration.</param>
// 		/// <param name="parent">Parent.</param>
// 		public  ViewEffect CreateByUri ( string uri, float duration, Transform parent,int layer = 0)
// 		{
// 			var ve = displayPool.Spwan<ViewEffect> ();
// 			UnityTools.SetParent (ve.transform, parent);
// 			projectors.Add(ve);
// 			ve.Init ( uri, duration,parent,layer);
// 			ve.LoadModel ();
//
// 			return ve;
// 		}
//
// 		/// <summary>
// 		/// 通用创建特效api
// 		/// </summary>
// 		/// <returns>The effect.</returns>
// 		/// <param name="display">Display.</param>
// 		/// <param name="uri">URI.</param>
// 		/// <param name="duration">Duration.</param>
// 		/// <param name="parent">Parent.</param>
// 		public  ViewEffect CreateByEffectDictId ( string effectDictId,Transform parent,int layer = 0)
// 		{
// 			var effectData = Dict.Blo.DictEffectBlo.GetEffect (effectDictId);
//             if (effectData.audio_switch == 1)
//             {
//                 string audioEvent = "Effect_" + effectDictId;
//                 SoundManager.Instance.PlayAudio(audioEvent);
//             }
//             string uri =  effectData.effect_model;
// 			float duration =  effectData.duration;
// 			var ve = this.CreateByUri (uri,duration, parent,layer);
// 			return ve;
// 		}
//
//
// 		public  ViewEffect CreateBindEffect (string effectBindDictId, GameObject model,int layer = 0)
// 		{
// 			var ebData = Dict.Blo.DictEffectBindBlo.GetEffectBind (effectBindDictId);
//
// 			var effectData = Dict.Blo.DictEffectBlo.GetEffect (ebData.effect_id);
//             if (effectData.audio_switch == 1)
//             {
//                 string audioEvent = "Effect_" + effectData.e_id;
//                 SoundManager.Instance.PlayAudio(audioEvent);
//             }
// 			string uri = effectData.effect_model;
// 			Transform bindTrans = GetEffectBindTransform (model, ebData.ebp_id);
// 			if (bindTrans == null) {
// 				bindTrans = model.transform;
// 				Debug.LogError ("无法找到特效绑定点："+ebData.ToString());
// 			}
// 			Transform moveTrans = GetEffectBindTransform (model, ebData.move_ebp_id);
// 			var ve = displayPool.Spwan<ViewEffect> ();
// 			Transform tran = ve.transform;
// 			UnityTools.SetParent (tran, this.effectTrans);
// 			projectors.Add ( ve);
// 			ve.InitForBindEffect ( uri, effectData.duration, ebData, bindTrans, moveTrans,layer);
// 			ve.LoadModel ();
// 			return ve;
// 		}
//
// 		private  Transform GetEffectBindTransform (GameObject actor, string ebpId)
// 		{
// 			if (string.IsNullOrEmpty(ebpId) || ebpId.Equals ("-1")) {
// 				return null;
// 			} else {
// 				string path = Dict.Blo.DictEffectBindPathBlo.GetEffectBindPathValue (ebpId);
// 				Transform bindTrans = actor.transform.SuperFind (path);
// 				return bindTrans;
// 			}
// 		}
//
// 		public ViewEffect GetViewEffectByUri (string url)
// 		{
// 			for (int i = 0; i < projectors.Count; i++) {
// 				if (projectors [i].uri == url) {
// 					return projectors [i];
// 				}
// 			}
// 			return null;
// 		}
// 		#endregion
//     }
// }
//
