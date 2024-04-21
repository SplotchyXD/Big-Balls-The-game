using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Tätä scriptiä käytetään Menussa olevien pallojen Luontiin
    public static Spawner instance;

    public GameObject Player;
    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;

    //kerrotaan aloituksessa että käytössä olevat gameobjektit ovat käytössä(jostain syystä saattavat pistää itsensä pois päältä joten tällä varmistetaan että ovat päällä silloin kun sille on tarvetta) 
    private void Start()
    {
        Player.SetActive(true);
        Red.SetActive(true);
        Yellow.SetActive(true);
        Green.SetActive(true);

        if (gameObject.name == "PlayerSpawner")
            Instantiate(Player, transform.position, Quaternion.identity);
        if (gameObject.name =="RedSpawner")
            Instantiate(Red, transform.position, Quaternion.identity);
        if (gameObject.name == "YellowSpawner")
            Instantiate(Yellow, transform.position, Quaternion.identity);
        if (gameObject.name =="GreenSpawner")
            Instantiate(Green, transform.position, Quaternion.identity);
    }

    //alhaalla on kaikille palloille omat luonti funktiot
    public void SpawnPlayer()
    {
        if (gameObject.name == "PlayerSpawner")
            Instantiate(Player, transform.position, Quaternion.identity);
    }

    public void SpawnRed()
    {
        if (gameObject.name == "RedSpawner")
            Red.SetActive(true);
            Instantiate(Red, transform.position, Quaternion.identity);
    }

    public void SpawnYellow()
    {
        if (gameObject.name == "YellowSpawner")
            Yellow.SetActive(true);
            Instantiate(Yellow, transform.position, Quaternion.identity);
    }

    public void SpawnGreen()
    {
        if (gameObject.name == "GreenSpawner")
            Green.SetActive(true);
            Instantiate(Green, transform.position, Quaternion.identity);
    }
}
