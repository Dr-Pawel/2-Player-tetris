using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    [SerializeField] Vector2 spawnPos;
    [SerializeField] GameObject TetrominoPiece;

    private void Start()
    {
        SpawnRandomTetromino();
    }

    public void SpawnRandomTetromino()
    {
        Vector2Int[][] shapes = {
            TetrominoShapes.I,
            TetrominoShapes.O,
            TetrominoShapes.T,
            TetrominoShapes.L
        };

        Vector2Int[] randomShape = shapes[Random.Range(0, shapes.Length)];

        SpawnTetromino(randomShape, spawnPos);
    }

    void SpawnTetromino(Vector2Int[] shape, Vector2 spawnPosition)
    {
        GameObject tetrominoObj = new GameObject("Tetromino");
        Tetromino tetromino = tetrominoObj.AddComponent<Tetromino>();
        tetromino.InitializeShape(shape);

        Rigidbody2D rb = tetrominoObj.AddComponent<Rigidbody2D>();
        rb.gravityScale = 1f;

        tetrominoObj.AddComponent<TetrominoController>();
        rb.freezeRotation = true;

        foreach (var pos in shape)
        {
            GameObject block = Instantiate(TetrominoPiece);
            block.transform.parent = tetrominoObj.transform;
            block.transform.position = spawnPosition + (Vector2)pos;

            BoxCollider2D collider = block.AddComponent<BoxCollider2D>();
        }
    }
}
