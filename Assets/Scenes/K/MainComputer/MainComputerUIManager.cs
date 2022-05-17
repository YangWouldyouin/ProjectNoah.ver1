using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainComputerUIManager : MonoBehaviour
{
    public GameObject MainMenu_UI; // 메인 화면

    /* 메인화면 목록*/
    public GameObject JournalMenu_UI; // 연구 일지 목록
    // public GameObject MeteorList_UI; // 목표 성분 리스트
    public GameObject DogProfile_UI; // 강아지 현재 상태
    public GameObject Wireless_UI; // 블루투스

    /* 연구일지 목록*/
    public GameObject Profile_UI; // 우주 비행사 프로필
    public GameObject Report_UI; // 연구 보고서
    public GameObject Record_UI; // 음성 녹음

    public GameObject HighBar_UI;


    void Start()
    {
        MainMenu_UI.transform.SetAsLastSibling(); // MainMenu_UI 을 가장 마지막에 그림 -> 맨 앞에 보이게 함

        MainMenu_UI.SetActive(true); // 메인 메뉴가 먼저 보이게
        HighBar_UI.SetActive(true); // 상단바 상시 고정

        JournalMenu_UI.SetActive(false);
        // MeteorList_UI.SetActive(false);
        DogProfile_UI.SetActive(false);
        Wireless_UI.SetActive(false);

        Profile_UI.SetActive(false);
        Report_UI.SetActive(false);
        Record_UI.SetActive(false);

    }

    void Update()
    {
    }


    /* 메인 화면 */
    public void ChangeJournal() // 메인 -> 연구일지 목록
    {
        MainMenu_UI.SetActive(false);
        JournalMenu_UI.SetActive(true);
    }
    public void BackMain_Journal() // 연구일지 목록 -> 메인
    {
        MainMenu_UI.SetActive(true);
        JournalMenu_UI.SetActive(false);
    }


/*    public void ChangeMeteorList() // 메인 -> 목표 성분 리스트
    {
        MainMenu_UI.SetActive(false);
        MeteorList_UI.SetActive(true);
    }
    public void BackMain_MeteorList() // 목표 성분 리스트 -> 메인
    {
        MainMenu_UI.SetActive(true);
        MeteorList_UI.SetActive(false);
    }*/


    public void ChangeDogProfile() // 메인 -> 강아지 현재 상태
    {
        MainMenu_UI.SetActive(false);
        DogProfile_UI.SetActive(true);
    }
    public void BackMain_DogProfile() // 강아지 현재 상태 -> 메인
    {
        MainMenu_UI.SetActive(true);
        DogProfile_UI.SetActive(false);
    }


    public void ChangeBluetooth() // 메인 -> 블루투스
    {
        MainMenu_UI.SetActive(false);
        Wireless_UI.SetActive(true);

        if (GameManager.gameManager._gameData.IsWirelessUI_firstEnter == false)
        {
            GameManager.gameManager._gameData.IsWirelessUI_firstEnter = true;
            //메인 컴퓨터와 태블릿 신호 연결 시작 시점

            GameManager.gameManager._gameData.ActiveMissionList[28] = true;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }
    public void BackMain_Bluetooth() // 블루투스 -> 메인
    {
        MainMenu_UI.SetActive(true);
        Wireless_UI.SetActive(false);
    }





    /* 연구일지 */
    public void ChangeProfile() // 연구일지 -> 우주 비행사 프로필
    {
        JournalMenu_UI.SetActive(false);
        Profile_UI.SetActive(true);
    }
    public void BackJournal_Profile() // 우주 비행사 프로필 -> 연구일지
    {
        JournalMenu_UI.SetActive(true);
        Profile_UI.SetActive(false);
    }


    public void ChangeReport() // 연구일지 -> 연구 보고서
    {
        JournalMenu_UI.SetActive(false);
        Report_UI.SetActive(true);
    }
    public void BackJournal_Report() // 연구 보고서 -> 연구일지
    {
        JournalMenu_UI.SetActive(true);
        Report_UI.SetActive(false);
    }


    public void ChangeRecord() // 연구일지 -> 녹음 파일
    {
        JournalMenu_UI.SetActive(false);
        Record_UI.SetActive(true);
    }
    public void BackJournal_Record() // 녹음 파일 -> 연구일지
    {
        JournalMenu_UI.SetActive(true);
        Record_UI.SetActive(false);
    }
}
