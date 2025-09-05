using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitsToBreak = 1;
    public GameObject breakEffect;
    public AudioClip breakSound;

    int hitsTaken = 0;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ball ball))
        {
            hitsTaken++;
            if (hitsTaken >= hitsToBreak)
            {
                if (breakEffect) Instantiate(breakEffect, transform.position, Quaternion.identity);
                if (breakSound) AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                GameManager.Instance.AddScore();
                Destroy(gameObject);
            }
            else
            {
                // optional: change color/sprite to indicate damage
            }
        }
    }
}
