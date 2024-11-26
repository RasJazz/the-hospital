using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PickupItem : Interactable
{
    public  Item item;
    
    public override void Interact()
    {
        InventorySystem.Instance.AddItem(item);

        // Destroy the item from the scene
        Destroy(gameObject);

        // Display a feedback message
        Debug.Log("Picked up " + item.itemName);
    }
}
