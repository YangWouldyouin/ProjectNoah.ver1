using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachine : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject T_IsAnalyticalMachinePlate;
    public GameObject T_IsAnalyticalMachineButton;
    //public GameObject Noah_Obj2;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_AnalyticalMachine, sniffButton_T_AnalyticalMachine, biteButton_T_AnalyticalMachine, 
        pressButton_T_AnalyticalMachine, observeButton_T_AnalyticalMachine;


    /*ObjData*/
    ObjData analyticalMachineObjData_T;
    public ObjectData analyticalMachineData_T;

    public ObjectData isAnalyticalMachinePlateData_T;
    public ObjectData isAnalyticalMachineButtonData_T;

    /*Outline*/
    Outline isAnalyticalMachinePlateOutline_T;
    Outline isAnalyticalMachineButtonOutline_T;

    /*Collider*/
    BoxCollider analyticalMachine_Collider;
    BoxCollider isAnalyticalMachineButton_Collider; //버튼
    //BoxCollider Noah_Obj2_Collider; //노아

    AudioSource AnalyticalMachine_Sound;
    public AudioClip AnalyticalMachine_On;

    // Start is called before the first frame update
    void Start()
    {
        AnalyticalMachine_Sound = GetComponent<AudioSource>();

        /*Collider*/
        analyticalMachine_Collider = GetComponent<BoxCollider>();
        //Noah_Obj2_Collider = Noah_Obj2.GetComponent<BoxCollider>();
        isAnalyticalMachineButton_Collider = T_IsAnalyticalMachineButton.GetComponent<BoxCollider>();

        /*ObjData*/
        analyticalMachineObjData_T = GetComponent<ObjData>();

        /*Outline*/
        isAnalyticalMachinePlateOutline_T = T_IsAnalyticalMachinePlate.GetComponent<Outline>();
        isAnalyticalMachineButtonOutline_T = T_IsAnalyticalMachineButton.GetComponent<Outline>();

        barkButton_T_AnalyticalMachine = analyticalMachineObjData_T.BarkButton;
        barkButton_T_AnalyticalMachine.onClick.AddListener(OnBark);

        sniffButton_T_AnalyticalMachine = analyticalMachineObjData_T.SniffButton;
        sniffButton_T_AnalyticalMachine.onClick.AddListener(OnSniff);

        biteButton_T_AnalyticalMachine = analyticalMachineObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_AnalyticalMachine = analyticalMachineObjData_T.PushOrPressButton;
        pressButton_T_AnalyticalMachine.onClick.AddListener(OnPushOrPress);

        observeButton_T_AnalyticalMachine = analyticalMachineObjData_T.CenterButton1;
        observeButton_T_AnalyticalMachine.onClick.AddListener(OnObserve);

        /*선언시작*/
        analyticalMachineData_T.IsObserve = false;
        //analyticalMachineData_T.IsCenterButtonChanged = false;

    }

    void Update()
    {

        if(analyticalMachineData_T.IsObserve)
        {
            analyticalMachine_Collider.enabled = false;
            isAnalyticalMachineButton_Collider.enabled = false;
        }

        //관찰하기 상태가 아니라면 콜라이더 감지를 켜준다.
        if (!analyticalMachineData_T.IsObserve)
        {
            analyticalMachine_Collider.enabled = true;
            //Noah_Obj2_Collider.enabled = true;
            isAnalyticalMachineButton_Collider.enabled = true;

/*            isAnalyticalMachinePlateData_T.IsNotInteractable = true; // 접시 상호작용 불 가능하게
            isAnalyticalMachinePlateOutline_T.OutlineWidth = 0;*/
        }


    }

    void DisableButton()
    {
        barkButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        sniffButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        biteButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        pressButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
        observeButton_T_AnalyticalMachine.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
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

    public void OnObserve()
    {
        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = analyticalMachineObjData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        AnalyticalMachine_Sound.clip = AnalyticalMachine_On;
        AnalyticalMachine_Sound.Play();

        analyticalMachine_Collider.enabled = false;
        //Noah_Obj2_Collider.enabled = false;
        isAnalyticalMachineButton_Collider.enabled = false;

        isAnalyticalMachinePlateData_T.IsNotInteractable = false; // 접시 상호작용 가능하게
        isAnalyticalMachinePlateOutline_T.OutlineWidth = 8;

        isAnalyticalMachineButtonData_T.IsNotInteractable = true; // 버튼 상호작용 불가능하게
        isAnalyticalMachineButtonOutline_T.OutlineWidth = 0;
    }

    public void OnSmash()
    {
       
    }

    public void OnUp()
    {
        
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


}
