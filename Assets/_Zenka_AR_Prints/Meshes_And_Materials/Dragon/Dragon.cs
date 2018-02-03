using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour {

	public bool flameEnableOnAwake;
	public GameObject[] flame;
    public AudioSource sound;


	void Awake(){
		ToggleFlameStatus (flameEnableOnAwake);

	}

	// Use this for initialization
	public void OnTriggerFlame(){

		ToggleFlameStatus (true);
		Invoke ("DeactivateFlame", 6f);
	}

    void PlayAudio() {

        
            sound.Play();
  
    }

    void DeactivateFlame(){
		ToggleFlameStatus (false);
	}

	void ToggleFlameStatus(bool status){
		for (int i = 0; i < flame.Length; i++) {
			flame[i].SetActive (status);
		}
	}
}
