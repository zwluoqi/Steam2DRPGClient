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
// * Filename:DictShopTypeFreshCost.cs
// * Created:2017/11/25
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;


public partial class DictShopTypeFreshCost
{

	public Dictionary<int, List<Model>> dictIndexCaches;

	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModels(int shopType)
	{
		if (dictIndexCaches == null)
		{
			InitDictIndexCaches();
		}
		if (dictIndexCaches.ContainsKey(shopType))
		{
			return dictIndexCaches[shopType];
		}
		else
		{
			return defaultVal;
		}
	}

	public void InitDictIndexCaches()
	{

		dictIndexCaches = new Dictionary<int, List<Model>>();

		foreach (var d in Dict)
		{
			if (!dictIndexCaches.ContainsKey(d.Value.shopType))
			{
				dictIndexCaches.Add(d.Value.shopType, new List<Model>());
			}
			dictIndexCaches[d.Value.shopType].Add(d.Value);
		}

		foreach (var kv in dictIndexCaches) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.num.CompareTo(y.num);	
			});
		}
	}
}