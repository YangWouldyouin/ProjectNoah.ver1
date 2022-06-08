using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage5 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_IsWrongMeteor4;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteoritesStorage5, sniffButton_M_MeteoritesStorage5,
        biteButton_M_MeteoritesStorage5, pressButton_M_MeteoritesStorage5, 
        observeButton_M_MeteoritesStorage5, observeDisableButton_M_MeteoritesStorage5;

    /*ObjData*/
    ObjData meteoritesStorage5ObjData_M;
    public ObjectData meteoritesStorage5Data_M;

    public ObjectData IsWrongMeteor4Data_M;

    /*Outline*/
    Outline IsWrongMeteor4Outline_M;


    /*Collider*/
    BoxCollider meteoritesStorage5_Collider;
    BoxCollider IsWrongMeteor4_Collider;

    void Start()
    {
        /*ObjData*/
        meteoritesStorage5ObjData_M = GetComponent<ObjData>();

        /*Outline*/
        IsWrongMeteor4Outline_M = M_IsWrongMeteor4.GetComponent<Outline>();

        /*Collider*/
        meteoritesStorage5_Collider = GetComponent<BoxCollider>();
        IsWrongMeteor4_Collider = M_IsWrongMeteor4.GetComponent<BoxCollider>();

        /*버튼 연결*/
        barkButton_M_MeteoritesStorage5 = meteoritesStorage5ObjData_M.BarkButton;
        barkButton_M_MeteoritesStorage5.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage5 = meteoritesStorage5ObjData_M.SniffButton;
        sniffButton_M_MeteoritesStorage5.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage5 = meteoritesStorage5ObjData_M.BiteButton;
        //biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage5 = meteoritesStorage5ObjData_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage5.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage5 = meteoritesStorage5ObjData_M.CenterButton1;
        observeButton_M_MeteoritesStorage5.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage5= meteoritesStorage5ObjData_M.CenterButton1;


        /*선언 시작*/
        meteoritesStorage5Data_M.IsObserve = false;
        meteoritesStorage5Data_M.IsNotInteractable = false;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage5.transform.gameObject.SetActive(false);
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

        CameraController.cameraController.currentView = meteoritesStorage5ObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsWrongMeteor4Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
        IsWrongMeteor4Outline_M.OutlineWidth = 8;
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
