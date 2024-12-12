using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Item;

public class Door : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    [SerializeField] private InventoryManager inventory;
    public string InteractionPrompt => prompt;

    private Animation doorAnim;
    private bool _isOpen;
    public int doorId;

    private void Start(){
        doorAnim = GetComponent<Animation>();
    }

    public bool Interact(Interactor interactor)
    {
        if (_isOpen) return true;

        // Play animation
        // Consume key
        // getComponent Inventory
        // if inventory == null, return false
        // if key id == door id
        // return false;
        // else, no key found
        // Debug.Log("No key in inventory");
        // return false;
        if(inventory == null)
        {
            Debug.Log("No inventory found");
            return _isOpen;
        }

        foreach (var item in inventory.Items.Where(item => item.itemType == ItemType.Key && item.id == doorId))
        {
            //doorAnim.Play("open door");
            Debug.Log("Opening Door");
               
            //Consume Key
            //inventory.Items.Remove(item);

            Destroy(gameObject);
            Debug.Log("Key removed from inventory");
            // Play animation
            _isOpen = true;
            return _isOpen;
        } 
        Debug.Log("No key in inventory");
        
        return _isOpen;
    }
}