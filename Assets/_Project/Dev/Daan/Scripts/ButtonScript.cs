using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();

        // If running in the editor, stop playing the scene.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1.0f;
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene("HelpMenu");
    }
}
