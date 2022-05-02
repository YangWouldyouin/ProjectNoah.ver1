using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*시작전에 앞서
    박스에 올라가면 박스 콜라이더를 꺼준다. 버튼 콜라이더를 켜준다. -> 운석 수집기 버튼을 누르면 
    -> 운석 수집기의 콜라이더가 켜진다. -> 운석 수집기에 관찰하기를 하면-> 버튼과 운석 수집기, 노아의 콜라이더가 꺼진다. ->문이 다시 닫히면 운석 콜라이더가 꺼진다. */

public class T_MeteorCollectMachine : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject T_DoNormalMeteor1;
    public GameObject T_DoImportantMeteor;
    public GameObject T_DoMeteorButton;
    public GameObject Box_Obj;
    public GameObject Noah_Obj;

    public GameObject T_AnalyticalButton;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_MeteorCollectMachine, sniffButton_T_MeteorCollectMachine, biteButton_T_MeteorCollectMachine,
        pressButton_T_MeteorCollectMachine, observeButton_T_MeteorCollectMachine, observeDisableButton_T_MeteorCollectMachine;

    /*ObjData*/
    ObjData meteorCollectMachineData_T;
    ObjData doNormalMeteor1Data_T;
    ObjData doImportantMeteorData_T;
    ObjData doMeteorButtonData_T;
    ObjData Box_ObjData_T;

    /*Outline*/
    Outline meteorCollectMachineOutline_T;
    Outline doNormalMeteor1Outline_T;
    Outline doImportantMeteorOutline_T;
    Outline doMeteorButtonOutline_T;

    /*Collider*/
    BoxCollider IScollectMachineCollider;
    BoxCollider Box_Collider;
    BoxCollider MeteorButton_Collider;
    BoxCollider Noah_Collider;
    BoxCollider AnalyticalButton_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        IScollectMachineCollider = GetComponent<BoxCollider>();
        Box_Collider = Box_Obj.GetComponent<BoxCollider>();
        MeteorButton_Collider = T_DoMeteorButton.GetComponent<BoxCollider>();
        Noah_Collider = Noah_Obj.GetComponent<BoxCollider>();
        AnalyticalButton_Collider = T_AnalyticalButton.GetComponent<BoxCollider>();

        /*ObjData*/
        meteorCollectMachineData_T = GetComponent<ObjData>();
        doNormalMeteor1Data_T = T_DoNormalMeteor1.GetComponent<ObjData>();
        doImportantMeteorData_T = T_DoImportantMeteor.GetComponent<ObjData>();
        doMeteorButtonData_T = T_DoMeteorButton.GetComponent<ObjData>();
        Box_ObjData_T = Box_Obj.GetComponent<ObjData>();

        /*Outline*/
        meteorCollectMachineOutline_T = GetComponent<Outline>();
        doNormalMeteor1Outline_T = T_DoNormalMeteor1.GetComponent<Outline>();
        doImportantMeteorOutline_T = T_DoImportantMeteor.GetComponent<Outline>();
        doMeteorButtonOutline_T = T_DoMeteorButton.GetComponent<Outline>();

        barkButton_T_MeteorCollectMachine = meteorCollectMachineData_T.BarkButton;
        barkButton_T_MeteorCollectMachine.onClick.AddListener(OnBark);

        sniffButton_T_MeteorCollectMachine = meteorCollectMachineData_T.SniffButton;
        sniffButton_T_MeteorCollectMachine.onClick.AddListener(OnSniff);

        biteButton_T_MeteorCollectMachine = meteorCollectMachineData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_MeteorCollectMachine = meteorCollectMachineData_T.PushOrPressButton;
        pressButton_T_MeteorCollectMachine.onClick.AddListener(OnPushOrPress);

        observeButton_T_MeteorCollectMachine = meteorCollectMachineData_T.CenterButton1;
        observeButton_T_MeteorCollectMachine.onClick.AddListener(OnObserve);

        observeDisableButton_T_MeteorCollectMachine = meteorCollectMachineData_T.CenterButton2;
    }

    void Update()
    {
        //관찰하기 상태가 아니라면 콜라이더 감지를 켜준다.
        if(!meteorCollectMachineData_T.IsObserve)
        {
            //Box_Collider.enabled = true;
          
        }

        //운석 수집기에 관찰하기 중이라면
        if(meteorCollectMachineData_T.IsObserve)
        {
            doMeteorButtonData_T.IsNotInteractable = true; // 버튼 상호작용 불가능하게
            doMeteorButtonOutline_T.OutlineWidth = 0;

            IScollectMachineCollider.enabled = false; // 운석 수집기 콜라이더도 꺼준다.
            Noah_Collider.enabled = false; // 노아 콜라이더도 꺼준다.
            Debug.Log("false");
        }

        if(Box_ObjData_T.IsUpDown)
        {
            Box_Collider.enabled = false;
            //collectMachineCollider.enabled = true;
            MeteorButton_Collider.enabled = true;
            AnalyticalButton_Collider.enabled = true;

        }
        else
        {
            Box_Collider.enabled = true;
            //collectMachineCollider.enabled = false;
            MeteorButton_Collider.enabled = false;
            AnalyticalButton_Collider.enabled = false;
        }
    }

    void DisableButton()
    {
        barkButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        sniffButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        biteButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        pressButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
        observeButton_T_MeteorCollectMachine.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        meteorCollectMachineData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        meteorCollectMachineData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        meteorCollectMachineData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteorCollectMachineData_T.IsPushOrPress = false;
    }


    public void OnObserve()
    {
        meteorCollectMachineData_T.IsObserve = true;

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = meteorCollectMachineData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();


        //콜라이더 감지 끄기
        //collectMachineCollider.enabled = false;
        //Box_Collider.enabled = false;
        MeteorButton_Collider.enabled = false;

        doNormalMeteor1Data_T.IsNotInteractable = false; // 상호작용 가능하게
        doNormalMeteor1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        doImportantMeteorData_T.IsNotInteractable = false; // 상호작용 가능하게
        doImportantMeteorOutline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

        meteorCollectMachineData_T.IsNotInteractable = true; // 상호작용 불가능하게
        meteorCollectMachineOutline_T.OutlineWidth = 0; // 아웃라인도 꺼줍니다.

   



        if(doImportantMeteorData_T.IsBite)
        {
            CameraController.cameraController.CancelObserve();

            GameManager.gameManager._gameData.IsBiteimportantMeteor_T_C2 = true;

        }

        if (doNormalMeteor1Data_T.IsBite)
        {
            CameraController.cameraController.CancelObserve();

            GameManager.gameManager._gameData.IsBiteNormalMeteor1_T_C2 = true;

        }

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
