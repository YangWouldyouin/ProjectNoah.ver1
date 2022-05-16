using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingController : MonoBehaviour
{
    public InGameTime inGameTime;

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
            //특별 운석 보고 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동

        }

        if (GameManager.gameManager._gameData.IsMakeForestEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 1;
            //생태계구축엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
        }

        if (GameManager.gameManager._gameData.IsReportCancleCount >= 3)
        {
            GameManager.gameManager._gameData.IsDefyMissionEnd = true;
            Debug.Log("Game Over");

            GameManager.gameManager._gameData.EndingNum = 2;
            //명령 불복종 엔딩
            // 스탯, 취소 리포트 개수 리셋
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            // 리포트 게임 엔딩씬으로 이동
            // 게임 오버
        }

        if (GameManager.gameManager._gameData.IsDisqualifiedEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 3;
            //인재부족 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

        if (GameManager.gameManager._gameData.IsDiscardNoahEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 4;
            //실험체 폐기 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 5;
            //당신이 구한 하나 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

        if (GameManager.gameManager._gameData.IsSaveAllEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 6;
            //당신이 구한 전부 엔딩, 진엔딩, 고발O
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
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

    public void SavePageManager()
    {
        if(GameManager.gameManager._gameData.IsDisqualifiedEnd0 == false && GameManager.gameManager._gameData.IsDisqualifiedEnd)
        {
            GameManager.gameManager._gameData.IsDisqualifiedEnd0 = true;
        }
        if (GameManager.gameManager._gameData.IsEatBadPotato0 == false && GameManager.gameManager._gameData.IsEatBadPotato)
        {
            GameManager.gameManager._gameData.IsEatBadPotato0 = true;
        }
        if (GameManager.gameManager._gameData.IsMakeForestEnd0 == false && GameManager.gameManager._gameData.IsMakeForestEnd)
        {
            GameManager.gameManager._gameData.IsMakeForestEnd0 = true;
        }
        if (GameManager.gameManager._gameData.IsManagerAbilityLack0 == false && GameManager.gameManager._gameData.IsManagerAbilityLack)
        {
            GameManager.gameManager._gameData.IsManagerAbilityLack0 = true;
        }
        if (GameManager.gameManager._gameData.IsInputImportantMeteorEnd0 == false && GameManager.gameManager._gameData.IsInputImportantMeteorEnd)
        {
            GameManager.gameManager._gameData.IsInputImportantMeteorEnd0 = true;
        }
        if (GameManager.gameManager._gameData.IsDiscardNoahEnd0 == false && GameManager.gameManager._gameData.IsDiscardNoahEnd)
        {
            GameManager.gameManager._gameData.IsDiscardNoahEnd0 = true;
        }
        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd0 == false && GameManager.gameManager._gameData.IsSaveOnlyOneEnd)
        {
            GameManager.gameManager._gameData.IsSaveOnlyOneEnd0 = true;
        }
        if (GameManager.gameManager._gameData.IsSaveAllEnd0 == false && GameManager.gameManager._gameData.IsSaveAllEnd)
        {
            GameManager.gameManager._gameData.IsSaveAllEnd0 = true;
        }
        if (GameManager.gameManager._gameData.IsDefyMissionEnd0 == false && GameManager.gameManager._gameData.IsDefyMissionEnd)
        {
            GameManager.gameManager._gameData.IsDefyMissionEnd0 = true;
        }


        if (GameManager.gameManager._gameData.IsTutorialClear0 == false && GameManager.gameManager._gameData.IsTutorialClear)
        {
            GameManager.gameManager._gameData.IsTutorialClear0 = true;
        }
        if (GameManager.gameManager._gameData.IsCWDoorOpened_M_C10 == false && GameManager.gameManager._gameData.IsCWDoorOpened_M_C1)
        {
            GameManager.gameManager._gameData.IsCWDoorOpened_M_C10 = true;
        }
        if (GameManager.gameManager._gameData.IsPhotoMissionFinish0 == false && GameManager.gameManager._gameData.IsPhotoMissionFinish)
        {
            GameManager.gameManager._gameData.IsPhotoMissionFinish0 = true;
        }
        if (GameManager.gameManager._gameData.IsCompleteFindLivingKey0 == false && GameManager.gameManager._gameData.IsCompleteFindLivingKey)
        {
            GameManager.gameManager._gameData.IsCompleteFindLivingKey0 = true;
        }
        if (GameManager.gameManager._gameData.IsCompleteFindEngineKey0 == false && GameManager.gameManager._gameData.IsCompleteFindEngineKey)
        {
            GameManager.gameManager._gameData.IsCompleteFindEngineKey0 = true;
        }
        if (GameManager.gameManager._gameData.IsSmartFarmOpen_T_C20 == false && GameManager.gameManager._gameData.IsSmartFarmOpen_T_C2)
        {
            GameManager.gameManager._gameData.IsSmartFarmOpen_T_C20 = true;
        }
        if (GameManager.gameManager._gameData.IsHealthMachineFixed_T_C20 == false && GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2)
        {
            GameManager.gameManager._gameData.IsHealthMachineFixed_T_C20 = true;
        }
        if (GameManager.gameManager._gameData.IsDummyDataReport0 == false && GameManager.gameManager._gameData.IsDummyDataReport)
        {
            GameManager.gameManager._gameData.IsDummyDataReport0 = true;
        }
        if (GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C20 == false && GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2)
        {
            GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C20 = true;
        }
        if (GameManager.gameManager._gameData.IsCompletePretendDead0 == false && GameManager.gameManager._gameData.IsCompletePretendDead)
        {
            GameManager.gameManager._gameData.IsCompletePretendDead0 = true;
        }
        if (GameManager.gameManager._gameData.IsKnowUsingSObj0 == false && GameManager.gameManager._gameData.IsKnowUsingSObj)
        {
            GameManager.gameManager._gameData.IsKnowUsingSObj0 = true;
        }
        if (GameManager.gameManager._gameData.IsFindDrugDone_T_C20 == false && GameManager.gameManager._gameData.IsFindDrugDone_T_C2)
        {
            GameManager.gameManager._gameData.IsFindDrugDone_T_C20 = true;
        }
        if (GameManager.gameManager._gameData.IsCompleteOpenEngineRoom0 == false && GameManager.gameManager._gameData.IsCompleteOpenEngineRoom)
        {
            GameManager.gameManager._gameData.IsCompleteOpenEngineRoom0 = true;
        }
        if (GameManager.gameManager._gameData.IsCompleteOpenLivingRoom0 == false && GameManager.gameManager._gameData.IsCompleteOpenLivingRoom)
        {
            GameManager.gameManager._gameData.IsCompleteOpenLivingRoom0 = true;
        }
        if (GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E10 == false && GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1)
        {
            GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E10 = true;
        }
        if (GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L10 == false && GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L1)
        {
            GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L10 = true;
        }
        if (GameManager.gameManager._gameData.IsTabletUnlock0 == false && GameManager.gameManager._gameData.IsTabletUnlock)
        {
            GameManager.gameManager._gameData.IsTabletUnlock0 = true;
        }
        if (GameManager.gameManager._gameData.IsAIVSMissionFinish0 == false && GameManager.gameManager._gameData.IsAIVSMissionFinish)
        {
            GameManager.gameManager._gameData.IsAIVSMissionFinish0 = true;
        }
        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet0 == false && GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            GameManager.gameManager._gameData.IsFakeHealthData_Tablet0 = true;
        }
        if (GameManager.gameManager._gameData.IsTabletDestory0 == false && GameManager.gameManager._gameData.IsTabletDestory)
        {
            GameManager.gameManager._gameData.IsTabletDestory0 = true;
        }
        if (GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet0 == false && GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet)
        {
            GameManager.gameManager._gameData.IsFakeCoordinateData_Tablet0 = true;
        }
        if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet0 == false && GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet0 = true;
        }
        if (GameManager.gameManager._gameData.IsAIDown_M_C1C30 == false && GameManager.gameManager._gameData.IsAIDown_M_C1C3)
        {
            GameManager.gameManager._gameData.IsAIDown_M_C1C30 = true;
        }
        if (GameManager.gameManager._gameData.IsRevisioncomplaint0 == false && GameManager.gameManager._gameData.IsRevisioncomplaint)
        {
            GameManager.gameManager._gameData.IsRevisioncomplaint0 = true;
        }

    }

}
