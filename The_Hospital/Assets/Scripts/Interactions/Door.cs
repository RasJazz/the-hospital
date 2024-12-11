using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    
    private bool _isOpen;
    
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor)
    {
        if (!_isOpen)
        {
            // Play animation
            // Consume key
            // getComponent Inventory
            // if inventory == null, return false
            // if key id == door id
                Debug.Log("Opening Door");
                _isOpen = true;
                // return false;
            // else, no key found
                // Debug.Log("No key in inventory");
                // return false;
            
        } else { Debug.Log("Door is already open");}
        
        return true;
    }
}
