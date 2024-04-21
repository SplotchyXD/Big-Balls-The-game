using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ebintesti : MonoBehaviour
{
    //scriptill‰ tarkisteaan mihin pelaaja on osunut ja sen mukaan luodaan unity partikkeleita

    public GameObject Blood;
    public GameObject Rubble;
    public GameObject PointsBlood;
    public GameObject Lava;
    //luodaan public gameobjeckti verelle

    //kerrotaan ett‰ jos pelaaja osuu sein‰‰n niin kutsutaan osuma animaatio mutta lis‰t‰‰n myˆs ett‰ jos se on jotain muuta niin k‰ytet‰‰n objecktille laitettu animaatio
    //alkuper‰isesti piti vain olla kuten nimest‰ huomaa mutta muuttui permamentiksi lis‰ykseksi
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Level"))
            Instantiate(Rubble, transform.position, Quaternion.identity);
        else if (col.collider.CompareTag("Neutrals"))
            Instantiate(Blood, transform.position, Quaternion.identity);
        else if (col.collider.CompareTag("BigMoney"))
            Instantiate(PointsBlood, transform.position, Quaternion.identity);
        else if (col.collider.CompareTag("Lava"))
            Instantiate(Lava, transform.position, Quaternion.identity);
    }
}
