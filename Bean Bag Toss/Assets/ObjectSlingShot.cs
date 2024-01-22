using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSlingShot : MonoBehaviour
{
    public GameObject[] objectsToSlingShot;
    public float slingShotForce = 10f;
    public Vector2 slingShotDirection = new Vector2(0f, 1f); 

    private bool gravityEnabled = false;

    void Start()
    {
        // SlingShotObjects();
    }

    public void SlingShotObjects()
    {
        foreach (GameObject obj in objectsToSlingShot)
        {
            if (obj != null) // Check if the object is not null
            {
                // Disable gravity temporarily
                obj.GetComponent<Rigidbody2D>().gravityScale = 0f;

                // Apply a force to sling-shot object(s)
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 force = slingShotDirection.normalized * slingShotForce;
                    rb.velocity = force;
                }
                else
                {
                    Debug.LogWarning("The object doesn't have a Rigidbody2D component.");
                }
            }
        }

        // Set a timer to re-enable gravity after a certain duration
        Invoke("EnableGravity", 2f); // Adjust the duration as needed
    }

    void EnableGravity()
    {
        gravityEnabled = true;

        // Re-enable gravity for all objects
        foreach (GameObject obj in objectsToSlingShot)
        {
            if (obj != null) 
            {
                obj.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            }
        }
    }
    
}
