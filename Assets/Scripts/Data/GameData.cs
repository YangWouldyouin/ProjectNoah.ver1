using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
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

    public bool IsFindDrugDone_T_C2; //마약 보고 혹은 해독하면 다시 안함
    public bool IsSmoke_T_C3; //소화기(일회용) 사용 시 연기 발생

    public bool IsFuelabsorberFixed_E_E1; //엔진실 고치기 임무, 해금해야 연료 돌발 임무 수행 가능

    public int HealthMachineCancelCount = 5;

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