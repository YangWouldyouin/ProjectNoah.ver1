using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int statNum = 10;
    //�ӹ� �����ϱ� ��� ī��Ʈ, 3�� �̻� ����ϱ� ������ ���� ����
    public int IsReportCancleCount = 0;
    //AI ��� �ӹ� ī��Ʈ, 2 �̻� �� �� �º� �˵� ��ǥ �ر�
    public int IsAIVSMissionCount = 0;

    public int EndingNum;

    [Header("<������ ���� ���̵�����>")]
    public int IsFakefatigue = 91; //�����Ƿε�
    public int IsFakeStrength = 87; //����ü��
    public int IsFakeThirst = 84; //���̸񸶸�
    public int IsFakeHunger = 88; //���̹����

    [Header("<������ ���� ���� ������>")]
    public int IsRealfatigue; //�Ƿε�
    public int IsRealStrength; //ü��
    public int IsRealThirst; //�񸶸�
    public int IsRealHunger; //�����

    public int IscurrentHealthData; //������ǻ�Ϳ��� ����ϴ� ���� ��ġ

    [Header("<�ӹ� ���� ���� (���ϸ�Ͽ� ������ �ƴ���)>")]
    public bool S_IsAIAwake_M_C1; // �׻� AI Ȱ��ȭ  
    public bool S_IsCWDoorOpened_M_C1; // �׻� �����ǿ��� �������� �̵� ����
    public bool S_IsHealthMachineFixed_T_C2; // ���������� ���� ���� �ӹ� ���� ���� 
    public bool[] ActiveMissionList = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public bool[] EndMissionList = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };


    [Header("<1ȸ�� �ӹ�>")]
    public bool IsAIAwake_M_C1; // �׻� AI Ȱ��ȭ  
    public bool IsPipeFound_M_C1; // �����ǿ��� ������ ã������ ���� ���̴� ���� �α�
    public bool IsCWDoorOpened_M_C1; // �׻� �����ǿ��� �������� �̵� ����
    
    public bool IsHealthMachineFixed_T_C2; // ���������� ���� ���� �ӹ� ���� ����   
    public bool IsSmartFarmOpen_T_C2; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����
    
    public bool IsWEDoorOpened_M_C2; // �׻� ������������ ������ �̵� ����

    public bool IsWLDoorHalfOpened_M_C2; // �׻� ������������ ��Ȱ���� �̵� ����. ��, ���� �ݸ� ����ä��
    public bool IsWLDoorOpened_M_C2; // �׻� ������������ ��Ȱ���� �̵� ����

    public bool IsAllDoorOpened; //��� ������ �ر� �Ϸ�Ǿ�����


    [Header("<���� ���� üũ>")]
    public bool IsFirstEnterWorking; //�������� ���� ���� Ȯ��
    public bool IsFirstEnterEngine; //������ ���� ���� Ȯ��
    public bool IsFirstEnterLiving; //��Ȱ���� ���� ���� Ȯ��
    public bool IsFirstExitTablet; //�簢���� ó������ �������� ��

    public bool IsFirstNoticeEnd; //������üũ ���� üũ

    public bool afterFirstTalk; //���� �Ϸ� �� ����ũ�� AI�� ��ȭ���� ��� ���� ��
    public bool afterNewsTalk; //���� �˾� & ���ֺ���� ���� ��ȭ�� ���� ��


    [Header("<����Ž�� ����>")]
    public bool IsCheckDrug; //������ ���� Ȯ��
    public bool IsDetox; //���� �ص�


    [Header("<���ѹ��� & AI �ٿ� ����>")]
    public bool IsFirstUsingStrangeObj; //������ ���� ����غ� �� �ִ���
    public bool IsHide; //��ȭ��(��ȸ��) ��� �� ���ڽ� ȿ��
    public bool IsAlert; //���ڽ� ��尡 �ƴѵ� Ĩ ���� ���νý��ۿ� ���� ��
    public bool IsAIDown; //����Ĩ ���� �� AI �ٿ� ��

    public bool IsFuelabsorberFixed_E_E1; //������ ��ġ�� �ӹ�, �ر��ؾ� ���� ���� �ӹ� ���� ����

    public int HealthMachineCancelCount = 5;

    public bool IsEngineDoorFix_M_C2; // ������ �� ���ƴ���

    [Header("<� ���� ����>")]
    public bool IsIsReallySmellDone_T_C2; // � ������ �þҴ���
    public bool IsReportImportantMeteor_T_C2; // �߿� ��� �м��⿡ �־���

    [Header("<����Ʈ�� ����>")]
    public bool IsIronDisappear_T_C2; // ����Ʈ�� ������ �� ��������

    public bool IsOutTroubleLine2_T_C2; // ����Ʈ�� ������ ���� ���´���
    public bool IsSmartFarmFix_T_C2;//����Ʈ�� ������ �Ϸ�


    [Header("<� ����>")]
    public bool IsBiteimportantMeteor_T_C2; // �߿� ��� ��������
    public bool IsBiteNormalMeteor1_T_C2; // �Ϲ� ��� ��������

    public bool IsAnswerInBeaker1_M_C2; // ��Ŀ 1�� �´� ��� �־�����
    public bool IsAnswerInBeaker2_M_C2; // ��Ŀ 2�� �´� ��� �־�����

    public bool IsAnswerBeakerColorChange1_M_C2; // ���� �� ������ ��Ŀ 1 ���� ��ȭ
    public bool IsWrongBeakerColorChange1_M_C2; // Ʋ�� �� ������ ��Ŀ 1 ���� ��ȭ
    public bool IsNoNeed1BeakerColorChange1_M_C2; // �ʿ���� ��1 ������ ��Ŀ 1 ���� ��ȭ
    public bool IsNoNeed2BeakerColorChange1_M_C2; // �ʿ���� ��2 ������ ��Ŀ 1 ���� ��ȭ

    public bool IsAnswerBeakerColorChange2_M_C2; // ���� �� ������ ��Ŀ 2 ���� ��ȭ
    public bool IsWrongBeakerColorChange2_M_C2; // Ʋ�� �� ������ ��Ŀ 2 ���� ��ȭ
    public bool IsNoNeed1BeakerColorChange2_M_C2; // �ʿ���� ��1 ������ ��Ŀ 2 ���� ��ȭ
    public bool IsNoNeed2BeakerColorChange2_M_C2; // �ʿ���� ��2 ������ ��Ŀ 2 ���� ��ȭ


    [Header("<�º� UI ����>")]
    public bool Is_Tablet_WirelessOn; //�º� ������� on/offüũ
    public bool IsFakeHealthData_Tablet; //�º� ������ ���� ���� ������
    public bool IsFakeCoordinateData_Tablet; //�º�������ǥ�ر� �Ǵ�
    public bool IsFakeCoordinateDatafile_Tablet; //�º�������ǥ�ٿ�ε� �Ǵ�
    public bool IsDontFakeCoordinateDatafile_Tablet; //�º� ������ǥ�ٿ�ε��Ʈ �Ұ�

    [Header("<������ǻ�� UI ����>")]
    public bool Is_MainComputer_WirelessOn; //������ǻ�� ���Ʈ�� on/offüũ
    public bool IsFinalBusinessReport_MC; //���� ���� ���� ������ �ر� �Ǵ�
    public bool IsFinalBusinessReportFile_MC; //���� ���� ���� ������ �ٿ�ε�


    [Header("<���νý��� UI ����>")]
    public bool Is_MainSystem_WirelessOn; //���νý��� ���Ʈ�� on/offüũ
    public bool IsCanConnect_C_MS; //���νý��� ������� ���� üũ 
    public bool IsReturnOfTheEarth;//�˵� ���� ����

    [Header("<�º� �ر� ����>")]
    public bool IsFullChargeTablet; // �º� ��������  
    public bool IsNoBoxes; // ������ �ڽ� ������
    public bool IsTabletMoved; // �º� AI �̰��� �������� ����� ��
    public bool IsTabletDestory; // �º� �ı�


    [Header("<���� ����>")]
    public bool[] sweetPotatoEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false }; //���� ���� �� Ȯ��
    public bool Pot1InPotato; // ����1�� ���� ������ Ȯ��
    public bool Pot2InPotato; // ����2�� ���� ������ Ȯ��
    public bool Pot3InPotato; // ����3�� ���� ������ Ȯ��
    public bool IsCanSeePotato1; // ������ ��Ÿ��ä�� ����
    public bool IsCanSeePotato2; // ������ ��Ÿ��ä�� ����
    public bool IsCanSeePotato3; // ������ ��Ÿ��ä�� ����

    public bool Pot1InBadPotato; // ����1�� ���� ���� ������ Ȯ��
    public bool Pot2InBadPotato; // ����1�� ���� ���� ������ Ȯ��
    public bool Pot3InBadPotato; // ����1�� ���� ���� ������ Ȯ��

    public bool Pot1InHealthyPotato; // ����1�� �ǰ��� ���� ������ Ȯ��
    public bool Pot2InHealthyPotato; // ����1�� �ǰ��� ���� ������ Ȯ��
    public bool Pot3InHealthyPotato; // ����1�� �ǰ��� ���� ������ Ȯ��

    public bool[] BadFoodEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };     //���� ���� �� Ȯ��
    public bool[] GoodFoodEat = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };     //���� ���� �� Ȯ��



    [Header("<������� ��>")]
    public bool IsMeteorCollectClose; //� ������ �� �������� Ȯ��
    public bool IsMeteorCollectOpen; // � ������ �� ���ȴ��� Ȯ��

    [Header("<��Ȱ���� ���� �ر�>")]
    public bool IsLivingRoomDollOut; // ��Ȱ���� ���� �����ִ� ���� ����

    [Header("<å�� ������>")]
    public bool IsUpTable1; //���̺� 1�� �� �ö󰬴��� Ȯ��
    public bool IsUpTable2; //���̺� 2�� �� �ö󰬴��� Ȯ��


    /*�߿� ���� �º��� AI���� ������ ���*/
    // public bool IsTabletDestroyed; // �º� AI���� ���� �ı���


    [Header("<�������>")]
    public bool IsStartCollectMeteorites; // � ���� �ӹ� ����
    public bool IsStartPretendDead; // ����ô �ϱ� �ӹ� ����
    public bool IsStartFIndDrug; //����ã�� �ӹ� ����
    public bool IsFindStrangeObj; //�̻��ѹ���(��ȭ��) ���� �þҴ���
    public bool IsStartToReady; //����� ���� �غ� ���� (��ݵ� �ӹ� 2�� �̻� ���� ��/���� ���� ��ũ��Ʈ �ʿ�)
    public bool IsStartOrbitChange; //'AI �ٿ�' Ȥ�� '���� ô �ϱ�' ���� �Ϸ� �� �ڵ� ���� (ä���� ����ô�ϱ� ���� �Ϸ� ������ �ش� ���� �߰����ֶ�~)


    [Header("<����Ϸ�>")]
    public bool IsBasicTuto; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ�
    public bool IsMiddleTuto; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ� Ȯ��
    public bool StopIDConsoleSpeak; // ID �ܼ� ���ϴ� �� �ݺ� ���ϰ� ���ַ���

    public bool IsRealMiddleTuto; //ä�� Ʃ�丮�� �� ��Ʈ ��¥ �Ϸ�
    public bool IsEndTuto; //ä�� Ʃ�丮�� ���� �Ϸ�
    [Header("< Ʃ�丮�� �Ϸ� ����>")]
    public bool IsTutorialClear; //������ Ʃ�丮�� �Ϸ�

    public bool IsCompleteSmartFarmOpen; // ����Ʈ�� ���� ���� �Ϸ�
    public bool IsCompleteFindEngineKey; // ������ ī��Ű ã�� ���� �Ϸ�
    public bool IsCompleteOpenEngineRoom; // ������ ���� ���� �Ϸ�
    public bool IsInputNormalMeteor1_T_C2; // �Ϲ� �1�� �����⿡ �ֱ� �Ϸ� (���߿� ������ �� �������� �ٲ�߰ڴ�)
    public bool IsCompletePretendDead; // ����ô ���� �Ϸ�
    public bool IsTabletUnlock; // �º� ��ݿ��� (�رݿϷ�)
    public bool IsPlanetInsertChip_In; // �ùٸ� ����Ĩ �Ⱦ� ��¥ �༺ ������ ��ȯ
    public bool IsAIDown_M_C1C3; //AI�ٿ� ���� �Ϸ�
    public bool IsKnowUsingSObj; //��ȭ�� ��� ����� �˾Ƴ´���
    public bool IsFindDrugDone_T_C2; //���� ���� Ȥ�� �ص��ϸ� �ٽ� ����
    public bool IsCompleteFindLivingKey; // ��Ȱ���� ī��Ű ã�� �Ϸ�
    public bool IsCompleteHalfOpenLivingRoom; // ��Ȱ���� �� �ݸ� ���� �Ϸ�

    public bool IsDummyDataReport; //���̵����ͺ��� �Ϸ�
    public bool IsAIVSMissionFinish; //��ݵ� ���� �ر�
    public bool IsPhotoMissionFinish; //������� ���� �Ϸ�
    public bool IsRevisioncomplaint; //����ϱ�

    public bool IsCompleteOpenLivingRoom; // ��Ȱ���� �� ���� ���� �Ϸ�
    public bool IsTrashDoorBTFixed_L_L1; //��Ȱ���� ��ġ��

    public int randomUPic;


    [Header("<����>")]
    public bool IsInputImportantMeteorEnd; // Ư�� � ���� ����
    public bool IsMakeForestEnd; // ���°� ���� ����
    public bool IsDefyMissionEnd; // ��� �Һ��� ����: �����ϱ� ���� Ƚ�� �ź�
    public bool IsDisqualifiedEnd; // ������� ����: Ʃ�丮�� ����
    public bool IsDiscardNoahEnd; // ����ü ��� ����: AI ����� �ð� �ȿ� �˵� ���� ����
    public bool IsSaveOnlyOneEnd; // ����� ���� �ϳ� ����: ��� ����, ��� X
    public bool IsSaveAllEnd; // ����� ���� ���� ����: �� ����, ��� O

    public bool IsManagerAbilityLack; //��������������

    public bool IsSuddenDeath; //������ üũ: ���� 0 ����, ���� ���� ���� ����

    public bool IsEatBadPotato;//���� ���� ���� ����

    [Header("<�ӹ�����/�� ����>")]
    public bool IsWirelessUI_firstEnter; //���� ������ ���� ���� üũ
    public bool IsWirelessMCTabletCheck; //������/�º� ���� ���� �Ϸ� ���� üũ

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


    [Header("<��Ÿ>")]
    public bool IsPhotoTime; //������� �ӹ� ���� üũ, �系 �������� ���� ���� Ȯ�� �� �ٽ� false
    public bool IsAIReportMissionTime; //����üũ��� �ӹ� ���� üũ 
}




//public GameData(bool _IsAIAwake, bool _IsCWDoorOpened)
//{
//    IsAIAwake = _IsAIAwake;
//    IsCWDoorOpened = _IsCWDoorOpened;
//}