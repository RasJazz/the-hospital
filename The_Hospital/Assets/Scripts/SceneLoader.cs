using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu; // main menu UI
    [SerializeField] private GameObject controlMenu; 
    // Scene names are saved as enum values to be used for scene switching
    private enum Scenes
    {
        Start,
        Level1
    }

    /// <summary>
    /// Starts the game and loads next level
    /// </summary>
    public void OnStartButton()
    {
        Debug.Log("Start");
        // SceneManager.LoadScene((int)Scenes.Level1);
    }
    
    /// <summary>
    /// Shows Controls
    /// </summary>
    public void OnControlButton()
    {
        // Disable main menu
        mainMenu.SetActive(false);
        // Enable next canvas
        controlMenu.SetActive(true);
        // Testing
        Debug.Log("Pressed Control\nQuitting");
        // Application.Quit();
    }
    
    public void OnBackButton()
    {
        // Disable main menu
        controlMenu.SetActive(false);
        // Enable next canvas
        mainMenu.SetActive(true);
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    public static void OnExitButton()
    {
        Debug.Log("Pressed Exit\nQuitting");
        // Application.Quit();
    }
}
