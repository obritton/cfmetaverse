using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
 
	 public class ClockBehavior : MonoBehaviour {


	  public MicrophoneInput micro;
	  public ParticleSystem[] bubblesArray;

	  public AudioSource sound;

	  float minParticles=5;
	  float emit;


	  public GameObject thunder;
	  public GameObject umbrellaMask;

	  private float minSoundTime = 2f;
	  private float maxSoundTime = 3f;

	  public Settings settings;


	  void OnEnable(){


			GameObject settingsGO = GameObject.Find ("Settings");
			if( settingsGO != null )
				settings = settingsGO.GetComponent<Settings> ();
	   micro = GameObject.Find ("AUDIO").GetComponent<MicrophoneInput> ();

	   thunder.SetActive (false);

			if (settings != null)
				settings.gameObject.SetActive (true);

	   Invoke ("PlaySound", Random.Range (minSoundTime, maxSoundTime));
	   umbrellaMask.SetActive (true);

	  }

	  // Update is called once per frame
	  void Update () {

	   if (umbrellaMask.activeSelf) {

//		Debug.Log (micro.loudness);
				if (settings != null)
		emit = micro.loudness * settings.sensibility * 2f;

		if (emit < 2) {
		 emit = 0; 
		}

//		foreach (ParticleSystem bubbles in bubblesArray) {
//
//		 var em = bubbles.emission;
//		 em.rate = emit;
//
//		 if (sound != null)
//		 {
//		  sound.volume = emit * 0.5f;
//		 }
//		}

	   }


	  }

	  void OnDisable(){

	   CancelInvoke ("StopSound");
	   CancelInvoke ("PlaySound");
	   CancelInvoke ("EnableUmbrellaMask");
	   thunder.SetActive (false);

	  }

	  void PlaySound(){

	   thunder.SetActive (true);

	   Invoke ("StopSound", minSoundTime);

	  }

	  void EnableUmbrellaMask(){
	   thunder.SetActive (false);
	  }

	  void StopSound(){
	   thunder.SetActive (false);
	   Invoke ("PlaySound", Random.Range (minSoundTime, maxSoundTime));
	  }


	 }

}
