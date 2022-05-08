using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahRot : MonoBehaviour
{
    float rotSpeed = 25f;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }
}
