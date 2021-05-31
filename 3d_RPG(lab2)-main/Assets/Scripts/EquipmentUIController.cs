using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUIController : MonoBehaviour
{
    [SerializeField] public EquipmentSlot weaponSlot;
    [SerializeField] public EquipmentSlot armorSlot;

    public void AddToEquipment (Item item)
    {
        switch (item.Type)
        {
            case SlotType.Weapon:
                weaponSlot.AddItemToSlot(item);
                break;
            case SlotType.Armor:
                armorSlot.AddItemToSlot(item);
                break;
            default:
                break;
        }
    }
}
