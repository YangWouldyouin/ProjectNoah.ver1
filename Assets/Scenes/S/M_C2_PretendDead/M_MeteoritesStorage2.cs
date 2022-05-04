using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage2 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_IsAnswerMeteor;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteoritesStorage2, sniffButton_M_MeteoritesStorage2,
        biteButton_M_MeteoritesStorage2, pressButton_M_MeteoritesStorage2, 
        observeButton_M_MeteoritesStorage2, observeDisableButton_M_MeteoritesStorage2;

    /*ObjData*/
    ObjData meteoritesStorage2Data_M;
    ObjData IsIsAnswerMeteorData_M;


    /*Outline*/
    Outline IsIsAnswerMeteorOutline_M;

    void Start()
    {
        /*ObjData*/
        meteoritesStorage2Data_M = GetComponent<ObjData>();
        IsIsAnswerMeteorData_M = M_IsAnswerMeteor.GetComponent<ObjData>();

        /*Outline*/
        IsIsAnswerMeteorOutline_M = M_IsAnswerMeteor.GetComponent<Outline>();


        barkButton_M_MeteoritesStorage2 = meteoritesStorage2Data_M.BarkButton;
        barkButton_M_MeteoritesStorage2.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage2 = meteoritesStorage2Data_M.SniffButton;
        sniffButton_M_MeteoritesStorage2.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage2 = meteoritesStorage2Data_M.BiteButton;
        //biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage2 = meteoritesStorage2Data_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage2.onClick.AddListener(OnPushOrPress);

        observeButton_M_MeteoritesStorage2 = meteoritesStorage2Data_M.CenterButton1;
        observeButton_M_MeteoritesStorage2.onClick.AddListener(OnObserve);

        observeDisableButton_M_MeteoritesStorage2= meteoritesStorage2Data_M.CenterButton1;
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
        meteoritesStorage2Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnObserve()
    {
        meteoritesStorage2Data_M.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteoritesStorage2Data_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        IsIsAnswerMeteorData_M.IsNotInteractable = false; // 버튼 상호작용 가능하게
        IsIsAnswerMeteorOutline_M.OutlineWidth = 8;
    }

    public void OnPushOrPress()
    {
        meteoritesStorage2Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteoritesStorage2Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        meteoritesStorage2Data_M.IsSniff = true;

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
