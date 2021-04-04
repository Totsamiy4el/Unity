using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : Interaction
{
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Торговец оружием(NPC): Открыть чат торговли. ");
    }
}
