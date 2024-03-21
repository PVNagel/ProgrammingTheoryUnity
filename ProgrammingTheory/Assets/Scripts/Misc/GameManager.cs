using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bomberPrefab; // Reference to the bomber prefab
    public GameObject fighterPrefab; // Reference to the fighter prefab

    public bool isGameOver;
    private float spawnInterval = 3f; // Time interval between spawning enemies
    private float lastSpawnTime; // Time when the last enemy was spawned

    private float leftBound = -130f;
    private float rightBound = 130f;
    private float topBound = 75f;
    private float bottomBound = -75f;

    void Start()
    {
        lastSpawnTime = Time.time; // Initialize last spawn time
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy
        if (!isGameOver && Time.time - lastSpawnTime >= spawnInterval)
        {
            // Randomly decide whether to spawn a bomber or a fighter
            if (Random.value < 0.5f)
            {
                SpawnBomber();
            }
            else
            {
                SpawnFighter();
            }

            lastSpawnTime = Time.time; // Update last spawn time
        }
    }

    void SpawnBomber()
    {
        if (bomberPrefab != null)
        {
            // Instantiate the bomber prefab at a random position
            Vector3 spawnPosition = GenerateRandomSpawnPosition();
            Instantiate(bomberPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnFighter()
    {
        if (fighterPrefab != null)
        {
            // Instantiate the fighter prefab at a random position
            Vector3 spawnPosition = GenerateRandomSpawnPosition();
            Instantiate(fighterPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GenerateRandomSpawnPosition()
    {
        // Randomly select one of the four boundaries
        int boundaryIndex = Random.Range(0, 4);
        float spawnX = 0f, spawnZ = 0f;

        switch (boundaryIndex)
        {
            case 0: // Left boundary
                spawnX = leftBound - 10f;
                spawnZ = Random.Range(bottomBound, topBound);
                break;
            case 1: // Right boundary
                spawnX = rightBound + 10f;
                spawnZ = Random.Range(bottomBound, topBound);
                break;
            case 2: // Top boundary
                spawnX = Random.Range(leftBound, rightBound);
                spawnZ = topBound + 10f;
                break;
            case 3: // Bottom boundary
                spawnX = Random.Range(leftBound, rightBound);
                spawnZ = bottomBound - 10f;
                break;
        }
        return new Vector3(spawnX, 10f, spawnZ);
    }

    public void GameOver()
    {
        isGameOver = true;
        // You can implement game over logic here, such as showing a game over screen or stopping game activities.
        Debug.Log("Game Over!");
    }
}
