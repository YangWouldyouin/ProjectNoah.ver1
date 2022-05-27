using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCameraController : MonoBehaviour
{
    Transform target;
    public Vector3 offset;
    void Start()
    {
        target = BaseCanvas._baseCanvas.noahPlayer.transform;
    }

    private void FixedUpdate()
    {        
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(target.position.z, -5.47f, 4.59f));
        //transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
    }
}
