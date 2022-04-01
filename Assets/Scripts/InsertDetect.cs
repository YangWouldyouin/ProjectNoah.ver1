using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertDetect : MonoBehaviour
{
    public static InsertDetect insertDetect { get; private set; }

    public bool Isdetected = false;
    public string insertObject = "EnvirPipe";

    private void Awake()
    {
        insertDetect = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == insertObject)
        {
            Isdetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == insertObject)
        {
            Isdetected = false;
        }
    }
}

