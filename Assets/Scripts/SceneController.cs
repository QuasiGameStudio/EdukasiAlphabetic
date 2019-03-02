using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController> {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToScene(string sceneName){
		isSceneBanner();
		if (sceneName != null){
			isSceneGame(sceneName);
			SceneManager.LoadScene(sceneName);
		}
	}

	private void isSceneBanner(){
		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "Home" || sceneName == "LevelSelector" || sceneName == "StudySelector"){
			AdMobmanager.Instance.DestroyBanner();
		}
	}

	private void isSceneGame(string sceneName){
		if(sceneName == "PengenalanBenda" || sceneName == "PengenalanHuruf1"){
			BGM.Instance.DecreaseBGMVolume();
			BGM.Instance.SetBGMClip(1);
		}else if(sceneName == "PuzzleHuruf" || sceneName == "TebakBentuk" || sceneName == "TebakHuruf" || sceneName == "TebakHurufKecil" || sceneName == "PasanganHuruf"){
			BGM.Instance.DecreaseBGMVolume();
			BGM.Instance.SetBGMClip(2);
		}else{
			if (SceneManager.GetActiveScene().name != "Home" && (sceneName == "LevelSelector" || sceneName == "StudySelector")){
				BGM.Instance.IncreaseBGMVolume();
				BGM.Instance.SetBGMClip(0);
			}
		}
	}

	public void GoToLevel(string sceneName){
		AdMobmanager.Instance.SetGoToSceneWithAdName(sceneName);
		AdMobmanager.instance.ShowInterstitial();
		// AdManagerController.Instance.SetShowInterstitial(sceneName);
		// AdMobmanager.Instance.SetInterstitialId(0);		
		// AdMobmanager.Instance.RequestInterstitial();
		// AdMobmanager.Instance.ShowInterstitial(sceneName);
	}

	public void RestartScene(){	
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
