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

    /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 끝 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    public void ChangeMain()
    {
        GameData gameData = SaveSystem.Load("save_001");
        if (gameData.IsTabletUnlock)
        {
            MainUI.SetActive(true);
            LockUI.SetActive(false);
            Locked.text = "UnLocked!";

            // 미션이 추가되어있는지 확인 후 삭제
            if (gameData.ActiveMissionList[7])
            {
                MissionGenerator.missionGenerator.DeleteNewMission(7);
            }
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

            //GameManager.gameManager._gameData.ActiveMissionList[29] = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.AddNewMission(29);
        }
    }
    public void ChangeWireless()
    {
        MainUI.SetActive(false);
        WirelessUI.SetActive(true);

        GameData gameData = SaveSystem.Load("save_001");
        if (!gameData.IsWirelessUI_firstEnter && !gameData.CompleteMissionList[28])
        {
            MissionGenerator.missionGenerator.AddNewMission(28);
            GameManager.gameManager._gameData.CompleteMissionList[28] = true;
            GameManager.gameManager._gameData.IsWirelessUI_firstEnter = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //메인 컴퓨터와 태블릿 신호 연결 시작 시점

            //GameManager.gameManager._gameData.ActiveMissionList[23] = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
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
