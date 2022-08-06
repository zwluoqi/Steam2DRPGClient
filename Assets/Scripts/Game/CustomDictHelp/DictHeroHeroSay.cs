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
// * Filename:DictHeroHeroSay.cs
// * Created:2017/11/21
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictHeroHeroSay
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
    }
}