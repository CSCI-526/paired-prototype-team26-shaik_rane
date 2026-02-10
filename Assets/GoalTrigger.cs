using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Needed for TextMeshPro

public class GoalTrigger : MonoBehaviour
{
    public GameObject winTextObject; // Slot for your UI text

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the "You Win!" message on screen
            if (winTextObject != null)
            {
                winTextObject.SetActive(true);
            }

            Debug.Log("S-Path Completed!");
            
            // Restart the level after 3 seconds so they can read the text
            Invoke("RestartGame", 3f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}