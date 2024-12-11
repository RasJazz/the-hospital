using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public void RemoveItem()
    {
        InventoryManager.instance.Remove(item);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
