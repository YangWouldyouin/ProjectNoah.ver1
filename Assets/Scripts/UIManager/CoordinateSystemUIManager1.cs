using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateSystemUIManager1 : MonoBehaviour
{
    public GameObject Open;
    public GameObject Fold;

    public GameObject MainUI;
    public GameObject alert;
    public GameObject PR_reportUI;

    public Transform rader;

    public GameObject normalPlanet_PR1;
    public int i;
    public SphereCollider PlanetCol1;

    public bool PR_TimeCheck = false;
    public bool MissionScriptCheck = false;

    public GameObject dialogManager_PR;
    DialogManager dialogManager;

    public void Start()
    {
        //PR_TimeCheck = true;

        MainUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);
        alert.SetActive(false);

        dialogManager = dialogManager_PR.GetComponent<DialogManager>();

        PlanetCol1 = normalPlanet_PR1.GetComponent<SphereCollider>();

        PR_TimeCheck = true;
    }

    public void Update()
    {

    }

    public void BTOpen()
    {
        if (PR_TimeCheck == true)
        {
            MainUI.SetActive(true);
            Open.SetActive(false);
            Fold.SetActive(true);
            alert.SetActive(false);
        }
        else
        {
            alert.SetActive(true);
            Invoke("Alert3sec", 3f);
        }

    }

    public void Alert3sec()
    {
        alert.SetActive(false);
    }

    public void BTFold()
    {
        MainUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);
    }

    public void BTright()
    {
        rader.transform.Rotate(0, 0, -10);
    }
    public void BTleft()
    {
        rader.transform.Rotate(0, 0, 10);
    }

    public void BTSelect()
    {
        if (GameManager.gameManager._gameData.IsSelectPlanetCheck == true)
        {
            PR_reportUI.SetActive(true);
        }
    }


    public void Report()
    {
        Debug.Log("보고하기");

        PR_reportUI.SetActive(false);
        PR_TimeCheck = false;

        PlanetCol1.enabled = false;

        if (i == 0)
        {
            PlanetCol1.enabled = false;
        }

        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(71));

        MainUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);
    }

    public void Cancle()
    {

    }
}
