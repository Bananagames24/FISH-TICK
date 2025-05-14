using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundEnd : MonoBehaviour
{
    private int round = 0;
    [SerializeField] private Timer timer;
    [SerializeField] private GameManeger gameManeger;
    [SerializeField] private TextMeshProUGUI roundsText;
    void Start()
    {
        
    }
    public void ToNextRound()
    {
        round++;
        roundsText.text = "" + round;
        StartCoroutine(NextRound());
    }
    private IEnumerator NextRound()
    {  
        gameManeger.RevealScore();
       
        yield return new WaitForSeconds(1f);
        timer.Beign(timer.Duration);
    }

    void Update()
    {
        
    }
}
