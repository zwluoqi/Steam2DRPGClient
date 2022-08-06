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
// * Filename:DictShopNormal.cs
// * Created:2017/11/21
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictShopNormal
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
            if (!dictIndexCaches.ContainsKey(d.Value.shop_type))
            {
                dictIndexCaches.Add(d.Value.shop_type, new List<Model>());
            }
            dictIndexCaches[d.Value.shop_type].Add(d.Value);
        }
    }

}