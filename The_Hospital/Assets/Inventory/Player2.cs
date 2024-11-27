using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public InventoryObject inventory;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Player collided with: {other.name}"); // Log to check if this is called

        var item = other.GetComponent<Item>();
        if (item != null)
        {
            Debug.Log($"Picked up item: {item.item.name}");
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("No Item component found on the collided object.");
        }        
    }   
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

}
