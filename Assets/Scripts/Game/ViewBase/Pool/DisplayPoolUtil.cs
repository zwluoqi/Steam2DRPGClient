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
// * Filename:DisplayPoolUtil.cs
// * Created:2018/6/14
// * Author:  zhouwei
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;
using Game.View.Hero.Skill;
using UnityEngine;

namespace Game.View
{

    public class DisplayPoolUtil
    {

		public static DisplayPoolUtil displayPool = new DisplayPoolUtil();


		Dictionary<long,DisplayPool > pools = new Dictionary<long, DisplayPool>();


		public T Spwan<T>() where T :class, IDisplayPoolObject 
		{
			Type t = typeof(T);
			long hashCode = t.GetHashCode ();
			DisplayPool p = null; 
			if (!pools.TryGetValue(hashCode,out p))
			{
				p = new DisplayPool (t);
				pools[hashCode] = p;
				p.New (1);
			}

#if DEBUG && !PROFILER
			Debug.Log("Spwan:" + t.Name + " name:");
#endif


			return p.SpwanObj() as T;
		}

		public void UnSpwan<T>(ref T obj) where T :class, IDisplayPoolObject
		{
			if (obj == null)
			{
				return;
			}
			Type t = obj.GetType();
			long hashCode = t.GetHashCode ();
			DisplayPool p = null; 
			if (pools.TryGetValue(hashCode,out p))
			{
#if DEBUG && !PROFILER
				Debug.Log("unspwan:" + t.Name + " name:");
#endif


				p.UnSpwanObj(obj);
			}
			else
			{
#if DEBUG && !PROFILER
				Debug.LogError("unspwan error:" + t.Name + " name:" );
#endif

            }
            obj = null;
		}

		public void UnSpwanList<T>(List<T> objs) where T :class, IDisplayPoolObject{
			foreach (var item in objs) {
				var p = item;
				DisplayPoolUtil.displayPool.UnSpwan (ref p);
			}
			objs.Clear ();
		}
		
		public void UnSpwanDict<T>(Dictionary<long, T> objs) where T :class, IDisplayPoolObject{
			foreach (var kv in objs) {
				var p = kv.Value;
				DisplayPoolUtil.displayPool.UnSpwan (ref p);
			}
			objs.Clear ();
		}


		public void Log()
		{

		}


		public void UnSpwanAll()
		{
			foreach (var pool in pools.Values)
			{
				pool.Clear();
			}
		}

		
    }
}

