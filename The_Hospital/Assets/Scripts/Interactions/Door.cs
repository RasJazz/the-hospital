using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private Animator theDoor = null;
    
    private bool _isOpen = false;
    public int doorID;

    public InventoryManager inventoryManager;
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor)
    {
        if (!_isOpen)
        {
             InventoryManager inventory = interactor.GetComponent<InventoryManager>();
            if(inventory == null)
            {
                Debug.Log("No inventory found");
                return false;
            }

            foreach (Item item in inventory.Items)
            {
                if(item.itemType == ItemType.Key && item.keyId == doorID)
                {
                    theDoor.Play("open door", 0 , 0.0f);
                    Debug.Log("Opening Door");
                    _isOpen = true;
                    //Consume Key
                    inventory.Items.Remove(item);
                    Debug.Log("Key removed from inventory");
                    // Play animation
                    return true;

                }
                else
                {
                    Debug.Log("No key in inventory");
                    return false;
                }
                
            }
            Debug.Log("Opening Door");
            _isOpen = true;
            } else { 
            
            Debug.Log("Door is already open");
        }
        
        return true;
    }
}
