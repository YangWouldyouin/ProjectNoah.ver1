using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class M_EngineDoor : MonoBehaviour, IInteraction
{


    /*�����ִ� ������Ʈ*/
    public GameObject M_IsBrokenArea;
    public GameObject M_canInsertCardPad;


    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_EngineDoor, sniffButton_M_EngineDoor, biteButton_M_EngineDoor, pressButton_M_EngineDoor, observeButton_M_EngineDoor;

    ObjData engineDoorData_M;
    ObjData IsBrokenAreaData_M;
    ObjData canInsertCardPadData_M;


    /*�ƿ�����*/
    Outline engineDoorOutline_M;
    Outline IsBrokenAreaOutline_M;
    Outline canInsertCardPadOutline_M;


    // Start is called before the first frame update
    void Start()
    {
        //M_BrokenDoorConduction CheckEngineDoor = GameObject.Find("brokenDoor_Conduction").GetComponent<M_BrokenDoorConduction>();



        /*ObjData*/
        IsBrokenAreaData_M = M_IsBrokenArea.GetComponent<ObjData>();

        canInsertCardPadData_M = M_canInsertCardPad.GetComponent<ObjData>();

        engineDoorData_M = GetComponent<ObjData>();


        /*��ư*/
        barkButton_M_EngineDoor = engineDoorData_M.BarkButton;
        barkButton_M_EngineDoor.onClick.AddListener(OnBark);

        sniffButton_M_EngineDoor = engineDoorData_M.SniffButton;
        sniffButton_M_EngineDoor.onClick.AddListener(OnSniff);

        biteButton_M_EngineDoor = engineDoorData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_EngineDoor = engineDoorData_M.PushOrPressButton;
        pressButton_M_EngineDoor.onClick.AddListener(OnPushOrPress);

        observeButton_M_EngineDoor = engineDoorData_M.CenterButton1;
        observeButton_M_EngineDoor.onClick.AddListener(OnObserve);

        /*�ƿ�����*/
        IsBrokenAreaOutline_M = M_IsBrokenArea.GetComponent<Outline>();
        canInsertCardPadOutline_M = M_canInsertCardPad.GetComponent<Outline>();
        engineDoorOutline_M = GetComponent<Outline>();

    }

    void Update()
    {
        if(engineDoorData_M.IsClicked)
        {
            //B-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        }

        if (GameManager.gameManager._gameData.IsEngineDoorFix_M_C2)
        {
            Invoke("DoorFix", 2f);
        }

        
    }
    void DisableButton()
    {
        barkButton_M_EngineDoor.transform.gameObject.SetActive(false);
        sniffButton_M_EngineDoor.transform.gameObject.SetActive(false);
        biteButton_M_EngineDoor.transform.gameObject.SetActive(false);
        pressButton_M_EngineDoor.transform.gameObject.SetActive(false);
        observeButton_M_EngineDoor.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        engineDoorData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnObserve()
    {
        //B-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�

        engineDoorData_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = engineDoorData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        if(engineDoorData_M.IsObserve)
        {
            //Debug.Log("���̶� ��ȣ�ۿ� ����!");
            IsBrokenAreaData_M.IsNotInteractable = false;
            IsBrokenAreaOutline_M.OutlineWidth = 8;
        }

        else
        {
            IsBrokenAreaData_M.IsNotInteractable = true;
            IsBrokenAreaOutline_M.OutlineWidth = 0;
            
        }
    }

    void DoorFix()
    {
        /*CameraController.cameraController.CancelObserve();
        engineDoorData_M.IsObserve = false;*/

        //ī���е� ��ȣ�ۿ� �����ϰ�
        canInsertCardPadData_M.IsNotInteractable = false;
        canInsertCardPadOutline_M.OutlineWidth = 8;

        //������ �� ��ü�� ��ȣ�ۿ��� �����Ѵ�.
        engineDoorData_M.IsNotInteractable = true;
        engineDoorOutline_M.OutlineWidth = 0;
    }



    public void OnPushOrPress()
    {
        engineDoorData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        engineDoorData_M.IsPushOrPress = false;
    }


    public void OnSniff()
    {
        engineDoorData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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


    public void OnSmash()
    {

    }

    public void OnUp()
    {

    }

    public void OnEat()
    {

    }

    public void OnInsert()
    {

    }
}
