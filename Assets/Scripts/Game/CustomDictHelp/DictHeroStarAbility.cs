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
// * Filename:DictHeroStarAbility.cs
// * Created:2018/9/12
// * Author:  lucy.yijian
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;

public partial class DictHeroStarAbility
{
    public Dictionary<string, List<Model>> heroStarAbilities;

	public Dictionary<string, List<string>> heroBeAdvanceByGirls;

    public List<Model> d = new List<Model>();
	public List<string> s = new List<string>();
    public List<Model> GetModelByHero(string heroId)
    {
        if (heroStarAbilities == null)
        {
            InitCache();
        }
        if (heroStarAbilities.ContainsKey(heroId))
        {
            return heroStarAbilities[heroId];
        }
        else
        {
//            UnityEngine.Debug.LogError(heroId + " not exist");
            return d;
        }

    }

	public List<string> GetGirlsByAdvanceHeroId(string heroId){

		if (heroBeAdvanceByGirls == null)
        {
            InitCache();
        }
		if (heroBeAdvanceByGirls.ContainsKey(heroId))
        {
			return heroBeAdvanceByGirls[heroId];
        }
        else
        {
//            UnityEngine.Debug.LogError(heroId + " not exist");
            return s;
        }
    }

    public void InitCache()
    {
        heroStarAbilities = new Dictionary<string, List<Model>>();
		heroBeAdvanceByGirls = new Dictionary<string, List<string>>();
        foreach (var model in Dict)
        {
            if (!heroStarAbilities.ContainsKey(model.Value.hero_id))
            {
                heroStarAbilities.Add(model.Value.hero_id, new List<Model>());
            }
            heroStarAbilities[model.Value.hero_id].Add( model.Value);

            foreach(var heroId in model.Value.advance_heros){
				List<string> hero2girls = null;
				if (!heroBeAdvanceByGirls.TryGetValue(heroId,out hero2girls))
                {
					hero2girls = new List<string> (); 
					heroBeAdvanceByGirls.Add(heroId,hero2girls);
                }
				if (hero2girls.IndexOf (model.Value.hero_id) < 0 ) {
					hero2girls.Add (model.Value.hero_id);
				}
//                heroStarAdvanceAbilities[heroId].Add(model.Value);
            }
        }
    }
}
