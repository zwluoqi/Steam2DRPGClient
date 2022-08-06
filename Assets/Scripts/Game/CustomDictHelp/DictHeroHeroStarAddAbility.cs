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
// * Filename:DictHeroHeroStarAddAbility.cs
// * Created:2019/4/6
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

public partial class DictHeroHeroStarAddAbility
{
	public Dictionary<string,Model> qulityLevs;

	public Model GetModelByHeroQulityAndStarAndHeroType(int qulity,int star,int hero_type){
		if (qulityLevs == null) {
			InitCache ();
		}
		string key = "q:" + qulity + "s:" + star + "ht:" + hero_type;
		if (qulityLevs.ContainsKey (key)) {
			return qulityLevs [key];
		} else {
			UnityEngine.Debug.LogError (key+" not exist");
			return null;
		}
	}

	void InitCache(){
		qulityLevs = new Dictionary<string, Model> ();
		foreach (var model in m_list) {
			string key = "q:" +model.quality + "s:" + model.star + "ht:" + model.hero_type;
			qulityLevs.Add (key, model);
		}
	}
}

