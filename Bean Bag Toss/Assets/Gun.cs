using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if the ray hits any collider
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Check if the hit object has a specific component (e.g., Collider or script)
                if (hit.collider != null)
                {
                    // Perform your interaction logic here
                    // For example, you can access the GameObject that was clicked:
                    GameObject clickedObject = hit.collider.gameObject;

                    // Add your interaction code here
                    // For example, print the name of the clicked object
                    Debug.Log("Clicked on: " + clickedObject.name);

                    // Add more interaction logic as needed
                }
            }
        }
    }
}

