using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ball ball))
        {
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, 1f);
        }
    }
}
