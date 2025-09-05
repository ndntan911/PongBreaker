using UnityEngine;

public class BottomTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            // Move ball out of view and notify
            other.gameObject.SetActive(false);
            Ball.Instance.Kill();
            // Reactivate ball after a small delay (GameManager will call ResetToPaddle)
            other.gameObject.SetActive(true); // immediate re-enable; Ball.ResetToPaddle called by GameManager.LoseLife
        }
    }
}
