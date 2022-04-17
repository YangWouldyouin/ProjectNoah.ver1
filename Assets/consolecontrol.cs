using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consolecontrol : MonoBehaviour
{
    public GameObject consoleCenter_CC;
    ObjData consoleCenterData_CC;

    public GameObject dialogManager_CC;
    DialogManager dialogManager;

    public void OnConsoleObserveClicked()
    {
        //CameraController.cameraController.currentView = consoleCenterData_CC.ObservePlusView;
        
        if(!InteractData.interactData.IsBoxUpDown)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(1));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_CC.GetComponent<DialogManager>();
        consoleCenterData_CC = consoleCenter_CC.GetComponent<ObjData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
