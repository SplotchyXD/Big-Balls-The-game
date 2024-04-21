using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// T‰m‰ skripti hoitaa mainosten initialisoinnin
/// </summary>
public class AdManager : MonoBehaviour, IUnityAdsInitializationListener //Rajapinta, jolla voidaan tehd‰ helpot testit onko initialisointi onnistunut vai ei
{
    public string androidGameID; // Android game ID johon yhdistet‰‰n
    public string iosGameID; // IOS game id johon yhdistet‰‰n
    public bool testMode = true; // K‰ytet‰‰nkˆ test modea vai ei

    /// <summary>
    /// IUnityAdsInitializationListener rajapinna toiminto, joka kutsutaan kun mainosten initialisointi on onnistunut
    /// </summary>
    public void OnInitializationComplete()
    {
        MessageLogger.Instance.AddEvent("Android Advertisements intialized");
    }

    /// <summary>
    /// IUnityAdsInitializationListener rajapinna toiminto, joka kutsutaan kun mainosten initialisointi on ep‰onnistunut
    /// </summary>
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        MessageLogger.Instance.AddEvent("Advertisements could not be initialized: " + message);
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Advertisement.isInitialized)
        {
            // Jos mainokset ON jo initialisoitu (esim eri sceness‰ tai restartin j‰lkeen)
            MessageLogger.Instance.AddEvent("Advertisements already initialized");
        }
        else
        { 
            // Jos mainoksia ei ole initialisoitu, initialisoidaan se joko Androidille tai IOS:‰lle
            MessageLogger.Instance.AddEvent("Initializing Advertisements..");
#if UNITY_ANDROID // Direktiivi, jonka avulla voidaan katsoa on peli buildattu Android laitteelle
            Advertisement.Initialize(androidGameID, testMode, true, this);
#elif UNITY_IOS // Direktiivi, jonka avulla voidaan katsoa on peli buildattu IOS laitteelle
            Advertisement.Initialize(iosGameID, testMode);
#endif
        }

    }
}
