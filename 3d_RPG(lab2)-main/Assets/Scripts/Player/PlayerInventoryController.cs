using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInventoryController : MonoBehaviour
{
    //private List<Item> inventory = new List<Item>();
    [SerializeField] private InventoryUIController inventoryUI;
    [SerializeField] private EquipmentUIController equipmentUI;
    //[SerializeField] private EquipmentUIController equipmentUI;
    private InventoryMenuController inventoryMenu;

    private SlotManager lastClickedSlot;
    private SlotManager newClickedSlot;
    private Item movingItem;
    private bool isMovingItem;

    private void Start()
    {
        inventoryMenu = GetComponent<PlayerController>().inventoryMenu;
        inventoryUI.Init();

        for (int i = 0; i < inventoryUI.InventorySlot.Length; i++)
        {
            inventoryUI.InventorySlot[i].LeftPointerClicked += OnMoveStarted;
        }

        equipmentUI.weaponSlot.LeftPointerClicked += OnMoveStarted;
        equipmentUI.armorSlot.LeftPointerClicked += OnMoveStarted;
    }

    private void Update()
    {
        if (isMovingItem)
        {
            inventoryUI.MovingImage.transform.position = Input.mousePosition;

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                EndMove(true);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                EndMove(false);
            }
        }
    }

    public bool AddToInventory (Item item)
    {
        SlotManager slot = inventoryUI.GetFreeSlot();
        if (slot == null)
            return false;

        slot.AddItemToSlot(item);
        slot.RightPointerClicked += OnItemUsed;
        return true;
    }

    public void OnItemUsed(SlotManager slot)
    {
        if (slot.CurrentItem.Use())
        {
            slot.RightPointerClicked -= OnItemUsed;
            slot.RemoveItemFromInventory();
        }
    }

    private void OnMoveStarted (SlotManager slot)
    {
        
        EquipmentSlot equipmentSlot = slot as EquipmentSlot;
        if(equipmentSlot == null)
            slot.RightPointerClicked -= OnItemUsed;

        if(lastClickedSlot != null)
        {
            newClickedSlot = slot;
            return;
        }
        if (slot.IsEquiped)
        {
            lastClickedSlot = slot;
            SetNewMovingItem(slot.CurrentItem);

            if (equipmentSlot != null)
                equipmentSlot.RemoveItemFromInventory();
            else
                slot.RemoveItemFromInventory();

        }
    }

    private void EndMove (bool needToMove)
    {
        Item newItem = null;
        bool isEquipedNewSlot = false;
        if(needToMove)
        {
            if(inventoryMenu.PointerOverWindow)
            {
                if (newClickedSlot != null)
                {
                    EquipmentSlot equipmentSlot = newClickedSlot as EquipmentSlot;
                    if (equipmentSlot != null)
                    {
                        if (equipmentSlot.SlotType == movingItem.Type)
                        {
                            equipmentUI.AddToEquipment(movingItem);
                        }
                    }
                    else
                    {
                        newItem = newClickedSlot.CurrentItem;
                        isEquipedNewSlot = newClickedSlot.IsEquiped;
                        newClickedSlot.RightPointerClicked += OnItemUsed;
                        newClickedSlot.AddItemToSlot(movingItem);
                    }

                }
                else
                    return;

                if (isEquipedNewSlot)
                {
                    SetNewMovingItem(newItem);
                    return;
                }
            }
            else
            {
                Debug.Log("Drop");
            }
        }
        else
        {
            if(lastClickedSlot is EquipmentSlot)
            {
                equipmentUI.AddToEquipment(movingItem as Item);
            }
            else
            {
                lastClickedSlot.AddItemToSlot(movingItem);
                lastClickedSlot.RightPointerClicked += OnItemUsed; 
            }
        }

        lastClickedSlot = null;
        newClickedSlot = null;
        movingItem = null;
        inventoryUI.MovingImage.color = Color.clear;
        inventoryUI.MovingImage.sprite = null;
        isMovingItem = false; 
    }

    private void SetNewMovingItem(Item item)
    {
        movingItem = item;
        isMovingItem = true;
        inventoryUI.MovingImage.color = Color.white;
        inventoryUI.MovingImage.sprite = movingItem.itemIcon;
    }
}
