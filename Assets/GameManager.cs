using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(InitialReveal());
    }

    IEnumerator InitialReveal()
    {
        // Find all objects tagged Environment
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Environment");
        
        // Step 1: Show everything that has a SpriteRenderer
        foreach (GameObject wall in walls) {
            SpriteRenderer rend = wall.GetComponent<SpriteRenderer>();
            if (rend != null) {
                rend.color = Color.white;
            }
        }

        // 3-second memory phase
        yield return new WaitForSeconds(1f); 

        // Step 2: Hide everything that has a SpriteRenderer
        foreach (GameObject wall in walls) {
            SpriteRenderer rend = wall.GetComponent<SpriteRenderer>();
            if (rend != null) {
                rend.color = Color.black;
            }
        }
    }
}