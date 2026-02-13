using UnityEngine;

public class SonarRevealed2D : MonoBehaviour
{
    private SpriteRenderer sr;
    private float hideTime = 0f;
    private bool isRevealed = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.black;       // hidden by default
    }

    void Update()
    {
        if (isRevealed && Time.time >= hideTime)
        {
            sr.color = Color.black;   // back to dark
            isRevealed = false;
        }
    }

    // Called only from PlayerSonar.DoPing()
    public void Reveal(float duration)
    {
        sr.color = Color.white;       // flash visible
        isRevealed = true;
        hideTime = Time.time + duration;
    }
}
