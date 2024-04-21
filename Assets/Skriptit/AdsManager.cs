using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;

public class AdsManager : MonoBehaviour
{
    //this whole section was made so i could pass the coursethis project was associated with
    //has stopped working since i last touched this project (i dont have it in me to try to debug it)
    /*
    //Mainosten hallinta

#if UNITY_IOS
private string gameId = "4455166";
#elif UNITY_ANDROID
    private string gameId = "4455167";
#endif

    static int deathCount = 0;
    bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        if(deathCount % 3 == 0)
        {
            ShowIntAd();
        }
        deathCount++;
    }

    // Update is called once per frame
    public void ShowIntAd()
    {
        {
            if(Advertisement.IsReady("Interstitial_Android"))
            Advertisement.Show("Interstitial_Android");
            Analytics.CustomEvent("AddPlayed");
        }
    }
    */
}
    