using UnityEngine;
using GoogleMobileAds.Api;
using System;


public class AdsManager : MonoBehaviour {

	#region AdMob
	[Header("Admob")]
	private string adMobAppID = "";
    private string videoAdMobId = "ca-app-pub-3940256099942544/5224354917";
	private BannerView bannerView;
	InterstitialAd interstitialAdMob;
	private RewardBasedVideoAd rewardBasedAdMobVideo; 
	AdRequest requestAdMobInterstitial, AdMobVideoRequest;
	#endregion
	[Space(15)]
	

	static AdsManager instance;
	public static AdsManager Instance
	{
		get
		{
			if(instance == null)
				instance = GameObject.FindObjectOfType(typeof(AdsManager)) as AdsManager;
			
			return instance;
		}
	}

	void Awake ()
	{
		gameObject.name = this.GetType().Name;
		DontDestroyOnLoad(gameObject);
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            InitializeAds();
        }	
	}
	
	public void ShowInterstitial()
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            ShowAdMob();
        }
	}

	public void IsVideoRewardAvailable()
	{
		if(isVideoAvaiable())
		{
            if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
            {
                ShowVideoReward();
            }
		}
		
	}

	public void ShowVideoReward()
	{
		if(rewardBasedAdMobVideo.IsLoaded())
		{
            if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
            {
                AdMobShowVideo();
            }
		}
	}

	private void RequestInterstitial()
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            // Initialize an InterstitialAd.
            interstitialAdMob = new InterstitialAd("ca-app-pub-3940256099942544/1033173712");

            // Called when an ad request has successfully loaded.
            interstitialAdMob.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            interstitialAdMob.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is shown.
            interstitialAdMob.OnAdOpening += HandleOnAdOpened;
            // Called when the ad is closed.
            interstitialAdMob.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            interstitialAdMob.OnAdLeavingApplication += HandleOnAdLeavingApplication;

            // Create an empty ad request.
            requestAdMobInterstitial = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            interstitialAdMob.LoadAd(requestAdMobInterstitial);
        }
	}

	public void ShowAdMob()
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            if (interstitialAdMob.IsLoaded())
            {
                interstitialAdMob.Show();
            }
            else
            {
                interstitialAdMob.LoadAd(requestAdMobInterstitial);
            }
        }
	}

	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleAdLoaded event received");
        }
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
        }
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleAdOpened event received");
        }
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleAdClosed event received");
            //FindObjectOfType<GameManager>().ContinueButton();
            interstitialAdMob.LoadAd(requestAdMobInterstitial);
        }
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            FindObjectOfType<GameManager>().ContinueButton();
            FindObjectOfType<GameManager>().paused = true;
            MonoBehaviour.print("HandleAdLeftApplication event received");
        }
	}

	private void RequestRewardedVideo()
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            // Called when an ad request has successfully loaded.
            rewardBasedAdMobVideo.OnAdLoaded += HandleRewardBasedVideoLoadedAdMob;
            // Called when an ad request failed to load.
            rewardBasedAdMobVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoadAdMob;
            // Called when an ad is shown.
            rewardBasedAdMobVideo.OnAdOpening += HandleRewardBasedVideoOpenedAdMob;
            // Called when the ad starts to play.
            rewardBasedAdMobVideo.OnAdStarted += HandleRewardBasedVideoStartedAdMob;
            // Called when the user should be rewarded for watching a video.
            rewardBasedAdMobVideo.OnAdRewarded += HandleRewardBasedVideoRewardedAdMob;
            // Called when the ad is closed.
            rewardBasedAdMobVideo.OnAdClosed += HandleRewardBasedVideoClosedAdMob;
            // Called when the ad click caused the user to leave the application.
            rewardBasedAdMobVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplicationAdMob;
            // Create an empty ad request.
            AdMobVideoRequest = new AdRequest.Builder().Build();
            // Load the rewarded video ad with the request.
            this.rewardBasedAdMobVideo.LoadAd(AdMobVideoRequest, videoAdMobId);
        }
	}

	public void HandleRewardBasedVideoLoadedAdMob(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
        }
	}

	public void HandleRewardBasedVideoFailedToLoadAdMob(object sender, AdFailedToLoadEventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
        }
	}

	public void HandleRewardBasedVideoOpenedAdMob(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
        }
	}

	public void HandleRewardBasedVideoStartedAdMob(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
        }
	}

	public void HandleRewardBasedVideoClosedAdMob(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
            this.rewardBasedAdMobVideo.LoadAd(AdMobVideoRequest, videoAdMobId);
        }
	}

	public void HandleRewardBasedVideoRewardedAdMob(object sender, Reward args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            string type = args.Type;
            double amount = args.Amount;
            MonoBehaviour.print("HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
        }

	}

	public void HandleRewardBasedVideoLeftApplicationAdMob(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
        }
	}

	void InitializeAds()
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MobileAds.Initialize(adMobAppID);
            this.RequestBanner();
            this.rewardBasedAdMobVideo = RewardBasedVideoAd.Instance;
            this.RequestRewardedVideo();
            RequestInterstitial();
        }
	}


	void AdMobShowVideo()
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            rewardBasedAdMobVideo.Show();
        }
	}



	bool isVideoAvaiable()
	{
		#if !UNITY_EDITOR
		 if(rewardBasedAdMobVideo.IsLoaded())
		{
			return true;
		}
		#endif
		return false;
	}

	private void RequestBanner()
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            // Create a 320x50 banner at the bottom of the screen.
            bannerView = new BannerView("ca-app-pub-3940256099942544/6300978111", AdSize.Banner, AdPosition.Bottom);

            // Called when an ad request has successfully loaded.
            bannerView.OnAdLoaded += HandleBannerOnAdLoaded;
            // Called when an ad request failed to load.
            bannerView.OnAdFailedToLoad += HandleBannerOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerView.OnAdOpening += HandleBannerOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerView.OnAdClosed += HandleBannerOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerView.OnAdLeavingApplication += HandleBannerOnAdLeavingApplication;

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();

            // Load the banner with the request.
            bannerView.LoadAd(request);
        }
	}

    public void BannerHide()
    {
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            bannerView.Hide();
        }
    }

    public void BannerShow()
    {
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            bannerView.Show();
        }
    }

    public void HandleBannerOnAdLoaded(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleAdLoaded event received");
            bannerView.Show();
        }
	}

	public void HandleBannerOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
            + args.Message);
        }
	}

	public void HandleBannerOnAdOpened(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleAdOpened event received");
        }
	}

	public void HandleBannerOnAdClosed(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleAdClosed event received");
        }
	}

	public void HandleBannerOnAdLeavingApplication(object sender, EventArgs args)
	{
        if (FindObjectOfType<GameManager>().googleAdsEnabled == true)
        {
            MonoBehaviour.print("HandleAdLeftApplication event received");
        }
	}
}
