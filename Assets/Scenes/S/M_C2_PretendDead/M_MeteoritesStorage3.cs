using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage3 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_IsWrongMeteor2;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteoritesStorage3, sniffButton_M_MeteoritesStorage3,
        biteButton_M_MeteoritesStorage3, pressButton_M_MeteoritesStorage3, 
        observeButton_M_MeteoritesStorage3, observeDisableButton_M_MeteoritesStorage3;

    /*ObjData*/
    ObjData meteoritesStorage3ObjData_M;

    public ObjectData IsWrongMeteor2Data_M;

    /*Outline*/
    Outline IsWrongMeteor2Outline_M;

    /*Collider*/
    BoxCollider meteoritesStorage3_Collider;
    BoxCollider IsWrongMeteor2_Collider;


    void Start()
    {
        /*ObjData*/
        meteoritesStorage3ObjData_M = GetComponent<ObjData>();

        /*Outline*/
        IsWrongMeteor2Outline_M = M_IsWrongMeteor2.GetComponent<Outline>();

        /*Collider*/
        meteoritesStorage3_Collider = GetComponent<BoxCollider>();
        IsWrongMeteor2_Collider = M_IsWrongMeteor2.GetComponent<BoxCollider>();

        /*버튼 연결*/
        barkButton_M_MeteoritesStorage3 = meteoritesStorage3ObjData_M.BarkButton;
        barkButton_M_MeteoritesStorage3.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage3 = meteoritesStorage3ObjData_M.SniffButton;
        sniffButton_M_MeteoritesStorage3.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage3 = meteoritesStorage3ObjData_M.BiteButton;
        //biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage3 = meteoritesStorage3ObjData_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage3.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage3 = meteoritesStorage3ObjData_M.CenterButton1;
        observeButton_M_MeteoritesStorage3.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage3= meteoritesStorage3ObjData_M.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage3.transform.gameObject.SetActive(false);
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

        CameraController.cameraController.currentView = meteoritesStorage3ObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsWrongMeteor2Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
        IsWrongMeteor2Outline_M.OutlineWidth = 8;
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
