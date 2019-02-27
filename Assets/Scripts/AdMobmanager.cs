using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// #if GOOGLE_MOBILE_ADS
using GoogleMobileAds;
using GoogleMobileAds.Api;
// #endif


public class AdMobmanager : Singleton<AdMobmanager> {

	#region
// #if GOOGLE_MOBILE_ADS
	
	bool testingMode = true;

	BannerView bannerView;
	InterstitialAd interstitial;
	AdRequest requestBanner;
	AdRequest requestInterstitial;

	string goToSceneWithAdName = "null";
// #endif

// #if GOOGLE_MOBILE_ADS
	private string appId = "ca-app-pub-3204981671781860~3869136015";	

	//original ads id
	// private string bannerId = "ca-app-pub-3204981671781860/2343467205";	
	// private string interstitialId = "ca-app-pub-3204981671781860/8130856791";

	//test ads id
	private string bannerIds = "ca-app-pub-3940256099942544/6300978111";
	private string interstitialIds = "ca-app-pub-3940256099942544/1033173712";

	//Edit with your device id
	// private string testDeviceId = "81A5D70CE479330C99C85E799E15DA1A";
	private string testDeviceId = "F09AB3757F39B35511FCD532B97BB035";
	
	
// #endif

	

	int tryingToShowInterstitial=0;

	void Awake(){

		// DontDestroyOnLoad (this);

// #if GOOGLE_MOBILE_ADS
		MobileAds.Initialize(appId);
// #endif
		Set();	
	}

	public void Set(){

		// if(bannerView != null){
		// 	bannerView.Hide();
		// }

		// if (showBanner){
		// 	RequestBanner();
		// }
		// if (showInterstitial){
		// 	ShowInterstitial();
		// }

		RequestBanner();
		RequestInterstitial();

	}

	// public void SetInterstitialId(int id){
	// 	interstitialId = id;
	// }

	public BannerView isBannerNull(){
		return bannerView;
	}

	public void DestroyBanner(){
		bannerView.Hide();
	}

	public void DestoryInterstitial(){
		interstitial.Destroy();
	}

	public void RequestBanner(){

		bannerView = new BannerView(bannerIds, AdSize.SmartBanner, AdPosition.Bottom);		

		if(testingMode)
			requestBanner = new AdRequest.Builder().AddTestDevice(testDeviceId).Build();
		else
			requestBanner = new AdRequest.Builder().Build();

		bannerView.LoadAd(requestBanner);	

		bannerView.OnAdLoaded -= HandleOnAdLoaded;
		bannerView.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
		bannerView.OnAdOpening -= HandleOnAdOpened;
		bannerView.OnAdClosed -= HandleOnAdClosed;

		// Called when an ad request has successfully loaded.
		bannerView.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleOnAdOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleOnAdClosed;
	}

	

	public void RequestInterstitial()
	{
// #if GOOGLE_MOBILE_ADS

		interstitial = new InterstitialAd(interstitialIds);
		
		if(testingMode)
			requestInterstitial = new AdRequest.Builder().AddTestDevice(testDeviceId).Build();
		else
			requestInterstitial = new AdRequest.Builder().Build();
		
		interstitial.LoadAd(requestInterstitial);

		interstitial.OnAdClosed += HandleOnAdClosed;
		interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		interstitial.OnAdOpening += HandleOnAdOpened;
		interstitial.OnAdClosed += HandleOnAdClosed;

// #endif
	}



	// Use this for initialization
	void Start () {

		//MobileAds.Initialize(appId);
		//ShowBanner();
		//ShowInterstitial();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowBanner(){
// #if GOOGLE_MOBILE_ADS		
		bannerView.Show();	
// #endif
	}

	public void ShowInterstitial(){
// #if GOOGLE_MOBILE_ADS
		while (tryingToShowInterstitial < 10){


		// interstitial.Show();			
			if (interstitial.IsLoaded())
			{	
				interstitial.Show();
				tryingToShowInterstitial=10;
			}
			else
			{
				RequestInterstitial();
				// tryingToShowInterstitial++;
				if (interstitial.IsLoaded())
				{
					interstitial.Show();
					tryingToShowInterstitial=10;
				}
			}
			tryingToShowInterstitial++;
		}

		if(tryingToShowInterstitial >= 10){
			SceneController.Instance.GoToScene(goToSceneWithAdName);		
		}
		
		tryingToShowInterstitial=0;
// #endif
	}

	public void ShowInterstitial(string goToSceneWithAdName){
// #if GOOGLE_MOBILE_ADS

		// this.goToSceneWithAdName = goToSceneWithAdName;

		// while (tryingToShowInterstitial < 10){

			
		// 	if (interstitial.IsLoaded())
		// 	{	
		// 		interstitial.Show();
		// 		break;
		// 	}
		// 	else
		// 	{
		// 		RequestInterstitial();
		// 		tryingToShowInterstitial++;
		// 	}
		// }

		// if(tryingToShowInterstitial >= 10){
		// 	SceneController.Instance.GoToScene(goToSceneWithAdName);		
		// }
		
		// tryingToShowInterstitial=0;
		interstitial.Show();
		SceneController.Instance.GoToScene(goToSceneWithAdName);
// #endif
	}

// #if GOOGLE_MOBILE_ADS
	// Called when an ad request has successfully loaded.
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
	
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		// SceneController.Instance.GoToScene(goToSceneWithAdName);
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
			
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		SceneController.Instance.GoToScene(goToSceneWithAdName);		
		// AdManagerController.Instance.setShowInterstitial(false);
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
			
	}
	// Called when the user is about to return to the app after an ad click.
	
	public void SetGoToSceneWithAdName(string goToSceneWithAdName){
		this.goToSceneWithAdName = goToSceneWithAdName;
	}
// #endif

	#endregion
}