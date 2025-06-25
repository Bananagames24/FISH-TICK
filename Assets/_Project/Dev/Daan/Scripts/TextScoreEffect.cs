using UnityEngine;

public class TextScoreEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(transform.position.x > 0)
        {
            transform.rotation = Quaternion.Euler(90, 0, 90);
        }
        else
        {
            transform.rotation = Quaternion.Euler(90, 0, -90);
        }
        Destroy(gameObject, 0.3f); // Destroy the game object after 3 seconds
    }
}
