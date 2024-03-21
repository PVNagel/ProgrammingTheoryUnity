using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxSpeed = 40f; // Adjust this value to control the maximum speed
    private float forwardForce = 5f; // Adjust this value to control the forward force
    private float rotationSpeed = 150f; // Adjust this value to control the rotation speed
    public GameObject missile; // Reference to the missile prefab
    private Rigidbody rb;

    // Define play area boundaries
    private float leftBound = -130f;
    private float rightBound = 130f;
    private float topBound = 75f;
    private float bottomBound = -75f;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the object
    }

    void Update()
    {
        Movement();
        WrapAround();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissile();
        }
    }

    void Movement()
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

    void WrapAround()
    {
        // Check if player is outside the left boundary
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
        // Check if player is outside the right boundary
        else if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        // Check if player is outside the top boundary
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
        // Check if player is outside the bottom boundary
        else if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
        }
    }
}
