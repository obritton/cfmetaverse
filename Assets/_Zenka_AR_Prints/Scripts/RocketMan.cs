using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMan : MonoBehaviour {

	private Animator animator;
	private Transform t;
	private int[] ltid;

	void Awake(){
		
		t = transform;
		animator = GetComponent<Animator> ();
		ltid = new int[4];

	}

	void OnEnable(){
		
		t.localPosition = new Vector3 (0.1855f, 0.0181f, -0.0854f);

		animator.Rebind ();
		StartCoroutine ("DoAnimation");


	}

	void OnDisable(){
		
		StopCoroutine ("DoAnimation");

		for (int i = 0; i < ltid.Length; i++) {
			LeanTween.cancel (ltid[i]);
		}

	}

	IEnumerator DoAnimation(){

		animator.SetBool ("right",true);
		animator.SetBool ("left",true);

		ltid[0] = LeanTween.moveLocal (gameObject, new Vector3 (0.299f, 0.117f, 0.0659f), 4f).id;
		yield return new WaitForSeconds (3.9f);
		while (true) {
			
			animator.SetBool ("left",true);
			animator.SetBool ("right",false);

			Vector3[] toLeft = new Vector3[] { 
				new Vector3(0.299f,0.117f,0.0659f),
				new Vector3(0.299f,0.117f,0.0659f),
				new Vector3(0.146f,0.117f,0.126f), 
				new Vector3(0.075f,0.117f,0.105f),
				new Vector3(0.075f,0.117f,0.105f)
			};

			ltid[1] = LeanTween.moveSplineLocal (gameObject, toLeft, 8.0f).setOnComplete (() => {
				
				animator.SetBool ("left",false);
				animator.SetBool ("right",true);

				ltid[2] = LeanTween.moveLocal (gameObject, new Vector3 (0.158f, 0.117f, 0.04f), 4f).setOnComplete (() => {
					ltid[3] = 	LeanTween.moveLocal (gameObject, new Vector3(0.299f,0.117f,0.0659f), 4f).setEase(LeanTweenType.linear).id;
				}).setEase(LeanTweenType.linear).id;
			}).setEase(LeanTweenType.linear).id;
			yield return new WaitForSeconds (16f);
		}

	}
			

}
