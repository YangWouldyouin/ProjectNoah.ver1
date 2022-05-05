using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSystemUIManager : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject MapUI;
    public GameObject WirelessUI;
    public GameObject Open;
    public GameObject Fold;
    public GameObject alert;

    public GameObject systemAlert;

    public Image MS_onoffBT;

    public Text OnOffText;

    public void Start()
    {
        MainUI.SetActive(false);
        MapUI.SetActive(false);
        WirelessUI.SetActive(false);
        alert.SetActive(false);
        Fold.SetActive(false);
        Open.SetActive(true);
    }

    public void Update()
    {
        if (GameManager.gameManager._gameData.Is_MainSystem_WirelessOn == true)
        {
            OnOffText.GetComponent<Text>().text = "무선 연결        ON";
            Color onoffcolor = MS_onoffBT.color;
            onoffcolor.a = 1f;
            MS_onoffBT.color = onoffcolor;
        }
        else
        {
            OnOffText.GetComponent<Text>().text = "무선 연결        OFF";
            Color onoffcolor = MS_onoffBT.color;
            onoffcolor.a = 0.3f;
            MS_onoffBT.color = onoffcolor;
        }

        if (GameManager.gameManager._gameData.IsReturnOfTheEarth)
        {
            systemAlert.SetActive(true);
            Invoke("systemAlertduration", 3f);
        }
    }

    public void systemAlertduration()
    {
        systemAlert.SetActive(false);
    }

    public void OpenBT()
    {
        MainUI.SetActive(true);

        Open.SetActive(false);
        Fold.SetActive(true);
    }
    public void FoldBT()
    {
        MainUI.SetActive(false);
        MapUI.SetActive(false);
        WirelessUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);
    }

    public void ChangeMapPage()
    {
        MainUI.SetActive(false);
        MapUI.SetActive(true);
    }
    public void MapBackBT()
    {
        MainUI.SetActive(true);
        MapUI.SetActive(false);
    }
    public void ChangeWirelessPage()
    {
        MainUI.SetActive(false);
        WirelessUI.SetActive(true);
    }
    public void WirelessBackBT()
    {
        MainUI.SetActive(true);
        WirelessUI.SetActive(false);
    }

    public void MS_WirelessCheck()
    {
        if (GameManager.gameManager._gameData.Is_MainSystem_WirelessOn == false)
        {
            GameManager.gameManager._gameData.Is_MainSystem_WirelessOn = true;
        }
        else
        {
            GameManager.gameManager._gameData.Is_MainSystem_WirelessOn = false;
        }
    }

    public void UploadBT()
    {
        if (GameManager.gameManager._gameData.Is_MainSystem_WirelessOn == true)
        {
            alert.SetActive(true);
            Invoke("Alert", 3f);
        }
    }
    public void Alert()
    {
        alert.SetActive(false);
    }
}