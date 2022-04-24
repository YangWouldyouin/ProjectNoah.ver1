using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationSystemUIManager : MonoBehaviour
{
    public GameObject Open;
    public GameObject alert;

    public void Start()
    {
        alert.SetActive(false);
        Open.SetActive(true);
    }

    public void OpenBT()
    {
        alert.SetActive(true);
        Invoke("Alert", 2f);
    }
    public void Alert()
    {
        alert.SetActive(false);
    }

}
