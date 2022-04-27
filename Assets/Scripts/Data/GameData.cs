using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    /* �ӹ� ���� ���� (���ϸ�Ͽ� ������ �ƴ���) */
    public bool S_IsAIAwake_M_C1; // �׻� AI Ȱ��ȭ  
    public bool S_IsCWDoorOpened_M_C1; // �׻� �����ǿ��� �������� �̵� ����
    public bool S_IsHealthMachineFixed_T_C2; // ���������� ���� ���� �ӹ� ���� ���� 
    public bool[] ActiveMissionList = { false, false, false, false, false };
    public bool[] EndMissionList = { false, false, false, false, false };

    /* 1ȸ�� �ӹ� */
    public bool IsAIAwake_M_C1; // �׻� AI Ȱ��ȭ  
    public bool IsCWDoorOpened_M_C1; // �׻� �����ǿ��� �������� �̵� ����
    
    public bool IsHealthMachineFixed_T_C2; // ���������� ���� ���� �ӹ� ���� ����   
    public bool IsSmartFarmOpen_T_C2; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����

    public bool IsWEDoorOpened_M_C2; // �׻� ������������ ������ �̵� ����

    public bool IsCheckDrug; //������ ���� Ȯ��
    public bool IsDetox; //���� �ص�
    public bool IsFindDrugDone_T_C2; //���� ���� Ȥ�� �ص��ϸ� �ٽ� ����

    public bool IsHide; //��ȭ��(��ȸ��) ��� �� ���ڽ� ȿ��
    public bool IsAlert; //���ڽ� ��尡 �ƴѵ� Ĩ ���� ���νý��ۿ� ���� ��
    public bool IsAIDown; //����Ĩ ���� �� AI �ٿ� ��

    public bool IsFuelabsorberFixed_E_E1; //������ ��ġ�� �ӹ�, �ر��ؾ� ���� ���� �ӹ� ���� ����

    public int HealthMachineCancelCount = 5;

    public bool IsEngineDoorFix_M_C2; // ������ �� ���ƴ���
    public bool IsDestroyPack_M_C2; // �� �ı��ߴ���

    //    //������ ī��Ű�� ����ִ� ī������ �ı�
    //    public bool IsDisappearPack_M_C2;
    //    // ������ �ر�
    //    public bool IsOpenCabinetDoor_M_C2;
    //    public bool IsFindRubbe_M_C2 ;
    //    public bool IsEngineDoorFix_M_C2;
    //    public bool IsEngineRoomOpen_M_C2;

    /* ���� �ӹ� ( ���� �ð��� ������ �ٽ� false �� �ٲ� �ٽ� �ؾ��� ) */

    //    // ���� üũ ����
    //    public bool IsHealthMachineDone = false;
    //    // ����Ʈ�� ����
    //    public bool IsSmartFarmMissionDone = false; 
}




//public GameData(bool _IsAIAwake, bool _IsCWDoorOpened)
//{
//    IsAIAwake = _IsAIAwake;
//    IsCWDoorOpened = _IsCWDoorOpened;
//}