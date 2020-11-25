using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickerMP : MonoBehaviour
{
    [SerializeField] private int _healMpValue;
    private void OnTriggerEnter2D(Collider2D info)
    {
        info.GetComponent<Player_controller>().RestoreMP(_healMpValue);
        Destroy(gameObject);
    }
}