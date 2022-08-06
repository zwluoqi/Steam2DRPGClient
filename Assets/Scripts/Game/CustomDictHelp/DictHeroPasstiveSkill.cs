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
// * Filename:DictHeroPasstiveSkill.cs
// * Created:2019/8/9
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

public partial class DictHeroPasstiveSkill
{
	public Dictionary<string, List<Model>> dictIndexCaches;

	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModels(string heroId)
	{
		if (dictIndexCaches == null)
		{
			InitDictIndexCaches();
		}
		if (dictIndexCaches.ContainsKey(heroId))
		{
			return dictIndexCaches[heroId];
		}
		else
		{
			return defaultVal;
		}
	}

	public void InitDictIndexCaches()
	{

		dictIndexCaches = new Dictionary<string, List<Model>>();

		foreach (var d in Dict)
		{
			if (!dictIndexCaches.ContainsKey(d.Value.hero_id))
			{
				dictIndexCaches.Add(d.Value.hero_id, new List<Model>());
			}
			dictIndexCaches[d.Value.hero_id].Add(d.Value);
		}

		foreach (var kv in dictIndexCaches) {
			kv.Value.Sort (delegate(Model x, Model y) {
				return x.hero_star.CompareTo(y.hero_star);	
			});
		}
	}

}