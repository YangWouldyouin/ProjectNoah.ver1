using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PotatoBox : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject SweetPotatoBoxDoor_T;

    /*오브젝트의 상호작용 버튼들*/
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
            //A-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
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

        /* 오브젝트 흔드는 애니메이션 시작*/
        InteractionButtonController.interactionButtonController.PlayerSmash1();

        /* 파괴하기 내용 쓰기 (2초 딜레이가 애니메이션이 자연스러움) */
        Invoke("ByePotatoBox", 2f);

        /* 오브젝트 흔드는 애니메이션 끝냄 */
        InteractionButtonController.interactionButtonController.PlayerSmash2();

    }

    void ByePotatoBox()
    {
        // 부모 비활성화, 자식 활성화 등등 각 오브젝트에 맞춰서 필요한 것들 쓰기
        SweetPotatoBoxDoor_T.SetActive(false);

        PotatoBoxObjData_T.IsCenterButtonChanged = true;

        IsBadSweetPotato1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        IsBadSweetPotato1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        IsHealthySweetPotato1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        IsHealthySweetPotato1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        IsUnGrownSweetPotato1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        IsUnGrownSweetPotato1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.


        //A-4 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
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
