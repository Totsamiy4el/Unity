using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInteraction : Interaction
{
    private Item item;

    protected override void Start()
    {
        base.Start();
        item = GetComponent<Item>();
    }
    protected override void Interact()
    {
        base.Interact();
        if (playerInventory.AddToInventory(item))
            Destroy(gameObject);
    }
}
