using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public List<Players> players;
    public List<TextMeshProUGUI> scores;
    [SerializeField] private List<TextMeshProUGUI> winLose;
    [SerializeField] private GameObject endrezoltScreen;
    [SerializeField] private List<TextMeshProUGUI> countDown;
    [SerializeField] private List<string> countDownText;
    [SerializeField] private List<GameObject> uiGameObjects;
    [SerializeField] private Timer timer;
    [SerializeField] private List<GameObject> eelEffect;
    private float countDowntimer = 0.3f;
    private bool countDownBool = true;
    private bool boolCancal = true;
    private bool timerBool = true;
    private int countDownCounter = 0;
    public bool isUltimateActive = false;

    void Start()
    {
        //BeginCountdown();
    }
    void Update()
    {
        if (boolCancal)
        {
           //ExstendSize();
        }
    }
    public void BeginCountdown()
    {
        countDowntimer = 0.3f;
        countDownBool = true;
        countDownCounter = 0;
        for (int i = 0; i < countDown.Count; i++)
        {
            countDown[i].text = countDownText[countDownCounter];
            countDown[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < uiGameObjects.Count; i++)
        {
            uiGameObjects[i].SetActive(false);
        }
        boolCancal = true;
    }
    private void ExstendSize()
    {
        if (countDownBool)
        {
            if (timerBool)
            {
                if (countDownCounter > 3)
                {
                    CountingDown();
                }
                else
                {
                    for (int i = 0; i < countDown.Count; i++)
                    {
                        countDown[i].text = countDownText[countDownCounter];
                    }
                    timerBool = false;
                }
                countDownCounter++;
            }
            countDowntimer += Time.deltaTime * 1.5f;
            if (countDowntimer >= 1)
            {
                countDownBool = false;
            }
        }
        else
        {
            countDowntimer -= Time.deltaTime * 1.5f;
            if (countDowntimer <= 0.3f)
            {
                countDownBool = true;
                timerBool = true;
            }
        }
        for (int i = 0; i < countDown.Count; i++)
        {
            countDown[i].transform.localScale = Vector3.one * countDowntimer * 2;
        }
    }
    private void CountingDown()
    {
        boolCancal = false;
        for (int i = 0; i < countDown.Count; i++)
        {
            countDown[i].gameObject.SetActive(false);
        }
        for(int i = 0;i < uiGameObjects.Count; i++)
        {
            uiGameObjects[i].SetActive(true);
        }
        timer.Beign(timer.Duration);
    }
    public void RevealScore()
    {
        if (players[0].Score > players[1].Score)
        {
            winLose[0].text = "Win";
            winLose[1].text = "Lose";
        }
        else if (players[0].Score < players[1].Score)
        {
            winLose[0].text = "Lose";
            winLose[1].text = "Win";
        }
        else
        {
            winLose[0].text = "Tie";
            winLose[1].text = "Tie";
        }
        for (int i = 0; i < players.Count; i++)
        {
            scores[i].text = "Your Score:" + players[i].Score;
            endrezoltScreen.SetActive(true);
        }
    }
    public void HideScore()
    {
        for (int i = 0; i < players.Count; i++)
        {
            endrezoltScreen.SetActive(false);
            players[i].Score = 0;
        }
    }
    public IEnumerator EelAbillity(int playerTouch)
    {
        Debug.Log("happend");
        eelEffect[playerTouch].SetActive(true);
        if (playerTouch == 0)
        {
            for(int i = 0; i < 3;i++)
            {
                uiGameObjects[i].SetActive(false);
            }
        }else if (playerTouch == 1)
        {
            for(int i = 3;i < 6;i++)
            {
                uiGameObjects[i].SetActive(false);
            }
        }
        yield return new WaitForSeconds(2);
        if (playerTouch == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                uiGameObjects[i].SetActive(true);
            }
        }
        else if (playerTouch == 1)
        {
            for (int i = 3; i < 6; i++)
            {
                uiGameObjects[i].SetActive(true);
            }
        }
        eelEffect[playerTouch].SetActive(false);
        Debug.Log("happend");
    }
}
