using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
public class StaticRaven : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Animator anim = GetComponent<Animator> ();
		anim.Play("Take 001", -1, Random.Range(0.0f, 1.0f));
		anim.speed = Random.Range(.2f,.5f);
	}

}
}