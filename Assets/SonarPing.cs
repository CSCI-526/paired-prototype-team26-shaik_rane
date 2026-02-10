using UnityEngine;
using System.Collections;

public class SonarPing : MonoBehaviour
{
    public float pingRadius = 15f; 
    public float revealDuration = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformPing();
        }
    }

    void PerformPing()
    {
        // 1. Alert the Stalker (as we discussed for the hearing logic)
        StalkerAI stalker = Object.FindFirstObjectByType<StalkerAI>();
        if (stalker != null)
        {
            stalker.AlertStalker(transform.position); 
        }

        // 2. Find all objects in range
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pingRadius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Environment"))
            {
                // FIX: Pass the 'gameObject' instead of 'GetComponent<SpriteRenderer>()'
                StartCoroutine(FlashWall(hit.gameObject)); 
            }
        }
    }

    IEnumerator FlashWall(GameObject obj)
    {
        SpriteRenderer rend = obj.GetComponent<SpriteRenderer>();
        if (rend == null) yield break;

        // Determine color: Red for Stalker, White for Walls
        if (obj.name == "Stalker") 
        {
            rend.color = Color.red; 
        }
        else
        {
            rend.color = Color.white; 
        }

        yield return new WaitForSeconds(revealDuration);
        rend.color = Color.black; 
    }
}