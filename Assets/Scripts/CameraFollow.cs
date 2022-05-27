using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    public Vector3 offset;
    void Start()
    {
        target = BaseCanvas._baseCanvas.noahPlayer.transform;
    }

    private void FixedUpdate()
    {
        //transform.position = target.position+offset;
        //transform.position = new Vector3(target.position.x + offset.x, transform.position.y, target.position.z + offset.z);
        transform.position = new Vector3( Mathf.Clamp(target.position.x , -262f, -251f) , transform.position.y, Mathf.Clamp(target.position.z, 672f, 688f));
    }

}
