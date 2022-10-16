using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_BluetoothUIManager : MonoBehaviour
{
    //// ���� ������
    //public GameObject MainPage_B; // ���� ������

    //public GameObject UploadButton_B; // ���ε� ��ư
    //public GameObject DownloadButton_B; // �ٿ�ε� ��ư


    //// ��, �ٿ�ε� ������
    //public GameObject UpDownloadPage_B; // ���� ������

    //public Text UploadPer_P; // ���ε� %
    //public Image Upload_Title_P;

    //public Text DownloadPer_P; // �ٿ�ε� %
    //public Image Download_Title_P;


    //// ������� ������
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
    //    UpDownloadPage_B.SetActive(true); // UpDownload �������� ����

    //    UploadPer_P.gameObject.SetActive(true); // Upload ���� ����
    //    Upload_Title_P.gameObject.SetActive(true);
    //    UploadPer_P.text = "���ε� " + "���⿡ 0~100 ��ġ" + "%";

    //}

    //public void OnClickDownLoadButton()
    //{
    //    MainPage_B.SetActive(false);
    //    UpDownloadPage_B.SetActive(true); // UpDownload �������� ����

    //    DownloadPer_P.gameObject.SetActive(true); // Download ���� ����
    //    Download_Title_P.gameObject.SetActive(true);
    //    DownloadPer_P.text = "�ٿ�ε� " + "���⿡ 0~100 ��ġ" + "%";
    //}
    
    public GameObject MCW_MainUI;
    public GameObject MCW_UploadSelectUI;
    public GameObject MCW_UploadUI;
    public GameObject MCW_alertUI;


    public GameObject TitleBar;

    public Image MCW_onoffBT; //Wireless on/off ��ư

    public Text OnOffText;
    public Text FinalBRText;

    public Text MCW_Alert_TitleText;
    public Text MCW_Alert_BodyText;
    public Text MCW_Alert_UploadText;

   // public bool Is_MainComputer_WirelessOn = false;

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
        if (GameManager.gameManager._gameData.Is_MainComputer_WirelessOn)
        {
            OnOffText.GetComponent<Text>().text = "���� ����        ON";
            Color onoffcolor = MCW_onoffBT.color;
            onoffcolor.a = 1f;
            MCW_onoffBT.color = onoffcolor;
        }
        else
        {
            OnOffText.GetComponent<Text>().text = "���� ����        OFF";
            Color onoffcolor = MCW_onoffBT.color;
            onoffcolor.a = 0.3f;
            MCW_onoffBT.color = onoffcolor;
        }

        /* ���� �ʿ� */
        if (GameManager.gameManager._gameData.IsAIVSMissionCount == 3)
        {
            GameManager.gameManager._gameData.IsFinalBusinessReport_MC = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        /* ���� �ʿ� */
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
                FinalBRText.GetComponent<Text>().text = "���� ���� ���� ������";

                Color FCDTcolor = FinalBRText.color;
                FCDTcolor.a = 1f;
                FinalBRText.color = FCDTcolor;
            }
        }
    }

    public void MCW_WirelessCheck()
    {
        if (!GameManager.gameManager._gameData.Is_MainComputer_WirelessOn)
        {
            GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            
            GameData wirelessData = SaveSystem.Load("save_001");
            //TabletWirelessUIManager tabletWirelessUIManager = new TabletWirelessUIManager();
            if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && GameManager.gameManager._gameData.Is_MainComputer_WirelessOn && !wirelessData.IsWirelessMCTabletCheck )
            {
                GameManager.gameManager._gameData.IsWirelessMCTabletCheck = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                if(wirelessData.ActiveMissionList[28])
                {
                    MissionGenerator.missionGenerator.DeleteNewMission(28);
                }
                //���� ��ǻ�Ϳ� �º� ��ȣ ���� �� ����
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

    /* ���� �ʿ� */
    public void MCW_ChangeUpload_File()
    {
        if (GameManager.gameManager._gameData.IsFinalBusinessReport_MC)
        {
            //TabletWirelessUIManager tabletWirelessUIManager = new TabletWirelessUIManager();

            if (GameManager.gameManager._gameData.Is_Tablet_WirelessOn && GameManager.gameManager._gameData.Is_MainComputer_WirelessOn)
            {
                GameData gameData = SaveSystem.Load("save_001");

                if (!gameData.IsFinalBusinessReportFile_MC )
                {
                    MCW_UploadSelectUI.SetActive(false);
                    TitleBar.SetActive(false);
                    MCW_UploadUI.SetActive(true);

                    Invoke("MCW_Alert", 3f);
                    MCW_Alert_UploadText.GetComponent<Text>().text = "FileUploading " + 100 + " % ";
                    MCW_Alert_TitleText.GetComponent<Text>().text = "Complete!";
                    MCW_Alert_BodyText.GetComponent<Text>().text = "[�º�]�� [���� ���� ���� ������]�� ���������� ���ε��߽��ϴ�.";

                    GameManager.gameManager._gameData.Is_Tablet_WirelessOn = false;
                    GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = false;

                    MissionGenerator.missionGenerator.DeleteNewMission(8);
                    GameManager.gameManager._gameData.IsFinalBusinessReportFile_MC = true;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                }
            }
            else
            {
                GameData gameData = SaveSystem.Load("save_001");

                if (!gameData.IsFinalBusinessReportFile_MC )
                {
                    MCW_alertUI.SetActive(true);

                    MCW_Alert_TitleText.GetComponent<Text>().text = "Warning!";
                    MCW_Alert_BodyText.GetComponent<Text>().text = "����� ��Ⱑ �����ϴ�." + "\n" + "���� ���� ���: �º�";

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
