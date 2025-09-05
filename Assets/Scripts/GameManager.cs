using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler OnGameStarted;
    public event EventHandler OnScoreChanged;
    public event EventHandler OnLivesChanged;

    [Header("Gameplay")]
    public int startingLives = 3;
    private int bricksTotal;
    public int scorePerBrick = 10;

    int score;
    int lives;
    int bricksDestroyed;

    bool gameStarted;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        lives = startingLives;
        score = 0;
        bricksDestroyed = 0;
        OnGameStarted?.Invoke(this, EventArgs.Empty);
        // winPanel.SetActive(false);
        // losePanel.SetActive(false);
        // startPanel.SetActive(true);
        // Time.timeScale = 0f; // pause until start
    }

    public void StartGame()
    {
        gameStarted = true;
        // startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddScore()
    {
        score += scorePerBrick;
        bricksDestroyed++;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
        if (bricksDestroyed >= bricksTotal) Win();
    }

    public void LoseLife()
    {
        lives--;
        OnLivesChanged?.Invoke(this, EventArgs.Empty);
        if (lives <= 0) Lose();
        else
        {
            Ball.Instance.ResetToPaddle();
        }
    }

    void Win()
    {
        // Time.timeScale = 0f;
        // winPanel.SetActive(true);
    }

    void Lose()
    {
        Time.timeScale = 0f;
        // losePanel.SetActive(true);
    }

    void UpdateUI()
    {
        // if (scoreText) scoreText.text = $"Score: {score}";
        // if (livesText) livesText.text = $"Lives: {lives}";
    }

    // simple restart
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetBricksTotal(int total)
    {
        bricksTotal = total;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetLives()
    {
        return lives;
    }
}
