using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private int height;
    private float curentHeight;

    private void Start()
    {
        curentHeight = target.transform.position.y + height;
    }
    private void Update()
    {
        gameObject.transform.position = new Vector3(target.transform.position.x, curentHeight, target.transform.position.z - 12);
    }
}
