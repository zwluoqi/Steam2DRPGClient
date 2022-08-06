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
// * Filename:DictHeroRelation.cs
// * Created:2020/2/8
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Xor;

public partial class DictHeroRelation
{

	Dictionary<string, List<Model>> caches;
	List<string> orderSources;

	public List<string> getOrdeRelationSources ()
	{
		InitCache ();	
		return orderSources;
	}

	public List<Model> getRelationsByTargets(string source){
		InitCache ();	
		return caches[source];
	}

	void InitCache ()
	{
		if (caches == null) {
			caches = new Dictionary<string, List<Model>> ();
			orderSources = new List<string> ();
			foreach (var item in getList()) {
				if(!caches.ContainsKey(item.heroId)){
					caches [item.heroId] = new List<Model> ();
					orderSources.Add (item.heroId);
				}
				caches [item.heroId].Add (item);
			}

			orderSources.Sort (delegate(string x, string y) {
				var xs = caches[x];
				var ys = caches[y];
				return -xs.Count.CompareTo(ys.Count);
			});
		}
	}
}

