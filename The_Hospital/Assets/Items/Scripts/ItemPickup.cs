using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public void Pickup()
    {
        InventoryManager.instance.AddItem(item);
        Destroy(gameObject);
    }


}
