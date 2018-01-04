using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

	public GameObject fadeObject;
	public GameObject fadeObject2;
	public float waitTime;
	public float fadeTime;
	public float passedTime = 0;
	public bool fadeIn;

	bool disabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!disabled)
		{
			waitTime -= Time.deltaTime;
			passedTime += Time.deltaTime;
			if (waitTime <= 0)
			{
				float delta = Time.deltaTime / fadeTime;
				waitTime = 0;
				Material fadeMaterial = fadeObject.GetComponent<Renderer>().material;
				Material fadeMaterial2 = fadeObject2.GetComponent<Renderer>().material;
				Color newColor = fadeMaterial.color;
				if (fadeIn)
				{
					newColor.a += delta;

					if (newColor.a >= 1)
					{
						newColor.a = 1;
						disabled = true;
					}
				}
				else
				{
					newColor.a -= delta;

					if (newColor.a <= 0)
					{
						newColor.a = 0;
						disabled = true;
					}
				}

				fadeMaterial.SetColor("_Color", newColor);
				fadeMaterial2.SetColor("_Color", newColor);
			}
		}


		
	}
}
