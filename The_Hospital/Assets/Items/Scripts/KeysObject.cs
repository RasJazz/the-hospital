using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Keys Object", menuName = "Inventory System/Item/Keys")]
public class KeysObject : ItemObject
{
    public string keyID;
    public string keyName;
    public bool isCollected = false;

    public bool UseKey(DoorObject door)
    {
        if (door !=null && door.keyID == keyID)
        {
            door.UnlockDoor();
            Debug.Log("Door unlocked!");
            return true;
        }
        else
        {
            Debug.Log("The key does not fit this door.");
            return false;
        }
    }

    // public void Interact()
    // {
    //     if(!isCollected)
    //     {
    //         CollectedKey();
    //     }
    //     else
    //     {
    //         Debug.Log($"{keyName} has already been collected");
    //     }
    // }

    // public void CollectedKey()
    // {
    //     isCollected = true;

    //     Debug.Log($"Collected key: {keyName} (ID: {keyID})");

    //     InventoryObject.Instance.(this);

    //     gameObject.SetActive(false);
    // }
}
