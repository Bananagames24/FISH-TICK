using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Players Player;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = "Score: "+Player.Score;
    }
}
