using UnityEngine;

public class Player2DController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Normalize so diagonal movement isn't faster
        input = input.normalized;
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.linearVelocity = input * moveSpeed;
    }
}
