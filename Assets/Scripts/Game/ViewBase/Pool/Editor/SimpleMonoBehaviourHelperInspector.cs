using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace Game.View{
	
	[CustomEditor (typeof(SimpleMonoBehaviourHelper), true)]
	public class SimpleMonoBehaviourHelperInspector : Editor {


		int maxDepth = 4;

        public Dictionary<string, bool> cachesToggles = new Dictionary<string, bool>();
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			maxDepth = EditorGUILayout.IntField ("序列化最高嵌套层级：",maxDepth);
			var helper = target as SimpleMonoBehaviourHelper;
			var sm = helper.simpleMonoBehaviour;
			if (sm == null) {
				// if (GUILayout.Button ("Create ViewEffect")) {
				// 	sm = new ViewEffect ();
				// 	helper.simpleMonoBehaviour = sm;
				// }
				// if (GUILayout.Button ("Create ViewLogicShip")) {
				// 	sm = new ViewLogicShip ();
				// 	helper.simpleMonoBehaviour = sm;
    //                 (sm as ViewLogicShip).shipDataComponent = new ShipDataComponent();
				// }
				// if (GUILayout.Button ("Create ViewFleet")) {
				// 	sm = new ViewFleet ();
				// 	helper.simpleMonoBehaviour = sm;
				// }
				// if (GUILayout.Button ("Create ViewProjector")) {
				// 	sm = new ViewProjector ();
				// 	helper.simpleMonoBehaviour = sm;
				// }
				// if (GUILayout.Button ("Create ViewVirtualObject")) {
				// 	sm = new ViewVirtualObject ();
				// 	helper.simpleMonoBehaviour = sm;
				// }
				// if (GUILayout.Button ("Create ViewShotSystemProject")) {
				// 	sm = new ViewShotSystemProject ();
				// 	helper.simpleMonoBehaviour = sm;
				// }
				// if (GUILayout.Button ("Create ViewTraceObject")) {
				// 	sm = new ViewTraceObject ();
				// 	helper.simpleMonoBehaviour = sm;
				// }
    //             if (GUILayout.Button("Create CameraObject"))
    //             {
    //                 sm = new CameraObject();
    //                 helper.simpleMonoBehaviour = sm;
    //             }
    //             if (GUILayout.Button("Create ViewPetObject"))
    //             {
    //                 sm = new ViewPetObject();
    //                 helper.simpleMonoBehaviour = sm;
    //             }
                return;
			}

			SimpleViewObjectDestail (sm, 1, "");
     //        if(sm is ViewPetObject)
     //        {
     //            if (GUILayout.Button("变身"))
     //            {
     //                (sm as ViewPetObject).PetChangeBigger();
     //            }
     //            if (GUILayout.Button("还原"))
     //            {
     //                (sm as ViewPetObject).PetResumeSmall();
     //            }
     //            if (GUILayout.Button("被动技能"))
     //            {
					//
					// (sm as ViewPetObject).TriggerPSkill(10855, 1);
     //            }
     //        }
		}

		void ViewTypeVal(System.Type fType,object fVal,string fName,int depth,string space){
			fName = space + fName;
			if (fType == typeof(int)) {
				EditorGUILayout.IntField (fName, (int)fVal);
			} else if (typeof(float) == fType) {
				EditorGUILayout.FloatField (fName, (float)fVal);
			} else if (typeof(double) == fType) {
				EditorGUILayout.DoubleField (fName, (double)fVal);
			} else if (typeof(long) == fType) {
				EditorGUILayout.LongField (fName, (long)fVal);
			} else if (typeof(string) == fType) {
				EditorGUILayout.LabelField (fName, (string)fVal);
			} else if (typeof(Vector2) == fType) {
				EditorGUILayout.Vector2Field (fName, (Vector2)fVal);
			} else if (typeof(Vector3) == fType) {
				EditorGUILayout.Vector3Field (fName, (Vector3)fVal);
			} else if (typeof(Vector4) == fType) {
				EditorGUILayout.Vector4Field (fName, (Vector4)fVal);
			}  else if (typeof(System.Boolean) == fType) {
				EditorGUILayout.Toggle (fName,(bool)fVal);
			}
			else if (fType.IsEnum) {
				EditorGUILayout.EnumPopup (fName, (System.Enum)fVal);
			}
			else if (fType.IsSubclassOf (typeof(SimpleMonoBehaviour))) {
				var behaviour = fVal as SimpleMonoBehaviour;
				SimpleMonoBehaviourHelper helper = null;
				if (behaviour != null) {
					helper = behaviour.gameObject.GetComponent<SimpleMonoBehaviourHelper> ();
				} else {

				}
				EditorGUILayout.ObjectField (fName, helper, fType);
			} else if (typeof(IList).IsAssignableFrom (fType)) {
				var itemTypes = fType.GetGenericArguments ();
				Type itemType = null;
				if (itemTypes.Length > 0) {
					itemType = itemTypes [0]; 
					var itemName = itemType.Name;
                    var key = fName + " List:" + itemType.Name;
                    if (!cachesToggles.ContainsKey(key))
                    {
                        cachesToggles[key] = false;
                    }
                    cachesToggles[key] = EditorGUILayout.BeginToggleGroup (key, cachesToggles[key]);
                    if (cachesToggles[key])
                    {
                        int count = Convert.ToInt32(fVal.GetType().GetProperty("Count").GetValue(fVal, null));
                        for (int i = 0; i < count; i++)
                        {
                            var itemVal = fType.GetProperty("Item").GetValue(fVal, new object[] { i });
                            ViewTypeVal(itemType, itemVal, itemName, depth + 1, space + "\t");
                        }
                    }
                    EditorGUILayout.EndToggleGroup();
                } else if (fType.IsArray) {
					if (fVal != null) {
                        var key = fName + "数组:" + fType;
                        if (!cachesToggles.ContainsKey(key))
                        {
                            cachesToggles[key] = false;
                        }
                        cachesToggles[key] = EditorGUILayout.BeginToggleGroup(key, cachesToggles[key]);
                        if (cachesToggles[key])
                        {
                            Array a = fVal as Array;
                            for (int i = 0; i < a.Length; i++)
                            {
                                var itemVal = a.GetValue(i);
                                itemType = itemVal.GetType();
                                ViewTypeVal(itemType, itemVal, i.ToString(), depth + 1, space + "\t");
                            }
                        }
                        EditorGUILayout.EndToggleGroup();
                    } else {
						EditorGUILayout.LabelField (fName, "空数组:" + fType);
					}
				} else {
					EditorGUILayout.LabelField (fName, "泛型List没类型:" + fType);
				}

			} else if (fType == typeof(Transform)) {
				EditorGUILayout.ObjectField (fName, (Transform)fVal, fType);
			} else if (fType == typeof(GameObject)) {
				EditorGUILayout.ObjectField (fName, (GameObject)fVal, fType);
			} else  {
                var key = fName + "展开:" + fType;
                if (!cachesToggles.ContainsKey(key))
                {
                    cachesToggles[key] = false;
                }
                cachesToggles[key] = EditorGUILayout.BeginToggleGroup(key, cachesToggles[key]);
                if (cachesToggles[key])
                {
                    if (fVal != null)
                    {
                        SimpleViewObjectDestail(fVal, depth + 1, space + "\t");
                    }
                }
                EditorGUILayout.EndToggleGroup();
            }
			//else {
			//	EditorGUILayout.LabelField (fName, "暂时不支持的类型:" + fType);
			//}
		}

		void SimpleViewObjectDestail (object sm,int depth,string space)
		{
			if (depth > maxDepth) {
				return;
			}
			var type = sm.GetType ();
			var fields = type.GetFields ();
			foreach (var f in fields) {
				var fType = f.FieldType;
				var fVal = f.GetValue (sm);
				var fName = f.Name;
				ViewTypeVal (fType, fVal, fName,depth,space);
			}

            var props = type.GetProperties();
            foreach (var p in props)
            {
                var fType = p.PropertyType;
                try
                {
                    var fVal = p.GetValue(sm, null);

                    if (fVal != null)
                    {
                        var fName = p.Name;
                        ViewTypeVal(fType, fVal, fName, depth, space);
                    }
                }catch(Exception e){
                    
                }
            }
		}
	}

}