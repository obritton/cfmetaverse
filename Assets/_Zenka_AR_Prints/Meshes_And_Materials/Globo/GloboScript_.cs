using UnityEngine;
using System.Collections;

public class GloboScript_ : MonoBehaviour
{
    Animator animGlobo;
    public float velAnimacion;

	// Use this for initialization
	void OnEnable(){
		transform.localRotation = Quaternion.Euler(180f,-90f,-90f);
		transform.localPosition = new Vector3(0.28f,0.189f,0.091f);
	}

	void Start ()
    {
        animGlobo = this.gameObject.GetComponent<Animator>();
		LeanTween.value (gameObject, (val) => {
			velAnimacion = val;
		}, .5f, 1f, 10f).setLoopPingPong(0);
		LeanTween.moveLocal(gameObject, new Vector3(0.28f,0.189f,.16f), 10f).setLoopPingPong(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
       animGlobo.speed = velAnimacion;
	}
}
