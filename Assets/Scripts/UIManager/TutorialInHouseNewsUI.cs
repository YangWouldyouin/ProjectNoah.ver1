using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInHouseNewsUI : MonoBehaviour
{
    public GameObject ExitBT;

    public GameObject InhouseNews_GUI;

    void Start()
    {
        Invoke("ExitBTNotice", 3f);
        Invoke("NewUIFalse", 230f);
    }

    void Update()
    {

    }

    public void ExitBTNotice()
    {
        ExitBT.SetActive(true);
    }

    public void NewUIFalse()
    {
        InhouseNews_GUI.SetActive(false);
        ExitBT.SetActive(false);
    }


    public void OnExitBT()
    {
        InhouseNews_GUI.SetActive(false);
        ExitBT.SetActive(false);
    }
}
