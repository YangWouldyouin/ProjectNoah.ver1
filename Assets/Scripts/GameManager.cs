using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public GameData _gameData;
    public SavePageData _savePageData;

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