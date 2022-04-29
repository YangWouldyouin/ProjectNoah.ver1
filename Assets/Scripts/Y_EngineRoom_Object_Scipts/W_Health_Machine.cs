using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Health_Machine : MonoBehaviour
{
    private Button barkButton_W_Health_Machine, sniffButton_W_Health_Machine, biteButton_W_Health_Machine, pushButton_W_Health_Machine, upButton_W_Health_Machine, upDisableButton_W_Health_Machine;

    ObjData Health_MachineData_W;

    public GameObject healthMachineFixPart_HM;
    ObjData healthMachineFixPartData_HM;
    Outline healthMachineFixPartDataOutline;

    public GameObject dialogManager_HM;
    DialogManager dialogManager;

    public Transform healthMachinePos;
    public Vector3 healthMachineRisePos;

    public GameObject Report_GUI;
    public GameObject DontMove;

    public bool AIReprotMissionTime = false;

    public CancelInteractions cancelInteractions;

    //��� �������� �ִϸ��̼� �ʿ�
    //���� ���� üũ
    //��� ���� ����/���̵����� ���� ������ǻ�ͷ� ����
    //���̾�α� ����

    // Start is called before the first frame update
    void Start()
    {
        Health_MachineData_W = GetComponent<ObjData>();
        healthMachineFixPartData_HM = healthMachineFixPart_HM.GetComponent<ObjData>();
        healthMachineFixPartDataOutline = healthMachineFixPart_HM.GetComponent<Outline>();

        dialogManager = dialogManager_HM.GetComponent<DialogManager>();

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

        AIReprotMissionTime = true;
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

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Health_MachineData_W.IsPushOrPress = false;
    }

    public void OnBark()
    {
        Health_MachineData_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        Health_MachineData_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());


        if (healthMachineFixPartData_HM.IsBite) // ��ǰ�� ��������
        {
            Invoke("HealthMachhineDone", 1.5f);
        }
    }

    public void OnSniff()
    {
        Health_MachineData_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        DiableButton();

        if (!Health_MachineData_W.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            /* ������Ʈ�� ������ ���� true �� �ٲ� */
            Health_MachineData_W.IsUpDown = true;

            /* ���� ��ư� �̵��� ������ ��ġ ��ǥ�� x, z ���� ���� */
            healthMachineRisePos.x = healthMachinePos.position.x;
            healthMachineRisePos.z = healthMachinePos.position.z;

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
        healthMachineFixPartData_HM.GetComponent<Rigidbody>().isKinematic = false;
        healthMachineFixPartData_HM.transform.parent = null;

        healthMachineFixPartData_HM.transform.position = new Vector3(-258.092f, 538.404f, 680.078f);
        healthMachineFixPartData_HM.transform.rotation = Quaternion.Euler(-90, 0, 0);

        healthMachineFixPartData_HM.IsNotInteractable = true;
        healthMachineFixPartDataOutline.OutlineWidth = 0;

        Health_MachineData_W.IsCenterButtonDisabled = false;

        //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(7));

        GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void ReportJudgment()
    {
        if (AIReprotMissionTime == true)
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
        AIReprotMissionTime = false;

        if (GameManager.gameManager._gameData.IsFakeHealthData_Tablet)
        {
            //���̵����� ������ǻ�Ϳ� ���ε�
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //Ȯ�εǾ����ϴ�. AI ��� ���
        }
        else
        {
            //if (��� ���� < 30) 
            //{
            //    GameManager.gameManager._gameData.IsReportCancleCount += 1;
            //    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //    //���� ���� ����� ���� ������ �ӹ����� �����ϵ��� �ϰڽ��ϴ�. AI ��� ���
            //}
            
            //���� ���� ���� ���� ��ǻ�Ϳ� ���ε� 
        }
    }

    public void Cancle()
    {
        Debug.Log("����ϱ�");
        Report_GUI.SetActive(false);
        cancelInteractions.enabled = true;

        GameManager.gameManager._gameData.IsReportCancleCount += 1;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //�ӹ��� ������ ������ ������ �ӹ����� �����ϵ��� �ϰڽ��ϴ�. AI ��� ���
        AIReprotMissionTime = false;
    }
}
