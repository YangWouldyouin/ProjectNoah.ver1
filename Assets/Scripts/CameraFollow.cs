using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    public Vector3 offset;
    float elapsedTime = 0;
    float waitTime = 1f;
    public float smoothSpeed = 3f;
    void Start()
    {
        target = BaseCanvas._baseCanvas.noahPlayer.transform;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(Mathf.Clamp(target.position.x, -262f, -251f), transform.position.y, Mathf.Clamp(target.position.z, 672f, 688f));
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        //transform.position = target.position+offset;
        //transform.position = new Vector3(target.position.x + offset.x, transform.position.y, target.position.z + offset.z);


        //transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(target.position.x, -262f, -251f), transform.position.y, Mathf.Clamp(target.position.z, 672f, 688f)), 0.5f*Time.deltaTime);
        //transform.position = new Vector3( Mathf.Clamp(target.position.x , -262f, -251f) , transform.position.y, Mathf.Clamp(target.position.z, 672f, 688f));
    }

}
//Vector3 currentAnglee = new Vector3(
//    Mathf.LerpAngle(transform.rotation.eulerAngles.x, target.transform.rotation.eulerAngles.x + rotatePositionOffsetX, Time.deltaTime * turnSpeed),
//    Mathf.LerpAngle(transform.rotation.eulerAngles.y, target.transform.rotation.eulerAngles.y + 180, Time.deltaTime * turnSpeed),
//    Mathf.LerpAngle(transform.rotation.eulerAngles.z, target.transform.rotation.eulerAngles.z, Time.deltaTime * turnSpeed));

//transform.eulerAngles = currentAnglee;

