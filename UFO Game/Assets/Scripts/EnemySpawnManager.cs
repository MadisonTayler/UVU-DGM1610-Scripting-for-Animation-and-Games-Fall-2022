using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    [SerializeField]
    private float spawnRangeX = 17.0f;
    [SerializeField]
    private float spawnPosZ;

    private float startDelay = 2f;
    private float spawnInterval = 2f;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandomEnemy", startDelay, spawnInterval);
    }

    void spawnRandomEnemy()
    {
        // Generate a position to spawn at
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0, spawnPosZ);

        // Pick a random enemy/ufo from the array
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        
        // Spawn the enemy indexed from the array
        // transform.rotate makes sure it is oriented the same way it is in the prefab
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
