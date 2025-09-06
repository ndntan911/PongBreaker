using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public float clampX = 7.5f; // edge limits, adjust to camera size
    Camera cam;
    [SerializeField] private AudioClip hitSound;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Keyboard / A/D / LeftRight
        float h = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x = pos.x + h * speed * Time.deltaTime;

        // Mouse control (optional)
        // if (Input.GetMouseButton(0))
        // {
        // Vector3 world = cam.ScreenToWorldPoint(Input.mousePosition);
        // pos.x = Mathf.Lerp(pos.x, world.x, speed * Time.deltaTime);
        // }

        pos.x = Mathf.Clamp(pos.x, -clampX, clampX);
        transform.position = pos;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Ball ball))
        {
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, 1f);
        }
    }
}
