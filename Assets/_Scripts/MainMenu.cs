using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

	public GUIStyle mainStyle;
	public GUIStyle whiteStyle;
	public GUIStyle invisStyle;
	public GUIStyle howToStyle;

	bool showHowTo = false;

	void OnGUI ()
	{
		float width = Screen.width;
		float height = width * 50.0f / 93.0f;
		GUI.Label (new Rect (0, 0, width, Screen.height), "", whiteStyle);
		GUI.Label (new Rect (0, (Screen.height - height) / 2, width, height), "", mainStyle);

		if (showHowTo) {
			height = width * 10.0f / 15.0f;
			GUI.Label (new Rect (0, (Screen.height - height) / 2, width, height), "", howToStyle);
			if (GUI.Button (new Rect (0, 0, width, Screen.height), "", invisStyle)) {
				showHowTo = false;
			}

		} else {

			if (GUI.Button (new Rect (0, Screen.height - Screen.height / 2, width / 3, Screen.height / 2), "", invisStyle)) {
				showHowTo = true;
			}
			if (GUI.Button (new Rect (width / 3, Screen.height - Screen.height / 2, width / 3, Screen.height / 2), "", invisStyle)) {
				Application.LoadLevel ("GeneralMetaverseARScene");
			}
			if (GUI.Button (new Rect (2 * width / 3, Screen.height - Screen.height / 2, width / 3, Screen.height / 2), "", invisStyle)) {
				Application.OpenURL ("http://finkmetaverse.com");
			}

		} 
	}
}
