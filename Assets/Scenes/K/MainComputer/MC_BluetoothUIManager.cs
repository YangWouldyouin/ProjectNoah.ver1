using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_BluetoothUIManager : MonoBehaviour
{
    // 메인 페이지
    public GameObject MainPage_B; // 메인 페이지

    public GameObject UploadButton_B; // 업로드 버튼
    public GameObject DownloadButton_B; // 다운로드 버튼


    // 업, 다운로드 페이지
    public GameObject UpDownloadPage_B; // 메인 페이지

    public Text UploadPer_P; // 업로드 %
    public Image Upload_Title_P;

    public Text DownloadPer_P; // 다운로드 %
    public Image Download_Title_P;


    // 블루투스 아이콘
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
        UpDownloadPage_B.SetActive(true); // UpDownload 페이지가 켜짐

        UploadPer_P.gameObject.SetActive(true); // Upload 파일 켜짐
        Upload_Title_P.gameObject.SetActive(true);
        UploadPer_P.text = "업로드 " + "여기에 0~100 수치" + "%";

    }

    public void OnClickDownLoadButton()
    {
        MainPage_B.SetActive(false);
        UpDownloadPage_B.SetActive(true); // UpDownload 페이지가 켜짐

        DownloadPer_P.gameObject.SetActive(true); // Download 파일 켜짐
        Download_Title_P.gameObject.SetActive(true);
        DownloadPer_P.text = "다운로드 " + "여기에 0~100 수치" + "%";
    }

}
