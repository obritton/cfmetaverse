using UnityEngine;
using System.Collections;

public class FakeChild : MonoBehaviour {

	public GameObject arm;

	// Use this for initialization
	void OnEnable () {
		arm.SetActive (true);
	}

	void OnDisable(){
		arm.SetActive (false);
	}
}
