using UnityEngine;
using UnityEngine.SceneManagement;

public class StalkerAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float killDistance = 0.8f;
    private Vector2 targetPosition;
    private bool hasTarget = false;
    private Rigidbody2D rb;
    private Transform playerTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) playerTransform = player.transform;
        
        targetPosition = transform.position;
    }

    public void AlertStalker(Vector3 noiseLocation)
    {
        targetPosition = noiseLocation;
        hasTarget = true;
        Debug.Log("Stalker heard ping at: " + noiseLocation);
    }

    void FixedUpdate() // Use FixedUpdate for physics movement
    {
        if (!hasTarget || rb == null) return;

        // Move toward the target while respecting wall colliders
        Vector2 currentPos = transform.position;
        Vector2 newPos = Vector2.MoveTowards(currentPos, targetPosition, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(currentPos, targetPosition) < 0.1f)
        {
            hasTarget = false;
        }

        // Kill logic
        if (playerTransform != null && Vector2.Distance(transform.position, playerTransform.position) < killDistance)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}