using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticAdManager : MonoBehaviour
{
    public GameObject bannerAd;
    public GameObject interstitialAd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showBannerAd()
    {
        bannerAd.SetActive(true);
    }

    public void showInterstitialAd()
    {
        interstitialAd.SetActive(true);
    }

    public void closeBannerAd()
    {
        bannerAd.SetActive(false);
    }

    public void closeInterstitialAd()
    {
        interstitialAd.SetActive(false);
    }

    public void openstore()
    {
        closeBannerAd();
        closeInterstitialAd();
        statusManager.isStaticAdClicked = 1;
        adManager.sharedInstance().loadAllAds();
        Application.OpenURL("market://details?id=com.darkweb.genesissearchengine"); //Replace 'Unity Remote' by <Your Publisher name>

    }

}
