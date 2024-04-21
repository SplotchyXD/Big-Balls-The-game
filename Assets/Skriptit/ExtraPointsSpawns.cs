using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPointsSpawns : MonoBehaviour
{
    //Tarkista EnemySpawns.cs jos haluat tarkemmin tiet‰‰ miten scripti toimii
    public GameObject Extra;

    private float distance;
    private float distanceUsed;

    private void Update()
    {
        if (distance < transform.position.x + 100)
            distance = transform.position.x + 150;

        float DistanceToGo = Mathf.Floor(distance - distanceUsed);

        if (distanceUsed < distance && DistanceToGo > 2)
        {
            distanceUsed = distance;
            print(DistanceToGo);
            SpawnExtra();
        }
    }
    private void SpawnExtra()
    {
        GameObject NeutralToSpawn = selectExtraToSpawn();

        float yPos = Mathf.Floor(Mathf.Abs(UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * (1 + 500 - (-5)));
        Vector2 posToSpawnNeutral = new Vector2(distance, yPos);

        Instantiate(NeutralToSpawn, posToSpawnNeutral, Quaternion.identity);
    }

    private GameObject selectExtraToSpawn()
    {
        return Extra;
    }
}
