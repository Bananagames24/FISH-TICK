using UnityEngine;
using UnityEngine.UI;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private Slider ultimateBar;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Timer gameTimer;
    [SerializeField] private float screenShake = 0.1f;
    private bool isScreenShaking = false;
    private float timeShake = 5;
    private float timer = 0;
    private bool isSwitching = false;

    private void Update()
    {
        if (ultimateBar.value == ultimateBar.maxValue)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
        }
        
        if (isScreenShaking)
        {
            ScreanShake();
        }
        
        if (gameTimer.pause)
        {
            GetComponent<Button>().enabled = false;
        }
        
        else if(!gameTimer.pause)
        {
            GetComponent<Button>().enabled = true;
        }
    }

    public void UseUltimate()
    {
        if (!gameManager.isUltimateActive&& ultimateBar.value == ultimateBar.maxValue)
        {
            timeShake = 5;
            ultimateBar.value = 0;
            isScreenShaking = true;
        }
    }
    private void ScreanShake()
    {
        float rand = Random.Range(-0.1f,0.1f);
        
        if (isSwitching && timer > 0.1f)
        {
            timer = 0;
            Camera.transform.position = new Vector3(screenShake, Camera.transform.position.y, rand);
            isSwitching = false;
        }
        else if(!isSwitching && timer >0.1f)
        {
            timer = 0;
            Camera.transform.position = new Vector3(-screenShake, Camera.transform.position.y, rand);
            isSwitching = true;
        }
        
        if (timeShake <= 0)
        {
            gameManager.isUltimateActive = false;
            isScreenShaking = false;
            Camera.transform.position = new Vector3(0, Camera.transform.position.y, 0);
        }
        else
        {
            gameManager.isUltimateActive = true;
        }
        
        timer += Time.deltaTime;
        timeShake -= Time.deltaTime;
    }
}
