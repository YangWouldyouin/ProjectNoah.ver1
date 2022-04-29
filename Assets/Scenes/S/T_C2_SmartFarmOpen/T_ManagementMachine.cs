using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ManagementMachine : MonoBehaviour, IInteraction
{
    public Animator smartFarmDoorAnim_T;

    /*�����ִ� ������Ʈ*/
    public GameObject T_canIronPlateDoor;
    public GameObject T_canTroubleLine2;
    public GameObject T_canLineHome2;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_ManagementMachine, sniffButton_T_ManagementMachine, biteButton_T_ManagementMachine,
        pressButton_T_ManagementMachine, observeButton_T_canIronPlateDoor;

    ObjData managementMachineData_T;
    ObjData canIronPlateDoorData_T;
    ObjData canTroubleLine2Data_T;
    ObjData canDoLineHome2Data_T;

    Outline canIronPlateDoorOutline_T;
    Outline canTroubleLine2Outline_T;
    Outline canLineHome2Outline_T;

    //BoxCollider ironPlateCollider_T;

    void Start()
    {
        managementMachineData_T = GetComponent<ObjData>();
        canIronPlateDoorData_T = T_canIronPlateDoor.GetComponent<ObjData>();
        canTroubleLine2Data_T = T_canTroubleLine2.GetComponent<ObjData>();
        canDoLineHome2Data_T = T_canLineHome2.GetComponent<ObjData>();

        canIronPlateDoorOutline_T = T_canIronPlateDoor.GetComponent<Outline>();
        canTroubleLine2Outline_T = T_canTroubleLine2.GetComponent<Outline>();
        canLineHome2Outline_T = T_canLineHome2.GetComponent<Outline>();

        // ironPlateCollider_T = T_canIronPlateDoor.GetComponent<BoxCollider>();


        barkButton_T_ManagementMachine = managementMachineData_T.BarkButton;
        barkButton_T_ManagementMachine.onClick.AddListener(OnBark);

        sniffButton_T_ManagementMachine = managementMachineData_T.SniffButton;
        sniffButton_T_ManagementMachine.onClick.AddListener(OnSniff);

        biteButton_T_ManagementMachine = managementMachineData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_ManagementMachine = managementMachineData_T.PushOrPressButton;
        pressButton_T_ManagementMachine.onClick.AddListener(OnPushOrPress);

        observeButton_T_canIronPlateDoor = managementMachineData_T.CenterButton1;
        observeButton_T_canIronPlateDoor.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        if(managementMachineData_T.IsObserve && GameManager.gameManager._gameData.IsIronDisappear_T_C2)
        {
            canTroubleLine2Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            canTroubleLine2Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.
        }

        else
        {
            canTroubleLine2Data_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            canTroubleLine2Outline_T.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.
        }

        if (managementMachineData_T.IsObserve && GameManager.gameManager._gameData.IsOutTroubleLine2_T_C2)
        {
            canDoLineHome2Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            canLineHome2Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.
        }

        else
        {
            canDoLineHome2Data_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            canLineHome2Outline_T.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.
        }

        if (managementMachineData_T .IsBark && GameManager.gameManager._gameData.IsSmartFarmFix_T_C2)
        {
            Invoke("SmartFarmOpen", 2f);
        }
    }
    void DisableButton()
    {
        barkButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        sniffButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        biteButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        pressButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        observeButton_T_canIronPlateDoor.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        managementMachineData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        managementMachineData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    void SmartFarmOpen()
    {
        smartFarmDoorAnim_T.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim_T.SetBool("FarmDoorStop", true);
    }

    public void OnPushOrPress()
    {
        managementMachineData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        managementMachineData_T.IsPushOrPress = false;
    }

    public void OnObserve()
    {
        managementMachineData_T.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = managementMachineData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        canIronPlateDoorData_T.IsNotInteractable = false;
        canIronPlateDoorOutline_T.OutlineWidth = 8;


/*        if (canIronPlateDoorData_T.IsBite)
        {
            // �θ� �ڽ� ���踦 �����Ѵ�.
            T_canIronPlateDoor.GetComponent<Rigidbody>().isKinematic = false;
            T_canIronPlateDoor.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            T_canIronPlateDoor.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //��ġ ����
            T_canIronPlateDoor.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
            T_canIronPlateDoor.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����

            // ���� �� �̻� ��ȣ�ۿ� �Ұ�
            canIronPlateDoorData_T.IsNotInteractable = true;
            canIronPlateDoorOutline_T.OutlineWidth = 0;

            //�ݶ��̴��� ����.
            ironPlateCollider_T.enabled = false;
            IsIronDisappear_T = true;
        }*/
    }

    public void OnBite()
    {

    }

    public void OnEat()
    {

    }

    public void OnInsert()
    {

    }

    public void OnSmash()
    {
        
    }

    public void OnUp()
    {
        
    }
}
