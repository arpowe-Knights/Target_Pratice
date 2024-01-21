using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public float moveVelocity = 5f; // Adjust the velocity as needed
    public float maxSpinSpeed = 180f; // Maximum spin speed in degrees per second

    private bool hasSpawned = false;

    void Awake()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        if (!hasSpawned)
        {
            // Spawn the object at the start of the game
            Vector2 spawnPosition = new Vector2(0f, 0f); // Adjust the spawn position as needed
            GameObject spawnedObject = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);

            // Calculate the spin speed based on the velocity
            float spinSpeed = Mathf.Clamp(moveVelocity * 10f, 0f, maxSpinSpeed);

            // Make the spawned object spin on its Z-axis based on the calculated spin speed
            spawnedObject.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
            spawnedObject.GetComponent<Rigidbody2D>().angularVelocity = spinSpeed;

            // Move the spawned object across the Y-axis
            Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(0f, moveVelocity);
            }
            else
            {
                Debug.LogWarning("The spawned object doesn't have a Rigidbody2D component.");
            }

            hasSpawned = true;
        }
    }
}
