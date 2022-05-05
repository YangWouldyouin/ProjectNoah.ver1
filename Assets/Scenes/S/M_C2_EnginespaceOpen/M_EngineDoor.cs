using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class M_EngineDoor : MonoBehaviour, IInteraction
{


    /*연관있는 오브젝트*/
    public GameObject M_IsBrokenArea;
    public GameObject M_canInsertCardPad;


    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_EngineDoor, sniffButton_M_EngineDoor, biteButton_M_EngineDoor, pressButton_M_EngineDoor, observeButton_M_EngineDoor;

    ObjData engineDoorData_M;
    ObjData IsBrokenAreaData_M;
    ObjData canInsertCardPadData_M;


    /*아웃라인*/
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


        /*버튼*/
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

        /*아웃라인*/
        IsBrokenAreaOutline_M = M_IsBrokenArea.GetComponent<Outline>();
        canInsertCardPadOutline_M = M_canInsertCardPad.GetComponent<Outline>();
        engineDoorOutline_M = GetComponent<Outline>();

    }

    void Update()
    {
        if(engineDoorData_M.IsClicked)
        {
            //B-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
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
        //B-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

        engineDoorData_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = engineDoorData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        if(engineDoorData_M.IsObserve)
        {
            //Debug.Log("문이랑 상호작용 가능!");
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

        //카드패드 상호작용 가능하게
        canInsertCardPadData_M.IsNotInteractable = false;
        canInsertCardPadOutline_M.OutlineWidth = 8;

        //엔진실 문 자체는 상호작용을 삭제한다.
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
        //상호작용 버튼을 끔
        DisableButton();
        //물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnBite()
    {
        //상호작용 버튼을 끔
        DisableButton();
        //물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림
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
