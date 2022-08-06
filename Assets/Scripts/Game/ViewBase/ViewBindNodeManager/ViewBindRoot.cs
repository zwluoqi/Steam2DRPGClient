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
// * Filename:ABViewBindRoot.cs
// * Created:2018/9/14
// * Author:  zhouwei
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;
using Game.View.Manager;

namespace Game.View
{
	public class ViewBindRoot:IViewBindRoot
    {
		public List<IViewBindNode> viewBindNodes = new List<IViewBindNode> ();


		#region IViewBindRoot implementation
		public void Removed(IViewBindNode vp)
		{
			viewBindNodes.Remove (vp);
			vp.root = null;
		}
		#endregion


		public void AddNode (IViewBindNode vp)
		{
			vp.root = this;
			viewBindNodes.Add (vp);
		}


		public void Pause ()
		{
			foreach (var sp in this.viewBindNodes) {
				if (sp == null) {
					continue;
				}
				sp.Pause ();
			}
		}

		public void Continue ()
		{
			foreach (var sp in this.viewBindNodes) {
				if (sp == null) {
					continue;
				}
				sp.Continue ();
			}
		}

		public void DestroyItems ()
		{
			List<IViewBindNode> nodes = new List<IViewBindNode>();
			nodes.AddRange (this.viewBindNodes);
			this.viewBindNodes.Clear ();
			foreach (var item in nodes) {
				item.ForceDestroy ();
			}
		}

    }
}

