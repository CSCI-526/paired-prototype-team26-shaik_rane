using UnityEngine;
using TMPro;

public class PlayerSonar : MonoBehaviour
{
    public KeyCode pingKey = KeyCode.Space;

    public int maxPings = 10;
    public TextMeshProUGUI pingText;

    private int currentPings;

    void Start()
    {
        currentPings = maxPings;
        UpdatePingUI();
    }

    void Update()
    {
        // Only allow pinging if we still have pings left
        if (currentPings > 0 && Input.GetKeyDown(pingKey))
        {
            TryPing();
        }
    }

    void TryPing()
    {
        currentPings--;
        UpdatePingUI();

        DoPing();

        // Optional: disable this script completely when empty
        if (currentPings <= 0)
        {
            Debug.Log("No more sonar pings remaining.");
        }
    }

    void DoPing()
    {
        Vector2 pingPos = transform.position;

        // Notify stalkers
        Stalker2D[] stalkers = FindObjectsOfType<Stalker2D>();
        foreach (var s in stalkers)
        {
            s.OnSonarPing(pingPos);
        }

        // Reveal nearby tiles
        SonarRevealed2D[] tiles = FindObjectsOfType<SonarRevealed2D>();
        foreach (var t in tiles)
        {
            float dist = Vector2.Distance(pingPos, t.transform.position);
            if (dist < 5f)
            {
                t.Reveal(0.3f);
            }
        }
    }

    void UpdatePingUI()
    {
        if (pingText != null)
        {
            pingText.text = "Pings: " + currentPings;
        }
    }
}
