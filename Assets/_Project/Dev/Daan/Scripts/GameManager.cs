using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score1;
    public int Score2;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText1.text = "Score: " + Score1;
        scoreText2.text = "Score: " + Score2;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText1.text = "Score: " + Score1;
        scoreText2.text = "Score: " + Score2;
    }
}
