using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score1;
    public float score2;
    public float score1Multiplier = 1f;
    public float score2Multiplier = 1f;

    public bool gameStarted = false;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;

    void Start()
    {
        scoreText1.text = "Score: " + score1;
        scoreText2.text = "Score: " + score2;
    }

    void Update()
    {
        scoreText1.text = "Score: " + score1;
        scoreText2.text = "Score: " + score2;
    }
}
