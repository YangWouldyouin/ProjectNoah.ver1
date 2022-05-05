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
    ObjData meteoritesStorage1Data_M;
    ObjData IsWrongMeteor1Data_M;


    /*Outline*/
    Outline IsWrongMeteor1Outline_M;


    /*Collider*/
    BoxCollider meteoritesStorage1_Collider;
    BoxCollider IsWrongMeteor1_Collider;

    void Start()
    {
        /*ObjData*/
        meteoritesStorage1Data_M = GetComponent<ObjData>();
        IsWrongMeteor1Data_M = M_IsWrongMeteor1.GetComponent<ObjData>();

        /*Outline*/
        IsWrongMeteor1Outline_M = M_IsWrongMeteor1.GetComponent<Outline>();

        /*Collider*/
        meteoritesStorage1_Collider = GetComponent<BoxCollider>();
        IsWrongMeteor1_Collider = M_IsWrongMeteor1.GetComponent<BoxCollider>();

        /*버튼 연결*/
        barkButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.BarkButton;
        barkButton_M_MeteoritesStorage1.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.SniffButton;
        sniffButton_M_MeteoritesStorage1.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.BiteButton;
        //biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage1.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.CenterButton1;
        observeButton_M_MeteoritesStorage1.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage1= meteoritesStorage1Data_M.CenterButton1;
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
        meteoritesStorage1Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();

    }

    public void OnObserve()
    {
        meteoritesStorage1Data_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteoritesStorage1Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsWrongMeteor1Data_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
        IsWrongMeteor1Outline_M.OutlineWidth = 8;
    }

    public void OnPushOrPress()
    {
        meteoritesStorage1Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteoritesStorage1Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        meteoritesStorage1Data_M.IsSniff = true;

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
