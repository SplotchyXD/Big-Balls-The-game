using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// T�t� skripti� voidaan hy�dynt�� monen erilaisen nostettavan itemin tekemiseen
/// </summary>
public class Pickupable : MonoBehaviour
{
    [Header("Item Data")]
    public string itemName; // Itemin nimi  
    public int value; // Itemin value, esim hinta

    [Header("Other Variables")]
    public float rotationSpeed = 10; // kuinka nopeasti itemi py�rii kent�ll�

    void Update()
    {
        // Py�ritet��n itemi� kent�ll� Y-askelilla (transform.up => y-akseli)
        this.transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
    }
}
