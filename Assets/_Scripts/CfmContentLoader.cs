using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CfmContentLoader : MonoBehaviour
{

	public void targetFound (string productName)
	{
		GameObject prefab = (GameObject)Resources.Load ("StructuredContent/" + productName + "/prefab", typeof(GameObject));
		if (prefab != null) {
			print (productName + " prefab found!");
			Instantiate (prefab, transform.position, Quaternion.identity, transform);
		} else {
			TextAsset linkAsset = (TextAsset)Resources.Load ("StructuredContent/" + productName + "/link", typeof(TextAsset));
			if (linkAsset != null) {
				print (productName + " link found!");
			} else {
				TextAsset youtubeAsset = (TextAsset)Resources.Load ("StructuredContent/" + productName + "/youtube", typeof(TextAsset));
				if (youtubeAsset != null) {
					print (productName + " youtube found!");
				} else {
					TextAsset captionAsset = (TextAsset)Resources.Load ("StructuredContent/" + productName + "/caption", typeof(TextAsset));
					if (captionAsset != null) {
						print (productName + " caption found!");
					}
				}
			}
		}
	}
}
