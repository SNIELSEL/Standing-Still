using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;
    public float spawnDistance;

    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if (distanceToHorizon < 120)
        {
            SpawnTriangle();
        }
    }
    void SpawnTriangle()
    {
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + spawnDistance);
        Instantiate (trianglePrefabs [(0)], spawnObstaclePosition, Quaternion.identity);
    }
}
