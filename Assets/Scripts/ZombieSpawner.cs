using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] float spawnInterval = 3f;
    float lastSpawnTime;

    private void Start()
    {
        lastSpawnTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (lastSpawnTime < Time.timeSinceLevelLoad - spawnInterval)
        {
            Instantiate(zombiePrefab, transform);
            lastSpawnTime = Time.timeSinceLevelLoad;
        }
    }

}
