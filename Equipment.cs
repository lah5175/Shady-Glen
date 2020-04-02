using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    
    public int armorModifier;
    public int damageModifier;

    public override UnityAction Use()
    {
        return EquipmentManager.instance.Equip(this);
    }
}

public enum EquipmentSlot { Sword, Head, Chest, Legs, Feet, Bow }