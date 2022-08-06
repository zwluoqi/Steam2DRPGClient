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
// * Filename:ViewEffectManager.cs
// * Created:2018/1/6
// * Author:  zhouwei
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;
using Game.View.Manager;
using UnityEngine;


namespace Game.View
{
	public abstract class ABViewBindNodeManager<T>
		where T:IViewBindNode
	{
		

		protected List<T> projectors = new List<T> ();

		private bool paused = false;
//		protected bool tickOrder = false;

		protected abstract void IFPoolDeathToPool (ref T p);
		#region projectors

		public  void OrderUpdate (float detalTime)
		{
			if (paused)
			{
				return;
			}
			int imax = projectors.Count;
			for (int i = 0; i < imax; ) {
				var p = projectors [i];
				if (p.beDestroyed) {
					if (p.root != null)
					{
						p.root.Removed(p);
					}
					projectors.RemoveAt (i);
					IFPoolDeathToPool (ref p);
					imax--;
				} else {
					p.OrderedUpdate (detalTime);
					i++;
				}
			}

		}

		public  void Clear ()
		{
			BeforeClear ();
			int imax = projectors.Count;
			for (int i = imax - 1; i >= 0; i--) {
				var p = projectors [i];
				p.ForceDestroy ();
				IFPoolDeathToPool (ref p);
			}
			projectors.Clear ();
			paused = false;
		}

		protected virtual void BeforeClear(){

		}

		#endregion

		internal void Pause()
		{
			paused = true;
			int imax = projectors.Count;

			for (int i = imax - 1; i >= 0; i--)
			{
				projectors[i].Pause();
			}
		}

		internal void Continue()
		{
			paused = false;
			int imax = projectors.Count;

			for (int i = imax - 1; i >= 0; i--)
			{
				projectors[i].Continue();
			}
		}

		public void Hide ()
		{
			int imax = projectors.Count;

			for (int i = imax - 1; i >= 0; i--)
			{
				projectors[i].Hide();
			}
		}

		public void Show ()
		{
			int imax = projectors.Count;

			for (int i = imax - 1; i >= 0; i--)
			{
				projectors[i].Show();
			}
		}
	}

}

