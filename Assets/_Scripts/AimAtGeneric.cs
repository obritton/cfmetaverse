using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtGeneric : MonoBehaviour
{
	[System.Serializable]
	public class AimAtNode
	{
		[Tooltip ("Node should be named yournode_AimAtNode and parented to the joint you want controlled")]
		public GameObject source;
		[Tooltip ("Node should be named yournode_Helper and parented to the parent of the joint you want controlled. Disable Mesh Renderer on these nodes after debugging")]
		public GameObject helper;
		[Tooltip ("Effective angle range. Time == angle, value == effect. At 0, value should be 1, at 90 (for example), value should be 0 so we get a soft dropoff")]
		public AnimationCurve effectiveAngle = AnimationCurve.EaseInOut (0, 1, 90, 0);
		[Tooltip ("Enable/Disable aimAt in time.")]
		public AnimationCurve effectTimeline = AnimationCurve.EaseInOut (0, 1, 30, 1);
		public float angleDiff;
		public float amplitude;
	}

	public List<AimAtNode> AimAtNodes;
	public GameObject target;

	void Traverse (GameObject obj)
	{
		if (obj.name.ToLower ().Contains ("_aimatnode")) {
			Debug.Log (obj.name);
			AimAtNode aan = new AimAtNode ();
			Transform helperTransform = obj.transform.parent.transform.parent.transform.Find (obj.transform.parent.gameObject.name.ToString () + "_Helper");
			if (helperTransform == null) {
				GameObject helper = GameObject.CreatePrimitive (PrimitiveType.Cube);
				helper.transform.parent = obj.transform.parent.transform.parent;
				helper.transform.position = obj.transform.parent.position;
				helper.transform.localScale = new Vector3 (0.025f, 0.05f, 0.25f);
				helper.name = obj.transform.parent.gameObject.name.ToString () + "_Helper";
				aan.helper = helper;
			} else {
				aan.helper = obj.transform.parent.transform.parent.transform.Find (obj.transform.parent.gameObject.name.ToString () + "_Helper").gameObject;
				;
			}
			aan.source = obj;
			AimAtNodes.Add (aan);
		}
		foreach (Transform child in obj.transform) {
			Traverse (child.gameObject);
		}
	}

	// Execute when added to gameobject or reset is selected
	void Reset ()
	{
		AimAtNodes.Clear ();
		Traverse (this.gameObject);
	}

	void LateUpdate ()
	{
		foreach (AimAtNode aan in AimAtNodes) {
			GameObject source = aan.source.transform.parent.gameObject;
			aan.helper.transform.position = aan.source.transform.parent.position;	// Make sure our helper is on top of the node we want to aim
			aan.helper.transform.LookAt (target.transform);
			aan.angleDiff = Quaternion.Angle (source.transform.rotation, aan.helper.transform.rotation);
			aan.amplitude = aan.effectiveAngle.Evaluate (aan.angleDiff) * aan.effectTimeline.Evaluate (Time.time);
			source.transform.rotation = Quaternion.Lerp (aan.helper.transform.rotation, source.transform.rotation, 1 - aan.amplitude);
			if (aan.helper.gameObject.GetComponent<Renderer> ())
				aan.helper.gameObject.GetComponent<Renderer> ().material.color = new Color (1, 1 - aan.amplitude, 1);
		}
	}
}
