using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Players> players;
    public List<TextMeshProUGUI> scores;
    public int score1;
    public int score2;
    [SerializeField] private List<TextMeshProUGUI> winLose;
    [SerializeField] private GameObject endResultScreen;
    [SerializeField] private List<TextMeshProUGUI> countDown;
    [SerializeField] private List<string> countDownText;
    [SerializeField] private List<GameObject> uiGameObjects;
    [SerializeField] private Timer timer;
    [SerializeField] private List<GameObject> eelEffect;
    private float countDownTimer = 0.3f;
    private bool countDownBool = true;
    private bool boolCancel = true;
    private bool timerBool = true;
    private int countDownCounter = 0;
    public bool isUltimateActive = false;

    void Start()
    {
        BeginCountdown();
    }

    void Update()
    {
        if (boolCancel)
        {
           ExstendSize();
        }

        players[0].score = score1;
        players[1].score = score2;
        scores[0].text = score1.ToString();
        scores[1].text = score2.ToString();
    }

    public void BeginCountdown()
    {
        countDownTimer = 0.3f;
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
        
        boolCancel = true;
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
            
            countDownTimer += Time.deltaTime * 1.5f;
            
            if (countDownTimer >= 1)
            {
                countDownBool = false;
            }
        }
        else
        {
            countDownTimer -= Time.deltaTime * 1.5f;
            if (countDownTimer <= 0.3f)
            {
                countDownBool = true;
                timerBool = true;
            }
        }
        
        for (int i = 0; i < countDown.Count; i++)
        {
            countDown[i].transform.localScale = Vector3.one * countDownTimer * 2;
        }
    }

    private void CountingDown()
    {
        boolCancel = false;
        
        for (int i = 0; i < countDown.Count; i++)
        {
            countDown[i].gameObject.SetActive(false);
        }
        
        for(int i = 0;i < uiGameObjects.Count; i++)
        {
            uiGameObjects[i].SetActive(true);
        }
        
        timer.Beign(timer.duration);
    }

    public void RevealScore()
    {
        if (score1 > score2)
        {
            winLose[0].text = "Win";
            winLose[1].text = "Lose";
        }
        else if (score1 < score2)
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
            endResultScreen.SetActive(false);
            players[i].score = 0;
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
        }
        else if (playerTouch == 1)
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
