using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomber : Enemy
{
    public GameObject mine; // Reference to the mine prefab
    private GameManager gameManager;
    private float mineInterval = 5f; // Time interval between dispersing mines
    private float lastTimeMined; // Time when the last mine was dispersed

    protected override void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        base.Start();
        movementSpeed = 10f; // Adjusted speed for the bomber
        lastTimeMined = Time.time; // Initialize last mine time
    }

    protected override void Update()
    {
        base.Update();

        // Disperse mines at the specified interval
        if (!gameManager.isGameOver && Time.time - lastTimeMined >= mineInterval)
        {
            FireMine();
            base.FireMissile();
            lastTimeMined = Time.time; // Update last mine time
        }
    }

    protected virtual void FireMine()
    {
        if (mine != null)
        {
            // Calculate the position ahead of the bomber
            Vector3 spawnPosition = transform.position - transform.forward * 10f;

            // Instantiate the mine prefab at the calculated position and rotation of the bomber
            Instantiate(mine, spawnPosition, transform.rotation);
        }
    }
}
