using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletWirelessUIManager : MonoBehaviour
{
    public GameObject TW_MainUI;
    public GameObject TW_UploadSelectUI;
    public GameObject TW_UploadUI;
    public GameObject TW_alertUI;

    public Image TW_onoffBT;

    //public bool TW_WirelessOn = false;
    //public bool LieHealthData = false;
    //public bool FakeCoordinateData = false;
    //public bool FakeCoordinateDatafile = false;

    public Text OnOffText;
    public Text HealthReportText;
    public Text FakeCoordinateDataText;

    // Start is called before the first frame update
    void Start()
    {
        TW_MainUI.SetActive(true);
        TW_UploadSelectUI.SetActive(false);
        TW_UploadUI.SetActive(false);
        TW_alertUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TW_WirelessCheck()
    {
        if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn == false)
        {
            GameManager.gameManager._gameData.Is_Tablet_WirelessOn = true;
            OnOffText.GetComponent<Text>().text = "무선 연결        ON";
            Color onoffcolor = TW_onoffBT.color;
            onoffcolor.a = 1f;
            TW_onoffBT.color = onoffcolor;
        }
        else
        {
            GameManager.gameManager._gameData.Is_Tablet_WirelessOn = false;
            OnOffText.GetComponent<Text>().text = "무선 연결        OFF";
            Color onoffcolor = TW_onoffBT.color;
            onoffcolor.a = 0.3f;
            TW_onoffBT.color = onoffcolor;
        }
    }

    public void TW_SelectFile()
    {
        if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn)
        {
            TW_MainUI.SetActive(false);
            TW_UploadSelectUI.SetActive(true);
        }
    }

    public void TW_ChangeUpload_HealthReport()
    {
        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet == false)
        {
            TW_UploadSelectUI.SetActive(false);
            TW_UploadUI.SetActive(true);

            Invoke("TW_Alert", 3f);

            GameManager.gameManager._gameData.IsFakeHealthData_Tablet = true;

            Color HRTcolor = HealthReportText.color;
            HRTcolor.a = 0.3f;
            HealthReportText.color = HRTcolor;
        }
    }

    public void TW_ChangeUpload_FakeCoordinateData()
    {
        if (GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet == true)
        {
            FakeCoordinateDataText.GetComponent<Text>().text = "귀환 좌표 데이터";

            Color FCDTcolor = FakeCoordinateDataText.color;
            FCDTcolor.a = 1f;
            FakeCoordinateDataText.color = FCDTcolor;

            TW_UploadSelectUI.SetActive(false);
            TW_UploadUI.SetActive(true);

            Invoke("TW_Alert", 4f);

            GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet = true;

            Color HRTcolor = FakeCoordinateDataText.color;
            HRTcolor.a = 0.3f;
            FakeCoordinateDataText.color = HRTcolor;
        }
        else
        {
            Color HRTcolor = FakeCoordinateDataText.color;
            HRTcolor.a = 0.3f;
            FakeCoordinateDataText.color = HRTcolor;
        }
    }

    public void TW_Alert()
    {
        TW_alertUI.SetActive(true);

        Invoke("TW_Change_MainUI", 2f);
    }

    public void TW_Change_MainUI()
    {
        TW_alertUI.SetActive(false);
        TW_UploadUI.SetActive(false);
        TW_UploadSelectUI.SetActive(false);
        TW_MainUI.SetActive(true);
    }
}