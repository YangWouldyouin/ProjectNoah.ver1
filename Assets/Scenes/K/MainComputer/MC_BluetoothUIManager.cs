using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_BluetoothUIManager : MonoBehaviour
{
    //// 메인 페이지
    //public GameObject MainPage_B; // 메인 페이지

    //public GameObject UploadButton_B; // 업로드 버튼
    //public GameObject DownloadButton_B; // 다운로드 버튼


    //// 업, 다운로드 페이지
    //public GameObject UpDownloadPage_B; // 메인 페이지

    //public Text UploadPer_P; // 업로드 %
    //public Image Upload_Title_P;

    //public Text DownloadPer_P; // 다운로드 %
    //public Image Download_Title_P;


    //// 블루투스 아이콘
    //public Image BluetoothIcon_Main_B;
    //public Image BluetoothIcon_UpDown_B;



    //void Start()
    //{
    //    MainPage_B.SetActive(true);
    //    UpDownloadPage_B.SetActive(false);
    //}

    //void Update()
    //{
    //}

    //public void OnClickUpLoadButton()
    //{
    //    MainPage_B.SetActive(false);
    //    UpDownloadPage_B.SetActive(true); // UpDownload 페이지가 켜짐

    //    UploadPer_P.gameObject.SetActive(true); // Upload 파일 켜짐
    //    Upload_Title_P.gameObject.SetActive(true);
    //    UploadPer_P.text = "업로드 " + "여기에 0~100 수치" + "%";

    //}

    //public void OnClickDownLoadButton()
    //{
    //    MainPage_B.SetActive(false);
    //    UpDownloadPage_B.SetActive(true); // UpDownload 페이지가 켜짐

    //    DownloadPer_P.gameObject.SetActive(true); // Download 파일 켜짐
    //    Download_Title_P.gameObject.SetActive(true);
    //    DownloadPer_P.text = "다운로드 " + "여기에 0~100 수치" + "%";
    //}
    
    public GameObject MCW_MainUI;
    public GameObject MCW_UploadSelectUI;
    public GameObject MCW_UploadUI;
    public GameObject MCW_alertUI;


    public GameObject TitleBar;

    public Image MCW_onoffBT; //Wireless on/off 버튼

    public Text OnOffText;
    public Text FinalBRText;

    public Text MCW_Alert_TitleText;
    public Text MCW_Alert_BodyText;
    public Text MCW_Alert_UploadText;

    // Start is called before the first frame update
    void Start()
    {
        MCW_MainUI.SetActive(true);
        MCW_UploadSelectUI.SetActive(false);
        MCW_UploadUI.SetActive(false);
        MCW_alertUI.SetActive(false);

        //GameManager.gameManager._gameData.IsFinalBusinessReport_MC = true;
        //GameManager.gameManager._gameData.Is_Tablet_WirelessOn = true;
    }

    void Update()
    {
        if (GameManager.gameManager._gameData.Is_MainComputer_WirelessOn == true)
        {
            OnOffText.GetComponent<Text>().text = "무선 연결        ON";
            Color onoffcolor = MCW_onoffBT.color;
            onoffcolor.a = 1f;
            MCW_onoffBT.color = onoffcolor;
        }
        else
        {
            OnOffText.GetComponent<Text>().text = "무선 연결        OFF";
            Color onoffcolor = MCW_onoffBT.color;
            onoffcolor.a = 0.3f;
            MCW_onoffBT.color = onoffcolor;
        }

        if (GameManager.gameManager._gameData.IsAIVSMissionCount == 3)
        {
            GameManager.gameManager._gameData.IsFinalBusinessReport_MC = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        if (GameManager.gameManager._gameData.IsFinalBusinessReport_MC)
        {
            if (GameManager.gameManager._gameData.IsFinalBusinessReportFile_MC)
            {
                Color HRTcolor = FinalBRText.color;
                HRTcolor.a = 0.3f;
                FinalBRText.color = HRTcolor;
            }
            else
            {
                FinalBRText.GetComponent<Text>().text = "업무 보고 파일 최종본";

                Color FCDTcolor = FinalBRText.color;
                FCDTcolor.a = 1f;
                FinalBRText.color = FCDTcolor;
            }
        }
    }

    public void MCW_WirelessCheck()
    {
        if (GameManager.gameManager._gameData.Is_MainComputer_WirelessOn == false)
        {
            GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = true;

            if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && GameManager.gameManager._gameData.Is_MainComputer_WirelessOn && GameManager.gameManager._gameData.IsWirelessMCTabletCheck == false)
            {
                GameManager.gameManager._gameData.IsWirelessMCTabletCheck = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //메인 컴퓨터와 태블릿 신호 연결 끝 시점

                //GameManager.gameManager._gameData.ActiveMissionList[28] = false;
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //MissionGenerator.missionGenerator.ActivateMissionList();
                MissionGenerator.missionGenerator.DeleteNewMission(28);
            }
        }
        else
        {
            GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    public void MCW_SelectFile()
    {
        if (GameManager.gameManager._gameData.Is_MainComputer_WirelessOn)
        {
            MCW_MainUI.SetActive(false);
            MCW_UploadSelectUI.SetActive(true);
        }
    }

    public void MCW_ChangeUpload_File()
    {
        if (GameManager.gameManager._gameData.IsFinalBusinessReport_MC)
        {
            if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && GameManager.gameManager._gameData.Is_MainComputer_WirelessOn)
            {
                if (GameManager.gameManager._gameData.IsFinalBusinessReportFile_MC == false)
                {
                    MCW_UploadSelectUI.SetActive(false);
                    TitleBar.SetActive(false);
                    MCW_UploadUI.SetActive(true);

                    Invoke("MCW_Alert", 3f);
                    MCW_Alert_UploadText.GetComponent<Text>().text = "FileUploading " + 100 + " % ";
                    MCW_Alert_TitleText.GetComponent<Text>().text = "Complete!";
                    MCW_Alert_BodyText.GetComponent<Text>().text = "[태블릿]에 [업무 보고 파일 최종본]을 성공적으로 업로드했습니다.";

                    GameManager.gameManager._gameData.Is_Tablet_WirelessOn = false;
                    GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = false;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                    GameManager.gameManager._gameData.IsFinalBusinessReportFile_MC = true;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                    //GameManager.gameManager._gameData.ActiveMissionList[8] = false;
                    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    //MissionGenerator.missionGenerator.ActivateMissionList();
                    MissionGenerator.missionGenerator.DeleteNewMission(8);
                }
            }
            else
            {
                if (GameManager.gameManager._gameData.IsFinalBusinessReportFile_MC == false)
                {
                    MCW_alertUI.SetActive(true);

                    MCW_Alert_TitleText.GetComponent<Text>().text = "Warning!";
                    MCW_Alert_BodyText.GetComponent<Text>().text = "연결된 기기가 없습니다.";

                    StartCoroutine(MCW_Alert_onetime());
                }
            }
        }
    }

    public void MCW_Alert()
    {
        MCW_alertUI.SetActive(true);

        Invoke("MCW_Change_MainUI", 2f);
    }

    IEnumerator MCW_Alert_onetime()
    {
        yield return new WaitForSeconds(3f);
        MCW_alertUI.SetActive(false);
    }

    public void MCW_Change_MainUI()
    {
        MCW_alertUI.SetActive(false);
        MCW_UploadUI.SetActive(false);
        MCW_UploadSelectUI.SetActive(false);
        MCW_MainUI.SetActive(true);
        TitleBar.SetActive(true);
    }
}
