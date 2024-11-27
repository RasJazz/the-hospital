using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
[CreateAssetMenu(fileName = "New Keys Object", menuName = "Inventory System/Item/Keys")]
public class KeysObject : ItemObject
{
    public int keyID;
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
}
