using UnityEngine;

public class Stalker2D : MonoBehaviour
{
    [Header("Speeds")]
    public float patrolSpeed = 0.4f;   // very slow to "stalk" the player
    public float investigateSpeed = 3.5f;
    public float chaseSpeed = 5f;

    [Header("Distances")]
    public float stopDistance = 0.2f;
    public float hearingRadius = 5f;    // how far it can hear pings
    public float chaseRadius = 1.5f;    // start chase if this close
    public float loseChaseRadius = 3f;  // stop chase if this far

    private Rigidbody2D rb;
    private Transform player;

    private Vector2? investigateTarget = null;

    private enum State { Patrol, Investigate, Chase }
    private State state = State.Patrol;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        state = State.Patrol;   // force start in Patrol
    }
    void FixedUpdate()
    {
        switch (state)
        {
            case State.Patrol:
                DoPatrol();
                break;
            case State.Investigate:
                DoInvestigate();
                break;
            case State.Chase:
                DoChase();
                break;
        }
        // Catch player //might not use this later :)
        if (Vector2.Distance(rb.position, (Vector2)player.position) < 0.4f)
        {
            Debug.Log("Caught by the stalker!");
        }
    }

    void DoPatrol()
    {
        if (patrolSpeed <= 0f)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // Slowly home towards the player.. so it "stalks" you
        if (player != null)
        {
            Vector2 dir = ((Vector2)player.position - rb.position).normalized;
            rb.linearVelocity = dir * patrolSpeed;   // small speed
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }


    void DoInvestigate()
    {
        if (!investigateTarget.HasValue)
        {
            state = State.Patrol;
            return;
        }

        Vector2 target = investigateTarget.Value;
        Vector2 dir = target - rb.position;

        if (dir.magnitude < stopDistance)
        {
            investigateTarget = null;
            state = State.Patrol;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = dir.normalized * investigateSpeed;

        float distToPlayer = Vector2.Distance(rb.position, (Vector2)player.position);
        if (distToPlayer < chaseRadius)
        {
            state = State.Chase;
        }
    }

    void DoChase()
    {
        Vector2 dir = (Vector2)player.position - rb.position;
        rb.linearVelocity = dir.normalized * chaseSpeed;

        float distToPlayer = dir.magnitude;
        if (distToPlayer > loseChaseRadius)
        {
            state = State.Patrol;
            investigateTarget = null;
        }
    }

    // Called by player sonar not sure if going to use this but might be useful for stalker to react to pings
    public void OnSonarPing(Vector2 pingPos)
    {
        // Only react if within range of the ping
        if (Vector2.Distance(rb.position, pingPos) > hearingRadius)
            return;

        // Go near the ping
        Vector2 offset = Random.insideUnitCircle * 0.7f;
        investigateTarget = pingPos + offset;

        state = State.Investigate;
    }
}
