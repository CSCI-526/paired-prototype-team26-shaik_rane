using UnityEngine;

public class TopDownMovement : MonoBehaviour 
{
    public float moveSpeed = 400f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("TopDownMovement: No Rigidbody2D found on " + gameObject.name + ". Movement will not work.");
        }
    }

    void Update() 
    {
        // Get input for WASD / Arrow Keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() 
    {
        // Apply movement to the player's physics using velocity
        if (rb == null)
            return;

        Vector2 velocity = movement.normalized * moveSpeed;
        rb.linearVelocity = velocity;
    }
}