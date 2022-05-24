using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystemUIManager2 : MonoBehaviour
{
    public GameObject Open;
    public GameObject alert;

    public Transform rader;

    public int raderZ = 0;

    public void Start()
    {
        alert.SetActive(false);
        Open.SetActive(true);
    }

    public void OpenBT()
    {
        //alert.SetActive(true);
        //Invoke("Alert", 3f);
    }

    public void Alert()
    {
        //alert.SetActive(false);
    }

    public void rigthBT()
    {
        raderZ += 5;
        rader.transform.Rotate(0f, 0f, raderZ);
    }
    public void leftBT()
    {
        raderZ -= 5;
        rader.transform.Rotate(0f, 0f, raderZ);
    }
}
