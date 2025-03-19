using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public Vector2Int[] shape;
    private Rigidbody2D rb;
    private bool isLocked = false;

    public void InitializeShape(Vector2Int[] newShape)
    {
        shape = newShape;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLocked) return;

        if (!isLocked && collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block"))
        {
            LockTetromino();
        }
    }

    void LockTetromino()
    {
        isLocked = true;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.tag = "Block";

        GetComponent<TetrominoController>().enabled = false;
        FindObjectOfType<TetrominoSpawner>().SpawnRandomTetromino();

        CheckForFullLines(); 
    }

    void CheckForFullLines()
    {
        // TODO: Check If line is full implementation
    }
}
