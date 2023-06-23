using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    private float zEnemySpawn = 12.0f;
    private float xSpawnBound = 16.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 0.75f;
    public float enemySpawnInterval = 2.0f;
    public float powerupSpawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (true)
        {
            SpawnPowerup();
            yield return new WaitForSeconds(powerupSpawnInterval);
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnBound, xSpawnBound);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
    }
    
    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnBound, xSpawnBound);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);
        
        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
        Instantiate(powerup, spawnPos, powerup.transform.rotation);
    }
}
