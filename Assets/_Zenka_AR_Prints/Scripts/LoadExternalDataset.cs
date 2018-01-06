using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
namespace ZenkaARPrints{
public class LoadExternalDataset : MonoBehaviour {

	//Only use in Preloader Scene for android split APK
	private string nextScene = "Play";

	private bool obbisok=false;
	private bool loading=false;
	private bool replacefiles=false; //true if you wish to over copy each time

	private string[] paths={	
		"QCAR/River_Zenka_13.dat",
		"QCAR/River_Zenka_13.xml",
		"QCAR/River_Zenka_11.dat",
		"QCAR/River_Zenka_11.xml",
		"QCAR/Zenka.dat",
		"QCAR/Zenka.xml",
	};


	// Use this for initialization
	void Start () {


		if (Application.platform==RuntimePlatform.Android)	{

			if (Application.dataPath.Contains(".obb") ) {
				
				StartCoroutine(CheckSetUp());

			}

		} else {

			if (!loading) {
				StartCoroutine("LoadPlayScene");
			}

		}


	}
	
	IEnumerator LoadPlayScene(){
		
		string name = "Play";
		AsyncOperation _async = new AsyncOperation();
		_async = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

		while (!_async.isDone) {
			yield return null;
		}

		Scene nextScene = SceneManager.GetSceneByName( name );
		if (nextScene.IsValid ()) {
			SceneManager.UnloadScene (SceneManager.GetActiveScene ().name);
			SceneManager.SetActiveScene (nextScene);
		}

	}		
		
	public IEnumerator CheckSetUp() {
		
		//Check and install!
		for(int i=0;i<paths.Length;++i) {
			yield return StartCoroutine(PullStreamingAssetFromObb(paths[i]));
		}
		yield return new WaitForSeconds(1f); 

		StartCoroutine("LoadPlayScene");
	}

	//Alternatively with movie files these could be extracted on demand and destroyed or written over
	//saving device storage space, but creating a small wait time.
	public IEnumerator PullStreamingAssetFromObb(string sapath) { 
		
		if (!File.Exists(Application.persistentDataPath+sapath)||replacefiles) {
			
			WWW unpackerWWW = new WWW(Application.streamingAssetsPath + "/" + sapath);

			while (!unpackerWWW.isDone) {
				yield return null;
			}

			if (!string.IsNullOrEmpty(unpackerWWW.error)) {
				
				Debug.Log("Error unpacking:" + unpackerWWW.error+" path: "+unpackerWWW.url);

				yield break; //skip it

			} else {
				Debug.Log ("Extracting "+sapath+" to Persistant Data");

				if(!Directory.Exists(Path.GetDirectoryName(Application.persistentDataPath+"/"+sapath))) {
					Directory.CreateDirectory(Path.GetDirectoryName(Application.persistentDataPath+"/"+sapath));
				}
				File.WriteAllBytes(Application.persistentDataPath+"/"+sapath,unpackerWWW.bytes);
				//could add to some kind of uninstall list?
			}

		}

		yield return 0;

	}

}
}