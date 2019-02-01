using admob;
using System;

public class adManager
{

    /*local variables*/
    String adid = "ca-app-pub-3940256099942544/1033173712";
    Admob advert;

    /*shared instances*/
    static adManager manager = new adManager();

    public static adManager sharedInstance()
    {
        return manager;
    }

    /*helper methods*/
    public void loadAdvertizement()
    {
        advert = Admob.Instance();
        advert.initAdmob("ca-app-pub-5074525529134731/7504358002", "ca-app-pub-5074525529134731/3318164008");
        //advert.setTesting(true);
        advert.loadInterstitial();
        Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.TOP_CENTER, 0);
        advert.loadInterstitial();
    }

    public void showStaticAds()
    {
        advert.loadInterstitial();
        advert.showInterstitial();
    }

    public void showVideoAds()
    {
        advert.showRewardedVideo();
    }

}
