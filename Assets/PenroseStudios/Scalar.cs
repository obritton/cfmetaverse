using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalar : MonoBehaviour {

	float targetScale;
	float timer = 0;
	public float waitTime = 0.5f;
	public bool scaleDown = false;
	float startScale;
	public float scaleSpeed = 1.75f;
	// Use this for initialization
	void Start () {
		if (!scaleDown)
		{
			targetScale = transform.localScale.x;
			transform.localScale = Vector3.zero;
		}
		else
		{
			startScale = 0.12f;
			targetScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		waitTime -= Time.deltaTime;

		if (waitTime <= 0)
		{
			waitTime = 0;
			timer += (Time.deltaTime / scaleSpeed);
			if (timer < 1)
			{
				float scale = 0;

				if (!scaleDown)
					scale = easeOutElastic(0, targetScale, timer);
				else
					scale = easeOutQuad(startScale, 0, timer);

				Vector3 newScale = new Vector3(scale, scale, scale);
				transform.localScale = newScale;
			}
			else
				timer = 1;
		}
	}

	/* GFX47 MOD START */
	//public float elastic(float start, float end, float value){
	public float easeOutElastic(float start, float end, float value)
	{
		/* GFX47 MOD END */
		//Thank you to rafael.marteleto for fixing this as a port over from Pedro's UnityTween
		end -= start;

		float d = 1f;
		float p = d * .7f;
		float s = 0;
		float a = 0;

		if (value == 0) return start;

		if ((value /= d) == 1) return start + end;

		if (a == 0f || a < Mathf.Abs(end))
		{
			a = end;
			s = p * 0.25f;
		}
		else
		{
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}

		return (a * Mathf.Pow(2, -8 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
	}

	public float easeOutQuad(float start, float end, float value)
	{
		end -= start;
		return -end * value * (value - 2) + start;
	}
}
