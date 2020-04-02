using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentManager : MonoBehaviour
{
    public Equipment startingSword;
    public Equipment startingBow;

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    public Equipment[] currentEquipment;

    void Start()
    {
        // This counts how many equipment slots are in the enum and makes an array of dynamic length

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

        Equip(startingSword)();
        Equip(startingBow)();
    }

    public UnityAction Equip (Equipment newItem)
    {
        // Returning a function here to prevent items from being automatically equipped
        return () =>
        {
            int slotIdx = (int)newItem.equipmentSlot;

            if (currentEquipment[slotIdx] != null)
            {
                Inventory.instance.Add(currentEquipment[slotIdx]);
            }

            currentEquipment[slotIdx] = newItem;
        };
    }
}
