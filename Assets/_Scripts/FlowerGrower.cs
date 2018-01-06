using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 scale = transform.localScale;
		transform.localScale = Vector3.one * .00001f;
		iTween.ScaleTo (gameObject, scale, 20);
	}
}
