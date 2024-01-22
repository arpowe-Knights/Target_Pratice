using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 60f; 

    void Start()
    {
        StartCoroutine(RotateObject());
    }

    IEnumerator RotateObject()
    {
        while (true) // Rotate continuously
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            // Destroy the object when colliding with an object tagged "Boundary"
            Destroy(gameObject);
        }
    }
}
