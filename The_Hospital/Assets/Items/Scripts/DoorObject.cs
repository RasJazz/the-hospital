using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour
{
    public int keyID;
    private bool islocked = true;

    public void UnlockDoor()
    {
        if (islocked)
        {
            islocked = false;

            Debug.Log("The Door is now Unlocked");

            //Play sound and animation 
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         InventoryObject inventory = other.GetComponent<InventoryObject>();
    //         if(inventory != null && inventory.HasKey(keyID))
    //         {
    //             UnlockDoor();
    //         }
    //         else
    //         {
    //             Debug.Log("You don't have the correct key!");
    //         }
    //     }
    // }
}
