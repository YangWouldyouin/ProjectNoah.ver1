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

    public Image MCW_onoffBT; //Wireless on/off ��ư

    public Text OnOffText; 
    public Text SelectFileNameText; //���� ���������� �𸣰����� ���ε��� ���� �̸� �ؽ�Ʈ

    public bool FileUpload = false; //���� ���������� �𸣰����� �� ���̶� ���ε������� ���úҰ� and ��ο���, ���߿� ������ GameData ������ ������ֱ�

    // Start is called before the first frame update
    void Start()
    {
        MCW_MainUI.SetActive(true);
        MCW_UploadSelectUI.SetActive(false);
        MCW_UploadUI.SetActive(false);
        MCW_alertUI.SetActive(false);
    }

    public void MCW_WirelessCheck()
    {
        if (GameManager.gameManager._gameData.Is_MainComputer_WirelessOn == false)
        {
            GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = true;
            OnOffText.GetComponent<Text>().text = "���� ����        ON";
            Color onoffcolor = MCW_onoffBT.color;
            onoffcolor.a = 1f;
            MCW_onoffBT.color = onoffcolor;
        }
        else
        {
            GameManager.gameManager._gameData.Is_MainComputer_WirelessOn = false;
            OnOffText.GetComponent<Text>().text = "���� ����        OFF";
            Color onoffcolor = MCW_onoffBT.color;
            onoffcolor.a = 0.3f;
            MCW_onoffBT.color = onoffcolor;
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
        if (/*GameManager.gameManager._gameData.IsFakeHealthData_Tablet == false*/FileUpload == false)
        {
            MCW_UploadSelectUI.SetActive(false);
            MCW_UploadUI.SetActive(true);

            Invoke("MCW_Alert", 3f);

            /*GameManager.gameManager._gameData.IsFakeHealthData_Tablet = true;*/
            FileUpload = true;

            Color HRTcolor = SelectFileNameText.color;  
            HRTcolor.a = 0.3f;
            SelectFileNameText.color = HRTcolor;
        }
    }

    public void MCW_Alert()
    {
        MCW_alertUI.SetActive(true);

        Invoke("MCW_Change_MainUI", 2f);
    }

    public void MCW_Change_MainUI()
    {
        MCW_alertUI.SetActive(false);
        MCW_UploadUI.SetActive(false);
        MCW_UploadSelectUI.SetActive(false);
        MCW_MainUI.SetActive(true);
    }
}
