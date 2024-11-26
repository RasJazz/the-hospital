using UnityEngine;

[System.Serializable]
public class Item
{
    // The name of the item
    public string itemName;

    // The description of the item
    public string description;

    // The icon of the item
    public Sprite itemIcon;

    // The prefab of the item
    public GameObject prefab;
    
    // The quantity of the item
    public int quantity;
}
