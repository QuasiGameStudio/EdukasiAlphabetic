using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdManagerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch(SceneManager.GetActiveScene().name){
		case "Home":
			AdMobmanager.Instance.SetBannerView(0);
			break;
		case "LevelSelector":
			AdMobmanager.Instance.SetBannerView(1);
			break;
		case "StudySelector":
			AdMobmanager.Instance.SetBannerView(2);
			break;
		case "TebakHuruf":
			AdMobmanager.Instance.SetInterstitial(0);
			break;
		case "TebakHurufKecil":
			AdMobmanager.Instance.SetInterstitial(1);
			break;
		case "PasanganHuruf":
			AdMobmanager.Instance.SetInterstitial(2);
			break;
		case "TebakBentuk":
			AdMobmanager.Instance.SetInterstitial(3);
			break;
		case "PuzzleHuruf":
			AdMobmanager.Instance.SetInterstitial(4);
			break;
		}
	}

	// public String getSceneName(){
	// 	return "A";
	// }
}
