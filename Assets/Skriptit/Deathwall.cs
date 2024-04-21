using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathwall : MonoBehaviour
{
    //Menussa käytetty seinä jolla pallot luodaan

    public Spawner PlayerSpawner;
    public Spawner RedSpawner;
    public Spawner YellowSpawner;
    public Spawner GreenSpawner;
    public GameObject Player;
    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;


    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.isTrigger)
        {
            PlayerSpawner.SpawnPlayer();
        }

        if (collision2D.isTrigger)
        {
            RedSpawner.SpawnRed();
        }

        if (collision2D.isTrigger)
        {
            YellowSpawner.SpawnYellow();
        }

        if (collision2D.isTrigger)
        {
            GreenSpawner.SpawnGreen();
        }
    }
}
