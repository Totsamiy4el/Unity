using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryMenuController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool PointerOverWindow { get; private set; }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ChangeWindowState()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerOverWindow = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerOverWindow = false;
    }
}
