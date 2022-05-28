using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingController : MonoBehaviour
{
    public InGameTime inGameTime;

    public GameObject fadeout;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SavePageManager();

        if(GameManager.gameManager._gameData.statNum <=0)
        {
            GameManager.gameManager._gameData.IsSuddenDeath = true;
            GameManager.gameManager._gameData.IsManagerAbilityLack = true;
            
            GameManager.gameManager._gameData.statNum = 5;
        }

        if (GameManager.gameManager._gameData.IsInputImportantMeteorEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 0;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //Ư�� � ���� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            fadeout.SetActive(true);
            Invoke("changeEndingScene", 1f);
            //SceneManager.LoadScene("EndingScene");
            //���� �� �̵�

        }

        if (GameManager.gameManager._gameData.IsMakeForestEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 1;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //���°豸�࿣��
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            fadeout.SetActive(true);
            Invoke("changeEndingScene", 1f);
            //SceneManager.LoadScene("EndingScene");
        }

        if (GameManager.gameManager._gameData.IsReportCancleCount >= 3)
        {
            GameManager.gameManager._gameData.IsDefyMissionEnd = true;
            Debug.Log("Game Over");

            GameManager.gameManager._gameData.EndingNum = 2;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //��� �Һ��� ����
            // ����, ��� ����Ʈ ���� ����
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            fadeout.SetActive(true);
            Invoke("changeEndingScene", 1f);
            //SceneManager.LoadScene("EndingScene");
            // ����Ʈ ���� ���������� �̵�
            // ���� ����
        }

        if (GameManager.gameManager._gameData.IsDisqualifiedEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 3;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //������� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            fadeout.SetActive(true);
            Invoke("changeEndingScene", 1f);
            //SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsDiscardNoahEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 4;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //����ü ��� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            fadeout.SetActive(true);
            Invoke("changeEndingScene", 1f);
            //SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 5;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //����� ���� �ϳ� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            fadeout.SetActive(true);
            Invoke("changeEndingScene", 1f);
            //SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsSaveAllEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 6;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //����� ���� ���� ����, ������, ���O
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            fadeout.SetActive(true);
            Invoke("changeEndingScene", 1f);
            //SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if(GameManager.gameManager._gameData.IsReturnOfTheEarth == false && GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._gameData.IsSaveOnlyOneEnd = true;
        }

        if (GameManager.gameManager._gameData.IsReturnOfTheEarth)
        {
            GameManager.gameManager._gameData.IsSaveAllEnd = true;
        }
    }

    public void changeEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }

    public void SavePageManager()
    {
        if(GameManager.gameManager._savePageData.IsDisqualifiedEnd0 == false && GameManager.gameManager._gameData.IsDisqualifiedEnd)
        {
            GameManager.gameManager._savePageData.IsDisqualifiedEnd0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsEatBadPotato0 == false && GameManager.gameManager._gameData.IsEatBadPotato)
        {
            GameManager.gameManager._savePageData.IsEatBadPotato0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsMakeForestEnd0 == false && GameManager.gameManager._gameData.IsMakeForestEnd)
        {
            GameManager.gameManager._savePageData.IsMakeForestEnd0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsManagerAbilityLack0 == false && GameManager.gameManager._gameData.IsManagerAbilityLack)
        {
            GameManager.gameManager._savePageData.IsManagerAbilityLack0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsInputImportantMeteorEnd0 == false && GameManager.gameManager._gameData.IsInputImportantMeteorEnd)
        {
            GameManager.gameManager._savePageData.IsInputImportantMeteorEnd0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsDiscardNoahEnd0 == false && GameManager.gameManager._gameData.IsDiscardNoahEnd)
        {
            GameManager.gameManager._savePageData.IsDiscardNoahEnd0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsSaveOnlyOneEnd0 == false && GameManager.gameManager._gameData.IsSaveOnlyOneEnd)
        {
            GameManager.gameManager._savePageData.IsSaveOnlyOneEnd0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsSaveAllEnd0 == false && GameManager.gameManager._gameData.IsSaveAllEnd)
        {
            GameManager.gameManager._savePageData.IsSaveAllEnd0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsDefyMissionEnd0 == false && GameManager.gameManager._gameData.IsDefyMissionEnd)
        {
            GameManager.gameManager._savePageData.IsDefyMissionEnd0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }


        if (GameManager.gameManager._savePageData.IsTutorialClear0 == false && GameManager.gameManager._gameData.IsTutorialClear)
        {
            GameManager.gameManager._savePageData.IsTutorialClear0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsCWDoorOpened_M_C10 == false && GameManager.gameManager._gameData.IsCWDoorOpened_M_C1)
        {
            GameManager.gameManager._savePageData.IsCWDoorOpened_M_C10 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsPlanetSelectMission0 == false && GameManager.gameManager._gameData.IsPlanetSelectMission)
        {
            GameManager.gameManager._savePageData.IsPlanetSelectMission0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsPhotoMissionFinish0 == false && GameManager.gameManager._gameData.IsPhotoMissionFinish)
        {
            GameManager.gameManager._savePageData.IsPhotoMissionFinish0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsCompleteFindLivingKey0 == false && GameManager.gameManager._gameData.IsCompleteFindLivingKey)
        {
            GameManager.gameManager._savePageData.IsCompleteFindLivingKey0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsCompleteFindEngineKey0 == false && GameManager.gameManager._gameData.IsCompleteFindEngineKey)
        {
            GameManager.gameManager._savePageData.IsCompleteFindEngineKey0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsSmartFarmOpen_T_C20 == false && GameManager.gameManager._gameData.IsSmartFarmOpen_T_C2)
        {
            GameManager.gameManager._savePageData.IsSmartFarmOpen_T_C20 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsHealthMachineFixed_T_C20 == false && GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2)
        {
            GameManager.gameManager._savePageData.IsHealthMachineFixed_T_C20 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsDummyDataReport0 == false && GameManager.gameManager._gameData.IsDummyDataReport)
        {
            GameManager.gameManager._savePageData.IsDummyDataReport0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsInputNormalMeteor1_T_C20 == false && GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2)
        {
            GameManager.gameManager._savePageData.IsInputNormalMeteor1_T_C20 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsCompletePretendDead0 == false && GameManager.gameManager._gameData.IsCompletePretendDead)
        {
            GameManager.gameManager._savePageData.IsCompletePretendDead0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsKnowUsingSObj0 == false && GameManager.gameManager._gameData.IsKnowUsingSObj)
        {
            GameManager.gameManager._savePageData.IsKnowUsingSObj0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsFindDrugDone_T_C20 == false && GameManager.gameManager._gameData.IsFindDrugDone_T_C2)
        {
            GameManager.gameManager._savePageData.IsFindDrugDone_T_C20 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsCompleteOpenEngineRoom0 == false && GameManager.gameManager._gameData.IsCompleteOpenEngineRoom)
        {
            GameManager.gameManager._savePageData.IsCompleteOpenEngineRoom0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsCompleteOpenLivingRoom0 == false && GameManager.gameManager._gameData.IsCompleteOpenLivingRoom)
        {
            GameManager.gameManager._savePageData.IsCompleteOpenLivingRoom0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsFuelabsorberFixed_E_E10 == false && GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1)
        {
            GameManager.gameManager._savePageData.IsFuelabsorberFixed_E_E10 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsTrashDoorBTFixed_L_L10 == false && GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L1)
        {
            GameManager.gameManager._savePageData.IsTrashDoorBTFixed_L_L10 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsTabletUnlock0 == false && GameManager.gameManager._gameData.IsTabletUnlock)
        {
            GameManager.gameManager._savePageData.IsTabletUnlock0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsAIVSMissionFinish0 == false && GameManager.gameManager._gameData.IsAIVSMissionFinish)
        {
            GameManager.gameManager._savePageData.IsAIVSMissionFinish0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsFakeHealthData_Tablet0 == false && GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            GameManager.gameManager._savePageData.IsFakeHealthData_Tablet0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsTabletDestory0 == false && GameManager.gameManager._gameData.IsTabletDestory)
        {
            GameManager.gameManager._savePageData.IsTabletDestory0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsFakeCoordinateData_Tablet0 == false && GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet)
        {
            GameManager.gameManager._savePageData.IsFakeCoordinateData_Tablet0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsFakeCoordinateDatafile_Tablet0 == false && GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._savePageData.IsFakeCoordinateDatafile_Tablet0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsAIDown_M_C1C30 == false && GameManager.gameManager._gameData.IsAIDown_M_C1C3)
        {
            GameManager.gameManager._savePageData.IsAIDown_M_C1C30 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsRevisioncomplaint0 == false && GameManager.gameManager._gameData.IsRevisioncomplaint)
        {
            GameManager.gameManager._savePageData.IsRevisioncomplaint0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }
        if (GameManager.gameManager._savePageData.IsFakePlanetSelectMission0 == false && GameManager.gameManager._gameData.IsFakePlanetSelectMission)
        {
            GameManager.gameManager._savePageData.IsFakePlanetSelectMission0 = true;
            SaveSystem.SaveCollectPage(GameManager.gameManager._savePageData, "ProjectNoah_SavePageData");
        }

    }

}
