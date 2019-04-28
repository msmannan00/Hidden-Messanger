using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class prefManager
{
    static prefManager manager = new prefManager();

    public static prefManager sharedInstance()
    {
        return manager;
    }

    public void loadPrefs()
    {
        using (WebClient client = new WebClient())
        {
            string htmlCode = client.DownloadString("http://boogle.store/global_prefs");
            Debug.Log("Response: " + htmlCode);
            statusManager.isGlobalPrefLoaded = true;
            statusManager.addType = helperMethods.sharedInstance().ToInt(htmlCode);
            adManager.sharedInstance().loadAdvertizement();
        }
    }


}
