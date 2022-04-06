using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcameracontroller : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 3f;
    public float turnSpeed = 300f;
    private Vector3 PositionOffset = new Vector3 (-0.5f, 2, 1); // 강아지가 보임

    //private Vector3 PositionOffset = new Vector3 (-0.5f, 1.5f, 1); // 낮
    //private Vector3 PositionOffset = new Vector3 (-0.5f, 1, 3); // 낮음
    //private Vector3 PositionOffset = new Vector3 (-0.5f, 0.5f, 3); // 완전 낮음
   
    public float rotatePositionOffsetX = 15;






    //public Vector3 Basicpos=new Vector3(0f, 131.1f, 35.4f);

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + PositionOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        //transform.LookAt(target);

        Vector3 currentAnglee = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, target.transform.rotation.eulerAngles.x+rotatePositionOffsetX, Time.deltaTime*turnSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, target.transform.rotation.eulerAngles.y+180, Time.deltaTime*turnSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, target.transform.rotation.eulerAngles.z, Time.deltaTime*turnSpeed));
        
        transform.eulerAngles = currentAnglee;

    }
}
