using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //simppeli seuraa pelaaja kamera scripti
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if(player.activeInHierarchy == false)
        {

        }
        else transform.position = player.transform.position + offset;       
    }
}

