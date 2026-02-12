using UnityEngine;

public class Player2DController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sonarRadius = 3f;
    public float sonarDuration = 0.25f;

    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SonarPing();
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
    void SonarPing()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, sonarRadius);

        foreach (Collider2D c in hits)
        {
            // Reveal walls!!! 
            SonarRevealed2D sr = c.GetComponent<SonarRevealed2D>();
            if (sr != null)
            {
                sr.Reveal(sonarDuration);
            }
            // Alert stalker!!! 
            Stalker2D stalker = c.GetComponent<Stalker2D>();
            if (stalker != null)
            {
                stalker.OnSonarPing(transform.position);
            }
        }
    }
}
