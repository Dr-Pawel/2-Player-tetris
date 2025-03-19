using UnityEngine;
using UnityEngine.InputSystem;

public class TetrominoController : MonoBehaviour
{
    private GameControls controls; 
    public float moveSpeed = 1f;
    public float fallSpeed = 1f;
    public float fastFallMultiplier = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        controls = new GameControls();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Tetris.MoveLeft.performed += _ => Move(Vector2.left);
        controls.Tetris.MoveRight.performed += _ => Move(Vector2.right);
        controls.Tetris.MoveDown.performed += _ => StartFastFall();
        controls.Tetris.MoveDown.canceled += _ => StopFastFall();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!controls.Tetris.MoveDown.IsPressed()) 
        {
            Fall();
        }
    }

    void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction * moveSpeed;
    }

    void Fall()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fallSpeed);
    }

    void StartFastFall()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fallSpeed * fastFallMultiplier); 
    }

    void StopFastFall()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fallSpeed); 
    }
}
