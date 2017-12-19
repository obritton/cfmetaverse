using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace ZenkaARPrints{
public class MainMenuUI : MonoBehaviour {

	public GameObject creditsPanel;

	public void OnLinkClicked(){
		Application.OpenURL("http://www.zenka.org/markers");
	}

	public void Play(){
		SceneManager.LoadScene("Loading");
	}

	public void DisableCredits(){
		Invoke ("_DisableCredits", 1f);
	}

	void _DisableCredits(){
		creditsPanel.SetActive (false);
	}


}
}