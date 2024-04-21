using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehaviour : MonoBehaviour
{
    public GameObject Player;

    //hyvin simpplei oncollision tarkastus Lava objekteille
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            Player.SetActive(false);
        }
    }
}
