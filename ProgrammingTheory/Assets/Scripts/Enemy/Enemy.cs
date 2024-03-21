using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public GameObject missile; // Reference to the missile prefab
    private GameManager gameManager;

    protected float movementSpeed = 15f; // Speed at which the enemy moves towards the player
    protected float fireInterval = 3f; // Time interval between firing missiles
    protected float rotationSpeed = 2.5f; // Speed at which the enemy rotates towards the player

    protected float lastTimeFired; // Time when the last missile was fired

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindObjectOfType<GameManager>();
        lastTimeFired = Time.time; // Initialize last fire time
    }

    protected virtual void Update()
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
            if (!gameManager.isGameOver && Time.time - lastTimeFired >= fireInterval)
            {
                FireMissile();
                lastTimeFired = Time.time; // Update last fire time
            }
        }
    }

    protected virtual void FireMissile()
    {
        if (missile != null)
        {
            // Calculate the position ahead of the player
            Vector3 spawnPosition = transform.position + transform.forward * 10f;

            // Instantiate the missile prefab at the calculated position and rotation of the player
            Instantiate(missile, spawnPosition, transform.rotation);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("Player"))
        {
            // Destroy both the enemy and the player
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
}

