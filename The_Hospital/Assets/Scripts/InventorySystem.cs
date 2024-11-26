using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    private List<Item> items = new List<Item>();
    public InventoryUI inventoryUI;

    void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        inventoryUI.UpdateUI(items);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        inventoryUI.UpdateUI(items);
    }

    public List<Item> GetItems()
    {
        return items;
    }
    
}
