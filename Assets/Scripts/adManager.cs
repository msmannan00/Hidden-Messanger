using admob;
using System;
using UnityEngine;

public class adManager
{

    /*local variables*/
    String adid = "ca-app-pub-3940256099942544/1033173712";
    Admob advert;
    Boolean isAdsInitialized = false;
    /*shared instances*/
    static adManager manager = new adManager();
    public int static_ad_count = 0;

    public static adManager sharedInstance()
    {
        return manager;
    }

    /*helper methods*/
    public void loadAdvertizement()
    {
        isAdsInitialized = true;
        advert = Admob.Instance();
        advert.initAdmob("ca-app-pub-5074525529134731/7504358002", "ca-app-pub-5074525529134731/3318164008");
        //advert.setTesting(true);
        loadAllAds();
    }

    public void loadAllAds()
    {
        advert.loadInterstitial();
        showBannerAds();
    }

    public void showBannerAds()
    {
        if (isAdsInitialized)
        {
            if (statusManager.addType == 0 || statusManager.isStaticAdClicked == 1 || statusManager.isGenesisAppInstalled)
            {
                Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.TOP_CENTER, 0);
            }
            else
            {
                GameObject.FindGameObjectWithTag("static_advertizement").GetComponent<staticAdManager>().showBannerAd();
            }
        }
    }

    public void showStaticAds()
    {
        if(isAdsInitialized)
        {
            if (statusManager.addType == 0 || (static_ad_count!=0 && static_ad_count % 3 !=0) || statusManager.isStaticAdClicked == 1 || statusManager.isGenesisAppInstalled)
            {
                advert.showInterstitial();
            }
            else
            {
                static_ad_count++;
                GameObject.FindGameObjectWithTag("static_advertizement").GetComponent<staticAdManager>().showInterstitialAd();
            }
            static_ad_count++;
        }
    }

    public void showVideoAds()
    {
        if (isAdsInitialized)
        {
            if(statusManager.addType== 0 || (static_ad_count != 0 && static_ad_count % 3 != 0) || statusManager.isStaticAdClicked == 1 || statusManager.isGenesisAppInstalled)
            {
                advert.showRewardedVideo();
            }
            else
            {
                static_ad_count++;
                GameObject.FindGameObjectWithTag("static advertizement").GetComponent<staticAdManager>().showInterstitialAd();
            }
            static_ad_count++;
        }
    }

}
