using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : Interaction
{
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Enemy: атакувати.");
    }
}
