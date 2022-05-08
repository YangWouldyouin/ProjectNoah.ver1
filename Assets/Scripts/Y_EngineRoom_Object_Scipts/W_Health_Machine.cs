using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Health_Machine : MonoBehaviour
{
    private Button barkButton_W_Health_Machine, sniffButton_W_Health_Machine, biteButton_W_Health_Machine, pushButton_W_Health_Machine, upButton_W_Health_Machine, upDisableButton_W_Health_Machine;

    ObjData Health_MachineData_W;

    public ObjectData healthMachineData;
    public ObjectData healthMachineFixPartData;

    public GameObject healthMachineFixPart_HM;
    Outline healthMachineFixPartDataOutline;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;

    public Vector3 healthMachineRisePos;

    public GameObject Report_GUI;
    public GameObject DontMove;

    public CancelInteractions cancelInteractions;

    public InGameTime inGameTime;

    public bool HealthDataReportbool;

    //��� �������� �ִϸ��̼� �ʿ�
    //��� ���� ����/���̵����� ���� ������ǻ�ͷ� ����

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_HM.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsFirstEnterWorking)
        {
            //W_HM_1
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(5));
            GameManager.gameManager._gameData.IsFirstEnterWorking = true;

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }


        Health_MachineData_W = GetComponent<ObjData>();
        healthMachineFixPartDataOutline = healthMachineFixPart_HM.GetComponent<Outline>();

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
    }

    void Update()
    {
        if ((inGameTime.days + 1) % 2 != 0 && (inGameTime.hours) == 10)
        {
            Debug.Log("���� üũ ���� ���� ����");
            GameManager.gameManager._gameData.IsAIReportMissionTime = true;
            HealthDataReportbool = false;

            //W_HM_��������
        }
        if ((inGameTime.days + 1) % 2 == 0 && (inGameTime.hours) == 10 && HealthDataReportbool == false)
        {
            Debug.Log("���� üũ ���� ���� ����");
            GameManager.gameManager._gameData.IsAIReportMissionTime = false;
            HealthDataReportbool = false;

            GameManager.gameManager._gameData.IsReportCancleCount += 1;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
        }
    }

    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
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
    }

    public void OnPushOrPress()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (healthMachineFixPartData.IsBite) // ��ǰ�� ��������
        {
            Invoke("HealthMachhineDone", 1.5f);
        }
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
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
            StartCoroutine(Delay3seconds());
        }
    }

    IEnumerator Delay3seconds()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("�˻�Ϸ�"); // �������� �ִϸ��̼�
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

    public void HealthMachhineDone()
    {
        healthMachineFixPart_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPart_HM.transform.parent = null;

        healthMachineFixPart_HM.transform.position = new Vector3(-258.092f, 0f, 680.078f);
        healthMachineFixPart_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);

        healthMachineFixPartData.IsNotInteractable = true;
        healthMachineFixPartDataOutline.OutlineWidth = 0;

        healthMachineData.IsCenterButtonDisabled = false;

        //W_HM_2
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(6));

        GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void ReportJudgment()
    {
        if (GameManager.gameManager._gameData.IsAIReportMissionTime == true)
        {
            Debug.Log("�����ϱ� �ӹ� ��");
            Report_GUI.SetActive(true);
            cancelInteractions.enabled = false;
        }
        else
        {
            if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
            {
                Debug.Log("���̵����� ���ε�!");
                //���̵����� ������ǻ�Ϳ� ���ε�
            }
            else
            {
                Debug.Log("��� ���� ���ε�!");
                //���� ���� ���� ���� ��ǻ�Ϳ� ���ε�
            }
        }
    }

    public void Report()
    {
        Debug.Log("�����ϱ�");
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsAIReportMissionTime = false;
        HealthDataReportbool = true;

        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            GameManager.gameManager._gameData.IsAIVSMissionCount += 1;

            //���̵����� ������ǻ�Ϳ� ���ε�
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //W_HM_3
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));
        }
        else
        {
            //���� ���� ���� ���� ��ǻ�Ϳ� ���ε� 

            //if (��� ���� < 30) 
            //{
            //    GameManager.gameManager._gameData.IsReportCancleCount += 1;
            //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //    //W_HM_5
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(37));
            //}
            //else
            //{
            //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //    //W_HM_3
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(35));
            //}
        }
    }

    public void Cancle()
    {
        Debug.Log("����ϱ�");
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsAIReportMissionTime = false;

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //W_HM_4
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(36));
    }
}
