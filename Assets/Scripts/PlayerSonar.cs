using UnityEngine;
using TMPro;

public class PlayerSonar : MonoBehaviour
{
    public KeyCode pingKey = KeyCode.Space;

    public int maxPings = 10;          // total pings for this run
    public TextMeshProUGUI pingText;  

    int currentPings;

    void Start()
    {
        currentPings = maxPings;
        UpdatePingUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(pingKey))
            TryPing();
    }

    void TryPing()
    {
        if (currentPings <= 0)
            return;    // no pings left

        DoPing();
        currentPings--;
        UpdatePingUI();
    }

    void DoPing()
    {
        Vector2 pingPos = transform.position;

        Stalker2D[] stalkers = FindObjectsOfType<Stalker2D>();
        foreach (var s in stalkers)
            s.OnSonarPing(pingPos);
    }

    void UpdatePingUI()
    {
        if (pingText != null)
            pingText.text = "Pings: " + currentPings;
    }
}
