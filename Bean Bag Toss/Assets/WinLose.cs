// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;

// public class WinLose : MonoBehaviour
// {
//     public Text resultText; // Reference to a UI Text component
//     private ScoreManager scoreManager;

//     void Start()
//     {
//         scoreManager = FindObjectOfType<ScoreManager>();

//         if (scoreManager == null)
//         {
//             Debug.LogError("ScoreManager script not found in the scene!");
//         }
//         else
//         {
//             UpdateResultText();
//         }
//     }

//     void UpdateResultText()
//     {
//         if (resultText != null)
//         {
//             int playerScore = scoreManager.GetPlayerScore();

//             if (playerScore < 125)
//             {
//                 resultText.text = "Better luck next time, Loser!";
//             }
//             else if (playerScore < 250)
//             {
//                 resultText.text = "Ohhh you almost had it";
//             }
//             else
//             {
//                 resultText.text = "Good aimmmm! You Won!";
//             }
//         }
//         else
//         {
//             Debug.LogError("UI Text component not assigned to resultText!");
//         }
//     }

//     public static void EndGame()
//     {
//         // Your logic to end the game (e.g., show game over screen, reset scene, etc.)
//         Debug.Log("Game Over!");
//     }

//     void Update()
//     {
//         // Check if all objects are destroyed
//         if (ObjectClickHandler.Instance.GetDestroyedObjects() == ObjectClickHandler.Instance.GetTotalObjects())
//         {
//             EndGame();
//         }
//     }
// }
