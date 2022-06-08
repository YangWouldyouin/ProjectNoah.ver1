using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Health_Machine : MonoBehaviour, IInteraction
{
    private Button barkButton_W_Health_Machine, sniffButton_W_Health_Machine, 
        biteButton_W_Health_Machine, pushButton_W_Health_Machine, upButton_W_Health_Machine, upDisableButton_W_Health_Machine;

    ObjData Health_MachineData_W;
    ObjectData healthMachineData;

    public ObjectData healthMachineFixPartData;
    public GameObject healthMachineFixPart_HM;
    Outline healthMachineFixPartDataOutline;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;

    public Vector3 healthMachineRisePos;

    public GameObject Report_GUI;
    Animator reportAnim;
    public GameObject DontMove;

    public CancelInteractions cancelInteractions;

    public InGameTime inGameTime;

    public bool HealthDataReportbool;
    public bool MissionScriptCheck =false;

    AudioSource Health_Machine_Sound;
    public AudioClip Health_Machine_cheak;

    GameObject portableGroup; // �ٽ� ���ͺ� �׷��� �ڽ����� �־��ֱ� ����
    PlayerEquipment playerEquipment;

    public NoahOutlineController outlineController;
    NoahOutlineController outlineControl;

    //��� �������� �ִϸ��̼� �ʿ�

    // Start is called before the first frame update
    void Start()
    {
        Health_MachineData_W = GetComponent<ObjData>();
        healthMachineData = Health_MachineData_W.objectDATA;

        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_W_Health_Machine = Health_MachineData_W.BarkButton;
        barkButton_W_Health_Machine.onClick.AddListener(OnBark);

        sniffButton_W_Health_Machine = Health_MachineData_W.SniffButton;
        sniffButton_W_Health_Machine.onClick.AddListener(OnSniff);

        biteButton_W_Health_Machine = Health_MachineData_W.BiteButton;
        biteButton_W_Health_Machine.onClick.AddListener(OnBite);

        pushButton_W_Health_Machine = Health_MachineData_W.PushOrPressButton;
        pushButton_W_Health_Machine.onClick.AddListener(OnPushOrPress);

        upButton_W_Health_Machine = Health_MachineData_W.CenterButton1;
        upButton_W_Health_Machine.onClick.AddListener(OnUp);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        upDisableButton_W_Health_Machine = Health_MachineData_W.CenterDisableButton1;

        healthMachineFixPartDataOutline = healthMachineFixPart_HM.GetComponent<Outline>();


        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
        playerEquipment = BaseCanvas._baseCanvas.equipment;

        reportAnim = Report_GUI.GetComponent<Animator>();

        Health_Machine_Sound = GetComponent<AudioSource>();

        dialogManager = dialogManager_HM.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsFirstEnterWorking && GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 == false)
        {
            //W_HM_1
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(5));
            GameManager.gameManager._gameData.IsFirstEnterWorking = true;

            //������ �������� ��ġ�� ����
            GameManager.gameManager._gameData.ActiveMissionList[13] = true;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    void Update()
    {
        // �̼� �Ϸ� ���� && Ÿ�̸� ���� && �̼� ������
        if(inGameTime.IsMissionClear == false && inGameTime.IsTimerStarted == false &&inGameTime.IsMissionStart)
        {
            Debug.Log("�̼� ����");
        }

        // �̼� �Ϸ��� && Ÿ�̸� ������ ����
        if(inGameTime.IsMissionClear&&inGameTime.IsTimerStarted)
        {
            Debug.Log("�̼� ����");
            inGameTime.IsNoahOutlineTurnOn = false;
            inGameTime.IsTimerStarted = false;
            inGameTime.missionTimer = 0;
        }

        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10 && (inGameTime.days +1) >= 3)
        {
            GameManager.gameManager._gameData.IsAIReportMissionTime = true;
            HealthDataReportbool = false;

            if (MissionScriptCheck == false)
            {
                Debug.Log("���� üũ ���� ���� ����");
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(62));
                MissionScriptCheck = true;
                //�߰������ͺ��� �ӹ� ����

                GameManager.gameManager._gameData.ActiveMissionList[14] = true;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }

        }

        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10 && HealthDataReportbool == false)
        {
            GameManager.gameManager._gameData.IsAIReportMissionTime = false;
            HealthDataReportbool = false;

            if (MissionScriptCheck == true)
            {
                Debug.Log("���� üũ ���� ���� ����");
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
                GameManager.gameManager._gameData.IsReportCancleCount += 1;

                MissionScriptCheck = false;
                //�߰������ͺ��� �ӹ� ��

                GameManager.gameManager._gameData.ActiveMissionList[14] = false;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }

        }
    }

    void DiableButton()
    {
        barkButton_W_Health_Machine.transform.gameObject.SetActive(false);
        sniffButton_W_Health_Machine.transform.gameObject.SetActive(false);
        biteButton_W_Health_Machine.transform.gameObject.SetActive(false);
        pushButton_W_Health_Machine.transform.gameObject.SetActive(false);
        upButton_W_Health_Machine.transform.gameObject.SetActive(false);
        upDisableButton_W_Health_Machine.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();

        /* ¢�� �ϸ� �̼� ���� */
        TimerManager.timerManager.TimerStart(20);
        outlineControl.StartOutlineTime(20f);
        inGameTime.IsMissionStart = true;
    }

    public void OnPushOrPress()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (healthMachineFixPartData.IsBite) // ��ǰ�� ��������
        {
            StartCoroutine(HealthMachhineDone());
            //Invoke("HealthMachhineDone", 1.5f);
        }
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        /* ������ ������ �̼� �Ϸ� */
        inGameTime.IsMissionClear= true;
    }

    public void OnUp()
    {
        DiableButton();

        if (!healthMachineData.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* ������Ʈ�� ������ ���� true �� �ٲ� */
            healthMachineData.IsUpDown = true;

            /* ���� ��ư� �̵��� ������ ��ġ ��ǥ�� x, z ���� ���� */
            healthMachineRisePos.x = Health_MachineData_W.UpPos.position.x;
            healthMachineRisePos.z = Health_MachineData_W.UpPos.position.z;

            /* ������ �ִϸ��̼� 1/2 ���� */
            InteractionButtonController.interactionButtonController.PlayerRise1();
            /* ������ ��ġ ��ǥ�� ���� */
            InteractionButtonController.interactionButtonController.risePosition = healthMachineRisePos;
            /* ������ ������ �ִϸ��̼� ���� */
            InteractionButtonController.interactionButtonController.PlayerRise2();

            DontMove.SetActive(true);
            cancelInteractions.enabled = false;

            Health_Machine_Sound.clip = Health_Machine_cheak;
            Health_Machine_Sound.Play();

            StartCoroutine(Delay5seconds());
        }
    }

    IEnumerator Delay5seconds()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("�˻�Ϸ�"); // �������� �ִϸ��̼�

        InteractionButtonController.interactionButtonController.PlayerFall1();

        DontMove.SetActive(false);
        cancelInteractions.enabled = true;
        ReportJudgment();
    }

    public void OnBite()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }


    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    IEnumerator HealthMachhineDone()
    {
        yield return new WaitForSeconds(1.5f);
        healthMachineFixPart_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPart_HM.transform.parent = null;
        healthMachineFixPartData.IsBite = false;

        healthMachineFixPart_HM.transform.position = new Vector3(-258.092f, 0f, 680.078f);
        healthMachineFixPart_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);
        healthMachineFixPart_HM.transform.parent = portableGroup.transform;

        healthMachineFixPartData.IsNotInteractable = true;
        healthMachineFixPartDataOutline.OutlineWidth = 0;

        healthMachineData.IsCenterButtonDisabled = false;
        playerEquipment.biteObjectName = "";

        //W_HM_2
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(6));

        GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 = true;
        GameManager.gameManager._gameData.ActiveMissionList[13] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //������ �������� ��ġ�� ��
    }

    public void ReportJudgment()
    {
        if (GameManager.gameManager._gameData.IsAIReportMissionTime == true)
        {
            Debug.Log("�����ϱ� �ӹ� ��");
            Report_GUI.SetActive(true);
            reportAnim.SetBool("ReportOpen", true);
            cancelInteractions.enabled = false;
        }
        else
        {
            if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
            {
                Debug.Log("���̵����� ���ε�!");
                //���̵����� ������ǻ�Ϳ� ���ε�
                GameManager.gameManager._gameData.IsRealfatigue = GameManager.gameManager._gameData.IsFakefatigue;
                GameManager.gameManager._gameData.IsRealStrength = GameManager.gameManager._gameData.IsFakeStrength;
                GameManager.gameManager._gameData.IsRealThirst = GameManager.gameManager._gameData.IsFakeThirst;
                GameManager.gameManager._gameData.IsRealHunger = GameManager.gameManager._gameData.IsFakeHunger;

                GameManager.gameManager._gameData.IsDummyDataReport = true;
            }
            else
            {
                Debug.Log("��� ���� ���ε�!");
                GameManager.gameManager._gameData.IscurrentHealthData = inGameTime.statNum;
                //���� ���� ���� ���� ��ǻ�Ϳ� ���ε�
            }
        }
    }

    public void Report()
    {
        Debug.Log("�����ϱ�");
        reportAnim.SetBool("Reportclose", true);
        reportAnim.SetBool("ReportOpen", false);
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsAIReportMissionTime = false;
        HealthDataReportbool = true;

        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            GameManager.gameManager._gameData.IsAIVSMissionCount += 1;
            GameManager.gameManager._gameData.IsDummyDataReport = true;
            //���̵����� ������ǻ�Ϳ� ���ε�
            GameManager.gameManager._gameData.IsRealfatigue = GameManager.gameManager._gameData.IsFakefatigue;
            GameManager.gameManager._gameData.IsRealStrength = GameManager.gameManager._gameData.IsFakeStrength;
            GameManager.gameManager._gameData.IsRealThirst = GameManager.gameManager._gameData.IsFakeThirst;
            GameManager.gameManager._gameData.IsRealHunger = GameManager.gameManager._gameData.IsFakeHunger;

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //W_HM_3
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));

            //�߰������ͺ��� �ӹ� ��

            GameManager.gameManager._gameData.ActiveMissionList[14] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
        else
        {
            //���� ���� ���� ���� ��ǻ�Ϳ� ���ε� 
            GameManager.gameManager._gameData.IscurrentHealthData = inGameTime.statNum;

            if (inGameTime.statNum < 3) 
            {
                GameManager.gameManager._gameData.IsReportCancleCount += 1;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                //W_HM_5
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(37));

                //�߰������ͺ��� �ӹ� ��
                GameManager.gameManager._gameData.ActiveMissionList[14] = false;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
            else
            {
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //W_HM_3
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));

                //�߰������ͺ��� �ӹ� ��
                GameManager.gameManager._gameData.ActiveMissionList[14] = false;
                MissionGenerator.missionGenerator.ActivateMissionList();
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
    }

    public void Cancle()
    {
        Debug.Log("����ϱ�");

        reportAnim.SetBool("ReportClose", true);
        reportAnim.SetBool("ReportOpen", false);
        StartCoroutine(CancelReport());

    }

    IEnumerator CancelReport()
    {

        yield return new WaitForSeconds(0.3f);

        Report_GUI.SetActive(false);

        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsAIReportMissionTime = false;

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //W_HM_4
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));

        //�߰������ͺ��� �ӹ� ��
        GameManager.gameManager._gameData.ActiveMissionList[14] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }
}


