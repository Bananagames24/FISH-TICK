using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public List<Players> players;
    public List<TextMeshProUGUI> Scores;
    public List<TextMeshProUGUI> WinLose;
    public GameObject EndrezoltScreen;

    public void RevealScore()
    {
        if (players[0].Score > players[1].Score)
        {
            WinLose[0].text = "Win";
            WinLose[1].text = "Lose";
        }
        else if (players[0].Score < players[1].Score)
        {
            WinLose[0].text = "Lose";
            WinLose[1].text = "Win";
        }
        else
        {
            WinLose[0].text = "Tie";
            WinLose[1].text = "Tie";
        }
        for (int i = 0; i < players.Count; i++)
        {

            Scores[i].text = "Your Score:" + players[i].Score;
            EndrezoltScreen.SetActive(true);
        }
    }
    public void HideScore()
    {
        for (int i = 0; i < players.Count; i++)
        {
            EndrezoltScreen.SetActive(false);
            players[i].Score = 0;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
