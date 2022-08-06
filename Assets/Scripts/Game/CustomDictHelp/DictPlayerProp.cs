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
// * Filename:DictPlayerProp.cs
// * Created:2018/3/18
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;
using UnityEngine;

public partial class DictPlayerProp 
{

	private Dictionary<string, Model> m_str_dict;

	void InitCache(){
		if (m_str_dict != null) {
			return;
		}
		m_str_dict = new Dictionary<string, Model> ();

		foreach (var kv in m_dict) {
			m_str_dict [kv.Value.id] = kv.Value;
		}

	}

	public Model GetModel(string propId){

		InitCache ();

		if (m_str_dict == null)
		{
			Debug.LogError("DictPlayerProp m_dict Is Null");
			return null;
		}
		else
		{
			if (m_str_dict.ContainsKey(propId))
			{
				return m_str_dict[propId];
			}
			else
			{
				Debug.LogError ("error id:"+propId);
				return null;
			}
		}

	}
	public Model GetModel(DictPlayerPropEnum propId){
		return this.GetModel ((int)propId);

	}
}