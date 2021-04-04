using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInteraction : Interaction
{
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Меч(item): Взять оружие.");
    }
}
