using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ScoreManager : MonoBehaviour
{
    //pisteihin käytettävä scripti
    public static ScoreManager Instance;

    public GameObject Player;
    public int score = 0;
    public Text ScoreText;
    public Text ScoreText1;
    public int highScore;

    public Text ScoreTextNum, ScoreTextNum1, HighScoreTextNum, HighScoreTextNum1;

    //tarkistetaan onko aikaisempaa Highscorea ja jos on niin asetetaan se sitten Highscoreksi
    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
    }

    //asetetaan piste teksti aktiiviseksi
    void Start()
    {
        ScoreText.gameObject.SetActive(true);
        ScoreText1.gameObject.SetActive(true);
    }

    //pisteiden nosto funktio
    public void IncreaseScore()
    {
        score = score + 100;
        ScoreText.text = "Score:" + score;
        ScoreText1.text = "Score:" + score;

        ScoreTextNum.text = "Your Score Was: " + score;
        ScoreTextNum1.text = "Your Score Was: " + score;

        HighScoreTextNum.text = "Your HighScore Is: " + highScore;
        HighScoreTextNum1.text = "Your HighScore Is: " + highScore;

        UpdateHighScore();
    }

    //Funktio jolla tarkestetaan että onko uusi Highscore saavutettu ja jos on niin asetetaan se uudeksi Highscoreksi
    public void UpdateHighScore()
    {
        if(score > highScore)
        {
            Analytics.CustomEvent("NewHighscore");

            highScore = score;

            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }
}