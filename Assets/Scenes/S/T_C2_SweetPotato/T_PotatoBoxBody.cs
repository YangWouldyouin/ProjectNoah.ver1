using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PotatoBoxBody : MonoBehaviour, IInteraction
{

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_PotatoBoxBody, sniffButton_T_PotatoBoxBody, biteButton_T_PotatoBoxBody,
        pressButton_T_PotatoBoxBody, observeButton_T_PotatoBoxBody;

    /*ObjData*/
    ObjData potatoBoxBodyData_T;
    public ObjectData IsPotatoBoxBodyData_T;

    public ObjectData IsBadSweetPotato1Data_T;
    public ObjectData IsHealthySweetPotato1Data_T;
    public ObjectData IsUnGrownSweetPotato1Data_T;

    /*Outline*/
    public Outline IsBadSweetPotato1Outline_T;
    public Outline IsHealthySweetPotato1Outline_T;
    public Outline IsUnGrownSweetPotato1Outline_T;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    BoxCollider PotatoBoxBody_Collider;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();
        
        PotatoBoxBody_Collider = GetComponent<BoxCollider>();


        /*ObjData*/
        potatoBoxBodyData_T = GetComponent<ObjData>();

        /*ObjData*/
        barkButton_T_PotatoBoxBody = potatoBoxBodyData_T.BarkButton;
        barkButton_T_PotatoBoxBody.onClick.AddListener(OnBark);

        sniffButton_T_PotatoBoxBody = potatoBoxBodyData_T.SniffButton;
        sniffButton_T_PotatoBoxBody.onClick.AddListener(OnSniff);

        biteButton_T_PotatoBoxBody = potatoBoxBodyData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_PotatoBoxBody = potatoBoxBodyData_T.PushOrPressButton;
        pressButton_T_PotatoBoxBody.onClick.AddListener(OnPushOrPress);

        observeButton_T_PotatoBoxBody = potatoBoxBodyData_T.CenterButton1;
        observeButton_T_PotatoBoxBody.onClick.AddListener(OnObserve);

    }

    void DisableButton()
    {
        barkButton_T_PotatoBoxBody.transform.gameObject.SetActive(false);
        sniffButton_T_PotatoBoxBody.transform.gameObject.SetActive(false);
        biteButton_T_PotatoBoxBody.transform.gameObject.SetActive(false);
        pressButton_T_PotatoBoxBody.transform.gameObject.SetActive(false);
        observeButton_T_PotatoBoxBody.transform.gameObject.SetActive(false);

    }

    void Update()
    {
        if(!potatoBoxBodyData_T.IsObserve)
        {
            PotatoBoxBody_Collider.enabled = true;
        }
    }

    public void OnSmash()
    {

    }

    void ByePotatoBox()
    {

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

        CameraController.cameraController.currentView = potatoBoxBodyData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        Debug.Log("potato");
        // �θ� ��Ȱ��ȭ, �ڽ� Ȱ��ȭ ��� �� ������Ʈ�� ���缭 �ʿ��� �͵� ����
        IsBadSweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsBadSweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        IsHealthySweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsHealthySweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        IsUnGrownSweetPotato1Data_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        IsUnGrownSweetPotato1Outline_T.OutlineWidth = 8; // �ƿ����ε� ���ݴϴ�.

        PotatoBoxBody_Collider.enabled = false;

        //A-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(16));
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
