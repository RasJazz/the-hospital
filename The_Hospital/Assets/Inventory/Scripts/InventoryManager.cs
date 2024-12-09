using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] InventoryItems;


    private void Awake()
    {
        instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        // Clear previous items
        foreach (Transform child in ItemContent)
        {
            Destroy(child.gameObject);
        }
        
        foreach (Item item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        
        // SetInventoryItems();
    }

//     public void SetInventoryItems()
//     {
//         InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
//         for(int i = 0; i < Items.Count; i++)
//         {
//             InventoryItems[i].AddItem(Items[i]);
//         }
//     }
}
