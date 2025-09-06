using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI stateText;

    private void Start()
    {
        Hide();
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }

    private void GameManager_OnGameOver(object sender, GameManager.OnGameOverArgs e)
    {
        Show();
        scoreText.text = $"Score: {e.score}";
        stateText.text = e.lives > 0 ? "You Win!" : "You Lose!";
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
