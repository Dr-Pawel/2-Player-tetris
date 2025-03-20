using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    private Vector2Int[] nextTetrominoShape;
    [SerializeField] Vector2 spawnPos;
    [SerializeField] Vector2 uiSpawnPos;
    [SerializeField] GameObject TetrominoPiece;
    [SerializeField] PhysicsMaterial2D TetrominoMat;
    
    GameObject uiTetrominoObj;

    private void Start()
    {
        nextTetrominoShape = RollRandomTetromino();
        SpawnRandomTetromino();
    }

    public void SpawnRandomTetromino()
    {
        Destroy(uiTetrominoObj);
        SpawnTetromino(nextTetrominoShape, spawnPos);
        UpdateUI();
    }

    void SpawnTetromino(Vector2Int[] shape, Vector2 spawnPosition)
    {
        GameObject tetrominoObj = new GameObject("Tetromino");
        Tetromino tetromino = tetrominoObj.AddComponent<Tetromino>();
        tetromino.InitializeShape(shape);

        Rigidbody2D rb = tetrominoObj.AddComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.mass = 3f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        tetrominoObj.AddComponent<TetrominoController>();
        rb.freezeRotation = true;

        foreach (var pos in shape)
        {
            GameObject block = Instantiate(TetrominoPiece);
            block.transform.parent = tetrominoObj.transform;
            block.transform.position = spawnPosition + (Vector2)pos;

            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.sharedMaterial = TetrominoMat;
        }
    }

    Vector2Int[] RollRandomTetromino()
    {
        Vector2Int[][] shapes = {
            TetrominoShapes.I,
            TetrominoShapes.O,
            TetrominoShapes.T,
            TetrominoShapes.L
        };

        Vector2Int[] randomShape = shapes[Random.Range(0, shapes.Length)];
        return randomShape;
    }

    void UpdateUI()
    {
        nextTetrominoShape = RollRandomTetromino();
        SpawnTetrominoOnUI(nextTetrominoShape, uiSpawnPos);        
    }

    void SpawnTetrominoOnUI(Vector2Int[] shape, Vector2 spawnPosition)
    {
        uiTetrominoObj = new GameObject("Tetromino");
        Tetromino tetromino = uiTetrominoObj.AddComponent<Tetromino>();
        tetromino.InitializeShape(shape);

        foreach (var pos in shape)
        {
            GameObject block = Instantiate(TetrominoPiece);
            block.transform.parent = uiTetrominoObj.transform;
            block.transform.position = spawnPosition + (Vector2)pos;
        }
    }
}
