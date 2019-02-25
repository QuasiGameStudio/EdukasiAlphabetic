using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdManagerController : Singleton<AdManagerController> {

	// Use this for initialization

	// bool showInterstitial=true;
	void Awake() {
		AdMobmanager.Instance.ShowBanner();
	}

	void Start(){
		AdMobmanager.Instance.ShowInterstitial();
	}
	
	// Update is called once per frame
	void Update () {
		// if (showInterstitial){
		// 	AdMobmanager.Instance.ShowInterstitial();
		// }	
	}

	// public String getSceneName(){
	// 	return "A";
	// }
}
