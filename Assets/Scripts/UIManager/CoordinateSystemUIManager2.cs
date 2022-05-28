using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateSystemUIManager2 : MonoBehaviour
{
    public GameObject Open;
    public GameObject Fold;

    public GameObject MainUI;
    public GameObject alert;
    public GameObject PR_reportUI;

    public Transform rader;

    public GameObject normalPlanet_PR1;
    public GameObject normalPlanet_PR2;
    public GameObject normalPlanet_PR3;
    public GameObject normalPlanet_PR4;
    public GameObject normalPlanet_PR5;
    public GameObject FakePlanet;
    public Image FakePlanetimg;
    public int i;
    public SphereCollider PlanetCol1;
    public SphereCollider PlanetCol2;
    public SphereCollider PlanetCol3;
    public SphereCollider PlanetCol4;
    public SphereCollider PlanetCol5;
    public SphereCollider FakePlanetCol;

    public bool PR_TimeCheck = false;

    public GameObject dialogManager_PR;
    DialogManager dialogManager;

    public void Start()
    {
        PR_TimeCheck = true;
        
        MainUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);
        alert.SetActive(false);

        dialogManager = dialogManager_PR.GetComponent<DialogManager>();

        FakePlanetCol = FakePlanet.GetComponent<SphereCollider>();
        FakePlanetCol.enabled = false;
        PlanetCol1 = normalPlanet_PR1.GetComponent<SphereCollider>();
        PlanetCol2 = normalPlanet_PR2.GetComponent<SphereCollider>();
        PlanetCol3 = normalPlanet_PR3.GetComponent<SphereCollider>();
        PlanetCol4 = normalPlanet_PR4.GetComponent<SphereCollider>();
        PlanetCol5 = normalPlanet_PR5.GetComponent<SphereCollider>();
    }

    public void Update()
    {
        i = GameManager.gameManager._gameData.SelectPlanetNum;

        if (GameManager.gameManager._gameData.FakePlanetOpen)
        {
            if (GameManager.gameManager._gameData.FakePlanetSelectMission == false)
            {
                FakePlanetCol.enabled = true;

                Color color = FakePlanetimg.GetComponent<Image>().color;
                color.a = 0.6f;
                FakePlanetimg.GetComponent<Image>().color = color;
            }
            if (GameManager.gameManager._gameData.FakePlanetSelectMission)
            {
                FakePlanetCol.enabled = false;
            }
        }
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
        if(GameManager.gameManager._gameData.SelectPlanetCheck == true)
        {
            PR_reportUI.SetActive(true);
        }
    }


    public void Report()
    {
        Debug.Log("보고하기");

        PR_reportUI.SetActive(false);
        PR_TimeCheck = false;

        if (i == 5)
        {
            Debug.Log("페이크");
            GameManager.gameManager._gameData.IsAIVSMissionCount += 1;
            GameManager.gameManager._gameData.FakePlanetSelectMission = true;
        }
        else if (i == 0)
        {
            PlanetCol1.enabled = false;
        }
        else if (i == 1)
        {
            PlanetCol2.enabled = false;
        }
        else if (i == 2)
        {
            PlanetCol3.enabled = false;
        }
        else if (i == 3)
        {
            PlanetCol4.enabled = false;
        }
        else if (i == 4)
        {
            PlanetCol5.enabled = false;
        }
    }

    public void Cancle()
    {
        Debug.Log("취소하기");

        PR_reportUI.SetActive(false);
        PR_TimeCheck = false;

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }
}
