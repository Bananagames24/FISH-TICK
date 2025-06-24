using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private Image ultimateBar;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private FishSpawner fishSpawner;
    [SerializeField] private Timer gameTimer;
    [SerializeField] private float screenShake = 0.1f;
    private bool isScreenShaking = false;
    private float timeShake = 5;
    private float timer = 0;
    private bool isSwitching = false;
    public float ultimateFillAmount;
    [Header("Switch Between Player 1 / 2, off = P1, on = P2")]
    public bool player;

    private void Update()
    {
        ultimateBar.fillAmount = ultimateFillAmount;

        if (ultimateBar.fillAmount == 1)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 0.8f);
        }

        if (isScreenShaking)
        {
            ScreenShake();
        }

        if (gameTimer.pause)
        {
            GetComponent<Button>().enabled = false;
        }

        else if (!gameTimer.pause)
        {
            GetComponent<Button>().enabled = true;
        }
    }

    public void UseUltimate()
    {
        if (!gameManager.isUltimateActive && ultimateBar.fillAmount >= 1)
        {
            timeShake = 5;
            ultimateFillAmount = 0;
            isScreenShaking = true;
            StartCoroutine(UltimateBuff());
        }
        else return;
    }

    private void ScreenShake()
    {
        float rand = Random.Range(-0.1f, 0.1f);

        if (isSwitching && timer > 0.1f)
        {
            timer = 0;
            Camera.transform.position = new Vector3(screenShake, Camera.transform.position.y, rand);
            isSwitching = false;
        }
        else if (!isSwitching && timer > 0.1f)
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

    IEnumerator UltimateBuff()
    {
        if (!player)
        {
            for (int i = 0; i < 100;)
            {
                fishSpawner.SpawnFishOnRandomPosition(fishSpawner.fishPuddlePrefab1, fishSpawner.spawnPoint1, -9.5f, -1f, fishSpawner.fishPuddles1, true);
                yield return new WaitForSeconds(0.07f);
                i++;
            }
        }
        else
        {
            for (int i = 0; i < 100;)
            {
                fishSpawner.SpawnFishOnRandomPosition(fishSpawner.fishPuddlePrefab2, fishSpawner.spawnPoint2, -9.5f, -1f, fishSpawner.fishPuddles2, true);
                yield return new WaitForSeconds(0.07f);
                i++;
            }
        }
    }
}
