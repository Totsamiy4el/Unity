using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private bool isFocused;
    private bool hasInteracted;
    private PlayerController player;
    [SerializeField] private float interactionDistance;
    [SerializeField] private float distanceMultiplier;
    public virtual float StopingDistance
    {
        get
        { return interactionDistance * distanceMultiplier; }
    }

    public void OnFocus (PlayerController _player)
    {
        isFocused = true;
        player = _player;
    }

    public void OnUnfocus()
    {
        isFocused = false;
        hasInteracted = false;
    }

    protected virtual void Interact()
    {
        hasInteracted = true;
    }

    void Update()
    {
        if (isFocused && player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < interactionDistance && !hasInteracted)
            {
                Interact();
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
