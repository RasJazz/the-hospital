using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu; // main menu UI
    [SerializeField] private GameObject controlMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;

    private enum Scenes
    {
        Start,
        Hosp
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene((int)Scenes.Hosp);
    }
    
    public static void OnExitButton()
    {
        Application.Quit();
    }

    // Move to separate script
    public void OnResumeButton()
    {
        Debug.Log("Resuming Game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    // Move to separate script
    public void OnRestartButton()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene((int)Scenes.Hosp);
    }

    // Move to separate script
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene((int)Scenes.Start);
    }
}