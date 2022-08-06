using System.Collections.Generic;
using Game.View.Hero;
using UnityEngine;

namespace Game.View.Util
{
    public class TargetUtil
    {
        public ViewHero GetNearest(List<ViewHero> heroes,ViewHero source,out float targetDis,List<ViewHero> ignoreList = null)
        {
            return GetNearest(heroes,source.GetPosition(),out targetDis,ignoreList);
        }

        public ViewHero GetNearest(List<ViewHero> heroes,Vector3 pos,out float targetDis,List<ViewHero> ignoreList = null)
        {
            float minDis = float.MaxValue;
            ViewHero target = null;
            foreach (var hero in heroes)
            {
                if (hero.isDead)
                {
                    continue;
                }

                if (ignoreList != null)
                {
                    if (ignoreList.Contains(hero))
                    {
                        continue;
                    }
                }
                var dis = MathUtil2D.SqrtDistanceNoZ(pos, hero.GetPosition());
                if (dis < minDis)
                {
                    minDis = dis;
                    target = hero;
                }
            }

            targetDis = Mathf.Sqrt(minDis);
            return target;
        }
    }
}