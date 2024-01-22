using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite shootingCursor;

    private static ObjectClickHandler _instance;
    public static ObjectClickHandler Instance { get { return _instance; } }

    private int totalObjects = 0;
    private int destroyedObjects = 0;

    public int scoreValue;

    public delegate void ObjectClickedAction(int points);
    public static event ObjectClickedAction OnObjectClicked;

    private ScoreManager scoreManager;

    void Awake()
    {
        _instance = this; // Set the instance when the script is first loaded
    }

    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();

        // Get the total number of objects in the scene
        totalObjects = GameObject.FindGameObjectsWithTag("Destroyable").Length;

        scoreManager = GameObject.Find("Global Object").GetComponent<ScoreManager>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if the player has clicked (object)
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            CursorController.Instance.ShootSound();
            
            // Send Raycast to check if the mouse click
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);
                Debug.Log("Object tag: " + hit.collider.tag);

                if (hit.collider.CompareTag("Destroyable"))
                {
                    int points = GetPointsBasedOnLayer(hit.collider.gameObject.layer);
                    // OnObjectClicked?.Invoke(points);

                    Destroy(hit.collider.gameObject);

                    // Update the count of destroyed objects
                    destroyedObjects++;

                    scoreManager.IncrementScore(scoreValue);

                    CursorController.Instance.EmitParticles(50);
                }
            }

            // Check if all objects are destroyed
            // if (destroyedObjects == totalObjects)
            // {
            //     WinLose.EndGame(); // Assuming WinLose has a static EndGame method
            // }
        }
    }

    int GetPointsBasedOnLayer(int layer)
    {
        // Check if the layer is "red" 
        if (LayerMask.LayerToName(layer) == "red")
        {
            return 50;
        }

        // Default points
        return 25;
    }

    // Method to get the total number of objects
    public int GetTotalObjects()
    {
        return totalObjects;
    }

    // Method to get the number of destroyed objects
    public int GetDestroyedObjects()
    {
        return destroyedObjects;
    }

    // Method to get the total score
    public int GetTotalScore()
    {
        // Implement your logic to calculate the total score
        // This might involve summing up scores of all objects, etc.
        return 0;
    }
}
