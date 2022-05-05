using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //�ӹ� �����ϱ� ��� ī��Ʈ, 2�� �̻� ����ϱ� ������ ���� ����
    public int IsReportCancleCount = 0;

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

    public bool IsIronDisappear_T_C2; // ����Ʈ�� ������ �� ��������

    public bool IsOutTroubleLine2_T_C2; // ����Ʈ�� ������ ���� ���´���
    public bool IsSmartFarmFix_T_C2;//����Ʈ�� ���� �Ϸ�

    public bool IsBiteimportantMeteor_T_C2; // �߿� ��� ��������
    public bool IsBiteNormalMeteor1_T_C2; // �Ϲ� ��� ��������

    public bool IsAnswerInBeaker1_M_C2; // ��Ŀ 1�� �´� ��� �־�����

    public bool IsAnswerBeakerColorChange1_M_C2; // ���� �� ������ ��Ŀ 1 ���� ��ȭ
    public bool IsWrongBeakerColorChange1_M_C2; // Ʋ�� �� ������ ��Ŀ 1 ���� ��ȭ
    public bool IsNoNeed1BeakerColorChange1_M_C2; // �ʿ���� ��1 ������ ��Ŀ 1 ���� ��ȭ
    public bool IsNoNeed2BeakerColorChange1_M_C2; // �ʿ���� ��2 ������ ��Ŀ 1 ���� ��ȭ


    public bool Is_Tablet_WirelessOn; //�º� ������� on/offüũ
    public bool IsFakeHealthData_Tablet; //�º� ������ ���� ���� ������
    public bool IsFakeCoordinateData_Tablet; //�º�������ǥ�ر� �Ǵ�
    public bool IsFakeCoordinateDatafile_Tablet; //�º�������ǥ�ٿ�ε� �Ǵ�
    public bool IsDontFakeCoordinateDatafile_Tablet; //�º� ������ǥ�ٿ�ε��Ʈ �Ұ�

    public bool Is_MainComputer_WirelessOn; //������ǻ�� ���Ʈ�� on/offüũ
    public bool IsFinalBusinessReport_MC; //���� ���� ���� ������ �ر� �Ǵ�
    public bool IsFinalBusinessReportFile_MC; //���� ���� ���� ������ �ٿ�ε�

    public bool Is_MainSystem_WirelessOn; //���νý��� ���Ʈ�� on/offüũ
    public bool IsCanConnect_C_MS; //���νý��� ������� ���� üũ 
    public bool IsReturnOfTheEarth;//�˵� ���� ����

    public bool IsPlanetInsertChip_In; // �ùٸ� ����Ĩ �Ⱦ� ��¥ �༺ ������ ��ȯ

    public bool IsTabletUnlock; // �º� ��ݿ���

    /*�������*/
    public bool IsStartCollectMeteorites; // � ���� �ӹ� ����
    public bool IsStartPretendDead; // ����ô �ϱ� �ӹ� ����

    /*����Ϸ�*/
    public bool IsCompleteSmartFarmOpen; // ����Ʈ�� ���� ���� �Ϸ�
    public bool IsCompleteFindEngineKey; // ������ ī��Ű ã�� ���� �Ϸ�
    public bool IsCompleteOpenEngineRoom; // ������ ī��Ű ã�� ���� �Ϸ�
    public bool IsInputNormalMeteor1_T_C2; // �Ϲ� �1�� ������⿡ �ֱ� �Ϸ�
    public bool IsCompletePretendDead; // ������ ī��Ű ã�� ���� �Ϸ�

    public int randomUPic;

    /*����*/
    public bool IsEatBadSweetPotato; // ���� ���� ���� ����
    public bool IsInputImportantMeteor1_T_C2; // Ư�� � ���� ����

    /*���� ���� �� Ȯ��*/
    public bool[] sweetPotatoEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    //public bool IsComTabletUploadClear;

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