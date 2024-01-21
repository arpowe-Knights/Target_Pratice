using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    // Invoked when the object is clicked
    public delegate void ObjectClickedAction(int points);
    public static event ObjectClickedAction OnObjectClicked;

    // Update is called once per frame
    void Update()
    {
        // if the player has clicked (object)
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            // Send Raycast to check if the mouse click hit an object in 2D
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Log additional information for debugging
                Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);
                Debug.Log("Object tag: " + hit.collider.tag);

                // Check if the clicked object has a specific tag (you can customize this)
                if (hit.collider.CompareTag("Destroyable"))
                {
                    // Notify subscribers that an object has been clicked
                    int points = GetPointsBasedOnLayer(hit.collider.gameObject.layer);
                    OnObjectClicked?.Invoke(points);

                    // Destroy the object
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    int GetPointsBasedOnLayer(int layer)
    {
        // Check if the layer is "red" and return points accordingly
        if (LayerMask.LayerToName(layer) == "red")
        {
            return 50;
        }

        // Default points if the layer doesn't match
        return 25;
    }
}
