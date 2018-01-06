using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{

	[RequireComponent(typeof(AudioSource))]
	public class MicrophoneInput : MonoBehaviour {
		
	    public float sensitivity = 100;
	    public float loudness = 0;

	    void Start() {

	        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 1, 44100);
//			iPhoneSpeaker.ForceToSpeaker ();
	        GetComponent<AudioSource>().loop = true; // Set the AudioClip to loop
	//        GetComponent<AudioSource>().mute = false; // Mute the sound, we don't want the player to hear it
	//        while (!(Microphone.GetPosition(AudioInputDevice) > 0)){} // Wait until the recording has started
	        GetComponent<AudioSource>().Play(); // Play the audio source!
	    }

	    void Update(){
	        loudness = GetAveragedVolume() * sensitivity;
	        //Debug.Log("loudness " + loudness);
	    }

	    float GetAveragedVolume()
	    { 
	        float[] data = new float[256];
	        float a = 0;
	        GetComponent<AudioSource>().GetOutputData(data,0);
	        foreach(float s in data)
	        {
	            a += Mathf.Abs(s);
	        }
	        return a/256;
	    }
	}
}