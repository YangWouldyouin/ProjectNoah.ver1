using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMissionManager : MonoBehaviour
{
    public bool MeteorMissionEnd;
    public InGameTime inGameTime;

    public GameObject dialogManager_RM;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_RM.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //����üũ �ӹ� 

        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10 && (inGameTime.days + 1) >= 3 && !GameManager.gameManager._gameData.IsHDRtimeCheck)
        {
            GameManager.gameManager._gameData.IsAIReportMissionTime = true;
            GameManager.gameManager._gameData.IsRM_HealthDataReportbool = false;
            GameManager.gameManager._gameData.IsHDRtimeCheck = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            if (GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck == false)
            {
                Debug.Log("���� üũ ���� ���� ����");
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(62));
                GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //�߰������ͺ��� �ӹ� ����

                //GameManager.gameManager._gameData.ActiveMissionList[14] = true;
                //MissionGenerator.missionGenerator.ActivateMissionList();
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                MissionGenerator.missionGenerator.AddNewMission(14);
            }

        }

        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 11 && (inGameTime.days + 1) >= 3 && GameManager.gameManager._gameData.IsHDRtimeCheck)
        {
            GameManager.gameManager._gameData.IsHDRtimeCheck = false;
        }

        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10 && GameManager.gameManager._gameData.IsRM_HealthDataReportbool == false)
        {
            GameManager.gameManager._gameData.IsAIReportMissionTime = false;
            //GameManager.gameManager._gameData.IsRM_HealthDataReportbool = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            if (GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck == true)
            {
                Debug.Log("���� üũ ���� ���� ����");
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
                GameManager.gameManager._gameData.IsReportCancleCount += 1;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                GameManager.gameManager._gameData.IsRM_HM_MissionScriptCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //�߰������ͺ��� �ӹ� ��

                //GameManager.gameManager._gameData.ActiveMissionList[14] = false;
                //MissionGenerator.missionGenerator.ActivateMissionList();
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                MissionGenerator.missionGenerator.DeleteNewMission(14);
            }

        }




        //��������ӹ�
        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10 && !GameManager.gameManager._gameData.IsPtimeCheck)
        {
            if (GameManager.gameManager._gameData.IsRM_P_MissionScriptCheck == false)
            {
                Debug.Log("������� ���� ����");

                GameManager.gameManager._gameData.IsPhotoTime = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(46));
                GameManager.gameManager._gameData.IsRM_P_MissionScriptCheck = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //������ ���� �Կ� ���� ����

                //GameManager.gameManager._gameData.ActiveMissionList[23] = true;
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //MissionGenerator.missionGenerator.ActivateMissionList();
                MissionGenerator.missionGenerator.AddNewMission(23);
            }
            GameManager.gameManager._gameData.IsPtimeCheck = true;
        }

        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 11 && GameManager.gameManager._gameData.IsPtimeCheck)
        {
            GameManager.gameManager._gameData.IsPtimeCheck = false;
        }

        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10)
        {
            if (GameManager.gameManager._gameData.IsRM_P_MissionScriptCheck == true)
            {
                Debug.Log("������� ���� ����");

                GameManager.gameManager._gameData.IsPhotoTime = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                GameManager.gameManager._gameData.IsReportCancleCount += 1;
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
                GameManager.gameManager._gameData.IsRM_P_MissionScriptCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //������ ���� �Կ� ���� ��

                //GameManager.gameManager._gameData.ActiveMissionList[23] = false;
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //MissionGenerator.missionGenerator.ActivateMissionList();
                MissionGenerator.missionGenerator.DeleteNewMission(23);
            }
        }




        //�༺Ž�� �ӹ�
        if ((inGameTime.days + 1) % 4 == 0 && (inGameTime.hours) == 12 && !GameManager.gameManager._gameData.IsPRtimeCheck)
        {
            GameManager.gameManager._gameData.IsPRtimeCheck = true;
            if (GameManager.gameManager._gameData.IsRM_PR_MissionScriptCheck == false)
            {
                Debug.Log("�༺ Ž�� �ӹ� ����");
                GameManager.gameManager._gameData.IsRM_PR_TimeCheck = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(70));
                GameManager.gameManager._gameData.IsRM_PR_MissionScriptCheck = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                if (GameManager.gameManager._gameData.IsFakePlanetOpen)
                {
                    //GameManager.gameManager._gameData.ActiveMissionList[33] = true;
                    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    //MissionGenerator.missionGenerator.ActivateMissionList();
                    MissionGenerator.missionGenerator.AddNewMission(33);
                }
                else
                {
                    //GameManager.gameManager._gameData.ActiveMissionList[31] = true;
                    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    //MissionGenerator.missionGenerator.ActivateMissionList();
                    MissionGenerator.missionGenerator.AddNewMission(31);
                }
            }

        }

        if ((inGameTime.days + 1) % 4 == 0 && (inGameTime.hours) == 13 && GameManager.gameManager._gameData.IsPRtimeCheck)
        {
            GameManager.gameManager._gameData.IsPRtimeCheck = false;
        }

        if ((inGameTime.days + 1) % 4 == 2 && (inGameTime.hours) == 12)
        {
            if (GameManager.gameManager._gameData.IsRM_PR_MissionScriptCheck == true)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
                GameManager.gameManager._gameData.IsReportCancleCount += 1;
                Debug.Log("�༺ Ž�� �ӹ� ����");
                GameManager.gameManager._gameData.IsRM_PR_TimeCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                GameManager.gameManager._gameData.IsRM_PR_MissionScriptCheck = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                if (GameManager.gameManager._gameData.IsFakePlanetOpen)
                {
                    //GameManager.gameManager._gameData.ActiveMissionList[33] = false;
                    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    //MissionGenerator.missionGenerator.ActivateMissionList();
                    MissionGenerator.missionGenerator.DeleteNewMission(33);
                }
                else
                {
                    //GameManager.gameManager._gameData.ActiveMissionList[31] = false;
                    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    //MissionGenerator.missionGenerator.ActivateMissionList();
                    MissionGenerator.missionGenerator.DeleteNewMission(31);
                }
            }
        }

        //��ӹ� ���� üũ

        if (inGameTime.timer >= 3300 && inGameTime.timer <= 3301 && MeteorMissionEnd == false)
        {
            MeteorMissionEnd = true;

            Debug.Log("� ���� ���� ���� ����");
            GameManager.gameManager._gameData.IsStartCollectMeteorites = true;
            //C-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            //������ ��翡 ���� �����н��� ���� ���� �ӹ��� �����ߴٸ� ���� �ӹ��� �غ��϶�� ���� �� ������ ������
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(42));

            // � ���� ���� �ӹ�����Ʈ ���� ����������������������������������������������������������������������
            //GameManager.gameManager._gameData.ActiveMissionList[22] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.AddNewMission(22);
        }
    }
}
