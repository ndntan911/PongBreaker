using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    public int rows = 5;
    public int cols = 10;
    public Vector2 startPos = new Vector2(-7.5f, 4f);
    public Vector2 spacing = new Vector2(1.6f, 0.7f);

    void Start()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Vector2 pos = startPos + new Vector2(c * spacing.x, -r * spacing.y);
                Instantiate(GetRandomBrickPrefab(), pos, Quaternion.identity, transform);
            }
        }

        // Let GameManager know total bricks
        GameManager gm = GameManager.Instance;
        if (gm != null) gm.SetBricksTotal(rows * cols);
    }

    private GameObject GetRandomBrickPrefab()
    {
        return brickPrefabs[Random.Range(0, brickPrefabs.Length)];
    }
}
