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
			AdMobmanager.Instance.isShowBanner(true);
			AdMobmanager.Instance.isShowInterstitial(false);
			break;
		case "LevelSelector":
			AdMobmanager.Instance.SetBannerView(1);
			AdMobmanager.Instance.isShowBanner(true);
			AdMobmanager.Instance.isShowInterstitial(false);
			break;
		case "StudySelector":
			AdMobmanager.Instance.SetBannerView(2);
			AdMobmanager.Instance.isShowBanner(true);
			AdMobmanager.Instance.isShowInterstitial(false);
			break;
		case "TebakHuruf":
			AdMobmanager.Instance.SetInterstitial(0);
			AdMobmanager.Instance.isShowBanner(false);
			AdMobmanager.Instance.isShowInterstitial(true);
			break;
		case "TebakHurufKecil":
			AdMobmanager.Instance.SetInterstitial(1);
			AdMobmanager.Instance.isShowBanner(false);
			AdMobmanager.Instance.isShowInterstitial(true);
			break;
		case "PasanganHuruf":
			AdMobmanager.Instance.SetInterstitial(2);
			AdMobmanager.Instance.isShowBanner(false);
			AdMobmanager.Instance.isShowInterstitial(true);
			break;
		case "TebakBentuk":
			AdMobmanager.Instance.SetInterstitial(3);
			AdMobmanager.Instance.isShowBanner(false);
			AdMobmanager.Instance.isShowInterstitial(true);
			break;
		case "PuzzleHuruf":
			AdMobmanager.Instance.SetInterstitial(4);
			AdMobmanager.Instance.isShowBanner(false);
			AdMobmanager.Instance.isShowInterstitial(true);
			break;
		default:
			AdMobmanager.Instance.isShowBanner(false);
			AdMobmanager.Instance.isShowInterstitial(false);	
			break;
		}
	}

	// public String getSceneName(){
	// 	return "A";
	// }
}
