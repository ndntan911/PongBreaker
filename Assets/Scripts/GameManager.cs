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
    public event EventHandler<OnGameOverArgs> OnGameOver;
    public class OnGameOverArgs : EventArgs { public int score; public int lives; public int bricksDestroyed; }

    [Header("Gameplay")]
    public int startingLives = 3;
    private int bricksTotal;

    int score;
    int lives;
    int bricksDestroyed;

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
        Time.timeScale = 0f; // pause until start
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void AddScore(int _score)
    {
        score += _score;
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
        Time.timeScale = 0f;
        OnGameOver?.Invoke(this, new OnGameOverArgs { score = score, lives = lives, bricksDestroyed = bricksDestroyed });
    }

    void Lose()
    {
        Time.timeScale = 0f;
        OnGameOver?.Invoke(this, new OnGameOverArgs { score = score, lives = lives, bricksDestroyed = bricksDestroyed });
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
