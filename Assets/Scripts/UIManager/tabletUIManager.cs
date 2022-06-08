using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabletUIManager : MonoBehaviour
{
    public GameObject DiaryUI;
    public GameObject MainUI;
    public GameObject CrackUI;
    public GameObject WirelessUI;
    public GameObject LockUI;

    public Text Locked;

    public bool CrackUI_firstEnter = false;

    public void Start()
    {
        DiaryUI.SetActive(false);
        CrackUI.SetActive(false);
        WirelessUI.SetActive(false);
        MainUI.SetActive(false);
        LockUI.SetActive(true);
    }

    public void Update()
    {
        if (GameManager.gameManager._gameData.IsTabletUnlock)
        {
            Locked.text = "UnLocked!";
        }
    }

    /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 끝 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    public void ChangeMain()
    {
        if (GameManager.gameManager._gameData.IsTabletUnlock == true)
        {
            MainUI.SetActive(true);
            LockUI.SetActive(false);

            GameManager.gameManager._gameData.ActiveMissionList[7] = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();
        }
    }

    public void ChangeDiary()
    {
        MainUI.SetActive(false);
        DiaryUI.SetActive(true);
    }
    public void ChangeCrack()
    {
        MainUI.SetActive(false);
        CrackUI.SetActive(true);

        if (CrackUI_firstEnter == false)
        {
            CrackUI_firstEnter = true;
            //더미데이터 보고(다운로드) 시작 시점

            GameManager.gameManager._gameData.ActiveMissionList[29] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();
        }
    }
    public void ChangeWireless()
    {
        MainUI.SetActive(false);
        WirelessUI.SetActive(true);

        if (GameManager.gameManager._gameData.IsWirelessUI_firstEnter == false)
        {
            GameManager.gameManager._gameData.IsWirelessUI_firstEnter = true;
            //메인 컴퓨터와 태블릿 신호 연결 시작 시점

            GameManager.gameManager._gameData.ActiveMissionList[23] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();
        }
    }

    public void BackMain_Diary()
    {
        DiaryUI.SetActive(false);
        MainUI.SetActive(true);
    }
    public void BackMain_Crack()
    {
        CrackUI.SetActive(false);
        MainUI.SetActive(true);
    }
    public void BackMain_Wireless()
    {
        WirelessUI.SetActive(false);
        MainUI.SetActive(true);
    }
}
