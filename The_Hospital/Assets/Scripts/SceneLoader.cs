using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Singleton instance
    public static SceneLoader Instance { get; private set; }

    [Header("UI Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject controlMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;

    private enum Scenes
    {
        Start,
        Hosp
    }

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnStartButton()
    {
        LoadScene(Scenes.Hosp);
    }

    public void OnControlButton()
    {
        ToggleMenu(mainMenu, false);
        ToggleMenu(pauseMenu, false);
        ToggleMenu(controlMenu, true);
    }

    public void OnBackButton()
    {
        ToggleMenu(controlMenu, false);

        ToggleMenu(SceneManager.GetActiveScene().name == Scenes.Start.ToString() ? 
            mainMenu : pauseMenu, true);
    }

    public void OnResumeButton()
    {
        Debug.Log("Resuming Game");
        ToggleMenu(pauseMenu, false);
        Time.timeScale = 1f; // Resume game time
    }

    public void OnRestartButton()
    {
        LoadScene(Scenes.Hosp);
    }

    public void OnMainMenuButton()
    {
        ToggleMenu(gameOverMenu, false);
        LoadScene(Scenes.Start);
        ToggleMenu(mainMenu, true);
    }

    public void OnExitButton()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    private void LoadScene(Scenes scene)
    {
        Debug.Log($"Loading Scene: {scene}");
        SceneManager.LoadScene((int)scene);
        Time.timeScale = 1f; // Ensure game time is normal
    }

    private void ToggleMenu(GameObject menu, bool isActive)
    {
        if (menu != null)
        {
            menu.SetActive(isActive);
        }
    }
}
