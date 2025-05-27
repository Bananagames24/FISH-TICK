using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Players player;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: "+ player.score;
    }
}
