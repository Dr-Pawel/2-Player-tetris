using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public Vector2Int[] shape;
    private Rigidbody2D rb;
    private bool isLocked = false;

    private float lockDelay = 0.2f; 
    private float lockTimer = 0f;

    public void InitializeShape(Vector2Int[] newShape)
    {
        shape = newShape;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (lockTimer > 0f && Time.time >= lockTimer)
        {
            LockTetromino();
            lockTimer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLocked) return; 

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal == Vector2.up) 
            {
                lockTimer = Time.time + lockDelay;
            }
        }
    }

    void LockTetromino()
    {
        isLocked = true;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.tag = "Block";

        Vector2 roundedPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        transform.position = roundedPos;

        GetComponent<TetrominoController>().enabled = false;
        FindObjectOfType<TetrominoSpawner>().SpawnRandomTetromino();

        CheckForFullLines(); 
    }

    void CheckForFullLines()
    {
        // TODO: Check If line is full implementation
    }
}
