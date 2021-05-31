using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public Sprite itemIcon;
    [SerializeField] private EquipmentUIController equipmentUI;
    [SerializeField] public SlotType Type;

    public bool Use()
    {
        equipmentUI.AddToEquipment(this);
        //Debug.Log(Type);
        return true;
    }

}
