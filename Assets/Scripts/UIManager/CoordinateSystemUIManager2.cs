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

    public InGameTime inGameTime;
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

        if (GameManager.gameManager._gameData.IsFakePlanetOpen)
        {
            if (GameManager.gameManager._gameData.IsFakePlanetSelectMission == false)
            {
                FakePlanetCol.enabled = true;

                Color color = FakePlanetimg.GetComponent<Image>().color;
                color.a = 0.6f;
                FakePlanetimg.GetComponent<Image>().color = color;
            }
            if (GameManager.gameManager._gameData.IsFakePlanetSelectMission)
            {
                FakePlanetCol.enabled = false;
            }
        }


        if ((inGameTime.days + 1) % 4 == 0 && (inGameTime.hours) == 12)
        {
            if (MissionScriptCheck == false)
            {
                Debug.Log("행성 탐사 임무 시작");
                PR_TimeCheck = true;

                //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(62));
                MissionScriptCheck = true;
            }
        }
        if ((inGameTime.days + 1) % 4 == 2 && (inGameTime.hours) == 12)
        {
            if (MissionScriptCheck == true)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
                GameManager.gameManager._gameData.IsReportCancleCount += 1;
                Debug.Log("행성 탐사 임무 종료");
                PR_TimeCheck = false;

                MissionScriptCheck = false;
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
        if(GameManager.gameManager._gameData.IsSelectPlanetCheck == true)
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
            GameManager.gameManager._gameData.IsFakePlanetSelectMission = true;
        }
        else if (i == 0)
        {
            PlanetCol1.enabled = false;
            GameManager.gameManager._gameData.IsPlanetSelectMission = true;
        }
        else if (i == 1)
        {
            PlanetCol2.enabled = false;
            GameManager.gameManager._gameData.IsPlanetSelectMission = true;
        }
        else if (i == 2)
        {
            PlanetCol3.enabled = false;
            GameManager.gameManager._gameData.IsPlanetSelectMission = true;
        }
        else if (i == 3)
        {
            PlanetCol4.enabled = false;
            GameManager.gameManager._gameData.IsPlanetSelectMission = true;
        }
        else if (i == 4)
        {
            PlanetCol5.enabled = false;
            GameManager.gameManager._gameData.IsPlanetSelectMission = true;
        }

        MainUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);
    }

    public void Cancle()
    {
        Debug.Log("취소하기");

        PR_reportUI.SetActive(false);
        PR_TimeCheck = false;

        MainUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }
}
