using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    public int Duration;
    private int remaningDuration;
    public bool pause;
    [SerializeField] private GameManeger gameManeger;
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
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remaningDuration);
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
        if (gameManeger.players[0].Score > gameManeger.players[1].Score)
        {
            gameManeger.players[0].RoundsWon++;
            gameManeger.RevealScore();
        }
        else if(gameManeger.players[0].Score < gameManeger.players[1].Score)
        {
            gameManeger.players[1].RoundsWon++;
            gameManeger.RevealScore();
        }
        else
        {
            gameManeger.players[0].RoundsWon++;
            gameManeger.players[1].RoundsWon++;
            gameManeger.RevealScore();
        }
    }
}
