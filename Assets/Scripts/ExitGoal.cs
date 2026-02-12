using UnityEngine;

public class ExitGoal : MonoBehaviour
{
    public GameObject winTextObject;   

    void Start()
    {
        if (winTextObject != null)
        {
            winTextObject.SetActive(false);   
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (winTextObject != null)
            {
                winTextObject.SetActive(true);   // YOU WIN
            }

            // pause the game when you win this is not sure I will implement 
            Time.timeScale = 0f;
        }
    }
}
