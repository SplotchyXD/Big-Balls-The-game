using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyBeheaviour : MonoBehaviour
{
    public GameObject Player;

    //Simppeli oncollision scripti jolla tarkistetaan mikä objecti osui
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            Player.SetActive(false);
        }

        if (collision2D.gameObject.tag == "Lava")
        {
            gameObject.SetActive(false);
        }
    }
}
