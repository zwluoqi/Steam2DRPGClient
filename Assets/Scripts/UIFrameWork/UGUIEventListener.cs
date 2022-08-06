using UnityEngine;  
using UnityEngine.UI;  
using System.Collections;  
using UnityEngine.EventSystems;
using System.Collections.Generic;
//using LuaInterface;  


namespace XZXD.UI
{
	public class UGUIEventListener:EventTrigger  
	{  
		public delegate void VoidDelegate(GameObject go);  

		public VoidDelegate onClick ;

		public Void_GO_Bool onPress ;


		public override void OnPointerClick(PointerEventData eventData)  
		{  
			XZXDDebug.Log ("OnPointerClick " + this.gameObject);
			// SoundManager.Instance.PlayClip ("audio/ui/ui_button");

			base.OnPointerClick (eventData);
			if (onClick != null)  
				onClick(gameObject);  
		} 
		#region IPointerDownHandler implementation


		public override void OnPointerDown (PointerEventData eventData)
		{
			if (this.onPress != null) {
				this.onPress (gameObject, true);
			}
		}


		#endregion

		#region IPointerUpHandler implementation

		public override void OnPointerUp (PointerEventData eventData)
		{
			if (this.onPress != null) {
				this.onPress (gameObject, false);
			}
		}

		#endregion

 


		public static UGUIEventListener Get(GameObject go)  
		{  
			var grapic = go.GetComponent<Graphic> ();
			if (grapic != null) {
				grapic.raycastTarget = true;
			} else {
				Debug.LogError (go.name + " can not trigger ui event");
			}
			UGUIEventListener listener =go.GetComponent<UGUIEventListener>();  
			if(listener==null) listener=go.AddComponent<UGUIEventListener>();  
			return listener;  
		}  
	}  

}