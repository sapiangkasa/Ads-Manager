using System.Collections;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {
    public string appId = "Insert AdMob App ID";

    [Header("Debug Mode")]
    [Tooltip("Debug mode uses sample add unit ID")]
    public bool debug = true;

    public static AdManager instance;

    private BannerView bannerView;

    // Singleton
    private void Awake()
    {
        if (instance == null)
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
#if UNITY_ANDROID
            appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            appId = "ca-app-pub-3940256099942544~1458002511";
#else
            appId = "unexpected_platform";
#endif
        }

        InitializeSDK();
    }

    private void InitializeSDK()
    {
        MobileAds.Initialize(appId);
    }

    #region banner

    /// <summary>
    /// <b>Request banner ads.</b>
    /// </summary>
    /// <param name="bannerAds"></param>
    public void RequestBanner(string adUnitId, AdSize adSize, AdPosition adPosition)
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        bannerView = new BannerView(adUnitId, adSize, adPosition);
    }

    /// <summary>
    /// <b>Request banner ads at x, y coordinate.</b>
    /// <para>
    /// The top-left corner of the BannerView will be positioned at the x and y values passed to the constructor, where the origin is the top-left of the screen.
    /// </para>
    /// </summary>
    /// <param name="adUnitId"></param>
    /// <param name="adSize"></param>
    /// <param name="xCoord"></param>
    /// <param name="yCoord"></param>
    public void RequestBanner(string adUnitId, AdSize adSize, int xCoord, int yCoord)
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
        bannerView = new BannerView(adUnitId, adSize, xCoord, yCoord);
    }

    /// <summary>
    /// <b>Load banner ads</b>
    /// </summary>
    /// <param name="bannerView"></param>
    public void LoadBanner()
    {
        // do nothing when banner view is null
        if (bannerView == null) return;

        // create an empty ad request
        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    public void LoadBanner(EventHandler<EventArgs> OnAdLoaded = null,
        EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad = null, EventHandler<EventArgs> OnAdOpened = null,
        EventHandler<EventArgs> OnAdClosed = null, EventHandler<EventArgs> OnAdLeavingApplication = null)
    {
        // do nothing when banner view is null
        if (bannerView == null) return;

        if (OnAdLoaded != null) bannerView.OnAdLoaded += OnAdLoaded;
        if (OnAdFailedToLoad != null) bannerView.OnAdFailedToLoad += OnAdFailedToLoad;
        if (OnAdOpened != null) bannerView.OnAdOpening += OnAdOpened;
        if (OnAdClosed != null) bannerView.OnAdClosed += OnAdClosed;
        if (OnAdLeavingApplication != null) bannerView.OnAdLeavingApplication += OnAdLeavingApplication;

        LoadBanner();
    }

    #endregion banner
}
