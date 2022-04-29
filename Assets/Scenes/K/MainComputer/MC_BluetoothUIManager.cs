using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_BluetoothUIManager : MonoBehaviour
{
    // ���� ������
    public GameObject MainPage_B; // ���� ������

    public GameObject UploadButton_B; // ���ε� ��ư
    public GameObject DownloadButton_B; // �ٿ�ε� ��ư


    // ��, �ٿ�ε� ������
    public GameObject UpDownloadPage_B; // ���� ������

    public Text UploadPer_P; // ���ε� %
    public Image Upload_Title_P;

    public Text DownloadPer_P; // �ٿ�ε� %
    public Image Download_Title_P;


    // ������� ������
    public Image BluetoothIcon_Main_B;
    public Image BluetoothIcon_UpDown_B;



    void Start()
    {
        MainPage_B.SetActive(true);
        UpDownloadPage_B.SetActive(false);
    }

    void Update()
    {
    }

    public void OnClickUpLoadButton()
    {
        MainPage_B.SetActive(false);
        UpDownloadPage_B.SetActive(true); // UpDownload �������� ����

        UploadPer_P.gameObject.SetActive(true); // Upload ���� ����
        Upload_Title_P.gameObject.SetActive(true);
        UploadPer_P.text = "���ε� " + "���⿡ 0~100 ��ġ" + "%";

    }

    public void OnClickDownLoadButton()
    {
        MainPage_B.SetActive(false);
        UpDownloadPage_B.SetActive(true); // UpDownload �������� ����

        DownloadPer_P.gameObject.SetActive(true); // Download ���� ����
        Download_Title_P.gameObject.SetActive(true);
        DownloadPer_P.text = "�ٿ�ε� " + "���⿡ 0~100 ��ġ" + "%";
    }

}
