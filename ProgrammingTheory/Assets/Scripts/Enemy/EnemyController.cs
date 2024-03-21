using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public GameObject missile; // Reference to the missile prefab
    private float movementSpeed = 15f; // Speed at which the enemy moves towards the player
    private float fireInterval = 3f; // Time interval between firing missiles
    private float lastTimeFired; // Time when the last missile was fired
    private float rotationSpeed = 2.5f; // Speed at which the enemy rotates towards the player

    void Start()
    {
        lastTimeFired = Time.time; // Initialize last fire time
    }

    void Update()
    {
        // Check if the player exists
        if (player != null)
        {
            // Move towards the player's position
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            transform.position += directionToPlayer * movementSpeed * Time.deltaTime;

            // Smoothly rotate towards the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Fire missiles at the specified interval
            if (Time.time - lastTimeFired >= fireInterval)
            {
                FireMissile();
                lastTimeFired = Time.time; // Update last fire time
            }
        }
    }

    void FireMissile()
    {
        if (missile != null)
        {
            // Calculate the position ahead of the player
            Vector3 spawnPosition = transform.position + transform.forward * 10f;

            // Instantiate the missile prefab at the calculated position and rotation of the player
            Instantiate(missile, spawnPosition, transform.rotation);
        }
    }
}
