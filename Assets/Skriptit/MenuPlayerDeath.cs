using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerDeath : MonoBehaviour
{
    //Scripti jolla tarkistetaan mik‰ pallo on osunut triggeriin ja sitten sen mukaan l‰hetet‰‰n kutsu toiseen scriptiin jolla luodaan palloja

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
        
            if (collision2D.isTrigger == true)
            {
                PlayerSpawner.SpawnPlayer();
                //Player.SetActive(false);
            }

            if (collision2D.isTrigger == true)
            {
                RedSpawner.SpawnRed();
                //Red.SetActive(false);
            }

            if (collision2D.isTrigger == true)
            {
                YellowSpawner.SpawnYellow();
                //Yellow.SetActive(false);
            }

            if (collision2D.isTrigger == true)
            {
                GreenSpawner.SpawnGreen();
                //Green.SetActive(false);
            }
    }
}

