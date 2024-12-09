using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor)
    {
        ItemPickup item = GetComponent<ItemPickup>();
        if (item != null)
        {
            item.Pickup();
            Debug.Log("Picking up key");
        }
        Debug.Log(item);
        Destroy(gameObject);
        return true;
    }
}
