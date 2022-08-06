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
// * Filename:DisplayPool.cs
// * Created:2018/6/14
// * Author:  zhouwei
// * Purpose:
// * ==============================================================================
// */
//
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;



namespace Game.View
{

	/// <summary>
	/// 请其他人不要再此处添加任何代码
	/// </summary>
	public class SimpleMonoBehaviour
	{
		public GameObject gameObject {
			get;
			private set;
		}

        public virtual void OnDrawGizmos()
        {
            
        }

        public Transform transform {
			get;
			private set;
		}

		private string _name;
		public string name{
			get{
				return _name;
			}
			set{
				_name = value;
				gameObject.name = value;
			}
		}

		public SimpleMonoBehaviour(){
			this.gameObject = new GameObject ();
			this.transform = this.gameObject.transform;
			this.trans = this.transform;
            this.name = this.gameObject.GetInstanceID().ToString();
#if UNITY_EDITOR && !PROFILER
			var s = this.gameObject.AddComponent<SimpleMonoBehaviourHelper>();
			s.simpleMonoBehaviour = this;
#endif
		}

		#region 位置

		public Vector3 Position3D
		{
			get
			{
				return trans.localPosition;
			}
			set
			{
				_pos.x = value.x;
				_pos.z = value.z;
				_pos.y = value.y;
				trans.localPosition = _pos;
			}
		}

		public Transform trans;
		private Vector3 _pos;
		public Vector3 Position {
			get {
				return trans.localPosition;
			}
			set {
				_pos.x = value.x;
				_pos.z = value.z;
				_pos.y = trans.localPosition.y;
				trans.localPosition = _pos;
			}
		}

		private Vector3 _forward;
		public float EulerY {
			get {
				return trans.localEulerAngles.y;
			}
			set {
				_forward.x = trans.localEulerAngles.x;
				_forward.z = trans.localEulerAngles.z;
				_forward.y = value;
				trans.localEulerAngles = _forward;
				//				BattleDebug.LogWarning (this.name+" EulerY:"+value);
			}
		}

		public Vector3 Forward {
			get {
				return trans.forward;
			}
			set {
				trans.forward = value;
				//				BattleDebug.LogWarning (this.name+" forward:"+value.ToString());
			}
		}

		private Vector3 _scale;
		public float Scale {
			set {
				_scale.x = value;
				_scale.y = value;
				_scale.z = value;
				trans.localScale = _scale;
			}
		}

		public Vector3 logicPos;
		/// <summary>
		/// 为了避免一直报错，初始方向给一个合法值
		/// </summary>
		public Vector3 logicForward = Vector3.forward;
		#endregion

		public Vector3 savePos;
		public Vector3 saveForward;
	}
}






