using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {

	public GameObject target = null;  
	public bool orbitY = false;

	public float speed=100;
	public float minDistance = 10;

	float initDistance;
	Vector3 targetPos;

	void Start () {
		initDistance = minDistance;
		InvokeRepeating ("ChangeDistance", 3f, 3f);
		ChangeDistance ();
	}

	void ChangeDistance(){
		minDistance = Random.Range (initDistance - 5, initDistance + 5);
		Debug.Log (minDistance);
		targetPos = target.transform.position - Vector3.forward * minDistance;
		if (Random.Range (0, 100) < 50) {
			targetPos = target.transform.position + Vector3.forward * minDistance;
		}
		if (Random.Range (0, 100) < 50) {
			targetPos = targetPos - Vector3.up * 5;
		} else {
			targetPos = targetPos + Vector3.up * 5;
		}
	}

	void Update () 
	{
		if (target != null) 
		{
			transform.LookAt(target.transform);
			if(orbitY)
			{
				transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
			}
			float distance = Vector3.Distance (target.transform.position, transform.position);
			if (distance != minDistance) {
				//transform.Translate (transform.forward);
				float step = distance/2 * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

			}
		}
	}
}
