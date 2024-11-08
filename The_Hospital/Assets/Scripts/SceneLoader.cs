using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Scene names are saved as enum values to be used for scene switching
    private enum Scenes
    {
        Start,
        Level1
    }

    /// <summary>
    /// Starts the game and loads next level
    /// </summary>
    public static void OnPlayButton()
    {
        SceneManager.LoadScene((int)Scenes.Level1);
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    public static void OnExitButton()
    {
        Application.Quit();
    }
}
