using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ReMeteorCollectMachine : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject T_DoNormalMeteor1_T;
    public GameObject T_DoImportantMeteor_T;
    public GameObject T_DoMeteorButton_T;
    public GameObject T_Box_Obj_T;
    public GameObject T_Noah_Obj_T;
    public GameObject T_AnalyticalButton;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_MeteorCollectMachine_T, sniffButton_T_MeteorCollectMachine_T, biteButton_T_MeteorCollectMachine_T,
        pressButton_T_MeteorCollectMachine_T, observeButton_T_MeteorCollectMachine_T, observeDisableButton_T_MeteorCollectMachine_T;

    /*ObjData*/
    ObjData T_meteorCollectMachineObjData_T;
    public ObjectData T_meteorCollectMachineData_T;

    public ObjectData T_doNormalMeteor1Data_T;
    public ObjectData T_doImportantMeteorData_T;
    public ObjectData T_doMeteorButtonData_T;
    public ObjectData T_Box_ObjData_T;

    public ObjectData AnalyticalMachineData_Observe;
    public ObjectData MeteorBoxButton1Data_Observe;
    public ObjectData MeteorBoxButton2Data_Observe;
    public ObjectData MeteorBoxButton3Data_Observe;
    public ObjectData MeteorBoxButton4Data_Observe;
    public ObjectData MeteorBoxButton5Data_Observe;

    /*Outline*/
    Outline T_meteorCollectMachineOutline_T;
    public Outline T_doNormalMeteor1Outline_T;
    public Outline T_doImportantMeteorOutline_T;
    Outline T_doMeteorButtonOutline_T;

    /*Collider*/
    BoxCollider T_IScollectMachine_Collider;
    BoxCollider T_Box_Collider;
    BoxCollider T_MeteorButton_Collider;
    BoxCollider T_Noah_Collider;
    BoxCollider T_AnalyticalButton_Collider;
    BoxCollider AnalyticalButton_Collider;

    void Start()
    {
        /*Collider*/
        T_IScollectMachine_Collider = GetComponent<BoxCollider>();
        T_Box_Collider = T_Box_Obj_T.GetComponent<BoxCollider>();
        T_MeteorButton_Collider = T_DoMeteorButton_T.GetComponent<BoxCollider>();
        T_Noah_Collider = T_Noah_Obj_T.GetComponent<BoxCollider>();
        AnalyticalButton_Collider = T_AnalyticalButton.GetComponent<BoxCollider>();

        /*ObjData*/
        T_meteorCollectMachineObjData_T = GetComponent<ObjData>();

        /*Outline*/
        T_meteorCollectMachineOutline_T = GetComponent<Outline>();
        //T_doNormalMeteor1Outline_T = T_DoNormalMeteor1_T.GetComponent<Outline>();
        //T_doImportantMeteorOutline_T = T_DoImportantMeteor_T.GetComponent<Outline>();
        T_doMeteorButtonOutline_T = T_DoMeteorButton_T.GetComponent<Outline>();

        barkButton_T_MeteorCollectMachine_T = T_meteorCollectMachineObjData_T.BarkButton;
        barkButton_T_MeteorCollectMachine_T.onClick.AddListener(OnBark);

        sniffButton_T_MeteorCollectMachine_T = T_meteorCollectMachineObjData_T.SniffButton;
        sniffButton_T_MeteorCollectMachine_T.onClick.AddListener(OnSniff);

        biteButton_T_MeteorCollectMachine_T = T_meteorCollectMachineObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_MeteorCollectMachine_T = T_meteorCollectMachineObjData_T.PushOrPressButton;
        pressButton_T_MeteorCollectMachine_T.onClick.AddListener(OnPushOrPress);

        observeButton_T_MeteorCollectMachine_T = T_meteorCollectMachineObjData_T.CenterButton1;
        observeButton_T_MeteorCollectMachine_T.onClick.AddListener(OnObserve);

        observeDisableButton_T_MeteorCollectMachine_T = T_meteorCollectMachineObjData_T.CenterButton2;


        /*선언시작*/
        T_meteorCollectMachineData_T.IsObserve = false;
        //T_meteorCollectMachineData_T.IsCenterButtonChanged = false;
    }

    void Update()
    {
        //관찰하기 상태가 아니라면 콜라이더 감지를 켜준다.
        if (!T_meteorCollectMachineData_T.IsObserve)
        {
            //Box_Collider.enabled = true;

        }

        //운석 수집기에 관찰하기 중이라면
        if (T_meteorCollectMachineData_T.IsObserve)
        {
            T_doMeteorButtonData_T.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            T_doMeteorButtonOutline_T.OutlineWidth = 0;

            T_IScollectMachine_Collider.enabled = false; // 운석 수집기 콜라이더도 꺼준다.
            T_Noah_Collider.enabled = false; // 노아 콜라이더도 꺼준다.
            //Debug.Log("false");
        }

        //분석기에 관찰하기 중이라면
        else if (AnalyticalMachineData_Observe.IsObserve || MeteorBoxButton1Data_Observe.IsObserve || MeteorBoxButton2Data_Observe.IsObserve ||
            MeteorBoxButton3Data_Observe.IsObserve || MeteorBoxButton4Data_Observe.IsObserve || MeteorBoxButton5Data_Observe.IsObserve)
        {
            T_Noah_Collider.enabled = false;
        }

        else
        {
            T_Noah_Collider.enabled = true;
        }

        if (T_Box_ObjData_T.IsUpDown)
        {
            T_Box_Collider.enabled = false;
            //collectMachineCollider.enabled = true;
            T_MeteorButton_Collider.enabled = true;
            AnalyticalButton_Collider.enabled = true;

        }
        else
        {
            T_Box_Collider.enabled = true;
            //collectMachineCollider.enabled = false;
            T_MeteorButton_Collider.enabled = false;
            AnalyticalButton_Collider.enabled = false;
        }
    }

    void DisableButton()
    {
        barkButton_T_MeteorCollectMachine_T.transform.gameObject.SetActive(false);
        sniffButton_T_MeteorCollectMachine_T.transform.gameObject.SetActive(false);
        biteButton_T_MeteorCollectMachine_T.transform.gameObject.SetActive(false);
        pressButton_T_MeteorCollectMachine_T.transform.gameObject.SetActive(false);
        observeButton_T_MeteorCollectMachine_T.transform.gameObject.SetActive(false);
        observeDisableButton_T_MeteorCollectMachine_T.transform.gameObject.SetActive(false);
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

        CameraController.cameraController.currentView = T_meteorCollectMachineObjData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        //콜라이더 감지 끄기
        T_IScollectMachine_Collider.enabled = false;
        //Box_Collider.enabled = false;
        T_MeteorButton_Collider.enabled = false;

        T_doNormalMeteor1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        T_doNormalMeteor1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        T_doImportantMeteorData_T.IsNotInteractable = false; // 상호작용 가능하게
        T_doImportantMeteorOutline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        T_meteorCollectMachineData_T.IsNotInteractable = true; // 상호작용 불가능하게
        T_meteorCollectMachineOutline_T.OutlineWidth = 0; // 아웃라인도 꺼줍니다.
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
