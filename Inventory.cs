using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // This code makes it so the inventory can always be referenced by simply typing Inventory.instance
    public static Inventory instance;

    void Awake()
    {
        if (instance != null) Debug.LogWarning("More than one instance of inventory found!");
        instance = this;
    }

    public Dictionary<string, Item> items = new Dictionary<string, Item>();

    // Methods that govern adding or removing items to the inventory
    public void Add(Item item)
    {
        if (items.ContainsKey(item.name)) items[item.name].quantity++;
        else if (!item.isDefaultItem)
        {
            item.quantity = 1;
            items.Add(item.name, item);
        }
    }
}
