using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    public GameObject startPosition;

	// Use this for initialization
	void Start () {
        transform.position = startPosition.transform.position;
        transform.rotation = startPosition.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
