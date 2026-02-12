using UnityEngine;

public class StartInstructions : MonoBehaviour
{
    public GameObject instructionsPanel;

    void Start()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);  // show at start
        }
        Time.timeScale = 0f;  // pause game while instructions aree onscreen
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (instructionsPanel != null)
            {
                instructionsPanel.SetActive(false);  
            }
            Time.timeScale = 1f;  // unpause game... and
            enabled = false;      // stop checking input
        }
    }
}
