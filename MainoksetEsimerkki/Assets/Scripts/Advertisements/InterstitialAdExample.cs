using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

/// <summary>
/// V‰limainoksen kutsuminen esimerkki
/// </summary>
public class InterstitialAdExample : MonoBehaviour
{ 
    public string adPlacementName; // Mainoksen nimi, esim "Interstitial_Android"

    /// <summary>
    /// T‰t‰ kutsumalla ladataan mainos valmiiksi
    /// </summary>
    public void InitializeAdLoad()
    {
        MessageLogger.Instance.AddEvent("Initializing Interstitial Ad Load..");
        Advertisement.Load(adPlacementName); // ladataan mainos
        StartCoroutine(ShowAd()); // K‰ynnistet‰‰n coroutine mainoksen aloittamiselle
    }

    IEnumerator ShowAd()
    {
        // Odotetaan yksi sekunti
        yield return new WaitForSeconds(1);

        // K‰ynnistet‰‰n mainos jos se on valmis
        if (Advertisement.IsReady(adPlacementName))
        {
            Advertisement.Show(adPlacementName);
            MessageLogger.Instance.AddEvent("Interstitial Advertisement showing");
        }
    }
}
