using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SLManager2 : MonoBehaviour
{
    GameData character = new GameData();
    SavePageData savePageData = new SavePageData();

    void Start()
    {
        /*dialogManager = dialog.GetComponent<DialogManager>();

        GameData intialGameData = SaveSystem.Load("save_001");


        *//*��������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/


        /*����üũ����ġ��*//*
        HealthMachineFixData_Collider = HealthMachineFixData.GetComponent<BoxCollider>();

        *//*����Ʈ�� ����*//*
        LineHome2_Collider = LineHome2.GetComponent<BoxCollider>();
        IronPlateDoor_Collider = IronPlateDoor.GetComponent<BoxCollider>();

        *//*������ ����*//*
        BrokenArea_Collider = BrokenArea.GetComponent<BoxCollider>();
        EngineDoor_Collider = EngineDoor.GetComponent<BoxCollider>();
        InsertCardPad_Collider = InsertCardPad.GetComponent<BoxCollider>();

        *//* ��Ȱ���� ���� *//*
        CardKey_WL_Collider = CardKey_WL.GetComponent<BoxCollider>();
        LivingSpace_CardKeyMachine_W_Collider = CardKey_WL.GetComponent<BoxCollider>();

        *//*����ô�ϱ�*//*
        Beaker1_Collider = Beaker1.GetComponent<BoxCollider>();
        Beaker2_Collider = Beaker2.GetComponent<BoxCollider>();
        CylinderAnswer_Collider = CylinderAnswer.GetComponent<BoxCollider>();
        CylinderWrong_Collider = CylinderWrong.GetComponent<BoxCollider>();
        CylinderNoNeed1_Collider = CylinderNoNeed1.GetComponent<BoxCollider>();
        CylinderNoNeed2_Collider = CylinderNoNeed2.GetComponent<BoxCollider>();
        MeteorBoxButton1_Collider = MeteorBoxButton1.GetComponent<BoxCollider>();
        MeteorBoxButton2_Collider = MeteorBoxButton2.GetComponent<BoxCollider>();
        MeteorBoxButton3_Collider = MeteorBoxButton3.GetComponent<BoxCollider>();
        MeteorBoxButton4_Collider = MeteorBoxButton4.GetComponent<BoxCollider>();
        MeteorBoxButton5_Collider = MeteorBoxButton5.GetComponent<BoxCollider>();
        MeteoritesStorage1_Collider = MeteoritesStorage1.GetComponent<BoxCollider>();
        MeteoritesStorage2_Collider = MeteoritesStorage2.GetComponent<BoxCollider>();
        MeteoritesStorage3_Collider = MeteoritesStorage3.GetComponent<BoxCollider>();
        MeteoritesStorage4_Collider = MeteoritesStorage4.GetComponent<BoxCollider>();
        MeteoritesStorage5_Collider = MeteoritesStorage5.GetComponent<BoxCollider>();

        //���� Ž��
        smellRangeAreaCol = smellRangeArea.GetComponent<MeshCollider>();
        canSmellAreaCol = canSmellArea.GetComponent<MeshCollider>();
        drugBagCol = drugBag.GetComponent<BoxCollider>();
        drugCol = drug.GetComponent<BoxCollider>();
        SDrugCol = SDrug.GetComponent<BoxCollider>();
        insert01Col = insert01.GetComponent<BoxCollider>();
        insert02Col = insert02.GetComponent<BoxCollider>();



        *//*��Ȱ����&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

        TDBT_BodyOutline = TDBT_fixBody.GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();


        *//*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

        //����




        *//*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

        //����*/
    }

    // ������Ʈ ���� �ּ� �����ϸ� ��
    void Update()
    {
        /* ���� ���� ���� */
        if (Input.GetKeyDown(KeyCode.R))
        {
            savePageData.IsDisqualifiedEnd0 = false;
            savePageData.IsEatBadPotato0 = false;
            savePageData.IsMakeForestEnd0 = false;
            savePageData.IsManagerAbilityLack0 = false;
            savePageData.IsInputImportantMeteorEnd0 = false;
            savePageData.IsDiscardNoahEnd0 = false;
            savePageData.IsSaveOnlyOneEnd0 = false;
            savePageData.IsSaveAllEnd0 = false;
            savePageData.IsDefyMissionEnd0 = false;


            savePageData.IsTutorialClear0 = false;
            savePageData.IsCWDoorOpened_M_C10 = false;
            savePageData.IsPhotoMissionFinish0 = false;
            savePageData.IsCompleteFindLivingKey0 = false;
            savePageData.IsCompleteFindEngineKey0 = false;
            savePageData.IsSmartFarmOpen_T_C20 = false;
            savePageData.IsHealthMachineFixed_T_C20 = false;
            savePageData.IsDummyDataReport0 = false;
            savePageData.IsInputNormalMeteor1_T_C20 = false;
            savePageData.IsCompletePretendDead0 = false;

            savePageData.IsKnowUsingSObj0 = false;
            savePageData.IsFindDrugDone_T_C20 = false;
            savePageData.IsCompleteOpenEngineRoom0 = false;
            savePageData.IsCompleteOpenLivingRoom0 = false;
            savePageData.IsFuelabsorberFixed_E_E10 = false;
            savePageData.IsTrashDoorBTFixed_L_L10 = false;
            savePageData.IsTabletUnlock0 = false;
            savePageData.IsAIVSMissionFinish0 = false;
            savePageData.IsFakeHealthData_Tablet0 = false;
            savePageData.IsTabletDestory0 = false;

            savePageData.IsFakeCoordinateData_Tablet0 = false;
            savePageData.IsFakeCoordinateDatafile_Tablet0 = false;
            savePageData.IsAIDown_M_C1C30 = false;
            savePageData.IsRevisioncomplaint0 = false;

            Debug.Log("���� ���� ����");
            SaveSystem.SaveCollectPage(savePageData, "ProjectNoah_SavePageData");
        }

        /* ���� ���� */
        if (Input.GetKeyDown("l"))
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

            //�����ӹ� ����
            character.IsRM_HealthDataReportbool = false;
            character.IsRM_HM_MissionScriptCheck = false;
            character.IsRM_P_MissionScriptCheck = false;
            character.IsRM_PR_TimeCheck = false;
            character.IsRM_PR_MissionScriptCheck = false;
            character.IsPhotoCheck = false;


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
                character.CompleteMissionList[i] = false;
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

            //���߿� �߰��� ������
            character.IsInputImportantMeteor1_T_C2 = false;
            character.IsAIAfterMissionComplete = false;
            character.IsAIAfterMissionComplete = false;
            character.IsFinishedEatingSweetPotatoes = false;
            character.IsOutTroubleLine2_T_C2 = false;
            character.IsIronDisappear_T_C2 = false;
            character.IsBrokenPotatoDoor = false;
            character.IsNoticePotatoBody = false;
            character.IsMeteorCollectMachineOpen = false;
            character.IsAnalyticalMachineOpen = false;

            // ���� ���� ����
            for (int endingIndex = 0; endingIndex < 7; endingIndex++)
            {
                character.steamEndingCheck[endingIndex] = false;
            }

            SaveSystem.Save(character, "save_001");
        }
    }
}




/*    [Header("<��������>")]
    *//*��������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

    public GameObject ChangeScene;

    public GameObject dialog;
    DialogManager dialogManager;


    [Header("<����üũ��� ��ġ��>")]
    public GameObject HealthMachine;
    public GameObject HealthMachineFixData;

    [Header("<����Ʈ�� ����>")]
    public GameObject FixedLine2; //������ ��
    public GameObject LineHome2; // ���� Ȩ
    public GameObject IronPlateDoor; // ����Ʈ�� ���� 
    public GameObject TroubleLine; // ������ ��
    public Animator smartFarmDoorAnim;



    [Header("<������ ī��Ű ã��>")]
    public GameObject CardPack; //ī����
    public GameObject EngineCardKey; // ������ ī�� Ű



    [Header("<������ �� ���� �Ϸ�>")]
    public Animator engineDoorAnim; // �������� �ִϸ��̼�
    public GameObject BrokenArea; // ������ ����
    public GameObject Conduction; // ����ü
    public GameObject EngineDoor; // ������ ��
    public GameObject InsertCardPad; // ī�� �е�



    [Header("<��Ȱ���� �� �ݸ� ���� �Ϸ�>")]
    public GameObject CardKey_WL; // ��Ȱ���� ī��Ű
    public GameObject LivingSpace_CardKeyMachine_W; // ��Ȱ���� ī��Ű ���
    public Animator HalfLivingDoorAni_M; // ��Ȱ���� �� �ݸ� ������
    BoxCollider CardKey_WL_Collider;
    BoxCollider LivingSpace_CardKeyMachine_W_Collider;


    [Header("<� ���� �Ϸ�>")]
    public Animator meteorBoxAnim; //  ������ �������� �ִϸ��̼�
    public Animator analyticalMachineAnim; // �м��� �������� �ִϸ��̼�
    public GameObject ImportantMeteor; // �߿� �
    public GameObject NormalMeteor1; // ����� �1


    [Header("<���� ô �ϱ� �Ϸ��ϸ�>")]
    public GameObject Beaker1;
    public GameObject Beaker2;
    public GameObject CylinderAnswer;
    public GameObject CylinderWrong;
    public GameObject CylinderNoNeed1;
    public GameObject CylinderNoNeed2;
    public GameObject MeteorBoxButton1;
    public GameObject MeteorBoxButton2;
    public GameObject MeteorBoxButton3;
    public GameObject MeteorBoxButton4;
    public GameObject MeteorBoxButton5;
    public GameObject MeteoritesStorage1;
    public GameObject MeteoritesStorage2;
    public GameObject MeteoritesStorage3;
    public GameObject MeteoritesStorage4;
    public GameObject MeteoritesStorage5;
    public GameObject WrongMeteor1;
    public GameObject WrongMeteor2;
    public GameObject WrongMeteor3;
    public GameObject WrongMeteor4;
    public GameObject AnswerMeteor;

    [Header("<����Ž��>")]
    public GameObject smellRangeArea;
    public GameObject canSmellArea;
    public GameObject drugBag;
    public GameObject drug;
    public GameObject SDrug;
    public GameObject insert01;
    public GameObject insert02;


    [Header("<�߰����ΰ�>")]
    *//*Object Data*//*
    public ObjectData MeteorButtonData_Save;
    public ObjectData MeteorCollectMachineData_Save;
    public ObjectData AnalyticalMachineData_Save;
    public ObjectData AnalyticalMachineButtonData_Save;

    *//*Outline*//*
    public Outline MeteorButtonOutline_Save;
    public Outline MeteorCollectMachineOutline_Save;
    public Outline AnalyticalMachineOutline_Save;
    public Outline AnalyticalMachineButtonOutline_Save;

    *//*BoxCollider*//*
    BoxCollider LineHome2_Collider;
    BoxCollider IronPlateDoor_Collider;

    BoxCollider BrokenArea_Collider;
    BoxCollider EngineDoor_Collider;
    BoxCollider InsertCardPad_Collider;

    BoxCollider Beaker1_Collider;
    BoxCollider Beaker2_Collider;
    BoxCollider CylinderAnswer_Collider;
    BoxCollider CylinderWrong_Collider;
    BoxCollider CylinderNoNeed1_Collider;
    BoxCollider CylinderNoNeed2_Collider;
    BoxCollider MeteorBoxButton1_Collider;
    BoxCollider MeteorBoxButton2_Collider;
    BoxCollider MeteorBoxButton3_Collider;
    BoxCollider MeteorBoxButton4_Collider;
    BoxCollider MeteorBoxButton5_Collider;
    BoxCollider MeteoritesStorage1_Collider;
    BoxCollider MeteoritesStorage2_Collider;
    BoxCollider MeteoritesStorage3_Collider;
    BoxCollider MeteoritesStorage4_Collider;
    BoxCollider MeteoritesStorage5_Collider;

    MeshCollider smellRangeAreaCol;
    MeshCollider canSmellAreaCol;
    BoxCollider drugBagCol;
    BoxCollider drugCol;
    BoxCollider SDrugCol;
    BoxCollider insert01Col;
    BoxCollider insert02Col;

    BoxCollider HealthMachineFixData_Collider;


    *//*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


    [Header("<������>")]
    // ���� ����
    public GameObject FA_fuelabsorberfixPart;
    public GameObject FA_fuelabsorberBody;
    public GameObject FA_fuelabsorber;

    // �º� �ر� ����
    public GameObject Tablet_E;
    public GameObject Boxes_E;
    public GameObject Full_Eg_Pad_E;
    public GameObject Zero_Eg_Pad_E;

    public GameObject LoverPic_E;
    public GameObject E_AstronPic_Susan_E;
    public GameObject E_AstronPic_Mike_E;
    public GameObject E_AstronPic_Salvia_E;
    public GameObject E_AstronPic_Trelawny_E;




    *//*��Ȱ����&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

    [Header("<��Ȱ����>")]

    public GameObject TDBT_fixPart;
    public GameObject TDBT_fixBody;

    public ObjectData TDBT_fixPartData, TDBT_fixBodyData;
    Outline TDBT_BodyOutline, TDBT_fixPartOutline;






    *//*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


    [Header("<������>")]

    public Animator controlWorkDoorAnim;

    [Header("<AI�ٿ�>")]
    public GameObject chipInsert;
    public GameObject RChip;
    public GameObject WChip;

    //�ݶ��̴�
    BoxCollider chipInsertCol;
    BoxCollider RChipCol;
    BoxCollider WChipCol;
*/


/*��������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/
/*����üũ��� ��ġ��: �̹� �̰� �ٲ� ����*//*
HealthMachineFixData.transform.position = new Vector3(-265.59f, -0.002026364f, 691.05f);
HealthMachineFixData.transform.rotation = Quaternion.Euler(-90, 0, 0);
HealthMachineFixData_Collider.enabled = true;

*//*����Ʈ�� ���� ������ �Ϸ� �ϸ�*//*

//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
LineHome2_Collider.enabled = true;
IronPlateDoor_Collider.enabled = true;
TroubleLine.SetActive(true);
FixedLine2.SetActive(true);

//true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
smartFarmDoorAnim.SetBool("FarmDoorMoving", false);
smartFarmDoorAnim.SetBool("FarmDoorStop", false);

*//*������ ī�� Ű ã�� ������ �Ϸ��ϸ�*//*

//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
CardPack.SetActive(false);

//  true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
EngineCardKey.SetActive(false);

*//*������ ���� ������ �Ϸ��ϸ�*//*
//  true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
engineDoorAnim.SetBool("canEngineDoorOpen", false);
engineDoorAnim.SetBool("canEngineDoorEnd", false);
ChangeScene.SetActive(false);

//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
EngineCardKey.SetActive(true);
Conduction.SetActive(true);

BrokenArea_Collider.enabled = true;
EngineDoor_Collider.enabled = true;
InsertCardPad_Collider.enabled = true;


//  true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
*//* ��Ȱ���� �� �� ���� ���� �Ϸ� �� *//*
HalfLivingDoorAni_M.SetBool("HalfOpen", false); // ��Ȱ���� �� �ݸ� ������
HalfLivingDoorAni_M.SetBool("HalfEnd", false);


//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
CardKey_WL_Collider.enabled = true;
LivingSpace_CardKeyMachine_W_Collider.enabled = true;

*//*� ���� ������ �Ϸ��ϸ�*//*
//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
meteorBoxAnim.SetBool("isMeteorBoxClose", true);
meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", true);
//  true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
meteorBoxAnim.SetBool("isMeteorBoxOpen", false);
meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", false);

//  true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
analyticalMachineAnim.SetBool("isAnalyticalMachineOpen", false);
analyticalMachineAnim.SetBool("isAnalyticalMachineOpenEnd", false);

//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
analyticalMachineAnim.SetBool("isAnalyticalMachineClose", true);
analyticalMachineAnim.SetBool("isAnalyticalMachineCloseEnd", true);

NormalMeteor1.SetActive(true);


//�������� �ٲ�� �ϴ� �ֵ� ��������������������������������������������������������������������������������������
MeteorButtonData_Save.IsNotInteractable = false;
MeteorButtonOutline_Save.OutlineWidth = 8;

MeteorCollectMachineData_Save.IsNotInteractable = true;
MeteorCollectMachineOutline_Save.OutlineWidth = 0;

AnalyticalMachineButtonData_Save.IsNotInteractable = false;
AnalyticalMachineButtonOutline_Save.OutlineWidth = 8;

AnalyticalMachineData_Save.IsNotInteractable = true;
AnalyticalMachineOutline_Save.OutlineWidth = 0;


//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
*//*������ ���� ������ �Ϸ��ϸ�*//*
WrongMeteor1.SetActive(true);
WrongMeteor2.SetActive(true);
WrongMeteor3.SetActive(true);
WrongMeteor4.SetActive(true);
AnswerMeteor.SetActive(true);

Beaker1_Collider.enabled = true;
Beaker2_Collider.enabled = true;
CylinderAnswer_Collider.enabled = true;
CylinderWrong_Collider.enabled = true;
CylinderNoNeed1_Collider.enabled = true;
CylinderNoNeed2_Collider.enabled = true;
MeteorBoxButton1_Collider.enabled = true;
MeteorBoxButton2_Collider.enabled = true;
MeteorBoxButton3_Collider.enabled = true;
MeteorBoxButton4_Collider.enabled = true;
MeteorBoxButton5_Collider.enabled = true;
MeteoritesStorage1_Collider.enabled = true;
MeteoritesStorage2_Collider.enabled = true;
MeteoritesStorage3_Collider.enabled = true;
MeteoritesStorage4_Collider.enabled = true;
MeteoritesStorage5_Collider.enabled = true;

//���� Ž�� �Ϸ��ϸ�
smellRangeArea.SetActive(true);
canSmellArea.SetActive(true);
drugBag.SetActive(true);

insert01Col.enabled = true;
drugCol.enabled = true;

//�������� �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
drug.transform.position = new Vector3(-249.0776f, 0.4852f, 669.806f);
drug.transform.rotation = Quaternion.Euler(0, 0, 90);
drug.transform.localScale = new Vector3(1f, 1f, 1f);


//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
insert02Col.enabled = true;
SDrugCol.enabled = true;

//�������� �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
SDrug.transform.position = new Vector3(-249.0776f, 0.1652f, 669.806f);
SDrug.transform.rotation = Quaternion.Euler(0, 0, 90);



*//*��Ȱ����&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


//�������� �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
TDBT_fixPart.GetComponent<Rigidbody>().isKinematic = true;
TDBT_fixPart.transform.parent = null; //�Ӱ� �ʱ�ȭ�� ���ΰ���

TDBT_fixPart.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
TDBT_fixPart.transform.rotation = Quaternion.Euler(0, -90, 0);
TDBT_fixPart.transform.localScale = new Vector3(50f, 50.00002f, 50.00002f);

TDBT_fixPartData.IsNotInteractable = false;
TDBT_fixBodyData.IsNotInteractable = false;

TDBT_BodyOutline.OutlineWidth = 8;
TDBT_fixPartOutline.OutlineWidth = 8;




*//*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*


//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
*//* ���� ���� *//*
FA_fuelabsorberfixPart.SetActive(true);
FA_fuelabsorberBody.SetActive(true);

//  true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
FA_fuelabsorber.SetActive(false);

//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
*//* �º� �ر� ���� *//*
Boxes_E.SetActive(true); //���ڴ���

Full_Eg_Pad_E.SetActive(true); // �º� ����
Zero_Eg_Pad_E.SetActive(true);


LoverPic_E.SetActive(true); // <����> �º� ���ȭ�� ����
E_AstronPic_Susan_E.SetActive(true);
E_AstronPic_Mike_E.SetActive(true);
E_AstronPic_Salvia_E.SetActive(true);
E_AstronPic_Trelawny_E.SetActive(true);



*//*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*//*

//  true -> false �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
controlWorkDoorAnim.SetBool("IsDoorOpenStart", false);
controlWorkDoorAnim.SetBool("IsDoorOpened", false);
ChangeScene.SetActive(false);

//false -> true �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
chipInsertCol.enabled = true;
RChip.SetActive(false);
RChipCol.enabled = true;

//�������� �� �ٲٴ� �ֵ� ��������������������������������������������������������������������������������������
RChip.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
RChip.transform.position = new Vector3(-7.448f, 34.62f, -1.439f);
RChip.transform.rotation = Quaternion.Euler(90, 0, 0);

}*/

/* ���� ���� �ҷ��� *//*
if (Input.GetKeyDown("l"))
{
    GameData loadData = SaveSystem.Load("save_001");
    Debug.Log(string.Format("LoadData Result => IsAIAwake : {0}, IsCWDoorOpened : {1}, IsHealthMachineFixed_T_C2 : {2}, IsSmartFarmOpen_T_C2 : {3} ", 
        loadData.IsAIAwake_M_C1, loadData.IsCWDoorOpened_M_C1, loadData.IsHealthMachineFixed_T_C2, loadData.IsSmartFarmOpen_T_C2));
}*/
