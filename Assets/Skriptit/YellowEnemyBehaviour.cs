using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowEnemyBehaviour : MonoBehaviour
{
    public AudioClip DeathSound;

    //Simppeli oncollision scripti jolla tarkistetaan mikä objecti osui
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            Destroy(gameObject);
        }

        if (collision2D.gameObject.tag == "Lava")
        {
            gameObject.SetActive(false);
        }
    }
}
