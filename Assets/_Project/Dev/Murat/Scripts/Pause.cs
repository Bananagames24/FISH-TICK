using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    public void Pausing()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void UnPausing()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
