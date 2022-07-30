using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SLManager2 : MonoBehaviour
{
    GameData character = new GameData();
    SavePageData savePageData = new SavePageData();

    void Start()
    {
        /*dialogManager = dialog.GetComponent<DialogManager>();

        GameData intialGameData = SaveSystem.Load("save_001");


        *//*업무공간&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/


        /*상태체크기계고치기*//*
        HealthMachineFixData_Collider = HealthMachineFixData.GetComponent<BoxCollider>();

        *//*스마트팜 오픈*//*
        LineHome2_Collider = LineHome2.GetComponent<BoxCollider>();
        IronPlateDoor_Collider = IronPlateDoor.GetComponent<BoxCollider>();

        *//*엔진실 오픈*//*
        BrokenArea_Collider = BrokenArea.GetComponent<BoxCollider>();
        EngineDoor_Collider = EngineDoor.GetComponent<BoxCollider>();
        InsertCardPad_Collider = InsertCardPad.GetComponent<BoxCollider>();

        *//* 생활공간 오픈 *//*
        CardKey_WL_Collider = CardKey_WL.GetComponent<BoxCollider>();
        LivingSpace_CardKeyMachine_W_Collider = CardKey_WL.GetComponent<BoxCollider>();

        *//*죽은척하기*//*
        Beaker1_Collider = Beaker1.GetComponent<BoxCollider>();
        Beaker2_Collider = Beaker2.GetComponent<BoxCollider>();
        CylinderAnswer_Collider = CylinderAnswer.GetComponent<BoxCollider>();
        CylinderWrong_Collider = CylinderWrong.GetComponent<BoxCollider>();
        CylinderNoNeed1_Collider = CylinderNoNeed1.GetComponent<BoxCollider>();
        CylinderNoNeed2_Collider = CylinderNoNeed2.GetComponent<BoxCollider>();
        MeteorBoxButton1_Collider = MeteorBoxButton1.GetComponent<BoxCollider>();
        MeteorBoxButton2_Collider = MeteorBoxButton2.GetComponent<BoxCollider>();
        MeteorBoxButton3_Collider = MeteorBoxButton3.GetComponent<BoxCollider>();
        MeteorBoxButton4_Collider = MeteorBoxButton4.GetComponent<BoxCollider>();
        MeteorBoxButton5_Collider = MeteorBoxButton5.GetComponent<BoxCollider>();
        MeteoritesStorage1_Collider = MeteoritesStorage1.GetComponent<BoxCollider>();
        MeteoritesStorage2_Collider = MeteoritesStorage2.GetComponent<BoxCollider>();
        MeteoritesStorage3_Collider = MeteoritesStorage3.GetComponent<BoxCollider>();
        MeteoritesStorage4_Collider = MeteoritesStorage4.GetComponent<BoxCollider>();
        MeteoritesStorage5_Collider = MeteoritesStorage5.GetComponent<BoxCollider>();

        //마약 탐지
        smellRangeAreaCol = smellRangeArea.GetComponent<MeshCollider>();
        canSmellAreaCol = canSmellArea.GetComponent<MeshCollider>();
        drugBagCol = drugBag.GetComponent<BoxCollider>();
        drugCol = drug.GetComponent<BoxCollider>();
        SDrugCol = SDrug.GetComponent<BoxCollider>();
        insert01Col = insert01.GetComponent<BoxCollider>();
        insert02Col = insert02.GetComponent<BoxCollider>();



        *//*생활공간&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

        TDBT_BodyOutline = TDBT_fixBody.GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();


        *//*엔진실&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

        //없음




        *//*조종실&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

        //없음*/
    }

    // 업데이트 문만 주석 해제하면 됨
    void Update()
    {
        /* 게임 엔딩 리셋 */
        if (Input.GetKeyDown(KeyCode.R))
        {
            savePageData.IsDisqualifiedEnd0 = false;
            savePageData.IsEatBadPotato0 = false;
            savePageData.IsMakeForestEnd0 = false;
            savePageData.IsManagerAbilityLack0 = false;
            savePageData.IsInputImportantMeteorEnd0 = false;
            savePageData.IsDiscardNoahEnd0 = false;
            savePageData.IsSaveOnlyOneEnd0 = false;
            savePageData.IsSaveAllEnd0 = false;
            savePageData.IsDefyMissionEnd0 = false;


            savePageData.IsTutorialClear0 = false;
            savePageData.IsCWDoorOpened_M_C10 = false;
            savePageData.IsPhotoMissionFinish0 = false;
            savePageData.IsCompleteFindLivingKey0 = false;
            savePageData.IsCompleteFindEngineKey0 = false;
            savePageData.IsSmartFarmOpen_T_C20 = false;
            savePageData.IsHealthMachineFixed_T_C20 = false;
            savePageData.IsDummyDataReport0 = false;
            savePageData.IsInputNormalMeteor1_T_C20 = false;
            savePageData.IsCompletePretendDead0 = false;

            savePageData.IsKnowUsingSObj0 = false;
            savePageData.IsFindDrugDone_T_C20 = false;
            savePageData.IsCompleteOpenEngineRoom0 = false;
            savePageData.IsCompleteOpenLivingRoom0 = false;
            savePageData.IsFuelabsorberFixed_E_E10 = false;
            savePageData.IsTrashDoorBTFixed_L_L10 = false;
            savePageData.IsTabletUnlock0 = false;
            savePageData.IsAIVSMissionFinish0 = false;
            savePageData.IsFakeHealthData_Tablet0 = false;
            savePageData.IsTabletDestory0 = false;

            savePageData.IsFakeCoordinateData_Tablet0 = false;
            savePageData.IsFakeCoordinateDatafile_Tablet0 = false;
            savePageData.IsAIDown_M_C1C30 = false;
            savePageData.IsRevisioncomplaint0 = false;

            Debug.Log("엔딩 리셋 성공");
            SaveSystem.SaveCollectPage(savePageData, "ProjectNoah_SavePageData");
        }

        /* 게임 리셋 */
        if (Input.GetKeyDown("l"))
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

            //정기임무 관련
            character.IsRM_HealthDataReportbool = false;
            character.IsRM_HM_MissionScriptCheck = false;
            character.IsRM_P_MissionScriptCheck = false;
            character.IsRM_PR_TimeCheck = false;
            character.IsRM_PR_MissionScriptCheck = false;
            character.IsPhotoCheck = false;


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
                character.CompleteMissionList[i] = false;
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

            //나중에 추가된 변수들
            character.IsInputImportantMeteor1_T_C2 = false;
            character.IsAIAfterMissionComplete = false;
            character.IsAIAfterMissionComplete = false;
            character.IsFinishedEatingSweetPotatoes = false;
            character.IsOutTroubleLine2_T_C2 = false;
            character.IsIronDisappear_T_C2 = false;
            character.IsBrokenPotatoDoor = false;
            character.IsNoticePotatoBody = false;
            character.IsMeteorCollectMachineOpen = false;
            character.IsAnalyticalMachineOpen = false;

            // 스팀 엔딩 리셋
            for (int endingIndex = 0; endingIndex < 7; endingIndex++)
            {
                character.steamEndingCheck[endingIndex] = false;
            }

            SaveSystem.Save(character, "save_001");
        }
    }
}




/*    [Header("<업무공간>")]
    *//*업무공간&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

    public GameObject ChangeScene;

    public GameObject dialog;
    DialogManager dialogManager;


    [Header("<상태체크기계 고치기>")]
    public GameObject HealthMachine;
    public GameObject HealthMachineFixData;

    [Header("<스마트팜 오픈>")]
    public GameObject FixedLine2; //고쳐진 줄
    public GameObject LineHome2; // 라인 홈
    public GameObject IronPlateDoor; // 스마트팜 합판 
    public GameObject TroubleLine; // 망가진 선
    public Animator smartFarmDoorAnim;



    [Header("<엔진실 카드키 찾기>")]
    public GameObject CardPack; //카드팩
    public GameObject EngineCardKey; // 엔진실 카드 키



    [Header("<엔진실 문 열기 완료>")]
    public Animator engineDoorAnim; // 문열리는 애니메이션
    public GameObject BrokenArea; // 망가진 구역
    public GameObject Conduction; // 전도체
    public GameObject EngineDoor; // 엔진실 문
    public GameObject InsertCardPad; // 카드 패드



    [Header("<생활공간 문 반만 열기 완료>")]
    public GameObject CardKey_WL; // 생활공간 카드키
    public GameObject LivingSpace_CardKeyMachine_W; // 생활공간 카드키 기계
    public Animator HalfLivingDoorAni_M; // 생활공간 문 반만 열리기
    BoxCollider CardKey_WL_Collider;
    BoxCollider LivingSpace_CardKeyMachine_W_Collider;


    [Header("<운석 수집 완료>")]
    public Animator meteorBoxAnim; //  수집기 문열리는 애니메이션
    public Animator analyticalMachineAnim; // 분석기 문열리는 애니메이션
    public GameObject ImportantMeteor; // 중요 운석
    public GameObject NormalMeteor1; // 평범한 운석1


    [Header("<죽은 척 하기 완료하면>")]
    public GameObject Beaker1;
    public GameObject Beaker2;
    public GameObject CylinderAnswer;
    public GameObject CylinderWrong;
    public GameObject CylinderNoNeed1;
    public GameObject CylinderNoNeed2;
    public GameObject MeteorBoxButton1;
    public GameObject MeteorBoxButton2;
    public GameObject MeteorBoxButton3;
    public GameObject MeteorBoxButton4;
    public GameObject MeteorBoxButton5;
    public GameObject MeteoritesStorage1;
    public GameObject MeteoritesStorage2;
    public GameObject MeteoritesStorage3;
    public GameObject MeteoritesStorage4;
    public GameObject MeteoritesStorage5;
    public GameObject WrongMeteor1;
    public GameObject WrongMeteor2;
    public GameObject WrongMeteor3;
    public GameObject WrongMeteor4;
    public GameObject AnswerMeteor;

    [Header("<마약탐지>")]
    public GameObject smellRangeArea;
    public GameObject canSmellArea;
    public GameObject drugBag;
    public GameObject drug;
    public GameObject SDrug;
    public GameObject insert01;
    public GameObject insert02;


    [Header("<추가적인것>")]
    *//*Object Data*//*
    public ObjectData MeteorButtonData_Save;
    public ObjectData MeteorCollectMachineData_Save;
    public ObjectData AnalyticalMachineData_Save;
    public ObjectData AnalyticalMachineButtonData_Save;

    *//*Outline*//*
    public Outline MeteorButtonOutline_Save;
    public Outline MeteorCollectMachineOutline_Save;
    public Outline AnalyticalMachineOutline_Save;
    public Outline AnalyticalMachineButtonOutline_Save;

    *//*BoxCollider*//*
    BoxCollider LineHome2_Collider;
    BoxCollider IronPlateDoor_Collider;

    BoxCollider BrokenArea_Collider;
    BoxCollider EngineDoor_Collider;
    BoxCollider InsertCardPad_Collider;

    BoxCollider Beaker1_Collider;
    BoxCollider Beaker2_Collider;
    BoxCollider CylinderAnswer_Collider;
    BoxCollider CylinderWrong_Collider;
    BoxCollider CylinderNoNeed1_Collider;
    BoxCollider CylinderNoNeed2_Collider;
    BoxCollider MeteorBoxButton1_Collider;
    BoxCollider MeteorBoxButton2_Collider;
    BoxCollider MeteorBoxButton3_Collider;
    BoxCollider MeteorBoxButton4_Collider;
    BoxCollider MeteorBoxButton5_Collider;
    BoxCollider MeteoritesStorage1_Collider;
    BoxCollider MeteoritesStorage2_Collider;
    BoxCollider MeteoritesStorage3_Collider;
    BoxCollider MeteoritesStorage4_Collider;
    BoxCollider MeteoritesStorage5_Collider;

    MeshCollider smellRangeAreaCol;
    MeshCollider canSmellAreaCol;
    BoxCollider drugBagCol;
    BoxCollider drugCol;
    BoxCollider SDrugCol;
    BoxCollider insert01Col;
    BoxCollider insert02Col;

    BoxCollider HealthMachineFixData_Collider;


    *//*엔진실&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


    [Header("<엔진실>")]
    // 연료 퍼즐
    public GameObject FA_fuelabsorberfixPart;
    public GameObject FA_fuelabsorberBody;
    public GameObject FA_fuelabsorber;

    // 태블릿 해금 퍼즐
    public GameObject Tablet_E;
    public GameObject Boxes_E;
    public GameObject Full_Eg_Pad_E;
    public GameObject Zero_Eg_Pad_E;

    public GameObject LoverPic_E;
    public GameObject E_AstronPic_Susan_E;
    public GameObject E_AstronPic_Mike_E;
    public GameObject E_AstronPic_Salvia_E;
    public GameObject E_AstronPic_Trelawny_E;




    *//*생활공간&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

    [Header("<생활공간>")]

    public GameObject TDBT_fixPart;
    public GameObject TDBT_fixBody;

    public ObjectData TDBT_fixPartData, TDBT_fixBodyData;
    Outline TDBT_BodyOutline, TDBT_fixPartOutline;






    *//*조종실&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


    [Header("<조종실>")]

    public Animator controlWorkDoorAnim;

    [Header("<AI다운>")]
    public GameObject chipInsert;
    public GameObject RChip;
    public GameObject WChip;

    //콜라이더
    BoxCollider chipInsertCol;
    BoxCollider RChipCol;
    BoxCollider WChipCol;
*/


/*업무공간&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/
/*상태체크기계 고치기: 이미 이건 바꾼 값임*//*
HealthMachineFixData.transform.position = new Vector3(-265.59f, -0.002026364f, 691.05f);
HealthMachineFixData.transform.rotation = Quaternion.Euler(-90, 0, 0);
HealthMachineFixData_Collider.enabled = true;

*//*스마트팜 오픈 퍼즐을 완료 하면*//*

//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
LineHome2_Collider.enabled = true;
IronPlateDoor_Collider.enabled = true;
TroubleLine.SetActive(true);
FixedLine2.SetActive(true);

//true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
smartFarmDoorAnim.SetBool("FarmDoorMoving", false);
smartFarmDoorAnim.SetBool("FarmDoorStop", false);

*//*엔진실 카드 키 찾기 퍼즐을 완료하면*//*

//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
CardPack.SetActive(false);

//  true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
EngineCardKey.SetActive(false);

*//*엔진실 열기 퍼즐을 완료하면*//*
//  true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
engineDoorAnim.SetBool("canEngineDoorOpen", false);
engineDoorAnim.SetBool("canEngineDoorEnd", false);
ChangeScene.SetActive(false);

//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
EngineCardKey.SetActive(true);
Conduction.SetActive(true);

BrokenArea_Collider.enabled = true;
EngineDoor_Collider.enabled = true;
InsertCardPad_Collider.enabled = true;


//  true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
*//* 생활공간 문 반 열기 퍼즐 완료 시 *//*
HalfLivingDoorAni_M.SetBool("HalfOpen", false); // 생활공간 문 반만 열리기
HalfLivingDoorAni_M.SetBool("HalfEnd", false);


//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
CardKey_WL_Collider.enabled = true;
LivingSpace_CardKeyMachine_W_Collider.enabled = true;

*//*운석 수집 퍼즐을 완료하면*//*
//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
meteorBoxAnim.SetBool("isMeteorBoxClose", true);
meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", true);
//  true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
meteorBoxAnim.SetBool("isMeteorBoxOpen", false);
meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", false);

//  true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
analyticalMachineAnim.SetBool("isAnalyticalMachineOpen", false);
analyticalMachineAnim.SetBool("isAnalyticalMachineOpenEnd", false);

//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
analyticalMachineAnim.SetBool("isAnalyticalMachineClose", true);
analyticalMachineAnim.SetBool("isAnalyticalMachineCloseEnd", true);

NormalMeteor1.SetActive(true);


//수동으로 바꿔야 하는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
MeteorButtonData_Save.IsNotInteractable = false;
MeteorButtonOutline_Save.OutlineWidth = 8;

MeteorCollectMachineData_Save.IsNotInteractable = true;
MeteorCollectMachineOutline_Save.OutlineWidth = 0;

AnalyticalMachineButtonData_Save.IsNotInteractable = false;
AnalyticalMachineButtonOutline_Save.OutlineWidth = 8;

AnalyticalMachineData_Save.IsNotInteractable = true;
AnalyticalMachineOutline_Save.OutlineWidth = 0;


//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
*//*엔진실 열기 퍼즐을 완료하면*//*
WrongMeteor1.SetActive(true);
WrongMeteor2.SetActive(true);
WrongMeteor3.SetActive(true);
WrongMeteor4.SetActive(true);
AnswerMeteor.SetActive(true);

Beaker1_Collider.enabled = true;
Beaker2_Collider.enabled = true;
CylinderAnswer_Collider.enabled = true;
CylinderWrong_Collider.enabled = true;
CylinderNoNeed1_Collider.enabled = true;
CylinderNoNeed2_Collider.enabled = true;
MeteorBoxButton1_Collider.enabled = true;
MeteorBoxButton2_Collider.enabled = true;
MeteorBoxButton3_Collider.enabled = true;
MeteorBoxButton4_Collider.enabled = true;
MeteorBoxButton5_Collider.enabled = true;
MeteoritesStorage1_Collider.enabled = true;
MeteoritesStorage2_Collider.enabled = true;
MeteoritesStorage3_Collider.enabled = true;
MeteoritesStorage4_Collider.enabled = true;
MeteoritesStorage5_Collider.enabled = true;

//마약 탐지 완료하면
smellRangeArea.SetActive(true);
canSmellArea.SetActive(true);
drugBag.SetActive(true);

insert01Col.enabled = true;
drugCol.enabled = true;

//수동으로 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
drug.transform.position = new Vector3(-249.0776f, 0.4852f, 669.806f);
drug.transform.rotation = Quaternion.Euler(0, 0, 90);
drug.transform.localScale = new Vector3(1f, 1f, 1f);


//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
insert02Col.enabled = true;
SDrugCol.enabled = true;

//수동으로 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
SDrug.transform.position = new Vector3(-249.0776f, 0.1652f, 669.806f);
SDrug.transform.rotation = Quaternion.Euler(0, 0, 90);



*//*생활공간&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


//수동으로 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
TDBT_fixPart.GetComponent<Rigidbody>().isKinematic = true;
TDBT_fixPart.transform.parent = null; //머가 초기화된 값인거지

TDBT_fixPart.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
TDBT_fixPart.transform.rotation = Quaternion.Euler(0, -90, 0);
TDBT_fixPart.transform.localScale = new Vector3(50f, 50.00002f, 50.00002f);

TDBT_fixPartData.IsNotInteractable = false;
TDBT_fixBodyData.IsNotInteractable = false;

TDBT_BodyOutline.OutlineWidth = 8;
TDBT_fixPartOutline.OutlineWidth = 8;




*//*엔진실&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
*//* 연료 퍼즐 *//*
FA_fuelabsorberfixPart.SetActive(true);
FA_fuelabsorberBody.SetActive(true);

//  true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
FA_fuelabsorber.SetActive(false);

//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
*//* 태블릿 해금 퍼즐 *//*
Boxes_E.SetActive(true); //상자더미

Full_Eg_Pad_E.SetActive(true); // 태블릿 충전
Zero_Eg_Pad_E.SetActive(true);


LoverPic_E.SetActive(true); // <최종> 태블릿 잠금화면 해제
E_AstronPic_Susan_E.SetActive(true);
E_AstronPic_Mike_E.SetActive(true);
E_AstronPic_Salvia_E.SetActive(true);
E_AstronPic_Trelawny_E.SetActive(true);



*//*조종실&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

//  true -> false 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
controlWorkDoorAnim.SetBool("IsDoorOpenStart", false);
controlWorkDoorAnim.SetBool("IsDoorOpened", false);
ChangeScene.SetActive(false);

//false -> true 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
chipInsertCol.enabled = true;
RChip.SetActive(false);
RChipCol.enabled = true;

//수동으로 로 바꾸는 애들 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
RChip.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
RChip.transform.position = new Vector3(-7.448f, 34.62f, -1.439f);
RChip.transform.rotation = Quaternion.Euler(90, 0, 0);

}*/

/* 저장 정보 불러옴 *//*
if (Input.GetKeyDown("l"))
{
    GameData loadData = SaveSystem.Load("save_001");
    Debug.Log(string.Format("LoadData Result => IsAIAwake : {0}, IsCWDoorOpened : {1}, IsHealthMachineFixed_T_C2 : {2}, IsSmartFarmOpen_T_C2 : {3} ", 
        loadData.IsAIAwake_M_C1, loadData.IsCWDoorOpened_M_C1, loadData.IsHealthMachineFixed_T_C2, loadData.IsSmartFarmOpen_T_C2));
}*/
