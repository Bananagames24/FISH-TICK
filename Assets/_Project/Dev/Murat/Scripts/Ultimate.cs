using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider UltimateBar;
    [SerializeField] private GameObject Camera;
    private bool isScreanshake = false;
    [SerializeField] private GameManeger gameManager;
    private float timeShake = 5;
    private float timer = 0;
    private bool Switch = false;
    [SerializeField] private float screanShake = 0.1f;

    private void Update()
    {
        if (UltimateBar.value == UltimateBar.maxValue)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 0.5f);
        }
        if (isScreanshake)
        {
            ScreanShake();
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
        if (Switch && timer > 0.1f)
        {
            timer = 0;
            Camera.transform.position = new Vector3(screanShake, Camera.transform.position.y, Camera.transform.position.z);
            Switch = false;
        }
        else if(!Switch && timer >0.1f)
        {
            timer = 0;
            Camera.transform.position = new Vector3(-screanShake, Camera.transform.position.y, Camera.transform.position.z);
            Switch = true;
        }
        if (timeShake <= 0)
        {
            gameManager.isUltimateActive = false;
            isScreanshake = false;
            Camera.transform.position = new Vector3(0, Camera.transform.position.y, Camera.transform.position.z);
        }
        else
        {
            gameManager.isUltimateActive = true;
        }
        timer += Time.deltaTime;
        timeShake -= Time.deltaTime;
    }
}
