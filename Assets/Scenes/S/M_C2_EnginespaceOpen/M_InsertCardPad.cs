using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_InsertCardPad : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_canEngineCardKey;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_InsertCardPad, sniffButton_M_InsertCardPad, biteButton_M_InsertCardPad, 
        pressButton_M_InsertCardPad, observeButton_M_InsertCardPad;

    ObjData insertCardPadData_M;
    ObjData canEngineCardKeyData_M;

    /*�ƿ�����*/
    Outline insertCardPadOutline_M;
    Outline canEngineCardKeyOutline_M;

    public Animator engineDoorAnim_M;

    void Start()
    {

        /*�����ִ� ������Ʈ*/
        canEngineCardKeyData_M = M_canEngineCardKey.GetComponent<ObjData>();
        insertCardPadData_M = GetComponent<ObjData>();



        /*��ư*/
        barkButton_M_InsertCardPad = insertCardPadData_M.BarkButton;
        barkButton_M_InsertCardPad.onClick.AddListener(OnBark);

        sniffButton_M_InsertCardPad = insertCardPadData_M.SniffButton;
        sniffButton_M_InsertCardPad.onClick.AddListener(OnSniff);

        biteButton_M_InsertCardPad = insertCardPadData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_InsertCardPad = insertCardPadData_M.PushOrPressButton;
        pressButton_M_InsertCardPad.onClick.AddListener(OnPushOrPress);

        observeButton_M_InsertCardPad = insertCardPadData_M.CenterButton1;
        observeButton_M_InsertCardPad.onClick.AddListener(OnObserve);

        /*�ƿ�����*/
        canEngineCardKeyOutline_M = M_canEngineCardKey.GetComponent<Outline>();
        insertCardPadOutline_M = GetComponent<Outline>();

    }

    void DisableButton()
    {
        barkButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        sniffButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        biteButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        pressButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        observeButton_M_InsertCardPad.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        insertCardPadData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnSniff()
    {
        insertCardPadData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        insertCardPadData_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = insertCardPadData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();
    }

    void CardBye()
    {
        CameraController.cameraController.CancelObserve();
    }

    void DoorOpen() // ������ ���� �ִϸ��̼�
    {
        engineDoorAnim_M.SetBool("canEngineDoorOpen", true);
        engineDoorAnim_M.SetBool("canEngineDoorEnd", true);
    }

    public void OnPushOrPress()
    {
        insertCardPadData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());


        if (canEngineCardKeyData_M.IsBite && insertCardPadData_M.IsObserve)
        {
            // ����� ����
            // �θ� �ڽ� ���踦 �����Ѵ�.
            M_canEngineCardKey.GetComponent<Rigidbody>().isKinematic = false;
            M_canEngineCardKey.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            M_canEngineCardKey.transform.position = new Vector3(-262.489f, 540.686f, 666.788f); //��ġ ����
            M_canEngineCardKey.transform.rotation = Quaternion.Euler(0, 0, 90); //���� ����

            // ī���е�� ī���� ��ȣ�ۿ��� �����Ѵ�.
            canEngineCardKeyData_M.IsNotInteractable = true;
            canEngineCardKeyOutline_M.OutlineWidth = 0;

            insertCardPadData_M.IsNotInteractable = true;
            insertCardPadOutline_M.OutlineWidth = 0;

            //�������� �ִϸ��̼� ����
            Invoke("CardBye", 1f);

            //�������� �ִϸ��̼� ����
            Invoke("DoorOpen", 2f);
        }
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        insertCardPadData_M.IsPushOrPress = false;
    }

    public void OnBiteDestroy()
    {
        //��ȣ�ۿ� ��ư�� ��
        DisableButton();
        //���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸�
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnBite()
    {
        //��ȣ�ۿ� ��ư�� ��
        DisableButton();
        //���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸�
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
