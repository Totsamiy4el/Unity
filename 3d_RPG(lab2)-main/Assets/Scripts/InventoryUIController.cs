using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private Image movingImage;
    public SlotManager[] InventorySlot { get; private set; }
    public Image MovingImage => movingImage;

    public void Init()
    {
        InventorySlot = grid.GetComponentsInChildren<SlotManager>();
    }

    public SlotManager GetFreeSlot()
    {
        for (int i = 0; i < InventorySlot.Length; i++)
        {
            if (!InventorySlot[i].IsEquiped)
                return InventorySlot[i];
        }
        return null;
    }
}
