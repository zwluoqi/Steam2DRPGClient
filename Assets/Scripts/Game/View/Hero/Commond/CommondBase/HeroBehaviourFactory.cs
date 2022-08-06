using System;
using System.Collections.Generic;
using UnityEngine;


namespace Game.View.Hero
{
    public class HeroBehaviourFactory
    {

        public static HeroBehaviour GetBehaviour(HeroBehaviourType behaviourName)
        {
            switch (behaviourName.ToString())
            {
                case "NormalAttack":
                    return new HB_RequestAttack();
                case "StandAttack":
                    return new HB_StandAttack();
                case "LoopAttack":
                    // return new HB_LoopAttack();
                case "Idle":
                    return new HB_Idle();
                case "CircleChase":
                    // return new HB_CircleChase();
                case "LinePatrol":
                    // return new HB_LinePatrol();
                case "LinePatrol_Pos":
                    // return new HB_LinePatrol_Pos();
                case "CirclePatrol":
                    // return new HB_CirclePatrol();
                case "MoveBackToInit":
                    return new HB_MoveToInit();
                case "MoveToCopyNextPos":
                    // return new HB_MoveToCopyNextPos();
                case "TriggerMoveToTargetPos":
                    // return new HB_TriggerMoveToPos();
                case "TriggerMoveToTargerHero":
                    // return new HB_TriggerMoveToHero();
                case "TriggerCastSkill":
                    // return new HB_TriggerCastSkill();
                case "FollowTeamHead":
                    // return new HB_FollowTeamHead();
                default:
                    Debug.LogError("behaviour name error!:" + behaviourName);
                    return new HeroBehaviour();
            }
        }
    }
}
