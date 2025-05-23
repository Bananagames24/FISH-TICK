using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public List<Players> players;
    public List<TextMeshProUGUI> Scores;
    [SerializeField] private List<TextMeshProUGUI> WinLose;
    [SerializeField] private GameObject EndrezoltScreen;
    [SerializeField] private List<TextMeshProUGUI> CountDown;
    [SerializeField] private List<string> CountDownText;
    [SerializeField] private List<GameObject> uiGameObjects;
    [SerializeField] private Timer Timer;
    private float CountDowntimer = 0.3f;
    private bool CountDownBool = true;
    private bool boolCancal = true;
    private bool timerBool = true;
    private int CountDownCounter = 0;
    public bool isUltimateActive = false;

    void Start()
    {
        BeginCountdown();
    }
    void Update()
    {
        if (boolCancal)
        {
            ExstendSize();
        }
    }
    public void BeginCountdown()
    {
        CountDowntimer = 0.3f;
        CountDownBool = true;
        CountDownCounter = 0;
        for (int i = 0; i < CountDown.Count; i++)
        {
            CountDown[i].text = CountDownText[CountDownCounter];
            CountDown[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < uiGameObjects.Count; i++)
        {
            uiGameObjects[i].SetActive(false);
        }
        boolCancal = true;
    }
    private void ExstendSize()
    {
        if (CountDownBool)
        {
            if (timerBool)
            {
                if (CountDownCounter > 3)
                {
                    CountingDown();
                }
                else
                {
                    for (int i = 0; i < CountDown.Count; i++)
                    {
                        CountDown[i].text = CountDownText[CountDownCounter];
                    }
                    timerBool = false;
                }
                CountDownCounter++;
            }
            CountDowntimer += Time.deltaTime * 1.5f;
            if (CountDowntimer >= 1)
            {
                CountDownBool = false;
            }
        }
        else
        {
            CountDowntimer -= Time.deltaTime * 1.5f;
            if (CountDowntimer <= 0.3f)
            {
                CountDownBool = true;
                timerBool = true;
            }
        }
        for (int i = 0; i < CountDown.Count; i++)
        {
            CountDown[i].transform.localScale = Vector3.one * CountDowntimer * 2;
        }
    }
    private void CountingDown()
    {
        boolCancal = false;
        for (int i = 0; i < CountDown.Count; i++)
        {
            CountDown[i].gameObject.SetActive(false);
        }
        for(int i = 0;i < uiGameObjects.Count; i++)
        {
            uiGameObjects[i].SetActive(true);
        }
        Timer.Beign(Timer.Duration);
    }
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
}
