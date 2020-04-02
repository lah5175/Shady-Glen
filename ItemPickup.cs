using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public void PickUp()
    {
        Debug.Log("Picking up item " + item);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}

// Destroy(gameObject) - destroy the game object this component is attached to