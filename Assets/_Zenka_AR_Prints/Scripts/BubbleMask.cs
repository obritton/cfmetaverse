using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
 
	public class BubbleMask : MonoBehaviour {

		private Vector3 initialPosition;
		public Vector3 endPosition;

		public bool playing;

		// Use this for initialization
		void Awake () {
			initialPosition = transform.localPosition;
			playing = false;
		}
		
		public void Play(){
			
			playing = true;
			LeanTween.moveLocal (this.gameObject, endPosition, .5f).setOnComplete(
				complete=>{
					LeanTween.moveLocal (this.gameObject, initialPosition,2f).setOnComplete(activate=>{playing=false;});
				}
			);

		}
	}

}