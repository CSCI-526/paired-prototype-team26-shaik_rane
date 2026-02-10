using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MemoryPhase());
    }

    IEnumerator MemoryPhase()
    {
        // 1. Show all walls (White)
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Environment");
        foreach (GameObject wall in walls) {
            wall.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("Showing wall: " + wall.name);
        }

        // 2. Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // 3. Hide all walls (Black)
        foreach (GameObject wall in walls) {
            wall.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}