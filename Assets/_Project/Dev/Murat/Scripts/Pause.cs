using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    public void Pausing()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void UnPausing()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
