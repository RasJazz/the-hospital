using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Keys,
    Tools,
    Notes,
    Default,
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public string itemName;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
