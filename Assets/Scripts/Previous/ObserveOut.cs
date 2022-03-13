using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserveOut : MonoBehaviour
{
    public Transform[] views;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            changeView(views[1]);
        }
    }

    void changeView(Transform view)
    {
        transform.position = view.position;
        transform.rotation = view.rotation;
    }
}
