using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    public int Duration;
    [SerializeField] private int remaningDuration;

    void Start()
    {
        Beign(Duration);
    }
    private void Beign(int second)
    {
        remaningDuration = second;
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while (remaningDuration>=0)
        {
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remaningDuration);
            remaningDuration--;
            yield return new WaitForSeconds(1f);
        }
        {
            OnEnd();
        }

    }
    private void OnEnd()
    {
        Debug.Log("end");
    }

    void Update()
    {
        
    }
}
