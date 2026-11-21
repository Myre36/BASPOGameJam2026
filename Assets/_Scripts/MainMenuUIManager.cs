using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel; 
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private string gameSceneName = "GameScene";
    
    private void Start()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
