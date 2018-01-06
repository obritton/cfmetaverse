using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace ZenkaARPrints{
public class InitVuforia : MonoBehaviour {

	[SerializeField] GameObject lateInit;
	[SerializeField] GameObject arCamera;

	IEnumerator Start () {
		VuforiaRuntime.Instance.InitVuforia ();

		yield return new WaitForSeconds (0.2f);
		arCamera.SetActive (true);

		yield return new WaitForSeconds (0.2f);
		lateInit.SetActive (true);
	}

}
}