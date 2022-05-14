using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_IDInsertPad : MonoBehaviour, IInteraction
{
    public PlayerEquipment playerEquipment;
   
    /*�����ִ� ������Ʈ*/
    public GameObject canPressCabinetDoor;
    public GameObject RealIDCard; // ī��Ű
    public GameObject RealIDConsole;


    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_S_IDInsertPad, sniffButton_S_IDInsertPad, biteButton_S_IDInsertPad,
        pressButton_S_IDInsertPad, noCenterButton_S_IDInsertPad; // eatDisableButton_T_SuperDrug;

    /*�ƿ�����*/
    public Outline realIDConsoleOutline_S;
    public Outline realIDCardOutline_S;

    /*ObjData*/
    ObjData IDInsertPadData_S;
    public ObjectData realIDConsoleData_S; //�ܼ�
    public ObjectData realIDCardData_S; // ī��

    /*BoxCollider*/
    BoxCollider IDInsertPad_Collider;
    BoxCollider canPressCabinetDoor_Collider;
    BoxCollider realIDInConsole_Collider;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {
        /*BoxCollider*/
        IDInsertPad_Collider = GetComponent<BoxCollider>();
        canPressCabinetDoor_Collider = canPressCabinetDoor.GetComponent<BoxCollider>();
        realIDInConsole_Collider = RealIDConsole.GetComponent<BoxCollider>();

        dialogManager = dialog.GetComponent<DialogManager>();

        /*�ƿ�����*//*
        realIDConsoleOutline_S = GetComponent<Outline>();
        realIDCardOutline_S = RealIDCard.GetComponent<Outline>();*/

        /*ObjData*/
        IDInsertPadData_S = GetComponent<ObjData>();

        barkButton_S_IDInsertPad = IDInsertPadData_S.BarkButton;
        barkButton_S_IDInsertPad.onClick.AddListener(OnBark);

        sniffButton_S_IDInsertPad = IDInsertPadData_S.SniffButton;
        sniffButton_S_IDInsertPad.onClick.AddListener(OnSniff);

        biteButton_S_IDInsertPad = IDInsertPadData_S.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_S_IDInsertPad = IDInsertPadData_S.PushOrPressButton;
        pressButton_S_IDInsertPad.onClick.AddListener(OnPushOrPress);

        noCenterButton_S_IDInsertPad = IDInsertPadData_S.CenterButton1;
        //noCenterButton_T_SuperDrug.onClick.AddListener(OnEat);

        //eatDisableButton_T_SuperDrug = SuperDrugData_T.CenterDisableButton1;


        IDInsertPad_Collider.enabled = false;
    }


    void DisableButton()
    {
        barkButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        sniffButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        biteButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        pressButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        noCenterButton_S_IDInsertPad.transform.gameObject.SetActive(false);
        //eatDisableButton_T_SuperDrug.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        if (realIDCardData_S.IsBite && realIDConsoleData_S.IsObserve)
        {
            // ����� ����
            // �θ� �ڽ� ���踦 �����Ѵ�.
            RealIDCard.GetComponent<Rigidbody>().isKinematic = false;
            RealIDCard.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            RealIDCard.transform.position = new Vector3(-30.153f, 1.054f, -25.293f); //��ġ ����
            RealIDCard.transform.rotation = Quaternion.Euler(-53.609f, 0, 90); //���� ����

            // ī���е�� ī���� ��ȣ�ۿ��� �����Ѵ�.
            realIDCardData_S.IsNotInteractable = true;
            realIDCardOutline_S.OutlineWidth = 0;

            realIDInConsole_Collider.enabled = false;
            realIDConsoleData_S.IsNotInteractable = true;
            realIDConsoleOutline_S.OutlineWidth = 0;
            playerEquipment.biteObjectName = "";
            Invoke("CompleteCard", 1f);

            /*ID �ܼ� ���� �Ϸ��Ŀ��� StopIDConsoleSpeak �� Ʈ�簡 �Ǿ �� �̻� ��� �ȳ���*/
            GameManager.gameManager._gameData.StopIDConsoleSpeak = true;

            /*Ʃ�丮�� �߰� �Ϸ�*/
            GameManager.gameManager._gameData.IsMiddleTuto = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //�ݶ��̴� ���ִ°�
            canPressCabinetDoor_Collider.enabled = true;

            //S-5 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(21));

            IDInsertPad_Collider.enabled = false;
        }

    }

    void CompleteCard()
    {
        CameraController.cameraController.CancelObserve();
        //S-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(20));
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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

    public void OnObserve()
    {
        
    }

    public void OnSmash()
    {
        
    }

    public void OnUp()
    {
        
    }
}
