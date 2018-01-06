using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
public class DisableSettings : MonoBehaviour {

	public GameObject settings;

	void OnEnable(){		
		settings.SetActive (false);
	}


}
}