using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // Check if the mine collides with a player, enemy, or missile
        if (other.CompareTag("Player") || other.CompareTag("Enemy") || other.CompareTag("Missile"))
        {
            // Destroy the GameObject that the mine collides with
            Destroy(other.gameObject);

            // Destroy the mine itself
            Destroy(gameObject);
        }
    }
}
