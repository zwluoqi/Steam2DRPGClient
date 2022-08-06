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
// * Filename:DictGoodWucaiBaoshiAbility.cs
// * Created:2019/4/9
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictGoodWucaiBaoshiAbility
{
   
    public Dictionary<string, List<Model>> dictIndexCaches;

    public List<Model> defaultVal = new List<Model>();
    public List<Model> GetModels(string indexID)
    {
        if (dictIndexCaches == null)
        {
            InitDictIndexCaches();
        }
        if (dictIndexCaches.ContainsKey(indexID))
        {
            return dictIndexCaches[indexID];
        }
        else
        {
            return defaultVal;
        }
    }

    public void InitDictIndexCaches()
    {

        dictIndexCaches = new Dictionary<string, List<Model>>();

        foreach (var d in getList())
        {
            if (!dictIndexCaches.ContainsKey(d.goodId))
            {
                dictIndexCaches.Add(d.goodId, new List<Model>());
            }
            dictIndexCaches[d.goodId].Add(d);
        }
    }
}