using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class UnityHeroTrigger : UnityBaseTrigger2D
{
   public override UnityCollide2DType collideType
   {
      get
      {
         return UnityCollide2DType.Hero;
      }
   }

   protected override void OnAwake()
   {
      
   }
}
