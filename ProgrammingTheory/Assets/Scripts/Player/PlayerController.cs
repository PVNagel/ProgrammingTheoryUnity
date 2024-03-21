using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 40f; // Adjust this value to control the maximum speed
    public float forwardForce = 5f; // Adjust this value to control the forward force
    public float rotationSpeed = 150f; // Adjust this value to control the rotation speed
    public GameObject missile; // Reference to the missile prefab
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the object
    }

    void Update()
    {
        // Read input for forward movement
        if (Input.GetKey(KeyCode.W))
        {
            // Apply forward force to move the object
            rb.AddForce(transform.forward * forwardForce);
        }

        // Check current velocity magnitude
        if (rb.velocity.magnitude > maxSpeed)
        {
            // If current velocity exceeds max speed, limit it
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Read input for rotation
        float rotationInput = Input.GetAxis("Horizontal");

        // Calculate the rotation amount based on input
        float rotationAmount = -rotationInput * rotationSpeed * Time.deltaTime;

        // Apply rotation to the object
        transform.Rotate(Vector3.up * rotationAmount);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissile();
        }
    }

    void FireMissile()
    {
        if (missile != null)
        {
            // Calculate the position ahead of the player
            Vector3 spawnPosition = transform.position + transform.forward * 7.5f;

            // Instantiate the missile prefab at the calculated position and rotation of the player
            Instantiate(missile, spawnPosition, transform.rotation);
        }
    }
}
