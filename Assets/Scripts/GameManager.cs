using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    /* 1ȸ�� �ӹ� ( �ѹ� ������ �ٽ� ���� ) */
    //GamaData �� ����
    //public bool IsAI_M_C1 = false; / /�׻� AI Ȱ��ȭ
    //public bool IsCockpitDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����
    //public bool IsHealthMachineFixedT_C2 = false; // ���������� ���� ���� �ӹ� ���� ����
    //public bool IsSmartFarmOpen_T_C2 = false; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����

    //������ ī��Ű�� ����ִ� ī������ �ı�
    public bool IsDisappearPack_M_C2 = false; 
    // ������ �ر�
    public bool IsOpenCabinetDoor_M_C2 = false;
    public bool IsFindRubbe_M_C2 = false;
    public bool IsEngineDoorFix_M_C2 = false;
    public bool IsEngineRoomOpen_M_C2 = false;

    /* ���� �ӹ� ( ���� �ð��� ������ �ٽ� false �� �ٲ� �ٽ� �ؾ��� ) */
    public bool IsHealthMachineDone = false; // ���� üũ ����
    public bool IsSmartFarmMissionDone = false; // ����Ʈ�� ����





    private void Awake()
    {
        gameManager = this;
    }



    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Debug.Log("ü��: " + Hp);
        //    //Debug.Log("isPush : " + isPush);
        //}
    }
}
