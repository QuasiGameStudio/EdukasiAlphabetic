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
	private string[] bannerIds = new string[3];
	private string[] interstitialIds = new string[5];

	private int InterstitialId;

	//Edit with your device id
	private string testDeviceId = "81A5D70CE479330C99C85E799E15DA1A";
	
	
// #endif

	private static AdMobmanager Instance;

	int tryingToShowInterstitial;

	void Awake(){

		// DontDestroyOnLoad (this);

		if(testingMode){
			bannerIds[0] = "ca-app-pub-3940256099942544/6300978111";
			bannerIds[1] = "ca-app-pub-3940256099942544/6300978111";
			bannerIds[2] = "ca-app-pub-3940256099942544/6300978111";	
			interstitialIds[0] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[1] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[2] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[3] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[4] = "ca-app-pub-3940256099942544/1033173712";				
		} else {
			bannerIds[0] = "ca-app-pub-3940256099942544/6300978111";
			bannerIds[1] = "ca-app-pub-3940256099942544/6300978111";
			bannerIds[2] = "ca-app-pub-3940256099942544/6300978111";	
			interstitialIds[0] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[1] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[2] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[3] = "ca-app-pub-3940256099942544/1033173712";
			interstitialIds[4] = "ca-app-pub-3940256099942544/1033173712";
		}

		if (Instance == null) {
			Instance = this;
		} else {
			DestroyObject(gameObject);
		}

// #if GOOGLE_MOBILE_ADS
		MobileAds.Initialize(appId);
// #endif
		// Set();	
	}

	// public void Set(){

	// 	if(bannerView != null){
	// 		bannerView.Hide();
	// 	}

	// 	if (showBanner){
	// 		RequestBanner();
	// 	}
	// 	if (showInterstitial){
	// 		ShowInterstitial();
	// 	}


	// }

	public void SetInterstitialId(int id){
		InterstitialId = id;
	}

	public void DestroyBanner(){
		bannerView.Destroy();
	}

	public void DestoryInterstitial(){
		interstitial.Destroy();
	}

	public void RequestBanner(int id){

		bannerView = new BannerView(bannerIds[id], AdSize.SmartBanner, AdPosition.Bottom);		

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

		interstitial = new InterstitialAd(interstitialIds[InterstitialId]);
		
		if(testingMode)
			requestInterstitial = new AdRequest.Builder().AddTestDevice(testDeviceId).Build();
		else
			requestInterstitial = new AdRequest.Builder().Build();
		

		interstitial.OnAdClosed += HandleOnAdClosed;
		interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;

		interstitial.LoadAd(requestInterstitial);
		
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
			if (interstitial.IsLoaded())
			{
				interstitial.Show();
				break;
			}
			else
			{
				RequestInterstitial();
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

		this.goToSceneWithAdName = goToSceneWithAdName;

		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
		else
		{
			RequestInterstitial();
		}
// #endif
	}

// #if GOOGLE_MOBILE_ADS
	// Called when an ad request has successfully loaded.
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
	
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		SceneController.Instance.GoToScene(goToSceneWithAdName);
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
			
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		SceneController.Instance.GoToScene(goToSceneWithAdName);			
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
			
	}
	// Called when the user is about to return to the app after an ad click.
	
	
// #endif

	#endregion
}