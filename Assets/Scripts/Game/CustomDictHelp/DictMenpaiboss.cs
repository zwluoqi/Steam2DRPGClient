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
// * Filename:DictMenpaiboss.cs
// * Created:2019/4/16
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictMenpaiboss
{
    int openTotalCount = 0;
    Dictionary<int, List<Model>> caches;
    public List<Model> getListByCanwuType(int canwuType)
    {
        InitCaches();
        return caches[canwuType];
    }

    void InitCaches()
    {
        if (caches != null)
        {
            return;
        }
        var maxOpenDay = 0;
        caches = new Dictionary<int, List<Model>>();
        foreach (var kv in getList())
        {
            if (!caches.ContainsKey(kv.open_day))
            {
                caches.Add(kv.open_day, new List<Model>());
            }
            caches[kv.open_day].Add(kv);
            if(kv.open_day >maxOpenDay){
                maxOpenDay = kv.open_day;
            }
        }
        openTotalCount = maxOpenDay + 1; 
    }

    public int GetOpenDay(){
		InitCaches();
        return openTotalCount;
    }


	public bool CheckBossOpened(int minitues){
		foreach (var kv in getList()) {
			if (kv.beginTime <= minitues && kv.endTime>=minitues) {
				return true;
			}
		}
		return false;
	}

}
