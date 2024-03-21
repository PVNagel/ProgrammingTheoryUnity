using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed = 20f; // Speed of the missile
    public float destroyDelay = 3f; // Time before the missile is destroyed

    void Start()
    {
        // Set the velocity of the missile to move forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        // Destroy the missile after a delay
        Destroy(gameObject, destroyDelay);
    }
}
