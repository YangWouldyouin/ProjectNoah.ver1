using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResetGameManager : MonoBehaviour
{
    // 엔딩 제외하고 변수 초기화
    GameData character = new GameData();

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
    public ObjectData W_extinguisherData;

    public ObjectData cylinderGlassAnswerData;
    public ObjectData cylinderGlassWrongData;
    public ObjectData cylinderGlassNoNeed1Data;
    public ObjectData cylinderGlassNoNeed2Data;

    /* 생활공간 오브젝트데이터 초기화 */
    public ObjectData trashBodyData;
    public ObjectData trashPartData;
    public ObjectData L_GoodFood2Data;
    public ObjectData L_GoodFood3Data;
    public ObjectData L_BadFood2Data;
    public ObjectData L_BadFood3Data;

    /* 엔진실 오브젝트데이터 초기화 */
    public ObjectData E_extinguisherData;

    private void Start()
    {
        //ClearObjectData();

        //ResetGame();
    }

    private void Update()
    {
        OpenDoor();
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("오브젝트 리셋");
            ResetGame();

            RestIngameData();

            ResetPortableObject();

            ResetWorkRoomObjectData();
            ResetLivingRoomObjectData();
            ResetControlData();
            ResetEngineRoomObjectData();
        }
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
        inGameTime.IsNoSeeFail1 = false;
        inGameTime.IsNoSeeFail2 = false;
        inGameTime.IsPretendDeadFail1 = false;

        inGameTime.IsMissionStart = false;
        inGameTime.IsMissionClear = false;

        inGameTime.IsGoToEarthMissionStart = false;
        inGameTime.IsGoToEarthMissionClear = false;

        inGameTime.IsBeakerEatAfterStart = false;
        inGameTime.IsBeakerEatAfterClear = false;

        inGameTime.IsAIAwake = true;
        equipment.biteObjectName = "";
        equipment.pushObjectName = "";
}

    void ResetPortableObject()
    {
        for (int i = 0; i < 59; i++)
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
            workData.IsObjectActiveList[q + 33] = true;
            workData.IsObjectActiveList[q + 41] = true;
        }

        for (int j = 50; j < 58; j++)
        {
            workData.IsObjectActiveList[j] = true;
        }
#if UNITY_EDITOR
        EditorUtility.SetDirty(controlData);
        EditorUtility.SetDirty(workData);
        EditorUtility.SetDirty(engineData);
        EditorUtility.SetDirty(livingData);
#endif

    }

    void ResetWorkRoomObjectData()
    {
        healthMachinePartData.IsNotInteractable = false; // 상태체크기계 부품
        engineDoorData.IsNotInteractable = false; // 엔진실 문
        engineKeyData.IsNotInteractable = false; // 엔진실 카드키
        engineKeyData.IsBite = false;
        E_extinguisherData.IsSmash = false; // 업무공간 소화전

        cylinderGlassAnswerData.IsBite = false; // 죽은척 실린더 초기화
        cylinderGlassWrongData.IsBite = false;
        cylinderGlassNoNeed1Data.IsBite = false;
        cylinderGlassNoNeed2Data.IsBite = false;
    }

    void ResetLivingRoomObjectData()
    {
        trashBodyData.IsNotInteractable = false; // 냄새 기계
        trashPartData.IsNotInteractable = false; // 냄새 부품
        L_GoodFood2Data.IsEaten = false; //좋은음식2
        L_GoodFood3Data.IsEaten = false; //좋은음식3
        L_BadFood2Data.IsEaten = false; //좋은음식2
        L_BadFood3Data.IsEaten = false; //좋은음식3
    }

    void ResetEngineRoomObjectData()
    {
        E_extinguisherData.IsSmash = false; // 엔진실 소화전
    }

    public void ClearObjectData()
    {
        for (int i = 0; i < objectList.Length; i++)
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

    public void ResetControlData()
    {
        //objectList[0].IsNotInteractable = true; // AI 버튼

        //objectList[1].IsNotInteractable = true; // 조종실 문
        //objectList[1].IsCenterButtonDisabled = true;

        //objectList[5].IsNotInteractable = true; // 포트 문

        //objectList[7].IsNotInteractable = true; // 포트 문

        //objectList[9].IsNotInteractable = true; // 포트 문
    }


    public void ResetTutorialData()
    {

    }

    void ResetGame()
    {
        Debug.Log("리셋 성공");
        character.IsAIAwake_M_C1 = false;
        character.IsCWDoorOpened_M_C1 = false;
        character.IsHealthMachineFixed_T_C2 = false;
        character.IsSmartFarmOpen_T_C2 = false;
        character.S_IsAIAwake_M_C1 = false;
        character.IsTabletUnlock = false;
        //character.IsBasicTuto = false;
        character.IsMiddleTuto = false;


        character.statNum = 10;
        //임무 보고하기 취소 카운트, 3번 이상 취소하기 누르면 게임 오버
        character.IsReportCancleCount = 0;
        //AI 상반 임무 카운트, 2 이상 될 시 태블릿 궤도 좌표 해금
        character.IsAIVSMissionCount = 0;

        character.EndingNum = 0;

        /*강아지 상태 더미데이터*/
        character.IsFakefatigue = 91; //더미피로도
        character.IsFakeStrength = 87; //더미체력
        character.IsFakeThirst = 84; //더미목마름
        character.IsFakeHunger = 88; //더미배고픔

        /*강아지 현재 상태 데이터*/
        character.IsRealfatigue = 0; //피로도
        character.IsRealStrength = 0; //체력
        character.IsRealThirst = 0; //목마름
        character.IsRealHunger = 0; //배고픔

        character.IscurrentHealthData = 0; //메인컴퓨터에서 계산하는 스탯 수치

        /* 임무 시작 여부 (할일목록에 들어갔는지 아닌지) */
        character.S_IsAIAwake_M_C1 = false; // 항상 AI 활성화  
        character.S_IsCWDoorOpened_M_C1 = false; // 항상 조종실에서 업무공간 이동 가능
        character.S_IsHealthMachineFixed_T_C2 = false; // 정기적으로 상태 측정 임무 수행 가능 

        // 미션 리스트 초기화 
        for (int i = 0; i < 34; i++)
        {
            character.ActiveMissionList[i] = false;
            character.EndMissionList[i] = false;
        }

        /* 1회성 임무 */
        character.IsAIAwake_M_C1 = false; // 항상 AI 활성화  
        character.IsPipeFound_M_C1 = false; // 조종실에서 파이프 찾았으면 이제 보이는 곳에 두기
        character.IsCWDoorOpened_M_C1 = false; // 항상 조종실에서 업무공간 이동 가능

        character.IsHealthMachineFixed_T_C2 = false; // 정기적으로 상태 측정 임무 수행 가능   
        character.IsSmartFarmOpen_T_C2 = false; // 항상 스마트팜 열려있고, 정기적으로 스마트팜 임무 수행 가능

        character.IsWEDoorOpened_M_C2 = false; // 항상 업무공간에서 엔진실 이동 가능

        character.IsWLDoorHalfOpened_M_C2 = false; // 항상 업무공간에서 생활공간 이동 가능. 단, 문이 반만 열린채로
        character.IsWLDoorOpened_M_C2 = false; // 항상 업무공간에서 생활공간 이동 가능

        character.IsAllDoorOpened = false; //모든 공간이 해금 완료되었는지

        //대사용 최초 체크
        character.IsFirstEnterWorking = false; //업무공간 최초 진입 확인
        character.IsFirstEnterEngine = false; //엔진실 최초 진입 확인
        character.IsFirstEnterLiving = false; //생활공간 최초 진입 확인
        character.IsFirstExitTablet = false; //사각지대 처음으로 빠져나올 때

        character.IsFirstNoticeEnd = false; //진엔딩체크 조건 체크

        character.afterFirstTalk = false; //퍼즐 완료 후 마이크와 AI의 대화까지 모두 끝난 후
        character.afterNewsTalk = false; //뉴스 팝업 & 우주비행사 관련 대화가 끝난 후


        //마약탐지 퍼즐
        character.IsCheckDrug = false; //마약인 것을 확인
        character.IsDetox = false; //마약 해독


        //수상한물건 & AI 다운 퍼즐
        character.IsFirstUsingStrangeObj = false; //수상한 물건 사용해본 적 있는지
        character.IsHide = false; //소화기(일회용) 사용 시 스텔스 효과
        character.IsAlert = false; //스텔스 모드가 아닌데 칩 물고 메인시스템에 접근 시
        character.IsAIDown = false; //교란칩 꽂을 시 AI 다운 됨

        character.IsFuelabsorberFixed_E_E1 = false; //엔진실 고치기 임무, 해금해야 연료 돌발 임무 수행 가능

        character.HealthMachineCancelCount = 5;

        character.IsEngineDoorFix_M_C2 = false; // 엔진실 문 고쳤는지

        //운석 수집 퍼즐
        character.IsIsReallySmellDone_T_C2 = false; // 운석 냄새를 맡았는지
        character.IsReportImportantMeteor_T_C2 = false; // 중요 운석을 분석기에 넣었다

        // 스마트팜 퍼즐
        character.IsIronDisappear_T_C2 = false; // 스마트팜 망가진 문 열었는지

        character.IsOutTroubleLine2_T_C2 = false; // 스마트팜 망가진 선을 꺼냈는지
        character.IsSmartFarmFix_T_C2 = false;//스마트팜 수리만 완료


        // 운석 퍼즐
        character.IsBiteimportantMeteor_T_C2 = false; // 중요 운석을 물었는지
        character.IsBiteNormalMeteor1_T_C2 = false; // 일반 운석을 물었는지

        character.IsAnswerInBeaker1_M_C2 = false; // 비커 1에 맞는 운석을 넣었는지
        character.IsAnswerInBeaker2_M_C2 = false; // 비커 2에 맞는 운석을 넣었는지

        character.IsAnswerBeakerColorChange1_M_C2 = false; // 정답 약 때문에 비커 1 색상 변화
        character.IsWrongBeakerColorChange1_M_C2 = false; // 틀린 약 때문에 비커 1 색상 변화
        character.IsNoNeed1BeakerColorChange1_M_C2 = false; // 필요없는 약1 때문에 비커 1 색상 변화
        character.IsNoNeed2BeakerColorChange1_M_C2 = false; // 필요없는 약2 때문에 비커 1 색상 변화

        character.IsAnswerBeakerColorChange2_M_C2 = false; // 정답 약 때문에 비커 2 색상 변화
        character.IsWrongBeakerColorChange2_M_C2 = false; // 틀린 약 때문에 비커 2 색상 변화
        character.IsNoNeed1BeakerColorChange2_M_C2 = false; // 필요없는 약1 때문에 비커 2 색상 변화
        character.IsNoNeed2BeakerColorChange2_M_C2 = false; // 필요없는 약2 때문에 비커 2 색상 변화

        character.IsDrinkBeaker_M_C2 = false;
        character.IsAITimerStart_M_C2 = false;


        // 태블릿 UI 관련
        character.Is_Tablet_WirelessOn = false; //태블릿 블루투스 on/off체크
        character.IsFakeHealthData_Tablet = false; //태블릿 강아지 더미 상태 데이터
        character.IsFakeCoordinateData_Tablet = false; //태블릿거짓좌표해금 판단
        character.IsFakeCoordinateDatafile_Tablet = false; //태블릿거짓좌표다운로드 판단
        character.IsDontFakeCoordinateDatafile_Tablet = false; //태블릿 거짓좌표다운로드루트 불가

        // 메인컴퓨터 UI 관련
        character.Is_MainComputer_WirelessOn = false; //메인컴퓨터 블루트스 on/off체크
        character.IsFinalBusinessReport_MC = false; //업무 보고 파일 최종본 해금 판단
        character.IsFinalBusinessReportFile_MC = false; //업무 보고 파일 최종본 다운로드


        // 메인시스템 UI 관련
        character.Is_MainSystem_WirelessOn = false; //메인시스템 블루트스 on/off체크
        character.IsCanConnect_C_MS = false; //메인시스템 블루투스 영역 체크 
        character.IsReturnOfTheEarth = false;//궤도 변경 성공


        // 태블릿 해금 퍼즐
        character.IsFullChargeTablet = false; // 태블릿 충전여부  
        character.IsNoBoxes = false; // 엔진실 박스 없어짐
        character.IsTabletMoved = false; // 태블릿 AI 미감지 구역에서 벗어났을 때
        character.IsTabletDestory = false; // 태블릿 파괴

        // 음식 초기화
        for (int foodNum = 0; foodNum < 14; foodNum++)
        {
            character.sweetPotatoEat[foodNum] = false; //고구마 먹은 거 확인
            character.BadFoodEat[foodNum] = false; //나쁜음식 먹은 거 확인                                                     
            character.GoodFoodEat[foodNum] = false; //음식 먹은 거 확인
        }

        character.Pot1InPotato = false; // 배양기1에 고구마 심은거 확인
        character.Pot2InPotato = false; // 배양기2에 고구마 심은거 확인
        character.Pot3InPotato = false; // 배양기3에 고구마 심은거 확인
        character.IsCanSeePotato1 = false; // 고구마가 나타낸채로 저장
        character.IsCanSeePotato2 = false; // 고구마가 나타낸채로 저장
        character.IsCanSeePotato3 = false; // 고구마가 나타낸채로 저장

        character.Pot1InBadPotato = false; // 배양기1에 상한 고구마 심은거 확인
        character.Pot2InBadPotato = false; // 배양기1에 상한 고구마 심은거 확인
        character.Pot3InBadPotato = false; // 배양기1에 상한 고구마 심은거 확인

        character.Pot1InHealthyPotato = false; // 배양기1에 건강한 고구마 심은거 확인
        character.Pot2InHealthyPotato = false; // 배양기1에 건강한 고구마 심은거 확인
        character.Pot3InHealthyPotato = false; // 배양기1에 건강한 고구마 심은거 확인

        // 운석수집기 문
        character.IsMeteorCollectClose = false; //운석 수집기 문 닫혔는지 확인
        character.IsMeteorCollectOpen = false; // 운석 수집기 문 열렸는지 확인


        // 생활공간 인형 해금
        character.IsLivingRoomDollOut = false; // 생활공간 문에 끼어있던 인형 꺼냄


        /*중요 구간 태블릿을 AI에게 들켰을 경우*/
        // character.IsTabletDestroyed; // 태블릿 AI에게 들켜 파괴됨

        /*책상 오르기*/
        character.IsUpTable1 = false;
        character.IsUpTable2 = false;

        /*퍼즐시작*/
        character.IsStartCollectMeteorites = false; // 운석 수집 임무 시작
        character.IsStartPretendDead = false; // 죽은척 하기 임무 시작
        character.IsStartFIndDrug = false; //마약찾기 임무 시작
        character.IsFindStrangeObj = false; //이상한물건(소화기) 냄새 맡았는지
        character.IsStartToReady = false; //고발을 위한 준비 시작 (상반된 임무 2개 이상 수행 시/별도 관리 스크립트 필요)
        character.IsStartOrbitChange = false; //'AI 다운' 혹은 '죽은 척 하기' 퍼즐 완료 시 자동 시작 (채현아 죽은척하기 퍼즐 완료 시점에 해당 변수 추가해주랑~)

        /*퍼즐완료*/
        character.IsBasicTuto = false; //튜토리얼 앞 파트 퍼즐 완료
        character.IsMiddleTuto = false; //튜토리얼 앞 파트 퍼즐 완료 확인
        character.StopIDConsoleSpeak = false; // ID 콘솔 말하는 거 반복 안하게 해주려고

        character.IsRealMiddleTuto = false; //튜토리얼 앞 파트 진짜 완료
        character.IsEndTuto = false; //튜토리얼 퍼즐 완료
        character.IsTutorialClear = false; //튜토리얼 퍼즐 찐 완료

        character.IsCompleteSmartFarmOpen = false; // 스마트팜 오픈 퍼즐 완료
        character.IsCompleteFindEngineKey = false; // 엔진실 카드키 찾기 퍼즐 완료
        character.IsCompleteOpenEngineRoom = false; // 엔진실 열기 퍼즐 완료
        character.IsInputNormalMeteor1_T_C2 = false; // 일반 운석1을 수집기에 넣기 완료 (나중에 보고한 거 기준으로 바꿔야겠다)
        character.IsCompletePretendDead = false; // 죽은척 퍼즐 완료
        character.IsTabletUnlock = false; // 태블릿 잠금여부 (해금완료)
        character.IsPlanetInsertChip_In = false; // 올바른 교란칩 꽂아 가짜 행성 데이터 변환
        character.IsAIDown_M_C1C3 = false; //AI다운 퍼즐 완료
        character.IsKnowUsingSObj = false; //소화기 사용 방법을 알아냈는지
        character.IsFindDrugDone_T_C2 = false; //마약 보고 혹은 해독하면 다시 안함
        character.IsCompleteFindLivingKey = false; // 생활공간 카드키 찾기 완료
        character.IsCompleteHalfOpenLivingRoom = false; // 생활공간 문 반만 오픈 완료

        character.IsDummyDataReport = false; //더미데이터보고 완료
        character.IsAIVSMissionFinish = false; //상반된 일지 해금
        character.IsPhotoMissionFinish = false; //사진찍기 보고 완료
        character.IsRevisioncomplaint = false; //고발하기

        character.IsCompleteOpenLivingRoom = false; // 생활공간 문 완전 오픈 완료
        character.IsTrashDoorBTFixed_L_L1 = false; //생활공간 고치기

        character.randomUPic = 4;

        //엔딩: 주석처리 이유는 엔딩 페이지 체크를 위해서/
        character.IsInputImportantMeteorEnd = false; // 특별 운석 보고 엔딩
        character.IsMakeForestEnd = false; // 생태계 구축 엔딩
        character.IsDefyMissionEnd = false; // 명령 불복종 엔딩: 보고하기 일정 횟수 거부
        character.IsDisqualifiedEnd = false; // 인재부족 엔딩: 튜토리얼 실패
        character.IsDiscardNoahEnd = false; // 실험체 폐기 엔딩: AI 재부팅 시간 안에 궤도 변경 실패
        character.IsSaveOnlyOneEnd = false; // 당신이 구한 하나 엔딩: 노멀 엔딩, 고발 X
        character.IsSaveAllEnd = false; // 당신이 구한 전부 엔딩: 진 엔딩, 고발 O

        character.IsManagerAbilityLack = false; //관리자자질부족
        character.IsEatBadPotato = false;//상한 고구마 섭취 엔딩

        character.IsSuddenDeath = false; //돌연사 체크: 스탯 0 엔딩, 상한 고구마 섭취 엔딩

        character.IsWirelessUI_firstEnter = false; //블투 페이지 진입 시점 체크
        character.IsWirelessMCTabletCheck = false; //메인컴/태블릿 블투 연결 완료 시점 체크

        //나중에 추가된 것
        character.IsInputImportantMeteor1_T_C2 = false;
        character.IsAIAfterMissionComplete = false;

        SaveSystem.Save(character, "save_001");
    }

    public void ResetData()
    {
        ResetGame();

        RestIngameData();

        ResetPortableObject();

        ResetWorkRoomObjectData();
        ResetLivingRoomObjectData();
        ResetControlData();
        ResetEngineRoomObjectData();
    }

    void OpenDoor()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            character.IsAIAwake_M_C1 = true;
            character.IsCWDoorOpened_M_C1 = true;

            character.S_IsAIAwake_M_C1 = true;

            /* 임무 시작 여부 (할일목록에 들어갔는지 아닌지) */
            character.S_IsCWDoorOpened_M_C1 = true;// 항상 조종실에서 업무공간 이동 가능
            character.IsWEDoorOpened_M_C2 = true; // 항상 업무공간에서 엔진실 이동 가능
            SaveSystem.Save(character, "save_001");
        }
    }
}
