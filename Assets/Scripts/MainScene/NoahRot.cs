using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahRot : MonoBehaviour
{
    float rotSpeed = 25f;
    bool stop;


    private void Start()
    {
        stop = false;
        rotSpeed = 25f;
    }

    void Update()
    {
        if(!stop)
        {
            transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        }


    }

    public void StopRotate()
    {
        rotSpeed = 4;
        //stop = true;
        //transform.position = _endPosition.position;
        //transform.rotation = _endPosition.rotation;

        //2 * Time.deltaTime);
        //       transform.rotation = Quaternion.Slerp(transform.rotation, _endPosition.rotation, 2 * Time.deltaTime);
        //transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
