using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMove : MonoBehaviour
{
    //Automaattinen liike Scripti

    autoMoveManager Amm;

    // Start is called before the first frame update
    void Start()
    {
        GameObject AutoMoveController = GameObject.FindGameObjectWithTag("AutoMoveManager");
        Amm = AutoMoveController.GetComponent<autoMoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Amm.moveVector * Amm.moveSpeed * Time.deltaTime);
    }
}
