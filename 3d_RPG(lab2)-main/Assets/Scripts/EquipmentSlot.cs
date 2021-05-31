using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : SlotManager
{
    [SerializeField] private SlotType slotType;
    [SerializeField] private GameObject player;
    private PlayerInventoryController playerInventory;
    private Sprite defaultSprite;
    private Color defaultCollor;
    public SlotType SlotType => slotType;

    void Start()
    {
        defaultSprite = slotImage.sprite;
        defaultCollor = slotImage.color;
        playerInventory = player.GetComponent<PlayerInventoryController>();

    }

    public override void AddItemToSlot(Item item)
    {
        
        if (!IsEquiped)
        {
            base.AddItemToSlot(item);
            RightPointerClicked += RemoveEquipment;
        }        
        else
        {
            RightPointerClicked -= RemoveEquipment;
            RightPointerClicked += RemoveEquipment;
            if (playerInventory.AddToInventory(CurrentItem))
                base.AddItemToSlot(item);
        }
    }

    public override void RemoveItemFromInventory()
    {
        base.RemoveItemFromInventory();
        slotImage.sprite = defaultSprite;
        slotImage.color = defaultCollor;
        RightPointerClicked -= RemoveEquipment;
    }

    private void RemoveEquipment (SlotManager slot)
    {
        if (playerInventory.AddToInventory(this.CurrentItem))
            RemoveItemFromInventory();
    }
}
