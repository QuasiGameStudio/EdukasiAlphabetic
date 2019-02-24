using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdManagerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		switch(SceneManager.GetActiveScene().name){
		case "Home":
			
			AdMobmanager.Instance.RequestBanner(0);
			AdMobmanager.Instance.ShowBanner();			
			break;
		case "LevelSelector":	
			AdMobmanager.Instance.RequestBanner(0);
			AdMobmanager.Instance.ShowBanner();			
			break;
		case "StudySelector":						
			AdMobmanager.Instance.RequestBanner(2);
			AdMobmanager.Instance.ShowBanner();			
			break;
		case "TebakHuruf":
			AdMobmanager.Instance.SetInterstitialId(0);		
			AdMobmanager.Instance.RequestInterstitial();
			AdMobmanager.Instance.ShowInterstitial();
			break;
		case "TebakHurufKecil":
			AdMobmanager.Instance.SetInterstitialId(1);		
			AdMobmanager.Instance.RequestInterstitial();
			AdMobmanager.Instance.ShowInterstitial();
			break;
		case "PasanganHuruf":
			AdMobmanager.Instance.SetInterstitialId(2);
			AdMobmanager.Instance.RequestInterstitial();
			AdMobmanager.Instance.ShowInterstitial();
			break;
		case "TebakBentuk":
			AdMobmanager.Instance.SetInterstitialId(3);
			AdMobmanager.Instance.RequestInterstitial();
			AdMobmanager.Instance.ShowInterstitial();
			break;
		case "PuzzleHuruf":
			AdMobmanager.Instance.SetInterstitialId(4);			
			AdMobmanager.Instance.RequestInterstitial();
			AdMobmanager.Instance.ShowInterstitial();
			break;
		default:

			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// public String getSceneName(){
	// 	return "A";
	// }
}
