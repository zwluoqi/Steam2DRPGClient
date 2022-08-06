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
// * Filename:DictGoodCompoundItem.cs
// * Created:2019/4/20
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictGoodCompoundItem
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
            if (!dictIndexCaches.ContainsKey(d.targetId))
            {
                dictIndexCaches.Add(d.targetId, new List<Model>());
            }
            dictIndexCaches[d.targetId].Add(d);
        }
    }

}
