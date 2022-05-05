using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PotatoBox : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject SweetPotatoBoxDoor_T;
    public GameObject IsBadSweetPotato1_T;
    public GameObject IsHealthySweetPotato1_T;
    public GameObject IsUnGrownSweetPotato1_T;

    /*오브젝트의 상호작용 버튼들*/
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
            //A-3 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
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

        PotatoBoxData_T.IsCenterButtonChanged = true;

        IsBadSweetPotato1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        IsBadSweetPotato1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        IsHealthySweetPotato1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        IsHealthySweetPotato1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        IsUnGrownSweetPotato1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        IsUnGrownSweetPotato1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.


        //A-4 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆


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
