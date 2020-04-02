using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryMenu : MonoBehaviour
{
    public GameObject inventoryButton;
    public Button selectedButton;
    Dictionary<string, Item> items;

    public static InventoryMenu instance;

    void Awake()
    {
        if (instance != null) Debug.LogWarning("More than one instance of inventory menu found!");
        instance = this;
    }

    void OnEnable()
    {
        selectedButton.Select();
        ListAll();
    }

    public void ListAll()
    {
        items = Inventory.instance.items;

        int counter = 0;

        foreach (KeyValuePair<string, Item> kvp in items)
        {
            string item = kvp.Key;
            int qty = kvp.Value.quantity;

            GameObject child = this.transform.GetChild(counter).gameObject;
            child.name = item;
            child.SetActive(true);

            Button button = child.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(kvp.Value.Use());

            Text textObj = child.transform.GetComponentInChildren<Text>();

            textObj.text = "";
            textObj.text += $"{item}\nQuantity: {qty}";
            counter++;
        }
    }

    // If an item is dropped or used, the window should refresh to show the new quantity
    public void Refresh()
    {
        foreach (Transform child in this.transform)
        {
            child.transform.gameObject.SetActive(false);
        }
    }

    public void Drop(string name)
    {
        Item item = items[name];
        bool lastItem = item.quantity == 1;

        item.Drop();

        Refresh();
        ListAll();

        if (lastItem) EventSystem.current.SetSelectedGameObject(inventoryButton);
    }

    void Update()
    {
        GameObject inventoryItem = EventSystem.current.currentSelectedGameObject;

        if (inventoryItem.tag == "InventoryTag" && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.E)))
        {
            Drop(inventoryItem.name);
        }
    }
}
