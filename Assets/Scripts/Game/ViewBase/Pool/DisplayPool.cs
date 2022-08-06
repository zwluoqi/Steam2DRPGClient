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

    public interface IDisplayPoolObject
    {
        void AwakeFromMemory();

        void DeathToPool();

        void ActiveFromPool();

        void DeadFromMemory();
    }


    public abstract class DisplayPoolObject : IDisplayPoolObject
    {
        public void DeathToPool()
        {
            if (this.isDeath)
            {
                throw new Exception("出现严重逻辑错误，需要排查，缓存对象多次被回收");
            }
            OnDeathToPool();
            this.isDeath = true;
        }

        public void ActiveFromPool()
        {
            this.m_pool_guid = DisplayPool.GET_GUID;
            this.isDeath = false;
            OnActiveFromPool();
        }


        public void DeadFromMemory()
        {

        }

        public void AwakeFromMemory()
        {

        }

        public abstract void OnDeathToPool();

        public abstract void OnActiveFromPool();

        bool isDeath = false;

		long m_pool_guid;

		public long GetObjPoolGuid(){
			return m_pool_guid;
		}
    }

    public abstract class DisplayMonoPoolObject : SimpleMonoBehaviour, IDisplayPoolObject
    {
        public string objName = "";
        public string parentName = "";
        GameObject obj;
        Transform tra;
#if UNITY_EDITOR
        public string deathStack;
        public string activeStack;
#endif
        public void DeathToPool()
        {
			if (this.isDeath)
			{
				throw new Exception("出现严重逻辑错误，需要排查，缓存对象多次被回收");
			}

#if UNITY_EDITOR
			deathStack = this.m_pool_guid+":" + ( new System.Diagnostics.StackTrace().ToString());
//			if (this is Battle.Display.ViewSailing) {
//				Debug.LogError (" deathStack:" + deathStack);
//			}
#endif

            
            OnDeathToPool();
            this.isDeath = true;
            if (obj == null)
            {
                UnityEngine.Debug.LogError("对象误删除， parent:" + parentName + " name:" + objName);
            }
            else
            {
                obj.SetActive(false);
				tra.SetParent(null);
            }
        }

        public void ActiveFromPool()
        {

			if (!this.isDeath) {
				throw new Exception("出现严重逻辑错误，需要排查，缓存对象多次被激活");
			}
			this.m_pool_guid = DisplayPool.GET_GUID;
			#if UNITY_EDITOR
			activeStack = this.m_pool_guid+":" + ( new System.Diagnostics.StackTrace().ToString());
//			if (this is Battle.Display.ViewSailing) {
//				Debug.LogError (" activeStack:" + activeStack);
//			}
			#endif

            this.isDeath = false;
            if (obj == null)
            {
                UnityEngine.Debug.LogError("对象误删除， parent:" + parentName + " name:" + objName);
            }
            else
            {
                obj.SetActive(true);
            }
            OnActiveFromPool();
        }

        public void DeadFromMemory()
        {
            GameObject.Destroy(obj);
        }

        public void AwakeFromMemory()
        {
            obj = this.gameObject;
			tra = this.transform;
        }

        public abstract void OnDeathToPool();

        public abstract void OnActiveFromPool();

		bool isDeath = true;

		long m_pool_guid;
		public long GetObjPoolGuid(){
			return m_pool_guid;
		}
    }

    public class DisplayPool
    {
        private Type t;
        public Queue<IDisplayPoolObject> unacticedObjs;
        public int counter = 0;

        protected Func<IDisplayPoolObject> objCreator = null;
        public bool isMonoBehaviour { private set; get; }

        public DisplayPool(Type type)
        {
            t = type;
            this.unacticedObjs = new Queue<IDisplayPoolObject>();


            if (!type.IsSubclassOf(typeof(MonoBehaviour)))
            {
                objCreator = new Func<IDisplayPoolObject>(delegate ()
                {
                    var id = Activator.CreateInstance(t) as IDisplayPoolObject;
                    id.AwakeFromMemory();
                    return id;
                });
                isMonoBehaviour = true;
            }
            else
            {
                objCreator = new Func<IDisplayPoolObject>(delegate ()
                {
                    var go = new GameObject();
                    var ins = go.AddComponent(t);
                    var id = ins as IDisplayPoolObject;
                    id.AwakeFromMemory();
                    return id;
                });
                isMonoBehaviour = false;
            }
        }

        public void New(int count)
        {
            for (int i = 0; i < count; i++)
            {
                IDisplayPoolObject obj = objCreator();
                unacticedObjs.Enqueue(obj);
            }
        }


        public IDisplayPoolObject SpwanObj()
        {
            counter++;
            if (unacticedObjs.Count > 0)
            {
                IDisplayPoolObject obj = unacticedObjs.Dequeue();
                obj.ActiveFromPool();
                return obj;
            }
            else
            {

                IDisplayPoolObject obj = objCreator();
                obj.ActiveFromPool();
                return obj;
            }
        }

        public void UnSpwanObj(IDisplayPoolObject obj)
        {
//			if (obj is Battle.Display.Context.Anim.Data.OnceAnimData) {
//				BattleDebug.Error ("un spwan animdata");
//			}
            obj.DeathToPool();
            counter--;
            unacticedObjs.Enqueue(obj);
        }


        public void Clear()
        {
            counter = 0;
            foreach (var go in unacticedObjs)
            {
                go.DeadFromMemory();
            }
            unacticedObjs.Clear();
        }

        public void Log()
        {
#if DEBUG
#if DEBUG && !PROFILER
            Debug.Log("Type:" + this.t.FullName + " unactiveCount:" + unacticedObjs.Count);
#endif

#endif
        }


        public override string ToString()
        {
            return string.Format("[DisplayPool] name:{0},counter:{1},unactive:{2}", t.Name, counter, unacticedObjs.Count);
        }

        private static long _guid = 0;
        public static long GET_GUID
        {
            get
            {
                return _guid++;
            }
        }
        
    }
}






