using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    private void Start()
    {
        Hide();
        GameManager.Instance.OnGameStarted += GameManager_OnGameStarted;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Hide();
            GameManager.Instance.StartGame();
        }
    } 

    private void GameManager_OnGameStarted(object sender, System.EventArgs e)
    {
        Show();
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
