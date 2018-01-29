using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAt : MonoBehaviour
{
	public GameObject source;
	public GameObject target;
	public GameObject clone;
	public AnimationCurve effectAngle = AnimationCurve.EaseInOut (0, 0.8f, 75, 0);
	public AnimationCurve effectTimeline = AnimationCurve.EaseInOut (0, 1, 30, 1);
	public float angleDiff;
	public float amplitude;

//	void Start ()
//	{
//		clone = Instantiate(source.gameObject, source.transform.parent);
//	}

	void LateUpdate ()
	{
		clone.transform.LookAt (target.transform.position);
		angleDiff = Quaternion.Angle(source.transform.rotation, clone.transform.rotation);
		amplitude = effectAngle.Evaluate (angleDiff)*effectTimeline.Evaluate (Time.time);
		source.transform.rotation = Quaternion.Lerp(clone.transform.rotation, source.transform.rotation, 1-amplitude);
		if(clone.gameObject.GetComponent<Renderer> ())
			clone.gameObject.GetComponent<Renderer> ().material.color = new Color (1, 1-amplitude, 1);
	}
}
