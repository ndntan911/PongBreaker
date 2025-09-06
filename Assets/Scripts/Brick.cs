using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitsToBreak = 1;
    public ParticleSystem breakEffect;
    [SerializeField] private Material breakMaterial;
    public AudioClip breakSound;
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private TextMeshPro remainingHitsText;

    int hitsTaken = 0;

    void Start()
    {
        remainingHitsText.text = hitsToBreak.ToString();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ball ball))
        {
            hitsTaken++;
            if (breakSound) AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

            if (hitsTaken >= hitsToBreak)
            {
                ParticleSystemRenderer psRenderer = breakEffect.GetComponent<ParticleSystemRenderer>();
                psRenderer.material = breakMaterial;
                if (breakEffect) Instantiate(breakEffect, transform.position + Vector3.back, Quaternion.identity);
                GameManager.Instance.AddScore(scoreValue);
                Destroy(gameObject);
            }
            else
            {
                // optional: change color/sprite to indicate damage
                remainingHitsText.text = (hitsToBreak - hitsTaken).ToString();
            }
        }
    }
}
