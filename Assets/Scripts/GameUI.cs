using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject startPanel;

    private void Start()
    {
        GameManager.Instance.OnGameStarted += GameManager_OnGameStarted;
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
        GameManager.Instance.OnLivesChanged += GameManager_OnLivesChanged;
    }

    private void GameManager_OnLivesChanged(object sender, System.EventArgs e)
    {
        livesText.text = $"Lives: {GameManager.Instance.GetLives()}";
    }

    private void GameManager_OnScoreChanged(object sender, System.EventArgs e)
    {
        scoreText.text = $"{GameManager.Instance.GetScore()}";
    }

    private void GameManager_OnGameStarted(object sender, System.EventArgs e)
    {
        livesText.text = $"Lives: {GameManager.Instance.GetLives()}";
        scoreText.text = $"{GameManager.Instance.GetScore()}";
    }
}
