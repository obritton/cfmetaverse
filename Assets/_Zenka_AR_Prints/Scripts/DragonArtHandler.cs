using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
public class DragonArtHandler : MonoBehaviour {

	public GameObject[] elements;

	public GameObject[] sequenceInactive;
	public GameObject[] sequenceActive;

	private bool playing = false;


	void OnEnable(){

		SetElementsActive (elements,false);
		SetElementsActive (sequenceActive, false);
		SetElementsActive (sequenceInactive, true);

		if (!playing) {
			StartCoroutine("ActivateCountDown");
			playing = true;
		}

	}	


	void OnDisable(){
		
		StopCoroutine ("ActivateCountDown");
		playing = false;

	}

	IEnumerator ActivateCountDown(){

		int activePos = Random.Range(-1,2);

//		int countDown = Random.Range (15, 20);
		int countDown = Random.Range (4, 6);

		float seconds = .5f;
		float decreaseTime = seconds / countDown;

//		while (countDown > 0) {
		while(countDown > 0) {
			
			activePos++;

			if (activePos >= sequenceInactive.Length) {
				activePos = 0;
			}

			yield return new WaitForSeconds (seconds);
			SetElementsActive (sequenceActive, false);
			sequenceActive [activePos].SetActive (true);

			//decreaseTime *= 1.1f;

			countDown--;

//			if (seconds > .25f) {
//				seconds -= decreaseTime;
//			}

		}

		LeanTween.alpha (sequenceActive [activePos],0,.5f).setLoopPingPong(2);
		yield return new WaitForSeconds (2f);
//		SetElementsActive (sequenceInactive, false);
		for (int i = 0; i < sequenceInactive.Length; i++) {
			LeanTween.alpha (sequenceInactive [i], 0, 2f);
		}
		LeanTween.alpha (sequenceActive [activePos],0,2f);
//		yield return new WaitForSeconds(1f);

		elements [activePos % 2].SetActive (true);
//		elements[1].SetActive(true);
//		elements[1].transform.FindChild ("NaveEscala/navv").GetComponent<Animator> ().Play("Take 001 0",0,.138f);
//		anim.cros
	}


	void SetElementsActive(GameObject[] el, bool toggleActive){

		for (int i = 0; i < el.Length; i++) {
			el [i].SetActive (toggleActive);
		}

	}
}
}