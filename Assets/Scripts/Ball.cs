using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance { get; private set; }

    Rigidbody2D rb;
    public float speed = 6f;
    public Transform paddleTransform;
    Vector3 paddleOffset;
    bool launched = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        paddleOffset = transform.position - paddleTransform.position;
        ResetToPaddle();
    }

    void Update()
    {
        if (!launched)
        {
            // stick to paddle
            transform.position = paddleTransform.position + paddleOffset;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Launch();
            }
        }
    }

    void FixedUpdate()
    {
        if (launched && rb.linearVelocity.magnitude != speed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }

    public void Launch()
    {
        if (launched) return;
        launched = true;
        float angle = Random.Range(-30f, 30f);
        Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.up;
        rb.linearVelocity = dir.normalized * speed;
    }

    public void ResetToPaddle()
    {
        launched = false;
        rb.linearVelocity = Vector2.zero;
        transform.position = paddleTransform.position + paddleOffset;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Prevent straight vertical bounce (adds small horizontal tweak)
        Vector2 v = rb.linearVelocity;
        if (v.x < 2f && v.x >= 0f)
        {
            v.x += 2f;
            rb.linearVelocity = v.normalized * speed;
        }
        else if (v.x > -2f && v.x < 0f)
        {
            v.x += -2f;
            rb.linearVelocity = v.normalized * speed;
        }
        else if (v.y < 2f && v.y >= 0f)
        {
            v.y += 2f;
            rb.linearVelocity = v.normalized * speed;
        }
        else if (v.y > -2f && v.y < 0f)
        {
            v.y += -2f;
            rb.linearVelocity = v.normalized * speed;
        }
    }

    // public API for GameManager to respawn ball if fall out
    public void Kill()
    {
        // If ball falls below bottom
        // notify GameManager
        GameManager.Instance.LoseLife();
    }
}
