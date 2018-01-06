using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
public class JazzMaskScript : MonoBehaviour {

	private SpriteRenderer sprite;
	private string[] imageNames;

	private bool running = false;
	void Awake(){
		
		sprite = GetComponent<SpriteRenderer> ();

		running = false;

		imageNames = new string[]{ "blue","green","original","purple","red"};

	}

	void OnEnable(){
		
		running = false;
		ChangeColor ();

	}

	void OnDisable(){
		
		running = false;
//		StopCoroutine ("PerformAlpha");
//		CancelInvoke ("ChangeColor");


	}


	void ChangeColor(){

		if (running)
			return;
		
		running = true;

		string iname = "Zenka/Music/" + imageNames [Random.Range (0, imageNames.Length)];
		Sprite s = Resources.Load<Sprite> (iname);
		sprite.sprite = s;

		float animSeconds = 4f;
		LeanTween.alpha (this.gameObject, 1, animSeconds).setEase (LeanTweenType.easeInOutSine).setLoopPingPong(1).setOnComplete(complete=>{ running = false; ChangeColor(); });

//		StartCoroutine ("PerformAlpha");

	}

	IEnumerator PerformAlpha(){

		float animSeconds = 4f;

		LeanTween.alpha (this.gameObject, 1, animSeconds).setEase (LeanTweenType.easeInCubic);
		yield return new WaitForSeconds (animSeconds * 1.5f);
		LeanTween.alpha (this.gameObject, 0, animSeconds).setEase (LeanTweenType.easeInCubic);
		yield return new WaitForSeconds (animSeconds);		

		running = false;
		ChangeColor ();

	}

}
}