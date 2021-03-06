using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage4 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_IsWrongMeteor3;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteoritesStorage4, sniffButton_M_MeteoritesStorage4,
        biteButton_M_MeteoritesStorage4, pressButton_M_MeteoritesStorage4, 
        observeButton_M_MeteoritesStorage4, observeDisableButton_M_MeteoritesStorage4;

    /*ObjData*/
    ObjData meteoritesStorage4ObjData_M;
    public ObjectData meteoritesStorage4Data_M;

    public ObjectData IsWrongMeteor3Data_M;


    /*Outline*/
    Outline IsWrongMeteor3Outline_M;

    /*Collider*/
    BoxCollider meteoritesStorage4_Collider;
    BoxCollider IsWrongMeteor3_Collider;

    void Start()
    {
        /*ObjData*/
        meteoritesStorage4ObjData_M = GetComponent<ObjData>();

        /*Outline*/
        IsWrongMeteor3Outline_M = M_IsWrongMeteor3.GetComponent<Outline>();

        /*Collider*/
        meteoritesStorage4_Collider = GetComponent<BoxCollider>();
        IsWrongMeteor3_Collider = M_IsWrongMeteor3.GetComponent<BoxCollider>();

        /*버튼 연결*/
        barkButton_M_MeteoritesStorage4 = meteoritesStorage4ObjData_M.BarkButton;
        barkButton_M_MeteoritesStorage4.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage4 = meteoritesStorage4ObjData_M.SniffButton;
        sniffButton_M_MeteoritesStorage4.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage4 = meteoritesStorage4ObjData_M.BiteButton;
        biteButton_M_MeteoritesStorage4.onClick.AddListener(OnBite);

        pressButton_M_MeteoritesStorage4 = meteoritesStorage4ObjData_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage4.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage4 = meteoritesStorage4ObjData_M.CenterButton1;
        observeButton_M_MeteoritesStorage4.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage4= meteoritesStorage4ObjData_M.CenterButton1;

        /*선언 시작*/
        meteoritesStorage4Data_M.IsObserve = false;
        meteoritesStorage4Data_M.IsNotInteractable = true;
        meteoritesStorage4Data_M.IsCenterButtonDisabled = true;
        IsWrongMeteor3Data_M.IsNotInteractable = true;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage4.transform.gameObject.SetActive(false);
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

        CameraController.cameraController.currentView = meteoritesStorage4ObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsWrongMeteor3Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
        IsWrongMeteor3Outline_M.OutlineWidth = 8;
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
