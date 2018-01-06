using UnityEngine;
using System.Collections;
namespace ZenkaARPrints{
public class Loader : MonoBehaviour {

	public string resource;
	private GameObject child;

	public Settings settings;
	public bool activeOnEnable;
	public bool updatePositionAndRotation = true;
	void OnEnable(){

		settings.ViewElements (activeOnEnable);

		child = Instantiate(Resources.Load<GameObject> (resource),transform) as GameObject;
//		child.transform.parent = transform;
		if (updatePositionAndRotation) {
			child.transform.position = new Vector3 (0, 0, 0);
			child.transform.rotation = Quaternion.Euler (0, 0, 0);
			child.transform.localScale = new Vector3 (1, 1, 1);

		}

		child.SetActive (true);


	}

	void OnDisable(){		
		Destroy (child);
	}

}
}