using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryPanel;
    public GameObject inventorySlotprefab;

    public void UpdateUI(List<Item> items)
    {
        // Clear the inventory panel
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        // Create a new inventory slot
        foreach(var item in items)
        {
            GameObject slot = Instantiate(inventorySlotprefab, inventoryPanel);
            slot.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().sprite = item.itemIcon;
            slot.transform.Find("Name").GetComponent<Text>().text = item.itemName;
            slot.transform.Find("Quantity").GetComponent<Text>().text = item.quantity.ToString();
        }
    }
}
