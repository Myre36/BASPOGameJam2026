using UnityEngine;
using UnityEngine.SceneManagement;

public class DayOverUIManager : MonoBehaviour
{
    [SerializeField] private string mainMenu = "MainMenu";

    [Tooltip("The level to load when restarting the game.")]
    [SerializeField] private string levelToLoad;

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(levelToLoad);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
