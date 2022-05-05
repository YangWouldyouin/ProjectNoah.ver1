using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PotatoBox : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject SweetPotatoBoxDoor_T;
    public GameObject IsBadSweetPotato1_T;
    public GameObject IsHealthySweetPotato1_T;
    public GameObject IsUnGrownSweetPotato1_T;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_PotatoBox, sniffButton_T_PotatoBox, biteButton_T_PotatoBox,
        pressButton_T_PotatoBox, observeButton_T_PotatoBox, observeDisableButton_T_PotatoBox;

    /*ObjData*/
    ObjData PotatoBoxData_T;
    ObjData IsBadSweetPotato1Data_T;
    ObjData IsHealthySweetPotato1Data_T;
    ObjData IsUnGrownSweetPotato1Data_T;

    /*Outline*/
    Outline IsBadSweetPotato1Outline_T;
    Outline IsHealthySweetPotato1Outline_T;
    Outline IsUnGrownSweetPotato1Outline_T;

    void Start()
    {
        /*ObjData*/
        PotatoBoxData_T = GetComponent<ObjData>();
        IsBadSweetPotato1Data_T = IsBadSweetPotato1_T.GetComponent<ObjData>();
        IsHealthySweetPotato1Data_T = IsHealthySweetPotato1_T.GetComponent<ObjData>();
        IsUnGrownSweetPotato1Data_T = IsUnGrownSweetPotato1_T.GetComponent<ObjData>();

        /*Outline*/
        IsBadSweetPotato1Outline_T = IsBadSweetPotato1_T.GetComponent<Outline>();
        IsHealthySweetPotato1Outline_T = IsHealthySweetPotato1_T.GetComponent<Outline>();
        IsUnGrownSweetPotato1Outline_T = IsUnGrownSweetPotato1_T.GetComponent<Outline>();

        /*ObjData*/
        barkButton_T_PotatoBox = PotatoBoxData_T.BarkButton;
        barkButton_T_PotatoBox.onClick.AddListener(OnBark);

        sniffButton_T_PotatoBox = PotatoBoxData_T.SniffButton;
        sniffButton_T_PotatoBox.onClick.AddListener(OnSniff);

        biteButton_T_PotatoBox = PotatoBoxData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_PotatoBox = PotatoBoxData_T.PushOrPressButton;
        pressButton_T_PotatoBox.onClick.AddListener(OnPushOrPress);

        observeButton_T_PotatoBox = PotatoBoxData_T.CenterButton1;
        observeButton_T_PotatoBox.onClick.AddListener(OnObserve);

        observeDisableButton_T_PotatoBox = PotatoBoxData_T.CenterButton2;

        if(PotatoBoxData_T.IsClicked)
        {
            //A-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
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
        PotatoBoxData_T.IsSmash = true;

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

        PotatoBoxData_T.IsCenterButtonChanged = true;

        IsBadSweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsBadSweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        IsHealthySweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsHealthySweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        IsUnGrownSweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsUnGrownSweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.


        //A-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١�


    }

    public void OnBark()
    {
        PotatoBoxData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        PotatoBoxData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());
    }


    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        PotatoBoxData_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        PotatoBoxData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        PotatoBoxData_T.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = PotatoBoxData_T.ObserveView;

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
