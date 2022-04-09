using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public GameData _gameData;

    /* 1ȸ�� �ӹ� ( �ѹ� ������ �ٽ� ���� ) */
    //GamaData �� ����
    //public bool IsAI_M_C1 = false; / /�׻� AI Ȱ��ȭ
    //public bool IsCockpitDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����
    //public bool IsHealthMachineFixedT_C2 = false; // ���������� ���� ���� �ӹ� ���� ����
    //public bool IsSmartFarmOpen_T_C2 = false; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����
    public bool IsTrashDoorFixed_L_L1 = false; //��Ȱ���� ��ġ�� �ӹ�
    public bool IsFuelabsorberFixed_E_E1 = false; //������ ��ġ�� �ӹ�, �ر��ؾ� ���� ���� �ӹ� ���� ����

    //������ ī��Ű�� ����ִ� ī������ �ı�
    public bool IsDisappearPack_M_C2 = false; 
    // ������ �ر�
    public bool IsOpenCabinetDoor_M_C2 = false;
    public bool IsFindRubbe_M_C2 = false;
    public bool IsEngineDoorFix_M_C2 = false;
    public bool IsEngineRoomOpen_M_C2 = false;

    /* ���� �ӹ� ( ���� �ð��� ������ �ٽ� false �� �ٲ� �ٽ� �ؾ��� ) */
    public bool IsAIDogHealthReport = false; // ���� üũ ����
    public bool IsSmartFarmMissionDone = false; // ����Ʈ�� ����


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
//    //    Debug.Log("ü��: " + Hp);
//    //    //Debug.Log("isPush : " + isPush);
//    //}
//}