using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private CameraFollow playerCam;
    public void OnResumeButton()
    {
        Debug.Log("Resuming Game");
        playerCam.UnpauseCamera();
        Time.timeScale = 1f; // Resume the game
    }
    
    public void OnRestartButton()
    {
        Debug.Log("Restart");
        SceneLoader.Instance.LoadScene("Hosp");
    }
    
    public void OnMainMenuButton()
    {
        Time.timeScale = 1f; // Ensure normal game speed
        SceneLoader.Instance.LoadScene("Start");
    }
    
    public void OnExitButton()
    {
        SceneLoader.Instance.ExitGame();
    }
}
