using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralSpawns : MonoBehaviour
{
    public GameObject Neutral;

    private float distance;
    private float distanceUsed;

    private void Update()
    {
        if (distance < transform.position.x + 40)
            distance = transform.position.x + 20;

        float DistanceToGo = Mathf.Floor(distance - distanceUsed);

        if(distanceUsed < distance && DistanceToGo > 2)
        {
            distanceUsed = distance;
            print(DistanceToGo);
            SpawnNeutral();
        }
    }
    private void SpawnNeutral()
    {
        GameObject NeutralToSpawn = selectNeutralToSpawn();

        float yPos = Mathf.Floor(Mathf.Abs(UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * (1 + 500 - (-5)));
        Vector2 posToSpawnNeutral = new Vector2(distance, yPos);

        Instantiate(NeutralToSpawn, posToSpawnNeutral, Quaternion.identity);
    }

    private GameObject selectNeutralToSpawn()
    {
        return Neutral;
    }
}
