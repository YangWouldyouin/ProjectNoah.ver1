using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomCameraController : MonoBehaviour
{
    Transform target;
    public Vector3 offset;
    void Start()
    {
        target = BaseCanvas._baseCanvas.noahPlayer.transform;


    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, -39f, -36f), transform.position.y, transform.position.z);
        //transform.position = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
