using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{
    public string idAndroid = "";
    public string idIOS = "";

    private InterstitialAd interstitial;

    private void Start()
    {
        this.Request();
    }

    private void Request()
    {
#if UNITY_ANDROID
        string adUnitId = idAndroid;
#elif UNITY_IPHONE
        string adUnitId = idIOS;
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdClosed += InterstitialClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    private void InterstitialClosed(object sender, EventArgs e)
    {
        this.Request();
    }

    public void Show()
    {
        this.interstitial.Show();
    }
}