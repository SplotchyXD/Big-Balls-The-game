using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class StateManager : MonoBehaviour
{
    //Scripti jota k‰ytet‰‰n navigoimaan pelaajaa menujen ja pelin v‰lill‰
    public void ReloadCurrentScene()
    {
        Analytics.CustomEvent("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMenu()
    {
        Analytics.CustomEvent("ReturnToMenu");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void GoToOptions()
    {
        Analytics.CustomEvent("OpenSettings");
        SceneManager.LoadScene("Options");
    }
    public void GoToGame()
    {
        Analytics.CustomEvent("StartLvl");
        SceneManager.LoadScene("MainLVL");
    }
    public void QuitGame()
    {
        Analytics.CustomEvent("ApplicationQuit");
        Application.Quit();
    }
}
