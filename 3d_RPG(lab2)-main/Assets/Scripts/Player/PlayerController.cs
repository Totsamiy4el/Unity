using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Camera cam;
    private bool leftPointerClicked;
    private MeshRenderer meshRenderer;
    private bool isMove;
    private Interaction lastTarget;
    public PlayerInventoryController PlayerInventory { get; private set; }
    [SerializeField] public InventoryMenuController inventoryMenu;

    void Start()
    {
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
        meshRenderer = GetComponent<MeshRenderer>();
        PlayerInventory = GetComponent<PlayerInventoryController>();
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            leftPointerClicked = Input.GetButton("Fire1");

        if (Input.GetKeyUp(KeyCode.I))
            inventoryMenu.ChangeWindowState();

    }

    private void FixedUpdate()
    {
        if(leftPointerClicked)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo, 100))
            {
                if (lastTarget != null)
                    lastTarget.OnUnfocus();  

                lastTarget = hitInfo.collider.GetComponent<Interaction>();
                
                if (lastTarget != null)
                {
                    lastTarget.OnFocus(this);
                    Move(hitInfo.point, lastTarget.StopingDistance);
                    return;
                }
 
            }
            Move(hitInfo.point);
        }

        if (Vector3.Distance(transform.position, navMeshAgent.destination) <= navMeshAgent.stoppingDistance + 1 && isMove)
        {
            meshRenderer.material.color = new Color(0, 0, 1);
            navMeshAgent.destination = transform.position;
            isMove = false;
        }
    }

    private void Move (Vector3 destination, float stopingDistance = 0.5f)
    {
        navMeshAgent.destination = destination;
        navMeshAgent.stoppingDistance = stopingDistance;
        meshRenderer.material.color = new Color(1, 1, 0);
        isMove = true;
    }
}
