using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private GameObject canvas;
    
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor)
    {
        Debug.Log("NOTES!");
        // Pause game
        Time.timeScale = 0f; // Pause the game
        cam.PauseCamera(); // Pause camera
        // Show canvas
        canvas.SetActive(true);
        return true;
    }
}
