using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected Image slotImage;
    public bool IsEquiped { get; private set; } = false;
    public Item CurrentItem { get; private set; }
    public Sprite slotIcon => slotImage.sprite;

    public Action<SlotManager> LeftPointerClicked = delegate { };
    public Action<SlotManager> RightPointerClicked = delegate { };

    public virtual void AddItemToSlot (Item item)
    {
        slotImage.sprite = item.itemIcon;
        slotImage.color = Color.white;
        CurrentItem = item;
        IsEquiped = true;
    }

    public virtual void RemoveItemFromInventory ()
    {
        slotImage.sprite = null;
        slotImage.color = Color.clear;
        CurrentItem = null;
        IsEquiped = false;
    }

    private void OnLeftClick()
    {
        LeftPointerClicked(this);
    }

    public void OnRightClick()
    { 
        if (!IsEquiped)
            return;
        RightPointerClicked(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnLeftClick();
        else if (eventData.button == PointerEventData.InputButton.Right)
            OnRightClick();
    }
}
