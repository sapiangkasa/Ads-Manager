using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdDemoScript : MonoBehaviour {
#if UNITY_ANDROID
    private string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    private string interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";
    private string rewardedVideoAdUnitId = "ca-app-pub-3940256099942544/5224354917";
    private string nativeAdvancedAdUnitId = "ca-app-pub-3940256099942544/2247696110";
#elif UNITY_IPHONE
    private string bannerAdUnitId = "ca-app-pub-3940256099942544/2934735716";
    private string interstitialAdUnitId = "ca-app-pub-3940256099942544/4411468910";
    private string rewardedVideoAdUnitId = "ca-app-pub-3940256099942544/1712485313";
    private string nativeAdvancedAdUnitId = "ca-app-pub-3940256099942544/3986624511";
#endif

    private AdManager adManager;

    private void Start()
    {
        adManager = AdManager.instance;
    }

    #region banner

    public void ShowBannerAd()
    {
        adManager.RequestBanner(bannerAdUnitId, AdSize.SmartBanner, AdPosition.Top);
        adManager.LoadBanner(OnBannerAdLoaded, OnBannerAdFailedToLoad, OnBannerAdOpened, OnBannerAdClosed, OnBannerAdLeavingApplication);
    }

    private void OnBannerAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("BannerAdLoaded event received");
    }

    private void OnBannerAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("BannerAdFailedToLoad event received: " + args.Message);
    }

    private void OnBannerAdOpened(object sender, EventArgs args)
    {
        Debug.Log("OnBannerAdOpened event received");
    }

    private void OnBannerAdClosed(object sender, EventArgs args)
    {
        Debug.Log("OnBannerAdClosed event received");
    }

    private void OnBannerAdLeavingApplication(object sender, EventArgs args)
    {
        Debug.Log("OnBannerAdLeavingApplication event received");
    }


    #endregion banner

    public void ShowInterstitialAd()
    {

    }

}
