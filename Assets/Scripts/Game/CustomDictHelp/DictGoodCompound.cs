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
// * Filename:DictGoodCompound.cs
// * Created:2019/5/29
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

public partial class DictGoodCompound
{

	public Dictionary<int, List<Model>> caches;
	public List<int> types;

	public List<Model> getListBigEqualEquipLev(int lev,int type){
		var rets = new List<Model> ();
		//var models = DictDataManager.Instance.dictGoodCompound.getList();
		var models = GetShenqisByType(type);
		foreach (var model in models) {
			if (model.class_id == "equip") {
				var equip = DictDataManager.Instance.dictEquipEquip.GetModel (model.obj_id);
				if (lev < equip.limited_lev) {
					continue;
				} 
			}
			rets.Add (model);
		}
		return rets;
	}

	internal List<int> GetShenqiTypeList()
	{
		if(types == null)
		{
			InitData();
		}
		return types;

	}

	/// <summary>
	/// 根据类型查所有神器行
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public List<Model> GetShenqisByType(int type)
	{
		if (types == null)
		{
			InitData();
		}
		return caches[type];
	}

	private void InitData()
	{

		types = new List<int>();
		caches = new Dictionary<int, List<Model>>();
		foreach (var item in getList())
		{
			if (types.Contains(item.type))
			{

			}
			else
			{
				types.Add(item.type);
			}

			if (!caches.ContainsKey(item.type))
			{
				caches[item.type] = new List<Model>();
			}
			caches[item.type].Add(item);
		}
	}
}