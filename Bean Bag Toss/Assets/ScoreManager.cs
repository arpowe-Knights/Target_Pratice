using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int playerScore = 0; // Variable to store the player's score

    void OnEnable()
    {
        // Subscribe to the event when an object is clicked
        ObjectClickHandler.OnObjectClicked += IncrementScore;
    }

    void OnDisable()
    {
        // Unsubscribe from the event when the script is disabled
        ObjectClickHandler.OnObjectClicked -= IncrementScore;
    }

    void IncrementScore(int points)
    {
        // Increment the player's score
        playerScore += points;

        // Display the player's score in the console
        Debug.Log("Player Score: " + playerScore);
    }
}
