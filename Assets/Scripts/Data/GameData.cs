using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //임무 보고하기 취소 카운트, 2번 이상 취소하기 누르면 게임 오버
    public int IsReportCancleCount = 0;

    /* 임무 시작 여부 (할일목록에 들어갔는지 아닌지) */
    public bool S_IsAIAwake_M_C1; // 항상 AI 활성화  
    public bool S_IsCWDoorOpened_M_C1; // 항상 조종실에서 업무공간 이동 가능
    public bool S_IsHealthMachineFixed_T_C2; // 정기적으로 상태 측정 임무 수행 가능 
    public bool[] ActiveMissionList = { false, false, false, false, false };
    public bool[] EndMissionList = { false, false, false, false, false };

    /* 1회성 임무 */
    public bool IsAIAwake_M_C1; // 항상 AI 활성화  
    public bool IsCWDoorOpened_M_C1; // 항상 조종실에서 업무공간 이동 가능
    
    public bool IsHealthMachineFixed_T_C2; // 정기적으로 상태 측정 임무 수행 가능   
    public bool IsSmartFarmOpen_T_C2; // 항상 스마트팜 열려있고, 정기적으로 스마트팜 임무 수행 가능

    public bool IsWEDoorOpened_M_C2; // 항상 업무공간에서 엔진실 이동 가능

    public bool IsCheckDrug; //마약인 것을 확인
    public bool IsDetox; //마약 해독
    public bool IsFindDrugDone_T_C2; //마약 보고 혹은 해독하면 다시 안함

    public bool IsHide; //소화기(일회용) 사용 시 스텔스 효과
    public bool IsAlert; //스텔스 모드가 아닌데 칩 물고 메인시스템에 접근 시
    public bool IsAIDown; //교란칩 꽂을 시 AI 다운 됨

    public bool IsFuelabsorberFixed_E_E1; //엔진실 고치기 임무, 해금해야 연료 돌발 임무 수행 가능

    public int HealthMachineCancelCount = 5;

    public bool IsEngineDoorFix_M_C2; // 엔진실 문 고쳤는지

    public bool IsIronDisappear_T_C2; // 스마트팜 망가진 문 열었는지

    public bool IsOutTroubleLine2_T_C2; // 스마트팜 망가진 선을 꺼냈는지
    public bool IsSmartFarmFix_T_C2;//스마트팜 수리 완료

    public bool IsBiteimportantMeteor_T_C2; // 중요 운석을 물었는지
    public bool IsBiteNormalMeteor1_T_C2; // 일반 운석을 물었는지

    public bool IsAnswerInBeaker1_M_C2; // 비커 1에 맞는 운석을 넣었는지

    public bool IsAnswerBeakerColorChange1_M_C2; // 정답 약 때문에 비커 1 색상 변화
    public bool IsWrongBeakerColorChange1_M_C2; // 틀린 약 때문에 비커 1 색상 변화
    public bool IsNoNeed1BeakerColorChange1_M_C2; // 필요없는 약1 때문에 비커 1 색상 변화
    public bool IsNoNeed2BeakerColorChange1_M_C2; // 필요없는 약2 때문에 비커 1 색상 변화


    public bool Is_Tablet_WirelessOn; //태블릿 블루투스 on/off체크
    public bool IsFakeHealthData_Tablet; //태블릿 강아지 더미 상태 데이터
    public bool IsFakeCoordinateData_Tablet; //태블릿거짓좌표해금 판단
    public bool IsFakeCoordinateDatafile_Tablet; //태블릿거짓좌표다운로드 판단
    public bool IsDontFakeCoordinateDatafile_Tablet; //태블릿 거짓좌표다운로드루트 불가

    public bool Is_MainComputer_WirelessOn; //메인컴퓨터 블루트스 on/off체크
    public bool IsFinalBusinessReport_MC; //업무 보고 파일 최종본 해금 판단
    public bool IsFinalBusinessReportFile_MC; //업무 보고 파일 최종본 다운로드

    public bool Is_MainSystem_WirelessOn; //메인시스템 블루트스 on/off체크
    public bool IsCanConnect_C_MS; //메인시스템 블루투스 영역 체크 
    public bool IsReturnOfTheEarth;//궤도 변경 성공

    public bool IsPlanetInsertChip_In; // 올바른 교란칩 꽂아 가짜 행성 데이터 변환

    public bool IsTabletUnlock; // 태블릿 잠금여부

    /*퍼즐시작*/
    public bool IsStartCollectMeteorites; // 운석 수집 임무 시작
    public bool IsStartPretendDead; // 죽은척 하기 임무 시작

    /*퍼즐완료*/
    public bool IsCompleteSmartFarmOpen; // 스마트팜 오픈 퍼즐 완료
    public bool IsCompleteFindEngineKey; // 엔진실 카드키 찾기 퍼즐 완료
    public bool IsCompleteOpenEngineRoom; // 엔진실 카드키 찾기 퍼즐 완료
    public bool IsInputNormalMeteor1_T_C2; // 일반 운석1을 수집기기에 넣기 완료
    public bool IsCompletePretendDead; // 엔진실 카드키 찾기 퍼즐 완료

    public int randomUPic;

    /*엔딩*/
    public bool IsEatBadSweetPotato; // 상한 고구마 섭취 엔딩
    public bool IsInputImportantMeteor1_T_C2; // 특별 운석 보고 엔딩

    /*고구마 먹은 거 확인*/
    public bool[] sweetPotatoEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };

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
}




//public GameData(bool _IsAIAwake, bool _IsCWDoorOpened)
//{
//    IsAIAwake = _IsAIAwake;
//    IsCWDoorOpened = _IsCWDoorOpened;
//}