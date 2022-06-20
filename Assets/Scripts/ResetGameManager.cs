using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResetGameManager : MonoBehaviour
{
    // ���� �����ϰ� ���� �ʱ�ȭ
    GameData character = new GameData();

    // �ݶ��̴�

    // �ƿ�����

    /* �� ������ ���� �ʱ�ȭ */
    public PortableObjectData controlData;
    public PortableObjectData workData;
    public PortableObjectData engineData;
    public PortableObjectData livingData;

    /* ����, ��¥, ���� �б� �ʱ�ȭ */
    public InGameTime inGameTime;
    public PlayerEquipment equipment;

    public ObjectData[] objectList;

    //public ObjectData[] controlObjectList;
    //public ObjectData[] workObjectList;
    //public ObjectData[] engineObjectList;
    //public ObjectData[] livingObjectList;

    /* �������� ������Ʈ������ �ʱ�ȭ */
    public ObjectData healthMachinePartData; // ����üũ���
    public ObjectData engineDoorData; // ��������-������ �� 
    public ObjectData engineKeyData; // ��������-������ ī��Ű
    public ObjectData W_extinguisherData;

    public ObjectData cylinderGlassAnswerData;
    public ObjectData cylinderGlassWrongData;
    public ObjectData cylinderGlassNoNeed1Data;
    public ObjectData cylinderGlassNoNeed2Data;

    /* ��Ȱ���� ������Ʈ������ �ʱ�ȭ */
    public ObjectData trashBodyData;
    public ObjectData trashPartData;
    public ObjectData L_GoodFood2Data;
    public ObjectData L_GoodFood3Data;
    public ObjectData L_BadFood2Data;
    public ObjectData L_BadFood3Data;

    /* ������ ������Ʈ������ �ʱ�ȭ */
    public ObjectData E_extinguisherData;

    private void Start()
    {
        //ClearObjectData();

        //ResetGame();
    }

    private void Update()
    {
        OpenDoor();
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("������Ʈ ����");
            ResetGame();

            RestIngameData();

            ResetPortableObject();

            ResetWorkRoomObjectData();
            ResetLivingRoomObjectData();
            ResetControlData();
            ResetEngineRoomObjectData();
        }
    }
    void RestIngameData()
    {
        inGameTime.days = 0;
        inGameTime.hours = 0;
        inGameTime.timer = 0;

        inGameTime.IsTimerStarted = false;
        inGameTime.maxTimer = 0;

        inGameTime.IsNoahOutlineTurnOn = false;
        inGameTime.outlineTimer = 0;

        inGameTime.missionTimer = 0;

        inGameTime.statNum = 10;
        inGameTime.statTimer = 0;
        inGameTime.IsNoSeeFail1 = false;
        inGameTime.IsNoSeeFail2 = false;
        inGameTime.IsPretendDeadFail1 = false;

        inGameTime.IsMissionStart = false;
        inGameTime.IsMissionClear = false;

        inGameTime.IsGoToEarthMissionStart = false;
        inGameTime.IsGoToEarthMissionClear = false;

        inGameTime.IsBeakerEatAfterStart = false;
        inGameTime.IsBeakerEatAfterClear = false;

        inGameTime.IsAIAwake = true;
        equipment.biteObjectName = "";
        equipment.pushObjectName = "";
}

    void ResetPortableObject()
    {
        for (int i = 0; i < 59; i++)
        {
            controlData.IsObjectActiveList[i] = false;
            workData.IsObjectActiveList[i] = false;
            engineData.IsObjectActiveList[i] = false;
            livingData.IsObjectActiveList[i] = false;
        }

        /* ������ �ʱ�ȭ */
        controlData.IsObjectActiveList[0] = true;
        controlData.IsObjectActiveList[1] = true;

        /* ������ �ʱ�ȭ */
        engineData.IsObjectActiveList[3] = true;
        engineData.IsObjectActiveList[5] = true;
        engineData.IsObjectActiveList[6] = true;
        engineData.IsObjectActiveList[8] = true;
        engineData.IsObjectActiveList[9] = true;
        engineData.IsObjectActiveList[39] = true;
        engineData.IsObjectActiveList[40] = true;
        engineData.IsObjectActiveList[58] = true;

        /* ��Ȱ���� �ʱ�ȭ */
        livingData.IsObjectActiveList[2] = true;
        livingData.IsObjectActiveList[7] = true;
        livingData.IsObjectActiveList[46] = true;
        livingData.IsObjectActiveList[47] = true;
        livingData.IsObjectActiveList[48] = true;
        livingData.IsObjectActiveList[49] = true;

        /* �������� �ʱ�ȭ */
        workData.IsObjectActiveList[4] = true;
        workData.IsObjectActiveList[10] = true;
        workData.IsObjectActiveList[11] = true;
        workData.IsObjectActiveList[12] = true;
        workData.IsObjectActiveList[13] = true;
        workData.IsObjectActiveList[14] = true;

        for (int k = 24; k < 32; k++)
        {
            workData.IsObjectActiveList[k] = true;
        }

        for (int q = 0; q < 5; q++)
        {
            workData.IsObjectActiveList[q + 33] = true;
            workData.IsObjectActiveList[q + 41] = true;
        }

        for (int j = 50; j < 58; j++)
        {
            workData.IsObjectActiveList[j] = true;
        }
#if UNITY_EDITOR
        EditorUtility.SetDirty(controlData);
        EditorUtility.SetDirty(workData);
        EditorUtility.SetDirty(engineData);
        EditorUtility.SetDirty(livingData);
#endif

    }

    void ResetWorkRoomObjectData()
    {
        healthMachinePartData.IsNotInteractable = false; // ����üũ��� ��ǰ
        engineDoorData.IsNotInteractable = false; // ������ ��
        engineKeyData.IsNotInteractable = false; // ������ ī��Ű
        engineKeyData.IsBite = false;
        E_extinguisherData.IsSmash = false; // �������� ��ȭ��

        cylinderGlassAnswerData.IsBite = false; // ����ô �Ǹ��� �ʱ�ȭ
        cylinderGlassWrongData.IsBite = false;
        cylinderGlassNoNeed1Data.IsBite = false;
        cylinderGlassNoNeed2Data.IsBite = false;
    }

    void ResetLivingRoomObjectData()
    {
        trashBodyData.IsNotInteractable = false; // ���� ���
        trashPartData.IsNotInteractable = false; // ���� ��ǰ
        L_GoodFood2Data.IsEaten = false; //��������2
        L_GoodFood3Data.IsEaten = false; //��������3
        L_BadFood2Data.IsEaten = false; //��������2
        L_BadFood3Data.IsEaten = false; //��������3
    }

    void ResetEngineRoomObjectData()
    {
        E_extinguisherData.IsSmash = false; // ������ ��ȭ��
    }

    public void ClearObjectData()
    {
        for (int i = 0; i < objectList.Length; i++)
        {
            objectList[i].IsBark = false;
            objectList[i].IsPushOrPress = false;
            objectList[i].IsSniff = false;
            objectList[i].IsBite = false;
            objectList[i].IsSmash = false;
            objectList[i].IsUpDown = false;
            objectList[i].IsEaten = false;
            objectList[i].IsInsert = false;
            objectList[i].IsEaten = false;
            objectList[i].IsObserve = false;
            objectList[i].IsCollision = false;

            objectList[i].IsClicked = false;
            objectList[i].IsCenterButtonChanged = false;
            objectList[i].IsCenterButtonDisabled = false;
            objectList[i].IsCenterPlusButtonDisabled = false;
            objectList[i].IsNotInteractable = false;
        }
    }

    public void ResetControlData()
    {
        //objectList[0].IsNotInteractable = true; // AI ��ư

        //objectList[1].IsNotInteractable = true; // ������ ��
        //objectList[1].IsCenterButtonDisabled = true;

        //objectList[5].IsNotInteractable = true; // ��Ʈ ��

        //objectList[7].IsNotInteractable = true; // ��Ʈ ��

        //objectList[9].IsNotInteractable = true; // ��Ʈ ��
    }


    public void ResetTutorialData()
    {

    }

    void ResetGame()
    {
        Debug.Log("���� ����");
        character.IsAIAwake_M_C1 = false;
        character.IsCWDoorOpened_M_C1 = false;
        character.IsHealthMachineFixed_T_C2 = false;
        character.IsSmartFarmOpen_T_C2 = false;
        character.S_IsAIAwake_M_C1 = false;
        character.IsTabletUnlock = false;
        //character.IsBasicTuto = false;
        character.IsMiddleTuto = false;


        character.statNum = 10;
        //�ӹ� �����ϱ� ��� ī��Ʈ, 3�� �̻� ����ϱ� ������ ���� ����
        character.IsReportCancleCount = 0;
        //AI ��� �ӹ� ī��Ʈ, 2 �̻� �� �� �º� �˵� ��ǥ �ر�
        character.IsAIVSMissionCount = 0;

        character.EndingNum = 0;

        /*������ ���� ���̵�����*/
        character.IsFakefatigue = 91; //�����Ƿε�
        character.IsFakeStrength = 87; //����ü��
        character.IsFakeThirst = 84; //���̸񸶸�
        character.IsFakeHunger = 88; //���̹����

        /*������ ���� ���� ������*/
        character.IsRealfatigue = 0; //�Ƿε�
        character.IsRealStrength = 0; //ü��
        character.IsRealThirst = 0; //�񸶸�
        character.IsRealHunger = 0; //�����

        character.IscurrentHealthData = 0; //������ǻ�Ϳ��� ����ϴ� ���� ��ġ

        /* �ӹ� ���� ���� (���ϸ�Ͽ� ������ �ƴ���) */
        character.S_IsAIAwake_M_C1 = false; // �׻� AI Ȱ��ȭ  
        character.S_IsCWDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����
        character.S_IsHealthMachineFixed_T_C2 = false; // ���������� ���� ���� �ӹ� ���� ���� 

        // �̼� ����Ʈ �ʱ�ȭ 
        for (int i = 0; i < 34; i++)
        {
            character.ActiveMissionList[i] = false;
            character.EndMissionList[i] = false;
        }

        /* 1ȸ�� �ӹ� */
        character.IsAIAwake_M_C1 = false; // �׻� AI Ȱ��ȭ  
        character.IsPipeFound_M_C1 = false; // �����ǿ��� ������ ã������ ���� ���̴� ���� �α�
        character.IsCWDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����

        character.IsHealthMachineFixed_T_C2 = false; // ���������� ���� ���� �ӹ� ���� ����   
        character.IsSmartFarmOpen_T_C2 = false; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����

        character.IsWEDoorOpened_M_C2 = false; // �׻� ������������ ������ �̵� ����

        character.IsWLDoorHalfOpened_M_C2 = false; // �׻� ������������ ��Ȱ���� �̵� ����. ��, ���� �ݸ� ����ä��
        character.IsWLDoorOpened_M_C2 = false; // �׻� ������������ ��Ȱ���� �̵� ����

        character.IsAllDoorOpened = false; //��� ������ �ر� �Ϸ�Ǿ�����

        //���� ���� üũ
        character.IsFirstEnterWorking = false; //�������� ���� ���� Ȯ��
        character.IsFirstEnterEngine = false; //������ ���� ���� Ȯ��
        character.IsFirstEnterLiving = false; //��Ȱ���� ���� ���� Ȯ��
        character.IsFirstExitTablet = false; //�簢���� ó������ �������� ��

        character.IsFirstNoticeEnd = false; //������üũ ���� üũ

        character.afterFirstTalk = false; //���� �Ϸ� �� ����ũ�� AI�� ��ȭ���� ��� ���� ��
        character.afterNewsTalk = false; //���� �˾� & ���ֺ���� ���� ��ȭ�� ���� ��


        //����Ž�� ����
        character.IsCheckDrug = false; //������ ���� Ȯ��
        character.IsDetox = false; //���� �ص�


        //�����ѹ��� & AI �ٿ� ����
        character.IsFirstUsingStrangeObj = false; //������ ���� ����غ� �� �ִ���
        character.IsHide = false; //��ȭ��(��ȸ��) ��� �� ���ڽ� ȿ��
        character.IsAlert = false; //���ڽ� ��尡 �ƴѵ� Ĩ ���� ���νý��ۿ� ���� ��
        character.IsAIDown = false; //����Ĩ ���� �� AI �ٿ� ��

        character.IsFuelabsorberFixed_E_E1 = false; //������ ��ġ�� �ӹ�, �ر��ؾ� ���� ���� �ӹ� ���� ����

        character.HealthMachineCancelCount = 5;

        character.IsEngineDoorFix_M_C2 = false; // ������ �� ���ƴ���

        //� ���� ����
        character.IsIsReallySmellDone_T_C2 = false; // � ������ �þҴ���
        character.IsReportImportantMeteor_T_C2 = false; // �߿� ��� �м��⿡ �־���

        // ����Ʈ�� ����
        character.IsIronDisappear_T_C2 = false; // ����Ʈ�� ������ �� ��������

        character.IsOutTroubleLine2_T_C2 = false; // ����Ʈ�� ������ ���� ���´���
        character.IsSmartFarmFix_T_C2 = false;//����Ʈ�� ������ �Ϸ�


        // � ����
        character.IsBiteimportantMeteor_T_C2 = false; // �߿� ��� ��������
        character.IsBiteNormalMeteor1_T_C2 = false; // �Ϲ� ��� ��������

        character.IsAnswerInBeaker1_M_C2 = false; // ��Ŀ 1�� �´� ��� �־�����
        character.IsAnswerInBeaker2_M_C2 = false; // ��Ŀ 2�� �´� ��� �־�����

        character.IsAnswerBeakerColorChange1_M_C2 = false; // ���� �� ������ ��Ŀ 1 ���� ��ȭ
        character.IsWrongBeakerColorChange1_M_C2 = false; // Ʋ�� �� ������ ��Ŀ 1 ���� ��ȭ
        character.IsNoNeed1BeakerColorChange1_M_C2 = false; // �ʿ���� ��1 ������ ��Ŀ 1 ���� ��ȭ
        character.IsNoNeed2BeakerColorChange1_M_C2 = false; // �ʿ���� ��2 ������ ��Ŀ 1 ���� ��ȭ

        character.IsAnswerBeakerColorChange2_M_C2 = false; // ���� �� ������ ��Ŀ 2 ���� ��ȭ
        character.IsWrongBeakerColorChange2_M_C2 = false; // Ʋ�� �� ������ ��Ŀ 2 ���� ��ȭ
        character.IsNoNeed1BeakerColorChange2_M_C2 = false; // �ʿ���� ��1 ������ ��Ŀ 2 ���� ��ȭ
        character.IsNoNeed2BeakerColorChange2_M_C2 = false; // �ʿ���� ��2 ������ ��Ŀ 2 ���� ��ȭ

        character.IsDrinkBeaker_M_C2 = false;
        character.IsAITimerStart_M_C2 = false;


        // �º� UI ����
        character.Is_Tablet_WirelessOn = false; //�º� ������� on/offüũ
        character.IsFakeHealthData_Tablet = false; //�º� ������ ���� ���� ������
        character.IsFakeCoordinateData_Tablet = false; //�º�������ǥ�ر� �Ǵ�
        character.IsFakeCoordinateDatafile_Tablet = false; //�º�������ǥ�ٿ�ε� �Ǵ�
        character.IsDontFakeCoordinateDatafile_Tablet = false; //�º� ������ǥ�ٿ�ε��Ʈ �Ұ�

        // ������ǻ�� UI ����
        character.Is_MainComputer_WirelessOn = false; //������ǻ�� ���Ʈ�� on/offüũ
        character.IsFinalBusinessReport_MC = false; //���� ���� ���� ������ �ر� �Ǵ�
        character.IsFinalBusinessReportFile_MC = false; //���� ���� ���� ������ �ٿ�ε�


        // ���νý��� UI ����
        character.Is_MainSystem_WirelessOn = false; //���νý��� ���Ʈ�� on/offüũ
        character.IsCanConnect_C_MS = false; //���νý��� ������� ���� üũ 
        character.IsReturnOfTheEarth = false;//�˵� ���� ����


        // �º� �ر� ����
        character.IsFullChargeTablet = false; // �º� ��������  
        character.IsNoBoxes = false; // ������ �ڽ� ������
        character.IsTabletMoved = false; // �º� AI �̰��� �������� ����� ��
        character.IsTabletDestory = false; // �º� �ı�

        // ���� �ʱ�ȭ
        for (int foodNum = 0; foodNum < 14; foodNum++)
        {
            character.sweetPotatoEat[foodNum] = false; //���� ���� �� Ȯ��
            character.BadFoodEat[foodNum] = false; //�������� ���� �� Ȯ��                                                     
            character.GoodFoodEat[foodNum] = false; //���� ���� �� Ȯ��
        }

        character.Pot1InPotato = false; // ����1�� ���� ������ Ȯ��
        character.Pot2InPotato = false; // ����2�� ���� ������ Ȯ��
        character.Pot3InPotato = false; // ����3�� ���� ������ Ȯ��
        character.IsCanSeePotato1 = false; // ������ ��Ÿ��ä�� ����
        character.IsCanSeePotato2 = false; // ������ ��Ÿ��ä�� ����
        character.IsCanSeePotato3 = false; // ������ ��Ÿ��ä�� ����

        character.Pot1InBadPotato = false; // ����1�� ���� ���� ������ Ȯ��
        character.Pot2InBadPotato = false; // ����1�� ���� ���� ������ Ȯ��
        character.Pot3InBadPotato = false; // ����1�� ���� ���� ������ Ȯ��

        character.Pot1InHealthyPotato = false; // ����1�� �ǰ��� ���� ������ Ȯ��
        character.Pot2InHealthyPotato = false; // ����1�� �ǰ��� ���� ������ Ȯ��
        character.Pot3InHealthyPotato = false; // ����1�� �ǰ��� ���� ������ Ȯ��

        // ������� ��
        character.IsMeteorCollectClose = false; //� ������ �� �������� Ȯ��
        character.IsMeteorCollectOpen = false; // � ������ �� ���ȴ��� Ȯ��


        // ��Ȱ���� ���� �ر�
        character.IsLivingRoomDollOut = false; // ��Ȱ���� ���� �����ִ� ���� ����


        /*�߿� ���� �º��� AI���� ������ ���*/
        // character.IsTabletDestroyed; // �º� AI���� ���� �ı���

        /*å�� ������*/
        character.IsUpTable1 = false;
        character.IsUpTable2 = false;

        /*�������*/
        character.IsStartCollectMeteorites = false; // � ���� �ӹ� ����
        character.IsStartPretendDead = false; // ����ô �ϱ� �ӹ� ����
        character.IsStartFIndDrug = false; //����ã�� �ӹ� ����
        character.IsFindStrangeObj = false; //�̻��ѹ���(��ȭ��) ���� �þҴ���
        character.IsStartToReady = false; //����� ���� �غ� ���� (��ݵ� �ӹ� 2�� �̻� ���� ��/���� ���� ��ũ��Ʈ �ʿ�)
        character.IsStartOrbitChange = false; //'AI �ٿ�' Ȥ�� '���� ô �ϱ�' ���� �Ϸ� �� �ڵ� ���� (ä���� ����ô�ϱ� ���� �Ϸ� ������ �ش� ���� �߰����ֶ�~)

        /*����Ϸ�*/
        character.IsBasicTuto = false; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ�
        character.IsMiddleTuto = false; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ� Ȯ��
        character.StopIDConsoleSpeak = false; // ID �ܼ� ���ϴ� �� �ݺ� ���ϰ� ���ַ���

        character.IsRealMiddleTuto = false; //Ʃ�丮�� �� ��Ʈ ��¥ �Ϸ�
        character.IsEndTuto = false; //Ʃ�丮�� ���� �Ϸ�
        character.IsTutorialClear = false; //Ʃ�丮�� ���� �� �Ϸ�

        character.IsCompleteSmartFarmOpen = false; // ����Ʈ�� ���� ���� �Ϸ�
        character.IsCompleteFindEngineKey = false; // ������ ī��Ű ã�� ���� �Ϸ�
        character.IsCompleteOpenEngineRoom = false; // ������ ���� ���� �Ϸ�
        character.IsInputNormalMeteor1_T_C2 = false; // �Ϲ� �1�� �����⿡ �ֱ� �Ϸ� (���߿� ������ �� �������� �ٲ�߰ڴ�)
        character.IsCompletePretendDead = false; // ����ô ���� �Ϸ�
        character.IsTabletUnlock = false; // �º� ��ݿ��� (�رݿϷ�)
        character.IsPlanetInsertChip_In = false; // �ùٸ� ����Ĩ �Ⱦ� ��¥ �༺ ������ ��ȯ
        character.IsAIDown_M_C1C3 = false; //AI�ٿ� ���� �Ϸ�
        character.IsKnowUsingSObj = false; //��ȭ�� ��� ����� �˾Ƴ´���
        character.IsFindDrugDone_T_C2 = false; //���� ���� Ȥ�� �ص��ϸ� �ٽ� ����
        character.IsCompleteFindLivingKey = false; // ��Ȱ���� ī��Ű ã�� �Ϸ�
        character.IsCompleteHalfOpenLivingRoom = false; // ��Ȱ���� �� �ݸ� ���� �Ϸ�

        character.IsDummyDataReport = false; //���̵����ͺ��� �Ϸ�
        character.IsAIVSMissionFinish = false; //��ݵ� ���� �ر�
        character.IsPhotoMissionFinish = false; //������� ���� �Ϸ�
        character.IsRevisioncomplaint = false; //����ϱ�

        character.IsCompleteOpenLivingRoom = false; // ��Ȱ���� �� ���� ���� �Ϸ�
        character.IsTrashDoorBTFixed_L_L1 = false; //��Ȱ���� ��ġ��

        character.randomUPic = 4;

        //����: �ּ�ó�� ������ ���� ������ üũ�� ���ؼ�/
        character.IsInputImportantMeteorEnd = false; // Ư�� � ���� ����
        character.IsMakeForestEnd = false; // ���°� ���� ����
        character.IsDefyMissionEnd = false; // ��� �Һ��� ����: �����ϱ� ���� Ƚ�� �ź�
        character.IsDisqualifiedEnd = false; // ������� ����: Ʃ�丮�� ����
        character.IsDiscardNoahEnd = false; // ����ü ��� ����: AI ����� �ð� �ȿ� �˵� ���� ����
        character.IsSaveOnlyOneEnd = false; // ����� ���� �ϳ� ����: ��� ����, ��� X
        character.IsSaveAllEnd = false; // ����� ���� ���� ����: �� ����, ��� O

        character.IsManagerAbilityLack = false; //��������������
        character.IsEatBadPotato = false;//���� ���� ���� ����

        character.IsSuddenDeath = false; //������ üũ: ���� 0 ����, ���� ���� ���� ����

        character.IsWirelessUI_firstEnter = false; //���� ������ ���� ���� üũ
        character.IsWirelessMCTabletCheck = false; //������/�º� ���� ���� �Ϸ� ���� üũ

        //���߿� �߰��� ��
        character.IsInputImportantMeteor1_T_C2 = false;
        character.IsAIAfterMissionComplete = false;

        SaveSystem.Save(character, "save_001");
    }

    public void ResetData()
    {
        ResetGame();

        RestIngameData();

        ResetPortableObject();

        ResetWorkRoomObjectData();
        ResetLivingRoomObjectData();
        ResetControlData();
        ResetEngineRoomObjectData();
    }

    void OpenDoor()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            character.IsAIAwake_M_C1 = true;
            character.IsCWDoorOpened_M_C1 = true;

            character.S_IsAIAwake_M_C1 = true;

            /* �ӹ� ���� ���� (���ϸ�Ͽ� ������ �ƴ���) */
            character.S_IsCWDoorOpened_M_C1 = true;// �׻� �����ǿ��� �������� �̵� ����
            character.IsWEDoorOpened_M_C2 = true; // �׻� ������������ ������ �̵� ����
            SaveSystem.Save(character, "save_001");
        }
    }
}
