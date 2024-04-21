using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject Player;
    public Text Highscore;
    public Text EndScore;
    [SerializeField] public GameObject deathPanel;


    //asetetaan Death paneeli ja sen sisällä olevat score seuraajat pois näkyviltä
    private void Start()
    {
        deathPanel.SetActive(false);
        Highscore.gameObject.SetActive(false);
        EndScore.gameObject.SetActive(false);
    }

    //Scripti Death paneelin aktivointiin
    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
        Highscore.gameObject.SetActive(!Highscore.gameObject.activeSelf);
        EndScore.gameObject.SetActive(!EndScore.gameObject.activeSelf);
    }
}
