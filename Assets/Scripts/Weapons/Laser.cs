using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    // The laser beam game object
    public GameObject laserBeam;

    // The damage the laser beam does to objects it hits
    public int damage = 10;

    // The speed at which the laser beam moves
    public float beamSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // If the user presses the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new laser beam game object at the position of the laser gun
            GameObject beam = Instantiate(laserBeam, transform.position, Quaternion.identity);

            // Get the Rigidbody component of the laser beam
            Rigidbody rb = beam.GetComponent<Rigidbody>();

            // Set the velocity of the laser beam to move in the forward direction of the laser gun
            rb.velocity = transform.forward * beamSpeed;

            // Destroy the laser beam after 1 second
            Destroy(beam, 1f);
        }
    }

    // Function called when the laser beam collides with another object
    void OnTriggerEnter(Collider other)
    {
        // If the laser beam hits an object with a Health script
        if (other.gameObject.GetComponent<Health>() != null)
        {
            // Get the Health script of the object
            Health health = other.gameObject.GetComponent<Health>();

            // Reduce the object's health by the damage of the laser beam
            health.currentHealth -= damage;

            // Destroy the laser beam
            Destroy(gameObject);
        }
    }
}
