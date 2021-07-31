using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject platform;
    public GameObject powerup;

    private float xSpawnRange = 15.0f;
    private float ySpawnPos = 0f;
    private float zSpawnPos = 12.0f;

    private float powerupSpawnTime = 5.0f;
    private float platformSpawnTime = 3.0f;
    private float enemySpawnTime = 2f;
    private float startDelay = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPlatform", startDelay, platformSpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(randomX, ySpawnPos + 1.1f, zSpawnPos);
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }
    void SpawnPlatform()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        Vector3 spawnPos = new Vector3(randomX, ySpawnPos, zSpawnPos);
        Instantiate(platform, spawnPos, platform.gameObject.transform.rotation);

    }
    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        Vector3 spawnPos = new Vector3(randomX, ySpawnPos + 0.5f, zSpawnPos);
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
