using UnityEngine;
using System.Collections;

public class GloboScript_ : MonoBehaviour
{
    Animator animGlobo;
    public float velAnimacion;

	// Use this for initialization
	void Start ()
    {
        animGlobo = this.gameObject.GetComponent<Animator>();
		LeanTween.value (gameObject, (val) => {
			velAnimacion = val;
		}, .5f, 1f, 10f).setLoopPingPong(0);
		LeanTween.moveZ (gameObject, .75f, 10f).setLoopPingPong(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
       animGlobo.speed = velAnimacion;
	}
}
