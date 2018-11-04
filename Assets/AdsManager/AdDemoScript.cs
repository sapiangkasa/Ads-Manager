using System.Collections;
using System.Collections.Generic;
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

    public void ShowBannerAd()
    {
        adManager.RequestBanner(bannerAdUnitId, AdSize.SmartBanner, AdPosition.Top);
        adManager.LoadBanner();
    }

    public void ShowInterstitialAd()
    {

    }

}
