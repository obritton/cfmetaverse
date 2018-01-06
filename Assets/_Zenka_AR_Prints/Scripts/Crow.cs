using UnityEngine;
using System.Collections;

namespace ZenkaARPrints{
public class Crow : MonoBehaviour {


    private Transform t;

    public float duration = 1;
    public float velocity = 1500;
	public AudioSource audio;

	private float timeLimit;
	public Animator animator;

	public bool performFlying = true;

	private bool flying = false;

	// Use this for initialization
	void Awake () {	
		
        t = transform;

	}

    void OnEnable(){

		flying = false;
		animator.speed = .2f;

		audio.Play ();
		timeLimit = Time.time + duration;

		// static bird in screen
		if (!performFlying) {
			animator.speed = .2f;
		}


    }

	public void Fly(){

		if (!performFlying) {
			return;
		}

		audio.Play ();
		animator.speed = 1;
		timeLimit = Time.time + duration;
		flying = true;

		float z = Random.Range(2f,40f);

		Vector3 r = new Vector3 (-20.164f,-3.492f,z);//possibilities [index];
		float rSpeed = Random.Range(3f,5f);

		LeanTweenType[] options = new LeanTweenType[]{ LeanTweenType.easeOutSine, LeanTweenType.easeInOutBack, LeanTweenType.easeInCubic} ;
		LeanTween.rotateLocal (this.gameObject, r, rSpeed).setEase (options[Random.Range(0,options.Length)]);
		velocity = Random.Range (200, 600);
		float animSpeed = (velocity / 600);
		animator.speed = animSpeed;


	}
	
	// Update is called once per frame
	void Update () {

		if (flying) {
			t.Translate(Vector3.up * velocity * Time.deltaTime);
			if (Time.time > timeLimit){
				t.gameObject.SetActive(false);
			}
		}

	}

}

}