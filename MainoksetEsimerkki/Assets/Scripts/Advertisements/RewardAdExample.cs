using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Events;

/// <summary>
/// Reward mainos, joka palkitsee pelaajaa sen katsomisesta
/// </summary>
public class RewardAdExample : MonoBehaviour, IUnityAdsListener
{
    public Button rewardAdButton; // Nappi, jota painamalla mainos alkaa

    public UnityEvent onFailedEvents; // Eventit jota kutsutaan kun mainos on ep‰onnistunut
    public UnityEvent rewardOnSuccessEvents; // eventit jota kutsutaan kun mainos on onnistunut (reward)

    public string rewardPlacementID = "Rewarded_Android"; // mainoksen ID (PlacementID)

    bool isReady = false; // Onko mainos valmis

    void Start()
    {
        rewardAdButton.onClick.AddListener(InitializeRewardAd); // lis‰t‰‰n nappiin uusi OnClick eventti, jota painamalla k‰ynnistet‰‰n mainos
        rewardAdButton.interactable = false; // Pistet‰‰n nappi alussa pois p‰‰lt‰ 
        Advertisement.AddListener(this); // Advertising event, jonka avulla voidaan katsoa onko mainos valmis vai ei
        Invoke("InitializeAdLoad", 2); // kutsutaan mainoksen alustamista 2-sekunnin kuluttua
    }

    /// <summary>
    /// Initialisoidaan mainoksen lataus
    /// </summary>
    void InitializeAdLoad()
    {
        Advertisement.Load(rewardPlacementID);
    }

    /// <summary>
    /// Mik‰li mainoksessa tulee ongelmia, l‰hetet‰‰n viesti ja pistet‰‰n nappi pois p‰‰lt‰
    /// </summary>
    /// <param name="message"></param>
    public void OnUnityAdsDidError(string message)
    {
        MessageLogger.Instance.AddEvent(message);
        rewardAdButton.interactable = false;
        Debug.Log(message);
    }

    /// <summary>
    /// Kun mainos on katsottu, tehd‰‰n eri toimenpiteet sille, onko se katsottu kokonaan, skipattu vai tullut virhe
    /// </summary>
    /// <param name="placementId"></param>
    /// <param name="showResult"></param>
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                // Jokin muu error tapahtui, ei palkita
                MessageLogger.Instance.AddEvent("Showing the ad failed. Reward not given");
                onFailedEvents.Invoke(); // K‰ynnistet‰‰n failed eventit
                break;
            case ShowResult.Skipped:
                // K‰ytt‰j‰ skippasi mainoksen, ei palkita
                MessageLogger.Instance.AddEvent("Reward Ad skipped. Reward not given");
                onFailedEvents.Invoke(); // K‰ynnistet‰‰n failed eventit
                break;
            case ShowResult.Finished:
                // K‰ytt‰j‰ katsoi mainoksen kokonaan, palkitaan pelaajaa
                MessageLogger.Instance.AddEvent("Reward Ad watched successfully. Reward has been given!");
                rewardOnSuccessEvents.Invoke(); // K‰ynnistet‰‰n reward eventit
                break;
        }
    }

    /// <summary>
    /// Kun mainos alkaa t‰m‰ metodi kutsutaan automaattisesti
    /// </summary>
    /// <param name="placementId"></param>
    public void OnUnityAdsDidStart(string placementId)
    {
        MessageLogger.Instance.AddEvent("Started showing reward ad");
        Debug.Log("Started Reward Ad");
    }

    /// <summary>
    /// Kun mainos on valmis, t‰m‰ kutsutaan automaattisesti
    /// </summary>
    /// <param name="placementId"></param>
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == rewardPlacementID)
        {
            isReady = true;
            rewardAdButton.interactable = true;
            MessageLogger.Instance.AddEvent("Reward advertisement ready");
        }
    }

    /// <summary>
    /// T‰t‰ metodia kutsumalla k‰ynnistet‰‰n mainos jos mainos on valmis.
    /// </summary>
    public void InitializeRewardAd()
    {
        MessageLogger.Instance.AddEvent("Initializing reward ad start..");
        if (Advertisement.IsReady(rewardPlacementID) && isReady)
        {
            Advertisement.Show(rewardPlacementID);
            rewardAdButton.interactable = false;
            isReady = false;
        }
    }

    // Jos t‰m‰ skripti / objekti tuhotaan, poistetaan "Kuuntelijat" Advertisement luokasta.
    // Jos t‰t‰ ei laita, voi tulla ongelmia kutsuessa samaa mainosta uudestaan.
    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
