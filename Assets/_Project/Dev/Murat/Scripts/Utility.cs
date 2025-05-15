using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("TestSceneMurat");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Help()
    {
       
    }
}
