using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    // luodaan variablet
    public GameObject Enemy;

    private float distance;
    private float distanceUsed;

    //updaten sis‰ll‰ on koodi p‰tk‰ jolla tarkistetaan miss‰ pelaaja on ja tarkistetaan ett‰ kuinka kaukana pelaaja on lattiasta.
    //n‰ill‰ luvuilla tehd‰‰n laskelma jolla katsotaan tarkka sij‰inti jonka j‰lkeen tarkistetaan miten l‰hell‰ viimeisin vihollinen on.
    //ja jos ollaan tarpeeksi kaukana niin k‰ynnistet‰‰n SpawnEnemy komento.
    private void Update()
    {
        if (distance < transform.position.x + 30)
            distance = transform.position.x + 25;

        float DistanceToGo = Mathf.Floor(distance - distanceUsed);

        if (distanceUsed < distance && DistanceToGo > 2)
        {
            distanceUsed = distance;
            print(DistanceToGo);
            SpawnEnemy();
        }
    }

    //SpawnEnemy:n sis‰ll‰ on pelin logiikka vihollisten lis‰ykseen.
    //ensin lis‰ttiin Gameobject jolla lis‰t‰‰n eri vihollisia peliin(t‰l‰‰ hetkell‰ kun kirjoitan t‰t‰ komentoa 6.11.2021 klo 8.42 on lis‰tty vain yksi vihollis tyyppi)
    //komento katsoo miss‰ pelaaja menee ja lis‰‰ Rng:ll‰ vihollisen johonkin pelaajan l‰helle
    //Vectori matikka ei ole helppoa joten en ai yritt‰‰ edes selitt‰‰ mit‰ tein koska lˆysin suuren osan t‰st‰ koodista stack overflowsta
    //voin lis‰t‰ ett‰ olen muunellut koodia jonkun verran alkuper‰isest‰ joten ei mennyt ihan kopionniksi
    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = selectEnemyToSpawn();

        float yPos = Mathf.Floor(Mathf.Abs(UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * (1 + 500 - (-2)) + (-2));
        Vector2 posToSpawnEnemy = new Vector2(distance, yPos);

        Instantiate(enemyToSpawn, posToSpawnEnemy, Quaternion.identity);
    }

    private GameObject selectEnemyToSpawn()
    {
        return Enemy;
    }
}
