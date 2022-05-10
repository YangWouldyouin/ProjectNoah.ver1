using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SLManager : MonoBehaviour
{


    [Header("<��������>")]
    /*��������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

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
    /*Object Data*/
    public ObjectData MeteorButtonData_Save;
    public ObjectData MeteorCollectMachineData_Save;
    public ObjectData AnalyticalMachineData_Save;
    public ObjectData AnalyticalMachineButtonData_Save;

    /*Outline*/
    public Outline MeteorButtonOutline_Save;
    public Outline MeteorCollectMachineOutline_Save;
    public Outline AnalyticalMachineOutline_Save;
    public Outline AnalyticalMachineButtonOutline_Save;

    /*BoxCollider*/
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


    /*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/


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




    /*��Ȱ����&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

    [Header("<��Ȱ����>")]

    public GameObject TDBT_fixPart;
    public GameObject TDBT_fixBody;

    public ObjectData TDBT_fixPartData, TDBT_fixBodyData;
    Outline TDBT_BodyOutline, TDBT_fixPartOutline;






    /*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/


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










    /*��ŸƮ �� ����&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        GameData intialGameData = SaveSystem.Load("save_001");


        /*��������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/


        /*����üũ����ġ��*/
        HealthMachineFixData_Collider = HealthMachineFixData.GetComponent<BoxCollider>();

        /*����Ʈ�� ����*/
        LineHome2_Collider = LineHome2.GetComponent<BoxCollider>();
        IronPlateDoor_Collider = IronPlateDoor.GetComponent<BoxCollider>();

        /*������ ����*/
        BrokenArea_Collider = BrokenArea.GetComponent<BoxCollider>();
        EngineDoor_Collider = EngineDoor.GetComponent<BoxCollider>();
        InsertCardPad_Collider = InsertCardPad.GetComponent<BoxCollider>();

        /* ��Ȱ���� ���� */
        CardKey_WL_Collider = CardKey_WL.GetComponent<BoxCollider>();
        LivingSpace_CardKeyMachine_W_Collider = CardKey_WL.GetComponent<BoxCollider>();

        /*����ô�ϱ�*/
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



        /*��Ȱ����&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

        TDBT_BodyOutline = TDBT_fixBody.GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();


        /*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

        //����




        /*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

        //����
    }

    void Update()
    {



        /* ���� ���� */
        if (Input.GetKeyDown("s"))
        {
            GameData character = new GameData();
            character.statNum = 10;
            character.IsAIAwake_M_C1 = false;
            character.IsCWDoorOpened_M_C1 = false;
            character.IsHealthMachineFixed_T_C2 = false;
            character.IsSmartFarmOpen_T_C2 = false;
            character.S_IsAIAwake_M_C1 = false;
            character.ActiveMissionList[0] = false;
            character.ActiveMissionList[3] = false;
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
            character.ActiveMissionList[0] = false;
            character.ActiveMissionList[1] = false;
            character.ActiveMissionList[2] = false;
            character.ActiveMissionList[3] = false;
            character.ActiveMissionList[4] = false;

            character.EndMissionList[0] = false;
            character.EndMissionList[1] = false;
            character.EndMissionList[2] = false;
            character.EndMissionList[3] = false;
            character.EndMissionList[4] = false;


            /* 1ȸ�� �ӹ� */
            character.IsAIAwake_M_C1 = false; // �׻� AI Ȱ��ȭ  
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

            // ���� ����
            character.sweetPotatoEat[0] = false; //���� ���� �� Ȯ��
            character.sweetPotatoEat[1] = false;
            character.sweetPotatoEat[2] = false;
            character.sweetPotatoEat[3] = false;
            character.sweetPotatoEat[4] = false;
            character.sweetPotatoEat[5] = false;
            character.sweetPotatoEat[6] = false;
            character.sweetPotatoEat[7] = false;
            character.sweetPotatoEat[8] = false;
            character.sweetPotatoEat[9] = false;
            character.sweetPotatoEat[10] = false;
            character.sweetPotatoEat[11] = false;
            character.sweetPotatoEat[12] = false;
            character.sweetPotatoEat[13] = false;



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

            //���� ���� �� Ȯ��
            character.BadFoodEat[0] = false;
            character.BadFoodEat[1] = false;
            character.BadFoodEat[2] = false;
            character.BadFoodEat[3] = false;
            character.BadFoodEat[4] = false;
            character.BadFoodEat[5] = false;
            character.BadFoodEat[6] = false;
            character.BadFoodEat[7] = false;
            character.BadFoodEat[8] = false;
            character.BadFoodEat[9] = false;
            character.BadFoodEat[10] = false;
            character.BadFoodEat[11] = false;
            character.BadFoodEat[12] = false;
            character.BadFoodEat[13] = false;



            //���� ���� �� Ȯ��
            character.GoodFoodEat[0] = false;
            character.GoodFoodEat[1] = false;
            character.GoodFoodEat[2] = false;
            character.GoodFoodEat[3] = false;
            character.GoodFoodEat[4] = false;
            character.GoodFoodEat[5] = false;
            character.GoodFoodEat[6] = false;
            character.GoodFoodEat[7] = false;
            character.GoodFoodEat[8] = false;
            character.GoodFoodEat[9] = false;
            character.GoodFoodEat[10] = false;
            character.GoodFoodEat[11] = false;
            character.GoodFoodEat[12] = false;
            character.GoodFoodEat[13] = false;



            // ������� ��
            character.IsMeteorCollectClose = false; //� ������ �� �������� Ȯ��
            character.IsMeteorCollectOpen = false; // � ������ �� ���ȴ��� Ȯ��


            // ��Ȱ���� ���� �ر�
            character.IsLivingRoomDollOut = false; // ��Ȱ���� ���� �����ִ� ���� ����


            /*�߿� ���� �º��� AI���� ������ ���*/
            // character.IsTabletDestroyed; // �º� AI���� ���� �ı���



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
            character.IsRealMiddleTuto = false; //Ʃ�丮�� �� ��Ʈ ��¥ �Ϸ�
            character.IsEndTuto = false; //Ʃ�丮�� ���� �Ϸ�
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

            //character.randomUPic = false;

            /*����:�ּ�ó�� ������ ���� ������ üũ�� ���ؼ�/
/*            character.IsInputImportantMeteorEnd = false; // Ư�� � ���� ����
            character.IsMakeForestEnd = false; // ���°� ���� ����
            character.IsDefyMissionEnd = false; // ��� �Һ��� ����: �����ϱ� ���� Ƚ�� �ź�
            character.IsDisqualifiedEnd = false; // ������� ����: Ʃ�丮�� ����
            character.IsDiscardNoahEnd = false; // ����ü ��� ����: AI ����� �ð� �ȿ� �˵� ���� ����
            character.IsSaveOnlyOneEnd = false; // ����� ���� �ϳ� ����: ��� ����, ��� X
            character.IsSaveAllEnd = false; // ����� ���� ���� ����: �� ����, ��� O

            character.IsManagerAbilityLack = false; //��������������
            character.IsEatBadPotato = false;//���� ���� ���� ����*/

            character.IsSuddenDeath = false; //������ üũ: ���� 0 ����, ���� ���� ���� ����
            SaveSystem.Save(character, "save_001");




            /*��������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/


            /*����üũ��� ��ġ��: �̹� �̰� �ٲ� ����*/
            HealthMachineFixData.transform.position = new Vector3(-265.59f, -0.002026364f, 691.05f);
            HealthMachineFixData.transform.rotation = Quaternion.Euler(-90, 0, 0);
            HealthMachineFixData_Collider.enabled = true;

            /*����Ʈ�� ���� ������ �Ϸ� �ϸ�*/

            //false -> true �� ��
            LineHome2_Collider.enabled = false;
            IronPlateDoor_Collider.enabled = false;
            TroubleLine.SetActive(false);
            FixedLine2.SetActive(false);
            smartFarmDoorAnim.SetBool("FarmDoorMoving", true);
            smartFarmDoorAnim.SetBool("FarmDoorStop", true);

            /*������ ī�� Ű ã�� ������ �Ϸ��ϸ�*/
            CardPack.SetActive(false);
            EngineCardKey.SetActive(true);

            /*������ ���� ������ �Ϸ��ϸ�*/
            engineDoorAnim.SetBool("canEngineDoorOpen", true);
            engineDoorAnim.SetBool("canEngineDoorEnd", true);
            ChangeScene.SetActive(true);

            EngineCardKey.SetActive(false);
            Conduction.SetActive(false);

            BrokenArea_Collider.enabled = false;
            EngineDoor_Collider.enabled = false;
            InsertCardPad_Collider.enabled = false;

            /* ��Ȱ���� �� �� ���� ���� �Ϸ� �� */
            HalfLivingDoorAni_M.SetBool("HalfOpen", true); // ��Ȱ���� �� �ݸ� ������
            HalfLivingDoorAni_M.SetBool("HalfEnd", true);

            CardKey_WL_Collider.enabled = false;
            LivingSpace_CardKeyMachine_W_Collider.enabled = false;

            /*� ���� ������ �Ϸ��ϸ�*/
            meteorBoxAnim.SetBool("isMeteorBoxClose", false);
            meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", false);
            meteorBoxAnim.SetBool("isMeteorBoxOpen", true);
            meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", true);


            analyticalMachineAnim.SetBool("isAnalyticalMachineOpen", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineOpenEnd", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineClose", false);
            analyticalMachineAnim.SetBool("isAnalyticalMachineCloseEnd", false);

            NormalMeteor1.SetActive(false);

            MeteorButtonData_Save.IsNotInteractable = true;
            MeteorButtonOutline_Save.OutlineWidth = 0;

            MeteorCollectMachineData_Save.IsNotInteractable = false;
            MeteorCollectMachineOutline_Save.OutlineWidth = 8;

            AnalyticalMachineButtonData_Save.IsNotInteractable = true;
            AnalyticalMachineButtonOutline_Save.OutlineWidth = 0;

            AnalyticalMachineData_Save.IsNotInteractable = false;
            AnalyticalMachineOutline_Save.OutlineWidth = 8;


            /*������ ���� ������ �Ϸ��ϸ�*/
            WrongMeteor1.SetActive(false);
            WrongMeteor2.SetActive(false);
            WrongMeteor3.SetActive(false);
            WrongMeteor4.SetActive(false);
            AnswerMeteor.SetActive(false);

            Beaker1_Collider.enabled = false;
            Beaker2_Collider.enabled = false;
            CylinderAnswer_Collider.enabled = false;
            CylinderNoNeed1_Collider.enabled = false;
            CylinderNoNeed2_Collider.enabled = false;
            MeteorBoxButton1_Collider.enabled = false;
            MeteorBoxButton2_Collider.enabled = false;
            MeteorBoxButton3_Collider.enabled = false;
            MeteorBoxButton4_Collider.enabled = false;
            MeteorBoxButton5_Collider.enabled = false;
            MeteoritesStorage1_Collider.enabled = false;
            MeteoritesStorage2_Collider.enabled = false;
            MeteoritesStorage3_Collider.enabled = false;
            MeteoritesStorage4_Collider.enabled = false;
            MeteoritesStorage5_Collider.enabled = false;

            //���� Ž�� �Ϸ��ϸ�
            smellRangeArea.SetActive(false);
            canSmellArea.SetActive(false);
            drugBag.SetActive(false);

            insert01Col.enabled = false;
            drugCol.enabled = false;

            drug.transform.position = new Vector3(-249.0776f, 0.4852f, 669.806f);
            drug.transform.rotation = Quaternion.Euler(0, 0, 90);
            drug.transform.localScale = new Vector3(1f, 1f, 1f);


            insert02Col.enabled = false;
            SDrugCol.enabled = false;

            SDrug.transform.position = new Vector3(-249.0776f, 0.1652f, 669.806f);
            SDrug.transform.rotation = Quaternion.Euler(0, 0, 90);



            /*��Ȱ����&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

            TDBT_fixPart.GetComponent<Rigidbody>().isKinematic = false;
            TDBT_fixPart.transform.parent = null;

            TDBT_fixPart.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
            TDBT_fixPart.transform.rotation = Quaternion.Euler(0, -90, 0);
            TDBT_fixPart.transform.localScale = new Vector3(50f, 50.00002f, 50.00002f);

            TDBT_fixPartData.IsNotInteractable = true;
            TDBT_fixBodyData.IsNotInteractable = true;

            TDBT_BodyOutline.OutlineWidth = 0;
            TDBT_fixPartOutline.OutlineWidth = 0;




            /*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/


            /* ���� ���� */
            FA_fuelabsorberfixPart.SetActive(false);
            FA_fuelabsorberBody.SetActive(false);
            FA_fuelabsorber.SetActive(true);


            /* �º� �ر� ���� */
            Boxes_E.SetActive(false); //���ڴ���

            Full_Eg_Pad_E.SetActive(false); // �º� ����
            Zero_Eg_Pad_E.SetActive(false);


            LoverPic_E.SetActive(false); // <����> �º� ���ȭ�� ����
            E_AstronPic_Susan_E.SetActive(false);
            E_AstronPic_Mike_E.SetActive(false);
            E_AstronPic_Salvia_E.SetActive(false);
            E_AstronPic_Trelawny_E.SetActive(false);



            /*������&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&*/

            controlWorkDoorAnim.SetBool("IsDoorOpenStart", true);
            controlWorkDoorAnim.SetBool("IsDoorOpened", true);
            ChangeScene.SetActive(true);

            chipInsertCol.enabled = false;
            RChip.SetActive(true);
            RChipCol.enabled = false;

            RChip.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            RChip.transform.position = new Vector3(-7.448f, 34.62f, -1.439f);
            RChip.transform.rotation = Quaternion.Euler(90, 0, 0);

        }

        /* ���� ���� �ҷ��� *//*
        if (Input.GetKeyDown("l"))
        {
            GameData loadData = SaveSystem.Load("save_001");
            Debug.Log(string.Format("LoadData Result => IsAIAwake : {0}, IsCWDoorOpened : {1}, IsHealthMachineFixed_T_C2 : {2}, IsSmartFarmOpen_T_C2 : {3} ", 
                loadData.IsAIAwake_M_C1, loadData.IsCWDoorOpened_M_C1, loadData.IsHealthMachineFixed_T_C2, loadData.IsSmartFarmOpen_T_C2));
        }*/
    }
}




//GameData character = new GameData(false, false);
//SaveSystem.Save(character, "save_001");