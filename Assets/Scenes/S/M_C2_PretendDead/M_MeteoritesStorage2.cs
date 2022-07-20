using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage2 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteoritesStorage2, sniffButton_M_MeteoritesStorage2,
        biteButton_M_MeteoritesStorage2, pressButton_M_MeteoritesStorage2, 
        observeButton_M_MeteoritesStorage2, observeDisableButton_M_MeteoritesStorage2;

    /*ObjData*/
    ObjData meteoritesStorage2ObjData_M;
    public ObjectData meteoritesStorage2Data_M;

    public ObjectData IsIsAnswerMeteorData_M;


    /*Outline*/
    public Outline IsIsAnswerMeteorOutline_M;

    void Start()
    {
        /*ObjData*/
        meteoritesStorage2ObjData_M = GetComponent<ObjData>();

        /*Outline*/

        barkButton_M_MeteoritesStorage2 = meteoritesStorage2ObjData_M.BarkButton;
        barkButton_M_MeteoritesStorage2.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage2 = meteoritesStorage2ObjData_M.SniffButton;
        sniffButton_M_MeteoritesStorage2.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage2 = meteoritesStorage2ObjData_M.BiteButton;
        biteButton_M_MeteoritesStorage2.onClick.AddListener(OnBite);

        pressButton_M_MeteoritesStorage2 = meteoritesStorage2ObjData_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage2.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage2 = meteoritesStorage2ObjData_M.CenterButton1;
        observeButton_M_MeteoritesStorage2.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage2= meteoritesStorage2ObjData_M.CenterButton1;


        /*선언 시작*/
        meteoritesStorage2Data_M.IsObserve = false;
        meteoritesStorage2Data_M.IsNotInteractable = true;
        meteoritesStorage2Data_M.IsCenterButtonDisabled = true;
        IsIsAnswerMeteorData_M.IsNotInteractable = true;
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage2.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage2.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage2.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage2.transform.gameObject.SetActive(false);
        observeButton_M_MeteoritesStorage2.transform.gameObject.SetActive(false);
        observeDisableButton_M_MeteoritesStorage2.transform.gameObject.SetActive(false);
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

        CameraController.cameraController.currentView = meteoritesStorage2ObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsIsAnswerMeteorData_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
        IsIsAnswerMeteorOutline_M.OutlineWidth = 8;
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
