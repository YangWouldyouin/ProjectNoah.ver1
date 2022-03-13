using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool iscollision = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Console_Left")
            iscollision = true;
    }
}
