using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameManager : MonoBehaviour
{
    // 엔딩 제외하고 변수 초기화

    // 콜라이더
    // 아웃라인

    /* 각 공간의 물건 초기화 */
    public PortableObjectData controlData;
    public PortableObjectData workData;
    public PortableObjectData engineData;
    public PortableObjectData livingData;

    /* 스탯, 날짜, 물기 밀기 초기화 */
    public InGameTime inGameTime;
    public PlayerEquipment equipment;

    public ObjectData[] objectList;

    //public ObjectData[] controlObjectList;
    //public ObjectData[] workObjectList;
    //public ObjectData[] engineObjectList;
    //public ObjectData[] livingObjectList;

    /* 업무공간 오브젝트데이터 초기화 */
    public ObjectData healthMachinePartData; // 상태체크기계
    public ObjectData engineDoorData; // 업무공간-엔진실 문 
    public ObjectData engineKeyData; // 업무공간-엔진실 카드키

    /* 생활공간 오브젝트데이터 초기화 */
    public ObjectData trashBodyData;
    public ObjectData trashPartData;
    private void Start()
    {
        //ClearObjectData();
        RestIngameData();
        ResetPortableObject();
        ResetWorkRoomObjectData();
        ResetLivingRoomObjectData();
    }

    void RestIngameData()
    {
        inGameTime.days = 0;
        inGameTime.hours = 0;
        inGameTime.timer = 0;

        inGameTime.IsTimerStarted = false;
        inGameTime.maxTimer = 0;

        inGameTime.IsNoahOutlineTurnOn = false;
        inGameTime.outlineTimer = 0;

        inGameTime.missionTimer = 0;

        inGameTime.statNum = 10;
        inGameTime.statTimer = 0;

        equipment.biteObjectName = "";
        equipment.pushObjectName = "";
    }

    void ResetPortableObject()
    {
        for(int i=0; i<59; i++)
        {
            controlData.IsObjectActiveList[i] = false;
            workData.IsObjectActiveList[i] = false;
            engineData.IsObjectActiveList[i] = false;
            livingData.IsObjectActiveList[i] = false;
        }

        /* 조종실 초기화 */
        controlData.IsObjectActiveList[0] = true;
        controlData.IsObjectActiveList[1] = true;

        /* 엔진실 초기화 */
        engineData.IsObjectActiveList[3] = true;
        engineData.IsObjectActiveList[5] = true;
        engineData.IsObjectActiveList[6] = true;
        engineData.IsObjectActiveList[8] = true;
        engineData.IsObjectActiveList[9] = true;
        engineData.IsObjectActiveList[39] = true;
        engineData.IsObjectActiveList[40] = true;
        engineData.IsObjectActiveList[58] = true;

        /* 생활공간 초기화 */
        livingData.IsObjectActiveList[2] = true;
        livingData.IsObjectActiveList[7] = true;
        livingData.IsObjectActiveList[46] = true;
        livingData.IsObjectActiveList[47] = true;
        livingData.IsObjectActiveList[48] = true;
        livingData.IsObjectActiveList[49] = true;

        /* 업무공간 초기화 */
        workData.IsObjectActiveList[4] = true;
        workData.IsObjectActiveList[10] = true;
        workData.IsObjectActiveList[11] = true;
        workData.IsObjectActiveList[12] = true;
        workData.IsObjectActiveList[13] = true;
        workData.IsObjectActiveList[14] = true;

        for (int k = 24; k < 32; k++)
        {
            workData.IsObjectActiveList[k] = true;
        }

        for (int q = 0; q < 5; q++)
        {
            workData.IsObjectActiveList[q+33] = true;
            workData.IsObjectActiveList[q+41] = true;
        }

        for(int j= 50; j<58; j++)
        {
            workData.IsObjectActiveList[j] = true;
        }
    }



    void ResetWorkRoomObjectData()
    {
        healthMachinePartData.IsNotInteractable = false; // 상태체크기계 부품
        engineDoorData.IsNotInteractable = false; // 엔진실 문
        engineKeyData.IsNotInteractable = false; // 엔진실 카드키
        engineKeyData.IsBite= false; 
    }

    void ResetLivingRoomObjectData()
    {
        trashBodyData.IsNotInteractable = false; // 냄새 기계
        trashPartData.IsNotInteractable = false; // 냄새 부품
    }

    public void ClearObjectData()
    {
        for(int i=0; i<objectList.Length; i++)
        {
            objectList[i].IsBark = false;
            objectList[i].IsPushOrPress = false;
            objectList[i].IsSniff = false;
            objectList[i].IsBite = false;
            objectList[i].IsSmash = false;
            objectList[i].IsUpDown = false;
            objectList[i].IsEaten = false;
            objectList[i].IsInsert = false;
            objectList[i].IsEaten = false;
            objectList[i].IsObserve = false;
            objectList[i].IsCollision = false;

            objectList[i].IsClicked = false;
            objectList[i].IsCenterButtonChanged = false;
            objectList[i].IsCenterButtonDisabled = false;
            objectList[i].IsCenterPlusButtonDisabled = false;
            objectList[i].IsNotInteractable = false;
        }
    }


    public  void ResetTutorialData()
    {

    }

    public void ResetControlData()
    {
        objectList[0].IsNotInteractable = true; // AI 버튼

        objectList[1].IsNotInteractable = true; // 조종실 문
        objectList[1].IsCenterButtonDisabled= true;

        objectList[5].IsNotInteractable = true; // 포트 문

        objectList[7].IsNotInteractable = true; // 포트 문

        objectList[9].IsNotInteractable = true; // 포트 문

        // 드러그백, 엔진문 셋액티브
    }


}
