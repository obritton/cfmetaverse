using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
public class CrowsBehaviour : MonoBehaviour{

    public Pool crows;
	private bool enabled = false;
	private bool sending = false;

    public Transform originalCrow;
	private Vector3 originalCrowPosition;
	private Quaternion originalCrowRotation;
	private Vector3 originalCrowScale;

    public float minInteraction;

	private GameObject firstShowingCrow;
	private int quantity;

	public Settings settings;
	public MicrophoneInput micro;

	// Use this for initialization
	void Awake () {
		
		originalCrowPosition = originalCrow.localPosition;
		originalCrowRotation = originalCrow.localRotation;
		originalCrowScale = originalCrow.localScale;

	}

	void OnEnable(){

		
		enabled = true;
		sending = false;
//		Invoke("SendFirstCrow",.1f);

		settings = GameObject.Find ("Settings").GetComponent<Settings> ();
		micro = GameObject.Find ("AUDIO").GetComponent<MicrophoneInput> ();

   		settings.gameObject.SetActive (true);
	}

	void OnDisable(){
		
		StopCoroutine ("SendCrows");
		quantity = 0;
		enabled = false;
		sending = false;

	}
	
    
    void SendFirstCrow(){

    	firstShowingCrow = crows.GetNext();
		firstShowingCrow.transform.parent = originalCrow.parent;
		firstShowingCrow.transform.localPosition = originalCrowPosition;
		firstShowingCrow.transform.localRotation = originalCrowRotation;
		firstShowingCrow.transform.localScale = originalCrowScale;
		firstShowingCrow.SetActive(true);

    }

    void Update(){


		if (!enabled)
            return;	
		
		float v = (micro.loudness * settings.sensibility);
//		Debug.Log (settings.sensibility);

		if (v > 1 && !sending){ //firstShowingCrow != null) {
				
//			firstShowingCrow.GetComponent<Crow> ().Fly ();
//			firstShowingCrow = null;
			sending = true;
			quantity += (int)v;
			StartCoroutine ("SendCrows");

		} 

    }

    IEnumerator SendCrows(){

		GameObject crow = null;
		while (quantity > 0){
				
			yield return new WaitForSeconds (.3f);

//			if (crow != null) {
//				crow.GetComponent<Crow> ().Fly ();
//			}

			crow = crows.GetNext ();
			crow.transform.localPosition = originalCrowPosition;
			crow.transform.localRotation = originalCrowRotation;
			crow.transform.localScale = originalCrowScale;
			crow.SetActive (true);
			crow.GetComponent<Crow> ().Fly ();
			quantity--;

			yield return null;
        }
		sending = false;
//		firstShowingCrow = crow;

    }

}

}