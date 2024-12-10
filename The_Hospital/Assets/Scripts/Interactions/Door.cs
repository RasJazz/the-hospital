using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private Animator theDoor = null;
    
    private bool _isOpen = false;
    
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor)
    {
        if (!_isOpen)
        {
            // Play animation
            // Consume key
            // getComponent Inventory
            // if inventory == null, return false
            theDoor.Play("open door", 0 , 0.0f);
            Debug.Log("Opening Door");
            _isOpen = true;
                // return false;
            // else, no key found
                // Debug.Log("No key in inventory");
                // return false;
            
        } else { 
            //Debug.Log("Door is already open");
            theDoor.Play("close door", 0, 0.0f);
            Debug.Log("Closing Door");
            _isOpen = false;
        }
        
        return true;
    }
}
