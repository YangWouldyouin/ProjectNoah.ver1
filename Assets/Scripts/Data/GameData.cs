using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    /* 1ȸ�� �ӹ� */   
    public bool IsAIAwake_M_C1; // �׻� AI Ȱ��ȭ  
    public bool IsCWDoorOpened_M_C1; // �׻� �����ǿ��� �������� �̵� ����
    
    public bool IsHealthMachineFixed_T_C2; // ���������� ���� ���� �ӹ� ���� ����   
    public bool IsSmartFarmOpen_T_C2; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����

    public bool IsWEDoorOpened_M_C2; // �׻� ������������ ������ �̵� ����

    public bool IsFindDrugDone_T_C2; //���� ���� Ȥ�� �ص��ϸ� �ٽ� ����
    public bool IsSmoke_T_C3; //��ȭ��(��ȸ��) ��� �� ���� �߻�


    //public bool IsInputDrug_M_C2;
    //public bool IsInputAnswerDrug1_M_C2;
    //public bool IsInputAnswerDrug2_M_C2;
    //public bool IsCompletionDeadDrug_M_C2;
    public bool IsInputMeteor1_M_C2; //���� ��� ��Ŀ1�� �־��ٸ�
    public bool IsInputMeteor2_M_C2; // ���� ��� ��Ŀ 2�� �־��ٸ�
    public bool IsNoahDead_M_C2; // ��ư� ���� ô�ϴ� ���� ���̴��� Ȯ��
    public bool IsAnswerBeakerColorChange1_M_C2; //���� ���� ��Ŀ 1�� �ξ����� Ȯ��
    public bool IsAnswerBeakerColorChange2_M_C2; //���� ���� ��Ŀ 2�� �ξ����� Ȯ��
    public bool IsWrongBeakerColorChange1_M_C2; //�߸��� ���� ��Ŀ 1�� �ξ����� Ȯ��
    public bool IsWrongBeakerColorChange2_M_C2; //�߸��� ���� ��Ŀ 2�� �ξ����� Ȯ��
    public bool IsNoNeed1BeakerColorChange1_M_C2; //�ʿ���� ��1�� ��Ŀ 1�� �ξ����� Ȯ��
    public bool IsNoNeed1BeakerColorChange2_M_C2;//�ʿ���� ��1�� ��Ŀ 2�� �ξ����� Ȯ��
    public bool IsNoNeed2BeakerColorChange1_M_C2; //�ʿ���� ��2�� ��Ŀ 1�� �ξ����� Ȯ��
    public bool IsNoNeed2BeakerColorChange2_M_C2;//�ʿ���� ��2�� ��Ŀ 2�� �ξ����� Ȯ��

    public bool IsBiteWrongMeteor1_M_C2; //�߸��� � 1�� ��� ������� �ٱ����� ���´��� Ȯ�� 
    public bool IsBiteWrongMeteor2_M_C2; //�߸��� � 1�� ��� ������� �ٱ����� ���´��� Ȯ��
    public bool IsBiteWrongMeteor3_M_C2; //�߸��� � 1�� ��� ������� �ٱ����� ���´��� Ȯ��
    public bool IsBiteWrongMeteor4_M_C2; //�߸��� � 1�� ��� ������� �ٱ����� ���´��� Ȯ��
    public bool IsBiteAnswerMeteor_M_C2; //�߸��� � 1�� ��� ������� �ٱ����� ���´��� Ȯ��

    public bool IsFuelabsorberFixed_E_E1; //������ ��ġ�� �ӹ�, �ر��ؾ� ���� ���� �ӹ� ���� ����

    public int HealthMachineCancelCount = 5;

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