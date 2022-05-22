using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public GameData _gameData;
    public SavePageData _savePageData;

    /* 1회성 임무 ( 한번 끝내면 다시 안함 ) */
    public bool IsTrashDoorFixed_L_L1 = false; //생활공간 고치기 임무
    // public bool IsFuelabsorberFixed_E_E1 = false; //엔진실 고치기 임무, 해금해야 연료 돌발 임무 수행 가능

    //엔진실 카드키가 들어있는 카드팩이 파괴
    //public bool IsDisappearPack_M_C2 = false; 
    // 엔진실 해금
    //public bool IsOpenCabinetDoor_M_C2 = false;
    //public bool IsFindRubbe_M_C2 = false;
    //public bool IsEngineDoorFix_M_C2 = false;
    //public bool IsEngineRoomOpen_M_C2 = false;

    //운석 수집
    public bool IsCanMeteorGet = false;
    public bool IsSmellDone = false;
    public bool IsCollectMeteor = false;

    //분석기에 운석 어떤 거 넣었는지 찾기
    public bool InputNormalMeteor1 = false;
    public bool InputNormalMeteor2 = false;
    public bool InputNormalMeteor3 = false;
    public bool InputNormalMeteor4 = false;
    public bool InputImportantMeteor1 = false;

    //지구 귀환 엔딩 조건 체크
    public bool IsyesImportantMeteor = false;


    /* 정기 임무 ( 일정 시간이 지나면 다시 false 로 바뀌어서 다시 해야함 ) */
    public bool IsAIDogHealthReport = false; // 상태 체크 업무
    public bool IsSmartFarmMissionDone = false; // 스마트팜 업무


    private void Awake()
    {
        gameManager = this;
        _gameData = SaveSystem.Load("save_001");
        _savePageData = SaveSystem.LoadCollectPage("ProjectNoah_SavePageData");

        if (_gameData == null)
        {
            GameData gameData = new GameData();
            SaveSystem.Save(gameData, "save_001");

            _gameData = gameData;
        }

        if(_savePageData==null)
        {
            SavePageData savePageData = new SavePageData();
            SaveSystem.SaveCollectPage(savePageData, "ProjectNoah_SavePageData");

            _savePageData = savePageData;
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