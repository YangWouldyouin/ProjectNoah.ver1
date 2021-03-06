using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage1 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_IsWrongMeteor1;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteoritesStorage1, sniffButton_M_MeteoritesStorage1,
        biteButton_M_MeteoritesStorage1, pressButton_M_MeteoritesStorage1, 
        observeButton_M_MeteoritesStorage1, observeDisableButton_M_MeteoritesStorage1;

    /*ObjData*/
    ObjData meteoritesStorage1ObjData_M;
    public ObjectData meteoritesStorage1Data_M;

    public ObjectData IsWrongMeteor1Data_M;


    /*Outline*/
    Outline IsWrongMeteor1Outline_M;


    /*Collider*/
    BoxCollider meteoritesStorage1_Collider;
    BoxCollider IsWrongMeteor1_Collider;

    void Start()
    {
        /*ObjData*/
        meteoritesStorage1ObjData_M = GetComponent<ObjData>();

        /*Outline*/
        IsWrongMeteor1Outline_M = M_IsWrongMeteor1.GetComponent<Outline>();

        /*Collider*/
        meteoritesStorage1_Collider = GetComponent<BoxCollider>();
        IsWrongMeteor1_Collider = M_IsWrongMeteor1.GetComponent<BoxCollider>();

        /*버튼 연결*/
        barkButton_M_MeteoritesStorage1 = meteoritesStorage1ObjData_M.BarkButton;
        barkButton_M_MeteoritesStorage1.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage1 = meteoritesStorage1ObjData_M.SniffButton;
        sniffButton_M_MeteoritesStorage1.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage1 = meteoritesStorage1ObjData_M.BiteButton;
        biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBite);

        pressButton_M_MeteoritesStorage1 = meteoritesStorage1ObjData_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage1.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage1 = meteoritesStorage1ObjData_M.CenterButton1;
        observeButton_M_MeteoritesStorage1.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage1= meteoritesStorage1ObjData_M.CenterButton1;


        /*선언 시작*/
        meteoritesStorage1Data_M.IsObserve = false;
        meteoritesStorage1Data_M.IsNotInteractable = true;
        meteoritesStorage1Data_M.IsCenterButtonDisabled = true;
        IsWrongMeteor1Data_M.IsNotInteractable = true;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBark()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();

    }

    public void OnObserve()
    {
        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteoritesStorage1ObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsWrongMeteor1Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
        IsWrongMeteor1Outline_M.OutlineWidth = 8;
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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
