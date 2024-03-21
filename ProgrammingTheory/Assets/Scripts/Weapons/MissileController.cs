using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    private float speed = 25f; // Speed of the missile
    private float destroyDelay = 3f; // Time before the missile is destroyed
    private GameManager gameManager;

    void Start()
    {
        // Set the velocity of the missile to move forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        gameManager = GameObject.FindObjectOfType<GameManager>();

        // Destroy the missile after a delay
        Destroy(gameObject, destroyDelay);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the missile hits a player
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.GameOver();
        }

        if (other.CompareTag("Enemy") || other.CompareTag("Mine"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
