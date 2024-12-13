using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void OnCloseNote()
    {
        playerCam.UnpauseCamera();
        Time.timeScale = 1f; // Resume the game
        //gameObject.transform.parent.gameObject.SetActive(false);
    }
}
