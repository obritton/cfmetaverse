using UnityEngine;
using UnityEngine.UI;

using System.Collections;
namespace ZenkaARPrints{
public class Settings : MonoBehaviour {

	public float sensibility;
	public Slider sliderSensibility;

	void Start(){
		//
		SetSensibility ();

	}

	// Update is called once per frame
	void Update () {
	
	}

	public void SetSensibility(){
		this.sensibility = sliderSensibility.value;		
	}

	public void ViewElements(bool b){
		sliderSensibility.gameObject.SetActive (b);
	}
}
}