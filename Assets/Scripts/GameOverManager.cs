using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "MainMenu";
    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
