using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Door : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    
    private bool _isOpen;

    public int doorID;

    public InventoryManager inventoryManager;
    
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor)
    {
        if (!_isOpen)
        {
            InventoryManager inventory = GetComponent<InventoryManager>();
            if(inventory == null)
            {
                Debug.Log("No inventory found");
                return false;
            }

            foreach (Item item in inventory.Items)
            {
                if(item.itemType == ItemType.Key && item.keyId == doorID)
                {
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

            

            // getComponent Inventory

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
