using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S_IDConsole : MonoBehaviour, IInteraction
{
    /*Ŭ����� �ٽ� �ȳ�����*/
    //public bool StopIDConsoleSpeak = false;

    //public PlayerEquipment playerEquipment;

    /*�����ִ� ������Ʈ*/
    public GameObject S_canIDCard;
    public GameObject IsIDInsertPad;
    /*    public GameObject S_BoxForConsole;*/
    //public GameObject canPressCabinetDoor; 


    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_S_IDConsole, sniffButton_S_IDConsole, biteButton_S_IDConsole,
        pressButton_S_IDConsole, observeButton_S_IDConsole, observeDisableButton_S_IDConsole;


    /*ObjData*/
    ObjData iDConsoleData_S;
    public ObjectData IDConsoleData_S;
    public ObjectData canIDCardData_S;
    /*    public ObjectData boxForConsoleData_S;*/
    public ObjectData boxData;

   /*�ƿ�����*/
   Outline iDConsoleOutline_S;
    Outline canIDCardOutline_S;

    /*BoxCollider*/
    BoxCollider IDConsole_Collider;
    BoxCollider BoxForConsole_Collider;
    //BoxCollider canPressCabinetDoor_Collider;
    BoxCollider IsIDInsertPad_Collider;

    public bool firstCheck = false;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {

        dialogManager = dialog.GetComponent<DialogManager>();

        /*ObjData*/
        iDConsoleData_S = GetComponent<ObjData>();

        /*�ƿ�����*/
        iDConsoleOutline_S = GetComponent<Outline>();
        canIDCardOutline_S = S_canIDCard.GetComponent<Outline>();



        /*BoxCollider*/
        IDConsole_Collider = GetComponent<BoxCollider>();
        /*
        IDConsole_Collider = GetComponent<BoxCollider>();
        BoxForConsole_Collider = S_BoxForConsole.GetComponent<BoxCollider>();*/
        IsIDInsertPad_Collider = IsIDInsertPad.GetComponent<BoxCollider>();


        //canPressCabinetDoor_Collider = canPressCabinetDoor.GetComponent<BoxCollider>();

        barkButton_S_IDConsole = iDConsoleData_S.BarkButton;
        barkButton_S_IDConsole.onClick.AddListener(OnBark);

        sniffButton_S_IDConsole = iDConsoleData_S.SniffButton;
        sniffButton_S_IDConsole.onClick.AddListener(OnSniff);

        biteButton_S_IDConsole = iDConsoleData_S.BiteButton;
        biteButton_S_IDConsole.onClick.AddListener(OnBite);

        pressButton_S_IDConsole = iDConsoleData_S.PushOrPressButton;
        pressButton_S_IDConsole.onClick.AddListener(OnPushOrPress);

        observeButton_S_IDConsole = iDConsoleData_S.CenterButton2;
        observeButton_S_IDConsole.onClick.AddListener(OnObserve);

        observeDisableButton_S_IDConsole = iDConsoleData_S.CenterButton1;

        firstCheck = false;

        IDConsoleData_S.IsCenterButtonChanged = false;
        IDConsoleData_S.IsObserve = false;
        IDConsoleData_S.IsSniff = false;
        IDConsoleData_S.IsBark = false;
        IDConsoleData_S.IsNotInteractable = false;



    }

    void Update()
    {
        if (GameManager.gameManager._gameData.IsBasicTuto && !firstCheck)
        {
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(15));
            firstCheck = true;
        }

        /*ID �ܼ� ���� �Ϸ��Ŀ��� StopIDConsoleSpeak �� Ʈ�簡 �Ǿ �� �̻� ��� �ȳ���*/
        if (IDConsoleData_S.IsClicked && GameManager.gameManager._gameData.StopIDConsoleSpeak == false && !boxData.IsUpDown)
        {
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(16));

            IDConsoleData_S.IsClicked = false;
        }

        if(IDConsoleData_S.IsObserve)
        {
            IDConsole_Collider.enabled = false;
            IsIDInsertPad_Collider.enabled = true;
        }

        else
        {
            IDConsole_Collider.enabled = true;
            IsIDInsertPad_Collider.enabled = false;
        }

/*
        if(boxForConsoleData_S.IsUpDown)
        {
            IDConsole_Collider.enabled = true;
            BoxForConsole_Collider.enabled = false;
        }

        else
        {

        }*/

        /*����� ���̰� å�� �ö� ���̰� �Ǵ��� Ȯ��*//*
        if (IDConsoleData_S.IsCollision)
        {
            IDConsoleData_S.IsCenterButtonChanged = true;

        }

        else 
        {
            IDConsoleData_S.IsCenterButtonChanged = false;
        }*/


/*        if (IDConsoleData_S.IsObserve)
        {
            IDConsoleData_S.IsNotInteractable = false;
            iDConsoleOutline_S.OutlineWidth = 8;

        }*/
    }



    void DisableButton()
    {
        barkButton_S_IDConsole.transform.gameObject.SetActive(false);
        sniffButton_S_IDConsole.transform.gameObject.SetActive(false);
        biteButton_S_IDConsole.transform.gameObject.SetActive(false);
        pressButton_S_IDConsole.transform.gameObject.SetActive(false);
        observeButton_S_IDConsole.transform.gameObject.SetActive(false);
        observeDisableButton_S_IDConsole.transform.gameObject.SetActive(false);

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

        CameraController.cameraController.currentView = iDConsoleData_S.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        //S-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintSubtitles(19));

        /*        IDConsoleData_S.IsNotInteractable = false;
                iDConsoleOutline_S.OutlineWidth = 8;*/

    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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
