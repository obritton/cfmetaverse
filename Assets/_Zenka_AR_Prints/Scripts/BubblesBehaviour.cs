using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
 
	public class BubblesBehaviour : MonoBehaviour {


	    public MicrophoneInput micro;
		public ParticleSystem singleBubble;
		public ParticleSystem bubbles;
	    public AudioSource sound;
	    public float maxParticles = 100;
		public Settings settings;

		private BubbleMask[] masks;
		private bool lookingForMask;

		private float emit;

		// Use this for initialization
		void Start () {

			Transform mask = transform.Find ("Masks");
			masks = new BubbleMask[mask.childCount];
			for (int i = 0; i < mask.childCount; i++) {
				masks [i] = mask.GetChild (i).GetComponent<BubbleMask>();	
			}

			lookingForMask = false;


			singleBubble.GetComponent<Renderer>().sortingLayerName = "Holo";
			singleBubble.GetComponent<Renderer>().sortingOrder = 2;

			bubbles.GetComponent<Renderer>().sortingLayerName = "Holo";
			bubbles.GetComponent<Renderer>().sortingOrder = 2;
		}

		void OnEnable(){

			GameObject settingsGO = GameObject.Find("Settings");
			if( settingsGO != null )
			settings = settingsGO.GetComponent<Settings> ();
			micro = GameObject.Find ("AUDIO").GetComponent<MicrophoneInput> ();

		}


		// Update is called once per frame
		void Update () {
			if( settings != null )
			emit = micro.loudness * settings.sensibility;

			if (emit > maxParticles) {
				emit = maxParticles;
			} else if (emit < 1) {
				emit = 0;
			}

			var em = bubbles.emission;
			em.rate = emit;

			int e = (int)emit;
			if (e > 2 && !lookingForMask) {
				lookingForMask = true;
				StartCoroutine (LookForMask(e));
			}

		}

		IEnumerator LookForMask(int count){

			while (count > 0) {
				
				int i = Random.Range (0, masks.Length);
				if (!masks [i].playing) {
					masks [i].Play ();
					count--;
				}
				yield return null;
			}
			lookingForMask = false;
			yield return null;

		}


	}
}