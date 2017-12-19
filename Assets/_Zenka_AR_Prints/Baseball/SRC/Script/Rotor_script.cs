using UnityEngine;
using System.Collections;

public class Rotor_script : MonoBehaviour 
{
    public float velRotor;
	
	void Update () 
    {
        transform.Rotate(new Vector3(0, velRotor * Time.deltaTime, 0));
	}
}
