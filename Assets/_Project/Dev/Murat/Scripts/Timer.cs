using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    public int duration;
    private int remaningDuration;
    public bool pause;
    [SerializeField] private GameManager gameManager;

    public void Beign(int second)
    {
        remaningDuration = second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remaningDuration>=0)
        {
            if (!pause)
            {
                uiFill.fillAmount = Mathf.InverseLerp(0, duration, remaningDuration);
                remaningDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        
        OnEnd();
    }

    public void Pause()
    {
        pause = !pause;
    }

    private void OnEnd()
    {
        // If the score of player 1 is higher or equal to player 2, player 1 wins the round (or its a draw).
        if (gameManager.score1 >= gameManager.score2)
        {
            gameManager.players[0].roundsWon++;
        }
        // If the score of player 2 is higher or equal to player 1, player 2 wins the round (or its a draw).
        else if (gameManager.score1 <= gameManager.score2)
        {
            gameManager.players[1].roundsWon++;
        }

        gameManager.RevealScore();
    }
}
