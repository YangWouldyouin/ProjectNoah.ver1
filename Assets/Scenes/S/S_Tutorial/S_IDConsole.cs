using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S_IDConsole : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject S_canIDCard;
/*    public GameObject S_BoxForConsole;*/

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_S_IDConsole, sniffButton_S_IDConsole, biteButton_S_IDConsole,
        pressButton_S_IDConsole, observeButton_S_IDConsole, observeDisableButton_S_IDConsole;


    /*ObjData*/
    ObjData iDConsoleData_S;
    public ObjectData canIDCardData_S;
/*    public ObjectData boxForConsoleData_S;*/

   /*�ƿ�����*/
   Outline iDConsoleOutline_S;
    Outline canIDCardOutline_S;

    /*BoxCollider*/
    BoxCollider IDConsole_Collider;
    BoxCollider BoxForConsole_Collider;

    void Start()
    {
        /*ObjData*/
        iDConsoleData_S = GetComponent<ObjData>();

        /*�ƿ�����*/
        iDConsoleOutline_S = GetComponent<Outline>();
        //canIDCardOutline_S = S_canIDCard.GetComponent<Outline>();

        /*BoxCollider*//*
        IDConsole_Collider = GetComponent<BoxCollider>();
        BoxForConsole_Collider = S_BoxForConsole.GetComponent<BoxCollider>();*/

        barkButton_S_IDConsole = iDConsoleData_S.BarkButton;
        barkButton_S_IDConsole.onClick.AddListener(OnBark);

        sniffButton_S_IDConsole = iDConsoleData_S.SniffButton;
        sniffButton_S_IDConsole.onClick.AddListener(OnSniff);

        biteButton_S_IDConsole = iDConsoleData_S.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_S_IDConsole = iDConsoleData_S.PushOrPressButton;
        pressButton_S_IDConsole.onClick.AddListener(OnPushOrPress);

        observeButton_S_IDConsole = iDConsoleData_S.CenterButton2;
        observeButton_S_IDConsole.onClick.AddListener(OnObserve);

        observeDisableButton_S_IDConsole = iDConsoleData_S.CenterButton1;

        //�ֿ����� Ʃ�丮�� ������ �Ϸ��ߴٸ� �� ������ �����Ѵ�.
        //S-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
    }

    void Update()
    {
/*
        if(boxForConsoleData_S.IsUpDown)
        {
            IDConsole_Collider.enabled = true;
            BoxForConsole_Collider.enabled = false;
        }

        else
        {

        }*/

        /*����� ���̰� å�� �ö� ���̰� �Ǵ��� Ȯ��*/
        if (iDConsoleData_S.IsCollision)
        {
            iDConsoleData_S.IsCenterButtonChanged = true;
            //S-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
        }

        else 
        {
            iDConsoleData_S.IsCenterButtonChanged = false;
        }
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

        if (canIDCardData_S.IsBite && iDConsoleData_S.IsObserve)
        {
            // ����� ����
            // �θ� �ڽ� ���踦 �����Ѵ�.
            S_canIDCard.GetComponent<Rigidbody>().isKinematic = false;
            S_canIDCard.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            S_canIDCard.transform.position = new Vector3(-30.153f, 1.054f, -25.293f); //��ġ ����
            S_canIDCard.transform.rotation = Quaternion.Euler(-53.609f, 0, 90); //���� ����

            // ī���е�� ī���� ��ȣ�ۿ��� �����Ѵ�.
            canIDCardData_S.IsNotInteractable = true;
            canIDCardOutline_S.OutlineWidth = 0;

            iDConsoleData_S.IsNotInteractable = true;
            iDConsoleOutline_S.OutlineWidth = 0;

            Invoke("CompleteCard",2f);
                    
        }
    }

    void CompleteCard()
    {
        CameraController.cameraController.CancelObserve();
        //S-4 ��� ��� �١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١١�
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