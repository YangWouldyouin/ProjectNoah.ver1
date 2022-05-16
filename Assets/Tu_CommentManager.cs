using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tu_CommentManager : MonoBehaviour
{
    public DialogManager dialog;
    DialogManager dialogManager;

    public GameObject newsUI;

    public ObjectData cardData;
    public InGameTime timerData;

    public bool check01;
    public bool check02;

    public GameObject StartAnim;
    public GameObject PassAnim;
    public GameObject EndAnim;

    public GameObject LoadingAnim;

    public GameObject condition;
    public GameObject smell;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        GameManager.gameManager._gameData.IsBasicTuto = false;
        GameManager.gameManager._gameData.IsEndTuto = false;
        GameManager.gameManager._gameData.afterFirstTalk = false;
        GameManager.gameManager._gameData.afterNewsTalk = false;

        cardData.IsBite = false;
        cardData.IsNotInteractable = false;
        timerData.IsTimerStarted = false;

        StartCoroutine(Dalay1());

        Invoke("ShowCon", 30f);

        //Invoke("TutoBye", 5f);


        //GameManager.gameManager._gameData.afterFirstTalk = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager._gameData.IsEndTuto &&  !GameManager.gameManager._gameData.afterFirstTalk && !check01)
        {
            Invoke("NewsTalk", 73f);
            check01 = true;
        }

        if (GameManager.gameManager._gameData.afterFirstTalk && !GameManager.gameManager._gameData.afterNewsTalk && !check02)
        {
            Invoke("TuTalkEnd", 43f);
            //Invoke("TuTalkEnd", 5f);
            check02 = true;
        }
    }

    void NewsTalk()
    {
        //����â �˾� ������ ������~!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        newsUI.SetActive(true);

        Debug.Log("������ȭ ����");

        GameManager.gameManager._gameData.afterFirstTalk = true;
        Invoke("MikeNews", 4f);
        
    }

    void TuTalkEnd()
    {
        Debug.Log("������ ��ȭ ����");

        GameManager.gameManager._gameData.afterNewsTalk = true;

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(64));
        Invoke("MikeLast", 0.1f);

        Invoke("StartPassing", 27f);
        Invoke("TuEnd", 47f);
    }

    void TuEnd()
    {
        EndAnim.SetActive(true);
        GameManager.gameManager._gameData.IsDisqualifiedEnd = true;

        Invoke("TutoBye", 3f);

        //Ʃ�丮�� ������ ���� üũ
        //ȭ�� ����
        //Ʃ�� �� ���� ���� ���������� ����
    }

    void StartPassing()
    {
        PassAnim.SetActive(true);
        Destroy(PassAnim, 4f);
    }

    void MikeNews()
    {
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(25));
    }

    void MikeLast()
    {
        //GameManager.gameManager._gameData.IsTutorialClear = true;
        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(26));
    }


/*    void Delay()
    {
        StartAnim.SetActive(true);
        Destroy(StartAnim, 4f);
        Destroy(LoadingAnim, 3f);
    }*/

    IEnumerator Dalay1()
    {
        yield return new WaitForSeconds(16f);
        StartAnim.SetActive(true);
        Destroy(StartAnim, 4f);
        Destroy(LoadingAnim, 3f);

    }

    void TutoBye()
    {
        GameManager.gameManager._gameData.statNum = 10;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        timerData.days = 0;
        timerData.hours = 0;
        timerData.timer = 0;

        slManagerload();
        SceneManager.LoadScene("new cockpit");
    }

    void ShowCon()
    {
        condition.SetActive(false);
    }

    public void slManagerload()
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
        //character.IsBasicTuto = false; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ�
        //character.IsMiddleTuto = false; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ� Ȯ��
        //character.IsRealMiddleTuto = false; //Ʃ�丮�� �� ��Ʈ ��¥ �Ϸ�
        //character.IsEndTuto = false; //Ʃ�丮�� ���� �Ϸ�
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
    }
}
