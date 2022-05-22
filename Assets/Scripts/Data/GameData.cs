using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int statNum = 10;
    //임무 보고하기 취소 카운트, 3번 이상 취소하기 누르면 게임 오버
    public int IsReportCancleCount = 0;
    //AI 상반 임무 카운트, 2 이상 될 시 태블릿 궤도 좌표 해금
    public int IsAIVSMissionCount = 0;

    public int EndingNum;

    [Header("<강아지 상태 더미데이터>")]
    public int IsFakefatigue = 91; //더미피로도
    public int IsFakeStrength = 87; //더미체력
    public int IsFakeThirst = 84; //더미목마름
    public int IsFakeHunger = 88; //더미배고픔

    [Header("<강아지 현재 상태 데이터>")]
    public int IsRealfatigue; //피로도
    public int IsRealStrength; //체력
    public int IsRealThirst; //목마름
    public int IsRealHunger; //배고픔

    public int IscurrentHealthData; //메인컴퓨터에서 계산하는 스탯 수치

    [Header("<임무 시작 여부 (할일목록에 들어갔는지 아닌지)>")]
    public bool S_IsAIAwake_M_C1; // 항상 AI 활성화  
    public bool S_IsCWDoorOpened_M_C1; // 항상 조종실에서 업무공간 이동 가능
    public bool S_IsHealthMachineFixed_T_C2; // 정기적으로 상태 측정 임무 수행 가능 
    public bool[] ActiveMissionList = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public bool[] EndMissionList = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };


    [Header("<1회성 임무>")]
    public bool IsAIAwake_M_C1; // 항상 AI 활성화  
    public bool IsPipeFound_M_C1; // 조종실에서 파이프 찾았으면 이제 보이는 곳에 두기
    public bool IsCWDoorOpened_M_C1; // 항상 조종실에서 업무공간 이동 가능
    
    public bool IsHealthMachineFixed_T_C2; // 정기적으로 상태 측정 임무 수행 가능   
    public bool IsSmartFarmOpen_T_C2; // 항상 스마트팜 열려있고, 정기적으로 스마트팜 임무 수행 가능
    
    public bool IsWEDoorOpened_M_C2; // 항상 업무공간에서 엔진실 이동 가능

    public bool IsWLDoorHalfOpened_M_C2; // 항상 업무공간에서 생활공간 이동 가능. 단, 문이 반만 열린채로
    public bool IsWLDoorOpened_M_C2; // 항상 업무공간에서 생활공간 이동 가능

    public bool IsAllDoorOpened; //모든 공간이 해금 완료되었는지


    [Header("<대사용 최초 체크>")]
    public bool IsFirstEnterWorking; //업무공간 최초 진입 확인
    public bool IsFirstEnterEngine; //엔진실 최초 진입 확인
    public bool IsFirstEnterLiving; //생활공간 최초 진입 확인
    public bool IsFirstExitTablet; //사각지대 처음으로 빠져나올 때

    public bool IsFirstNoticeEnd; //진엔딩체크 조건 체크

    public bool afterFirstTalk; //퍼즐 완료 후 마이크와 AI의 대화까지 모두 끝난 후
    public bool afterNewsTalk; //뉴스 팝업 & 우주비행사 관련 대화가 끝난 후


    [Header("<마약탐지 퍼즐>")]
    public bool IsCheckDrug; //마약인 것을 확인
    public bool IsDetox; //마약 해독


    [Header("<상한물건 & AI 다운 퍼즐>")]
    public bool IsFirstUsingStrangeObj; //수상한 물건 사용해본 적 있는지
    public bool IsHide; //소화기(일회용) 사용 시 스텔스 효과
    public bool IsAlert; //스텔스 모드가 아닌데 칩 물고 메인시스템에 접근 시
    public bool IsAIDown; //교란칩 꽂을 시 AI 다운 됨

    public bool IsFuelabsorberFixed_E_E1; //엔진실 고치기 임무, 해금해야 연료 돌발 임무 수행 가능

    public int HealthMachineCancelCount = 5;

    public bool IsEngineDoorFix_M_C2; // 엔진실 문 고쳤는지

    [Header("<운석 수집 퍼즐>")]
    public bool IsIsReallySmellDone_T_C2; // 운석 냄새를 맡았는지
    public bool IsReportImportantMeteor_T_C2; // 중요 운석을 분석기에 넣었다

    [Header("<스마트팜 퍼즐>")]
    public bool IsIronDisappear_T_C2; // 스마트팜 망가진 문 열었는지

    public bool IsOutTroubleLine2_T_C2; // 스마트팜 망가진 선을 꺼냈는지
    public bool IsSmartFarmFix_T_C2;//스마트팜 수리만 완료


    [Header("<운석 퍼즐>")]
    public bool IsBiteimportantMeteor_T_C2; // 중요 운석을 물었는지
    public bool IsBiteNormalMeteor1_T_C2; // 일반 운석을 물었는지

    public bool IsAnswerInBeaker1_M_C2; // 비커 1에 맞는 운석을 넣었는지
    public bool IsAnswerInBeaker2_M_C2; // 비커 2에 맞는 운석을 넣었는지

    public bool IsAnswerBeakerColorChange1_M_C2; // 정답 약 때문에 비커 1 색상 변화
    public bool IsWrongBeakerColorChange1_M_C2; // 틀린 약 때문에 비커 1 색상 변화
    public bool IsNoNeed1BeakerColorChange1_M_C2; // 필요없는 약1 때문에 비커 1 색상 변화
    public bool IsNoNeed2BeakerColorChange1_M_C2; // 필요없는 약2 때문에 비커 1 색상 변화

    public bool IsAnswerBeakerColorChange2_M_C2; // 정답 약 때문에 비커 2 색상 변화
    public bool IsWrongBeakerColorChange2_M_C2; // 틀린 약 때문에 비커 2 색상 변화
    public bool IsNoNeed1BeakerColorChange2_M_C2; // 필요없는 약1 때문에 비커 2 색상 변화
    public bool IsNoNeed2BeakerColorChange2_M_C2; // 필요없는 약2 때문에 비커 2 색상 변화


    [Header("<태블릿 UI 관련>")]
    public bool Is_Tablet_WirelessOn; //태블릿 블루투스 on/off체크
    public bool IsFakeHealthData_Tablet; //태블릿 강아지 더미 상태 데이터
    public bool IsFakeCoordinateData_Tablet; //태블릿거짓좌표해금 판단
    public bool IsFakeCoordinateDatafile_Tablet; //태블릿거짓좌표다운로드 판단
    public bool IsDontFakeCoordinateDatafile_Tablet; //태블릿 거짓좌표다운로드루트 불가

    [Header("<메인컴퓨터 UI 관련>")]
    public bool Is_MainComputer_WirelessOn; //메인컴퓨터 블루트스 on/off체크
    public bool IsFinalBusinessReport_MC; //업무 보고 파일 최종본 해금 판단
    public bool IsFinalBusinessReportFile_MC; //업무 보고 파일 최종본 다운로드


    [Header("<메인시스템 UI 관련>")]
    public bool Is_MainSystem_WirelessOn; //메인시스템 블루트스 on/off체크
    public bool IsCanConnect_C_MS; //메인시스템 블루투스 영역 체크 
    public bool IsReturnOfTheEarth;//궤도 변경 성공

    [Header("<태블릿 해금 퍼즐>")]
    public bool IsFullChargeTablet; // 태블릿 충전여부  
    public bool IsNoBoxes; // 엔진실 박스 없어짐
    public bool IsTabletMoved; // 태블릿 AI 미감지 구역에서 벗어났을 때
    public bool IsTabletDestory; // 태블릿 파괴


    [Header("<고구마 관련>")]
    public bool[] sweetPotatoEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false }; //고구마 먹은 거 확인
    public bool Pot1InPotato; // 배양기1에 고구마 심은거 확인
    public bool Pot2InPotato; // 배양기2에 고구마 심은거 확인
    public bool Pot3InPotato; // 배양기3에 고구마 심은거 확인
    public bool IsCanSeePotato1; // 고구마가 나타낸채로 저장
    public bool IsCanSeePotato2; // 고구마가 나타낸채로 저장
    public bool IsCanSeePotato3; // 고구마가 나타낸채로 저장

    public bool Pot1InBadPotato; // 배양기1에 상한 고구마 심은거 확인
    public bool Pot2InBadPotato; // 배양기1에 상한 고구마 심은거 확인
    public bool Pot3InBadPotato; // 배양기1에 상한 고구마 심은거 확인

    public bool Pot1InHealthyPotato; // 배양기1에 건강한 고구마 심은거 확인
    public bool Pot2InHealthyPotato; // 배양기1에 건강한 고구마 심은거 확인
    public bool Pot3InHealthyPotato; // 배양기1에 건강한 고구마 심은거 확인

    public bool[] BadFoodEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };     //음식 먹은 거 확인
    public bool[] GoodFoodEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };     //음식 먹은 거 확인



    [Header("<운석수집기 문>")]
    public bool IsMeteorCollectClose; //운석 수집기 문 닫혔는지 확인
    public bool IsMeteorCollectOpen; // 운석 수집기 문 열렸는지 확인

    [Header("<생활공간 인형 해금>")]
    public bool IsLivingRoomDollOut; // 생활공간 문에 끼어있던 인형 꺼냄

    [Header("<책상 오르기>")]
    public bool IsUpTable1; //테이블 1에 잘 올라갔는지 확인
    public bool IsUpTable2; //테이블 2에 잘 올라갔는지 확인


    /*중요 구간 태블릿을 AI에게 들켰을 경우*/
    // public bool IsTabletDestroyed; // 태블릿 AI에게 들켜 파괴됨


    [Header("<퍼즐시작>")]
    public bool IsStartCollectMeteorites; // 운석 수집 임무 시작
    public bool IsStartPretendDead; // 죽은척 하기 임무 시작
    public bool IsStartFIndDrug; //마약찾기 임무 시작
    public bool IsFindStrangeObj; //이상한물건(소화기) 냄새 맡았는지
    public bool IsStartToReady; //고발을 위한 준비 시작 (상반된 임무 2개 이상 수행 시/별도 관리 스크립트 필요)
    public bool IsStartOrbitChange; //'AI 다운' 혹은 '죽은 척 하기' 퍼즐 완료 시 자동 시작 (채현아 죽은척하기 퍼즐 완료 시점에 해당 변수 추가해주랑~)


    [Header("<퍼즐완료>")]
    public bool IsBasicTuto; //튜토리얼 앞 파트 퍼즐 완료
    public bool IsMiddleTuto; //튜토리얼 앞 파트 퍼즐 완료 확인
    public bool StopIDConsoleSpeak; // ID 콘솔 말하는 거 반복 안하게 해주려고

    public bool IsRealMiddleTuto; //채현 튜토리얼 앞 파트 진짜 완료
    public bool IsEndTuto; //채현 튜토리얼 퍼즐 완료
    [Header("< 튜토리얼 완료 여부>")]
    public bool IsTutorialClear; //찐찐찐 튜토리얼 완료

    public bool IsCompleteSmartFarmOpen; // 스마트팜 오픈 퍼즐 완료
    public bool IsCompleteFindEngineKey; // 엔진실 카드키 찾기 퍼즐 완료
    public bool IsCompleteOpenEngineRoom; // 엔진실 열기 퍼즐 완료
    public bool IsInputNormalMeteor1_T_C2; // 일반 운석1을 수집기에 넣기 완료 (나중에 보고한 거 기준으로 바꿔야겠다)
    public bool IsCompletePretendDead; // 죽은척 퍼즐 완료
    public bool IsTabletUnlock; // 태블릿 잠금여부 (해금완료)
    public bool IsPlanetInsertChip_In; // 올바른 교란칩 꽂아 가짜 행성 데이터 변환
    public bool IsAIDown_M_C1C3; //AI다운 퍼즐 완료
    public bool IsKnowUsingSObj; //소화기 사용 방법을 알아냈는지
    public bool IsFindDrugDone_T_C2; //마약 보고 혹은 해독하면 다시 안함
    public bool IsCompleteFindLivingKey; // 생활공간 카드키 찾기 완료
    public bool IsCompleteHalfOpenLivingRoom; // 생활공간 문 반만 오픈 완료

    public bool IsDummyDataReport; //더미데이터보고 완료
    public bool IsAIVSMissionFinish; //상반된 일지 해금
    public bool IsPhotoMissionFinish; //사진찍기 보고 완료
    public bool IsRevisioncomplaint; //고발하기

    public bool IsCompleteOpenLivingRoom; // 생활공간 문 완전 오픈 완료
    public bool IsTrashDoorBTFixed_L_L1; //생활공간 고치기

    public int randomUPic;


    [Header("<엔딩>")]
    public bool IsInputImportantMeteorEnd; // 특별 운석 보고 엔딩
    public bool IsMakeForestEnd; // 생태계 구축 엔딩
    public bool IsDefyMissionEnd; // 명령 불복종 엔딩: 보고하기 일정 횟수 거부
    public bool IsDisqualifiedEnd; // 인재부족 엔딩: 튜토리얼 실패
    public bool IsDiscardNoahEnd; // 실험체 폐기 엔딩: AI 재부팅 시간 안에 궤도 변경 실패
    public bool IsSaveOnlyOneEnd; // 당신이 구한 하나 엔딩: 노멀 엔딩, 고발 X
    public bool IsSaveAllEnd; // 당신이 구한 전부 엔딩: 진 엔딩, 고발 O

    public bool IsManagerAbilityLack; //관리자자질부족

    public bool IsSuddenDeath; //돌연사 체크: 스탯 0 엔딩, 상한 고구마 섭취 엔딩

    public bool IsEatBadPotato;//상한 고구마 섭취 엔딩

    [Header("<임무시작/끝 시점>")]
    public bool IsWirelessUI_firstEnter; //블투 페이지 진입 시점 체크
    public bool IsWirelessMCTabletCheck; //메인컴/태블릿 블투 연결 완료 시점 체크

    //public bool IsComTabletUploadClear;

    //    //엔진실 카드키가 들어있는 카드팩이 파괴
    //    public bool IsDisappearPack_M_C2;
    //    // 엔진실 해금
    //    public bool IsOpenCabinetDoor_M_C2;
    //    public bool IsFindRubbe_M_C2 ;
    //    public bool IsEngineDoorFix_M_C2;
    //    public bool IsEngineRoomOpen_M_C2;

    /* 정기 임무 ( 일정 시간이 지나면 다시 false 로 바뀌어서 다시 해야함 ) */

    //    // 상태 체크 업무
    //    public bool IsHealthMachineDone = false;
    //    // 스마트팜 업무
    //    public bool IsSmartFarmMissionDone = false; 


    [Header("<기타>")]
    public bool IsPhotoTime; //사진찍기 임무 진행 체크, 사내 뉴스에서 찍은 사진 확인 후 다시 false
    public bool IsAIReportMissionTime; //상태체크기계 임무 진행 체크 
}




//public GameData(bool _IsAIAwake, bool _IsCWDoorOpened)
//{
//    IsAIAwake = _IsAIAwake;
//    IsCWDoorOpened = _IsCWDoorOpened;
//}