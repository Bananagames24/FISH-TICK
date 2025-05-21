using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider UltimateBar;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameManeger gameManager;
    [SerializeField] private Timer time;
    [SerializeField] private float screanShake = 0.1f;
    private bool isScreanshake = false;
    private float timeShake = 5;
    private float timer = 0;
    private bool Switch = false;
    private void Update()
    {
        if (UltimateBar.value == UltimateBar.maxValue)
        {
            GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 0.5f);
        }
        if (isScreanshake)
        {
            ScreanShake();
        }
        if (time.pause)
        {
            GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
        else if(!time.pause)
        {
            GetComponent<UnityEngine.UI.Button>().enabled = true;
        }
    }
    public void UseUltimate()
    {
        if (!gameManager.isUltimateActive&& UltimateBar.value == UltimateBar.maxValue)
        {
            timeShake = 5;
            UltimateBar.value = 0;
            isScreanshake = true;
        }
    }
    private void ScreanShake()
    {
        float rand = Random.Range(-0.1f,0.1f);
        if (Switch && timer > 0.1f)
        {
            timer = 0;
            Camera.transform.position = new Vector3(screanShake, Camera.transform.position.y, rand);
            Switch = false;
        }
        else if(!Switch && timer >0.1f)
        {
            timer = 0;
            Camera.transform.position = new Vector3(-screanShake, Camera.transform.position.y, rand);
            Switch = true;
        }
        if (timeShake <= 0)
        {
            gameManager.isUltimateActive = false;
            isScreanshake = false;
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
