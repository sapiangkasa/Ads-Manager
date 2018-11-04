using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour {
    public string AndroidBannerID = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
    public string AndroidInterstitialID = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
    public string IOSBannerID = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
    public string IOSInterstitialID = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";

    [Header("Debug Mode")]
    [Tooltip("Debug mode uses sample add unit ID")]
    public bool debug;

    private static AdsManager instance;

    // Singleton
    private void Awake()
    {
        if (instance ==  null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (debug)
        {
            // use sample ad unit ID
            AndroidBannerID = "ca-app-pub-3940256099942544/6300978111";
            AndroidInterstitialID = "ca-app-pub-3940256099942544/1033173712";
            IOSBannerID = "ca-app-pub-3940256099942544/2934735716";
            IOSInterstitialID = "ca-app-pub-3940256099942544/4411468910";
        }

        InitializeSDK();
    }

    private void InitializeSDK()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif
        MobileAds.Initialize(appId);
    }
}
