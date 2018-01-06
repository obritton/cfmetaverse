using UnityEngine;
using System.Collections;
using Vuforia;

namespace ZenkaARPrints{

	public class BackSoundBehavior : MonoBehaviour, ITrackableEventHandler {

	    private TrackableBehaviour mTrackableBehaviour;

		public GameObject[] sounds;

		// Use this for initialization
		void Start () {

			foreach (GameObject sound in sounds) {
				sound.SetActive (false);
			}

	        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
	        if (mTrackableBehaviour){
	            mTrackableBehaviour.RegisterTrackableEventHandler(this);
	        }

		}
		
	    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus){
	        if (newStatus == TrackableBehaviour.Status.DETECTED ||
	            newStatus == TrackableBehaviour.Status.TRACKED ||
	            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED){
				foreach (GameObject sound in sounds) {
					sound.SetActive (true);
				}
	//            sound.SetActive(true);

	        }else{
				foreach (GameObject sound in sounds) {
					sound.SetActive (false);
				}
	//            sound.SetActive(false); 
	        }
	    } 
	}

}