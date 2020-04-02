using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int quantity = 1;
    public Sprite icon = null;
    public bool isDefaultItem = false;

    // virtual keyword makes it so that a method can be overwritten by a class that inherits this one
    public virtual UnityAction Use()
    {
        return ItemEffects.instance.UseItem(name);
    }

    public void Drop()
    {
        if (quantity == 0) Debug.Log("Error: Item does not exist in inventory!");
        else if (quantity == 1) Inventory.instance.items.Remove(name);
        else quantity -= 1;

        InventoryMenu.instance.Refresh();
        InventoryMenu.instance.ListAll();
    }
}
