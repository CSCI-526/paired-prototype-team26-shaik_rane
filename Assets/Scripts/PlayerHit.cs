using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject loseTextObject;
    public CameraShake2D cameraShake;   

    void Start()
    {
        if (loseTextObject != null)
            loseTextObject.SetActive(false);
    }

    void Lose()
    {
        if (loseTextObject != null)
            loseTextObject.SetActive(true);

        if (cameraShake != null)
            cameraShake.Shake(0.3f, 0.15f);   

        Time.timeScale = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
            Lose();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            Lose();
    }
}
