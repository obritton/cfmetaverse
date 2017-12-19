using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace ZenkaARPrints{
 
	public class Pool : MonoBehaviour {

		public int poolSize;
		public int poolIncrementRate = 5;

		public bool removeUnusedElements = false;
		public int poolPurgeTimeSecs = 5; 

		public GameObject instance;

		public bool useMyParent = false;

		private GameObject[] objects;
		private Transform t;

		private Transform gParent;

		void Awake(){

			t = transform;

			objects = new GameObject[poolSize];
			//objects [0] = instance;
		}

		void Start(){
			
			InitializeArray (0);

		}

		void OnEnable(){

			if (!useMyParent) {
	//			gParent = GameObject.Find("BulletPools").transform;
				Debug.Log("NO PARENT!!");
			} else {
				gParent = transform;
			}

		}

		private void IncreasePoolSize(){

			int previousSize = objects.Length;
			Array.Resize (ref objects, objects.Length + poolIncrementRate);
			InitializeArray (previousSize);

			if (removeUnusedElements)
				Invoke ("Purge", poolPurgeTimeSecs);

		}


		private void InitializeArray(){
			InitializeArray (0);
		}

		private void InitializeArray(int offset){

	//		Debug.Log ("( " + t.name + " -- " +  gParent.name + " ) Initialize for offset: " + offset + " + Objects Length: " + objects.Length);

			for (int i=offset; i< objects.Length; i++) {
				objects [i] = Instantiate (instance) as GameObject;
				//(objects [i]).transform.parent = instance.transform.parent;
				(objects [i]).transform.parent = gParent;
				(objects [i]).transform.localPosition = instance.transform.localPosition;
				(objects [i]).transform.localScale=instance.transform.localScale;
				(objects [i]).name = instance.name + "_" + i;
				(objects [i]).SetActive(false);
			}

		}

		private void Purge(){

			if (objects.Length > poolSize) { // remove till the initial pool size
			
		//		Debug.Log("Implementa el Purgueador la concha de tu hermana!!!");



				Invoke("Purge",poolPurgeTimeSecs);
			}

		}
		

		private GameObject GetNextPoolObject(Vector3 position){

			GameObject response = null;

			for (int i=0; i<objects.Length; i++) {
				if(objects[i]!=null){
					if(objects[i].activeSelf==false){
						objects[i].transform.position = position+ new Vector3(1f,0,0);
						objects[i].transform.rotation = instance.transform.rotation;
						objects[i].SetActive (true);
						return objects[i];
					}
				}
			}

			IncreasePoolSize ();
			return GetNextPoolObject (position);

		}
		public GameObject[] GetNext(Vector3 position, int count){
			GameObject[] collection = new GameObject[count];
			for (int i=0; i<count; i++)
				collection [i] = GetNextPoolObject (position);
			
			return collection;
		}

		public GameObject GetNext(Vector3 position){
			return GetNextPoolObject (position);
		}

		public GameObject GetNext(Transform t){
			return GetNextPoolObject(t.position);
		}

		public GameObject GetNext(){
			return GetNextPoolObject (t.position);
		}


	}
}