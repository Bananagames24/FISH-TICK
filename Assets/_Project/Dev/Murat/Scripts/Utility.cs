using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("AlphaScene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("CreditsMurat");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Help()
    {
        SceneManager.LoadScene("HelpMurat");
    }
    public void ReturnToStart()
    {
        SceneManager.LoadScene("StartMurat");
    }
}
