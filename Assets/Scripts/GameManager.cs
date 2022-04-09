using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public GameData _gameData;

    /* 1회성 임무 ( 한번 끝내면 다시 안함 ) */
    //GamaData 로 옯김
    //public bool IsAI_M_C1 = false; / /항상 AI 활성화
    //public bool IsCockpitDoorOpened_M_C1 = false; // 항상 조종실에서 업무공간 이동 가능
    //public bool IsHealthMachineFixedT_C2 = false; // 정기적으로 상태 측정 임무 수행 가능
    //public bool IsSmartFarmOpen_T_C2 = false; // 항상 스마트팜 열려있고, 정기적으로 스마트팜 임무 수행 가능
    public bool IsTrashDoorFixed_L_L1 = false; //생활공간 고치기 임무
    public bool IsFuelabsorberFixed_E_E1 = false; //엔진실 고치기 임무, 해금해야 연료 돌발 임무 수행 가능

    //엔진실 카드키가 들어있는 카드팩이 파괴
    public bool IsDisappearPack_M_C2 = false; 
    // 엔진실 해금
    public bool IsOpenCabinetDoor_M_C2 = false;
    public bool IsFindRubbe_M_C2 = false;
    public bool IsEngineDoorFix_M_C2 = false;
    public bool IsEngineRoomOpen_M_C2 = false;

    /* 정기 임무 ( 일정 시간이 지나면 다시 false 로 바뀌어서 다시 해야함 ) */
    public bool IsAIDogHealthReport = false; // 상태 체크 업무
    public bool IsSmartFarmMissionDone = false; // 스마트팜 업무


    private void Awake()
    {
        gameManager = this;
        _gameData = SaveSystem.Load("save_001");

        if (_gameData == null)
        {
            GameData gameData = new GameData();
            SaveSystem.Save(gameData, "save_001");

            _gameData = gameData;
        }
    }
}




//private void Update()
//{

//    //if (Input.GetKeyDown(KeyCode.Q))
//    //{
//    //    Debug.Log("체력: " + Hp);
//    //    //Debug.Log("isPush : " + isPush);
//    //}
//}