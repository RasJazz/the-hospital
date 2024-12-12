using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private readonly Vector3[] _directions = { Vector3.left, Vector3.forward, Vector3.right, Vector3.back };
    private readonly KeyCode[] _keys = { KeyCode.A, KeyCode.W, KeyCode.D, KeyCode.S };
    
    public GameObject HUD;
    public InventoryManager inventoryManager;

    public Vector3 UpdateInput()
    {
        Vector3 movementDirection = Vector3.zero;
        // Detect input and set movement direction of player
        for (int i = 0; i < _keys.Length; i++)
        {
            if (Input.GetKey(_keys[i])) movementDirection += _directions[i];
        }

         //Check if the "H" key is pressed
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            HUD.SetActive(!HUD.activeSelf);

            if (HUD.activeSelf)
            {
                inventoryManager.ListItems();
            }
        }

        return movementDirection.normalized;
    }

    public void PauseGame(GameObject pauseScreen, CameraFollow cam)
    {
        if (!Input.GetKey(KeyCode.Escape)) return;
        
        if (!pauseScreen.activeSelf) pauseScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        cam.PauseCamera(); // Pause camera
    }
}