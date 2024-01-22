using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int playerScore = 0;

    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text instructionsText;
    public TMP_Text gameOverText;

    public ObjectSlingShot slingshot1;
    public ObjectSlingShot slingshot2;

    private bool gameStarted;
    private bool gameOver;

    private float timer = 2;

    private const int WinningScore = 4;

    public AudioClip introSound;
    public AudioClip gameplaySong;
    public AudioClip winSound;
    public AudioClip loseSound;

    public AudioSource audioSource;


    void OnEnable()
    {
        // ObjectClickHandler.OnObjectClicked += IncrementScore;
    }

    void OnDisable()
    {
        // stop event when script disabled
        // ObjectClickHandler.OnObjectClicked -= IncrementScore;
    }

    void Start()
    {
        gameStarted = false;
        gameOverText.enabled = false;

        UpdateScoreText();

        PlaySound(introSound);
    }

    private void Update()
    {
        UpdateTimerText();

        if (!gameStarted)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                StartGame();
        }

        else if (gameStarted && !gameOver)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                EndGame();
        }

        else if (gameOver)
        {
            timer -= Time.deltaTime;

        }
    }

    private void StartGame()
    {
        gameStarted = true;

        instructionsText.enabled = false;
        timer = 10;

        slingshot1.SlingShotObjects();
        slingshot2.SlingShotObjects();

        PlaySound(gameplaySong);
    }

    private void EndGame()
    {
        gameOver = true;

        gameOverText.enabled = true;

        // Win condition
        if (playerScore >= WinningScore)
        {
            gameOverText.text = "Game Over.\nYou Win!";
            PlaySound(winSound);
        }

        // Lose condition
        else
        {
            gameOverText.text = $"You Lose!\nYou failed to get {WinningScore} bean bags";
            PlaySound(loseSound);
        }

    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {playerScore}";
    }

    private void UpdateTimerText()
    {
        timerText.text = $"Timer: {timer}";
    }

    public void IncrementScore(int points)
    {
        playerScore += 1;

        Debug.Log("Player Score: " + playerScore);

        UpdateScoreText();
    }
    public int GetPlayerScore()
    {
        return playerScore;
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
