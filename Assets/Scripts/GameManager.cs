using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public GameData _gameData;
    public SavePageData _savePageData;

    /* 1ȸ�� �ӹ� ( �ѹ� ������ �ٽ� ���� ) */
    public bool IsTrashDoorFixed_L_L1 = false; //��Ȱ���� ��ġ�� �ӹ�
    // public bool IsFuelabsorberFixed_E_E1 = false; //������ ��ġ�� �ӹ�, �ر��ؾ� ���� ���� �ӹ� ���� ����

    //������ ī��Ű�� ����ִ� ī������ �ı�
    //public bool IsDisappearPack_M_C2 = false; 
    // ������ �ر�
    //public bool IsOpenCabinetDoor_M_C2 = false;
    //public bool IsFindRubbe_M_C2 = false;
    //public bool IsEngineDoorFix_M_C2 = false;
    //public bool IsEngineRoomOpen_M_C2 = false;

    //� ����
    public bool IsCanMeteorGet = false;
    public bool IsSmellDone = false;
    public bool IsCollectMeteor = false;

    //�м��⿡ � � �� �־����� ã��
    public bool InputNormalMeteor1 = false;
    public bool InputNormalMeteor2 = false;
    public bool InputNormalMeteor3 = false;
    public bool InputNormalMeteor4 = false;
    public bool InputImportantMeteor1 = false;

    //���� ��ȯ ���� ���� üũ
    public bool IsyesImportantMeteor = false;


    /* ���� �ӹ� ( ���� �ð��� ������ �ٽ� false �� �ٲ� �ٽ� �ؾ��� ) */
    public bool IsAIDogHealthReport = false; // ���� üũ ����
    public bool IsSmartFarmMissionDone = false; // ����Ʈ�� ����


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
//    //    Debug.Log("ü��: " + Hp);
//    //    //Debug.Log("isPush : " + isPush);
//    //}
//}