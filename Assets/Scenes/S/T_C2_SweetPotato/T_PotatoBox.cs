using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PotatoBox : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject SweetPotatoBoxDoor_T;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_PotatoBox, sniffButton_T_PotatoBox, biteButton_T_PotatoBox,
        pressButton_T_PotatoBox, observeButton_T_PotatoBox, observeDisableButton_T_PotatoBox;

    /*ObjData*/
    ObjData PotatoBoxObjData_T;
    public ObjectData PotatoBoxData_T;

    public ObjectData IsBadSweetPotato1Data_T;
    public ObjectData IsHealthySweetPotato1Data_T;
    public ObjectData IsUnGrownSweetPotato1Data_T;

    /*Outline*/
    public Outline IsBadSweetPotato1Outline_T;
    public Outline IsHealthySweetPotato1Outline_T;
    public Outline IsUnGrownSweetPotato1Outline_T;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        /*ObjData*/
        PotatoBoxObjData_T = GetComponent<ObjData>();

        /*ObjData*/
        barkButton_T_PotatoBox = PotatoBoxObjData_T.BarkButton;
        barkButton_T_PotatoBox.onClick.AddListener(OnBark);

        sniffButton_T_PotatoBox = PotatoBoxObjData_T.SniffButton;
        sniffButton_T_PotatoBox.onClick.AddListener(OnSniff);

        biteButton_T_PotatoBox = PotatoBoxObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_PotatoBox = PotatoBoxObjData_T.PushOrPressButton;
        pressButton_T_PotatoBox.onClick.AddListener(OnPushOrPress);

        observeButton_T_PotatoBox = PotatoBoxObjData_T.CenterButton1;
        observeButton_T_PotatoBox.onClick.AddListener(OnObserve);

        observeDisableButton_T_PotatoBox = PotatoBoxObjData_T.CenterButton2;

        if(PotatoBoxData_T.IsClicked)
        {
            //A-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(15));
        }

    }

    void DisableButton()
    {
        barkButton_T_PotatoBox.transform.gameObject.SetActive(false);
        sniffButton_T_PotatoBox.transform.gameObject.SetActive(false);
        biteButton_T_PotatoBox.transform.gameObject.SetActive(false);
        pressButton_T_PotatoBox.transform.gameObject.SetActive(false);
        observeButton_T_PotatoBox.transform.gameObject.SetActive(false);
        observeDisableButton_T_PotatoBox.transform.gameObject.SetActive(false);

    }


    public void OnSmash()
    {

        DisableButton();

        /* ������Ʈ ���� �ִϸ��̼� ����*/
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* �ı��ϱ� ���� ���� (2�� �����̰� �ִϸ��̼��� �ڿ�������) */
        Invoke("ByePotatoBox", 2f);

        /* ������Ʈ ���� �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.PlayerSmash2();

    }

    void ByePotatoBox()
    {
        // �θ� ��Ȱ��ȭ, �ڽ� Ȱ��ȭ ��� �� ������Ʈ�� ���缭 �ʿ��� �͵� ����
        SweetPotatoBoxDoor_T.SetActive(false);

        PotatoBoxObjData_T.IsCenterButtonChanged = true;

        IsBadSweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsBadSweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        IsHealthySweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsHealthySweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        IsUnGrownSweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsUnGrownSweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.


        //A-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(16));


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
    }

    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = PotatoBoxObjData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();
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



    public void OnUp()
    {
       
    }
}
