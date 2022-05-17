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
        pressButton_M_InsertCardPad, observeButton_M_InsertCardPad, observeDisableButton_M_InsertCardPad;

    ObjData insertCardPadObjData_M;
    public ObjectData insertCardPadData_M;
    public ObjectData canEngineCardKeyData_M;

    /*아웃라인*/
    Outline insertCardPadOutline_M;
    Outline canEngineCardKeyOutline_M;

    public Animator engineDoorAnim_M;

    void Start()
    {

        /*연관있는 오브젝트*/
        insertCardPadObjData_M = GetComponent<ObjData>();



        /*버튼*/
        barkButton_M_InsertCardPad = insertCardPadObjData_M.BarkButton;
        barkButton_M_InsertCardPad.onClick.AddListener(OnBark);

        sniffButton_M_InsertCardPad = insertCardPadObjData_M.SniffButton;
        sniffButton_M_InsertCardPad.onClick.AddListener(OnSniff);

        biteButton_M_InsertCardPad = insertCardPadObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_InsertCardPad = insertCardPadObjData_M.PushOrPressButton;
        pressButton_M_InsertCardPad.onClick.AddListener(OnPushOrPress);

        observeButton_M_InsertCardPad = insertCardPadObjData_M.CenterButton1;
        observeButton_M_InsertCardPad.onClick.AddListener(OnObserve);

        observeDisableButton_M_InsertCardPad = insertCardPadObjData_M.CenterButton2;


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
        observeDisableButton_M_InsertCardPad.transform.gameObject.SetActive(false);

    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        DisableButton();

        insertCardPadData_M.IsCenterButtonChanged = true;

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = insertCardPadObjData_M.ObserveView;

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

        /*엔진실 오픈 퍼즐 완료*/
        GameManager.gameManager._gameData.IsCompleteOpenEngineRoom = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // 엔진실/창고 해금 임무리스트 끝 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
        GameManager.gameManager._gameData.ActiveMissionList[5] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();
    }

    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        if (canEngineCardKeyData_M.IsBite && insertCardPadData_M.IsObserve)
        {
            // 끼우기 성공
            // 부모 자식 관계를 해제한다.
            M_canEngineCardKey.GetComponent<Rigidbody>().isKinematic = false;
            M_canEngineCardKey.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            M_canEngineCardKey.transform.position = new Vector3(-262.489f, 2.2762f, 666.788f); //위치 고정
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
