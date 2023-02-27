using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public float minTime;
    public float maxTime;

    private float spawnTimer = 1.5f;
    private int randEnemy;
    private int randSpawnPoint;
    private int randNumOfEnemies;
    public bool kill = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy",spawnTimer);
    }

    void Update()
    {
        // Random Spawn Timer
        spawnTimer = Random.Range(minTime, maxTime);

        // Random Enemy Prefabs
        randEnemy = Random.Range(0, enemyPrefabs.Length);

        // Random Spawn Point
        randSpawnPoint = Random.Range(0, spawnPoints.Length);

        // Random number of enemies
        randNumOfEnemies = Random.Range(0, spawnPoints.Length);
    }

    public void SpawnEnemy()
    {
        if (randSpawnPoint + randNumOfEnemies > spawnPoints.Length)
        {
            StartCoroutine(MultipleEnemies(0, enemyPrefabs[0]));
        }
        else
        {
            StartCoroutine(MultipleEnemies(0, enemyPrefabs[0]));
        }
        Invoke("SpawnEnemy", spawnTimer); // Recurrsion
    }

    public IEnumerator MultipleEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        int numOfEnemies = spawnPoints.Length - randSpawnPoint;
        int difference = randSpawnPoint + numOfEnemies;       
        for (int i = randSpawnPoint; i < difference; i++)
        {
            if (!kill)
            {
                // Random Prefab Generator selected from list from 0 to the list length
                randEnemy = Random.Range(0, enemyPrefabs.Length);

                // Spawn enemies here -> (The prefab, position, Quaternion.Identity)
                Instantiate(enemyPrefabs[randEnemy], spawnPoints[i].position, Quaternion.identity);
            }          
        }
    }
}
