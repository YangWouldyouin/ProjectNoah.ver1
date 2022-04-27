using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_InsertCardPad : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_canEngineCardKey;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_InsertCardPad, sniffButton_M_InsertCardPad, biteButton_M_InsertCardPad, 
        pressButton_M_InsertCardPad, observeButton_M_InsertCardPad;

    ObjData insertCardPadData_M;
    ObjData canEngineCardKeyData_M;

    /*아웃라인*/
    Outline insertCardPadOutline_M;
    Outline canEngineCardKeyOutline_M;

    public Animator engineDoorAnim_M;

    void Start()
    {

        /*연관있는 오브젝트*/
        canEngineCardKeyData_M = M_canEngineCardKey.GetComponent<ObjData>();
        insertCardPadData_M = GetComponent<ObjData>();



        /*버튼*/
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

        /*아웃라인*/
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

    void DoorOpen() // 엔진실 열기 애니메이션
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
            // 끼우기 성공
            // 부모 자식 관계를 해제한다.
            M_canEngineCardKey.GetComponent<Rigidbody>().isKinematic = false;
            M_canEngineCardKey.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            M_canEngineCardKey.transform.position = new Vector3(-262.489f, 540.686f, 666.788f); //위치 고정
            M_canEngineCardKey.transform.rotation = Quaternion.Euler(0, 0, 90); //각도 고정

            // 카드패드와 카드의 상호작용을 삭제한다.
            canEngineCardKeyData_M.IsNotInteractable = true;
            canEngineCardKeyOutline_M.OutlineWidth = 0;

            insertCardPadData_M.IsNotInteractable = true;
            insertCardPadOutline_M.OutlineWidth = 0;

            //문열리는 애니메이션 실행
            Invoke("CardBye", 1f);

            //문열리는 애니메이션 실행
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
