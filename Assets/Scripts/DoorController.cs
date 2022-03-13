using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static DoorController doorController { get; private set; }

    public GameObject DoorOpen, DoorClose;
    public bool isDoorOpen = false;

    private void Awake()
    {
        doorController = this;
    }

    private void LateUpdate()
    {
        if(isDoorOpen)
        {
            transform.position = Vector3.Lerp(transform.position, DoorOpen.transform.position, Time.deltaTime * 6);
            
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, DoorClose.transform.position, Time.deltaTime * 6);
        }

    }
}
