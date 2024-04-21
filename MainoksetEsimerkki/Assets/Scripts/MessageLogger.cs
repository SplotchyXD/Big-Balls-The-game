using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tämä skripti lisää peliin Globa User Interface (GUI) Ikkunan, johon voidaan laittaa viestejä "MessageLogger.Instance.AddEvent("teksti")" toiminnon avulla
/// Tämä on hyödyllinen erilaisten console viestin kirjoittamiseen, jotka näkyvät myös buildatussa pelissä
/// Esim: Mainosten initialisoinnin onnistuminen, mainoksen lataaminne/aloittaminen/katsominen yms.
/// </summary>
public class MessageLogger : MonoBehaviour
{
    public static MessageLogger Instance;

    private List<string> Eventlog = new List<string>();
    private string guiText = "";

    public int maxLines = 10;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, Screen.height - (Screen.height / 3), Screen.width / 3, Screen.height / 4), guiText, GUI.skin.textArea);
    }

    public void AddEvent(string eventString)
    {
        Eventlog.Add(eventString);

        if (Eventlog.Count >= maxLines)
            Eventlog.RemoveAt(0);

        guiText = "";

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "\n";
        }
    }
}