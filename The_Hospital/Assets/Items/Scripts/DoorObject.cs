using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour
{
    public string keyID;
    private bool islocked = true;

    public void UnlockDoor()
    {
        if (islocked)
        {
            islocked = false;

            Debug.Log("The Door is now Unlocked");

            //Play sound and animation 
        }
        else
        {
            Debug.Log("The Door is Already Unlocked");
        }
    }
}
