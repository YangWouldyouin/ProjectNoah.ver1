using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class T_ManagementMachine : MonoBehaviour, IInteraction
{
    public NavMeshObstacle doorObstacle;
    public Animator smartFarmDoorAnim_T;

    /*연관있는 오브젝트*/
    public GameObject T_canIronPlateDoor;
    public GameObject T_canTroubleLine2;
    public GameObject T_canLineHome2;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_ManagementMachine, sniffButton_T_ManagementMachine, biteButton_T_ManagementMachine,
        pressButton_T_ManagementMachine, observeButton_T_canIronPlateDoor;

    ObjData managementMachineObjData_T;
    public ObjectData managementMachineData_T;

    public ObjectData canIronPlateDoorData_T;
    public ObjectData canTroubleLine2Data_T;
    public ObjectData canDoLineHome2Data_T;

    public ObjectData OpenPot1Data_T;
    public ObjectData OpenPot2Data_T;
    public ObjectData OpenPot3Data_T;



    Outline canIronPlateDoorOutline_T;
    Outline canTroubleLine2Outline_T;
    public Outline canLineHome2Outline_T;

    public Outline OpenPot1Outline_T;
    public Outline OpenPot2Outline_T;
    public Outline OpenPot3Outline_T;

    //BoxCollider ironPlateCollider_T;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    public bool firstCheck;

    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        managementMachineObjData_T = GetComponent<ObjData>();

        canIronPlateDoorOutline_T = T_canIronPlateDoor.GetComponent<Outline>();
        canTroubleLine2Outline_T = T_canTroubleLine2.GetComponent<Outline>();
        //canLineHome2Outline_T = T_canLineHome2.GetComponent<Outline>();

        // ironPlateCollider_T = T_canIronPlateDoor.GetComponent<BoxCollider>();


        barkButton_T_ManagementMachine = managementMachineObjData_T.BarkButton;
        barkButton_T_ManagementMachine.onClick.AddListener(OnBark);

        sniffButton_T_ManagementMachine = managementMachineObjData_T.SniffButton;
        sniffButton_T_ManagementMachine.onClick.AddListener(OnSniff);

        biteButton_T_ManagementMachine = managementMachineObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_ManagementMachine = managementMachineObjData_T.PushOrPressButton;
        pressButton_T_ManagementMachine.onClick.AddListener(OnPushOrPress);

        observeButton_T_canIronPlateDoor = managementMachineObjData_T.CenterButton1;
        observeButton_T_canIronPlateDoor.onClick.AddListener(OnObserve);

        /*선언시작*/
        managementMachineData_T.IsObserve = false;
        managementMachineData_T.IsNotInteractable = false;

    }

    void Update()
    {
        if(managementMachineData_T.IsClicked && !firstCheck)
        {
            // A-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            // 스마트 팜 해금 퍼즐 시작 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(13));
            GameManager.gameManager._gameData.ActiveMissionList[17] = true;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            firstCheck = true;
        }

        if (managementMachineData_T.IsObserve && GameManager.gameManager._gameData.IsIronDisappear_T_C2)
        {
            canTroubleLine2Data_T.IsNotInteractable = false; // 상호작용 가능하게
            canTroubleLine2Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.
        }

        else
        {
            canTroubleLine2Data_T.IsNotInteractable = true; // 상호작용 불가능하게
            canTroubleLine2Outline_T.OutlineWidth = 0; // 아웃라인도 꺼줍니다.
        }

        if (managementMachineData_T.IsObserve && GameManager.gameManager._gameData.IsOutTroubleLine2_T_C2)
        {
            canDoLineHome2Data_T.IsNotInteractable = false; // 상호작용 가능하게
            canLineHome2Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.
        }

        else
        {
            canDoLineHome2Data_T.IsNotInteractable = true; // 상호작용 불가능하게
            canLineHome2Outline_T.OutlineWidth = 0; // 아웃라인도 꺼줍니다.
        }

/*        if (managementMachineData_T.IsBark && GameManager.gameManager._gameData.IsSmartFarmFix_T_C2)
        {
            Invoke("SmartFarmOpen", 2f);

            *//*스마트팜 오픈 퍼즐 완료*//*
            GameManager.gameManager._gameData.IsCompleteSmartFarmOpen = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //A-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(14));
        }*/

        if(GameManager.gameManager._gameData.IsCompleteSmartFarmOpen)
        {
            //화분들 전부 상호작용 가능하게 해주기 
            OpenPot1Data_T.IsNotInteractable = false; // 상호작용 가능하게
            OpenPot1Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

            OpenPot2Data_T.IsNotInteractable = false; // 상호작용 가능하게
            OpenPot2Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.

            OpenPot3Data_T.IsNotInteractable = false; // 상호작용 가능하게
            OpenPot3Outline_T.OutlineWidth = 8; // 아웃라인도 켜줍니다.
        }
    }
    void DisableButton()
    {
        barkButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        sniffButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        biteButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        pressButton_T_ManagementMachine.transform.gameObject.SetActive(false);
        observeButton_T_canIronPlateDoor.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();

        if(GameManager.gameManager._gameData.IsSmartFarmFix_T_C2)
        {

            Invoke("SmartFarmOpen", 2f);
            doorObstacle.enabled = false;
            /*스마트팜 오픈 퍼즐 완료*/
            GameManager.gameManager._gameData.IsCompleteSmartFarmOpen = true;
            GameManager.gameManager._gameData.ActiveMissionList[17] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //A-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(14));

            // 스마트 팜 해금 퍼즐 끝 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧
        }
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    void SmartFarmOpen()
    {
        smartFarmDoorAnim_T.SetBool("FarmDoorMoving", true);
        smartFarmDoorAnim_T.SetBool("FarmDoorStop", true);

    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnObserve()
    {

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = managementMachineObjData_T.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        canIronPlateDoorData_T.IsNotInteractable = false;
        canIronPlateDoorOutline_T.OutlineWidth = 8;


/*        if (canIronPlateDoorData_T.IsBite)
        {
            // 부모 자식 관계를 해제한다.
            T_canIronPlateDoor.GetComponent<Rigidbody>().isKinematic = false;
            T_canIronPlateDoor.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            T_canIronPlateDoor.transform.position = new Vector3(-258.15f, 538.619f, 670.1605f); //위치 고정
            T_canIronPlateDoor.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //각도 고정
            T_canIronPlateDoor.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // 크기 고정

            // 합판 더 이상 상호작용 불가
            canIronPlateDoorData_T.IsNotInteractable = true;
            canIronPlateDoorOutline_T.OutlineWidth = 0;

            //콜라이더도 끈다.
            ironPlateCollider_T.enabled = false;
            IsIronDisappear_T = true;
        }*/
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
