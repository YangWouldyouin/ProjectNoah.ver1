using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class M_EngineDoor : MonoBehaviour, IInteraction
{
    public bool dontrootmore2 = false;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_EngineDoor, sniffButton_M_EngineDoor, biteButton_M_EngineDoor, pressButton_M_EngineDoor, observeButton_M_EngineDoor;

    ObjData engineDoorObjData_M;
    public ObjectData engineDoorData_M;

    public ObjectData IsBrokenAreaData_M;
    public ObjectData canInsertCardPadData_M;

    /*아웃라인*/
    Outline engineDoorOutline_M;
    public Outline IsBrokenAreaOutline_M;
    public Outline canInsertCardPadOutline_M;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        //M_BrokenDoorConduction CheckEngineDoor = GameObject.Find("brokenDoor_Conduction").GetComponent<M_BrokenDoorConduction>();

        /*ObjData*/
        engineDoorObjData_M = GetComponent<ObjData>();

        /*버튼*/
        barkButton_M_EngineDoor = engineDoorObjData_M.BarkButton;
        barkButton_M_EngineDoor.onClick.AddListener(OnBark);

        sniffButton_M_EngineDoor = engineDoorObjData_M.SniffButton;
        sniffButton_M_EngineDoor.onClick.AddListener(OnSniff);

        biteButton_M_EngineDoor = engineDoorObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_EngineDoor = engineDoorObjData_M.PushOrPressButton;
        pressButton_M_EngineDoor.onClick.AddListener(OnPushOrPress);

        observeButton_M_EngineDoor = engineDoorObjData_M.CenterButton1;
        observeButton_M_EngineDoor.onClick.AddListener(OnObserve);

        /*아웃라인*/
        engineDoorOutline_M = GetComponent<Outline>();

        /*선언시작*/
        engineDoorData_M.IsObserve = false;

    }

    void Update()
    {
        if (engineDoorData_M.IsClicked && dontrootmore2 == false )
        {
            //B-1 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(20));
            GameData gameData = SaveSystem.Load("save_001");
            {
                // 아직 미션 추가 전인지 확인 후 추가
                if (!gameData.CompleteMissionList[30])
                {
                    MissionGenerator.missionGenerator.AddNewMission(30);
                    GameManager.gameManager._gameData.CompleteMissionList[30]= true;
                    SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                }
            }

            dontrootmore2 = true;
        }

        if (GameManager.gameManager._gameData.IsEngineDoorFix_M_C2)
        {
            Invoke("DoorFix", 2f);
        }

        
    }
    void DisableButton()
    {
        barkButton_M_EngineDoor.transform.gameObject.SetActive(false);
        sniffButton_M_EngineDoor.transform.gameObject.SetActive(false);
        biteButton_M_EngineDoor.transform.gameObject.SetActive(false);
        pressButton_M_EngineDoor.transform.gameObject.SetActive(false);
        observeButton_M_EngineDoor.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnObserve()
    {
        //B-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(21));

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = engineDoorObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsBrokenAreaData_M.IsNotInteractable = false;
        IsBrokenAreaOutline_M.OutlineWidth = 8;

/*        if (engineDoorData_M.IsObserve)
        {
            //Debug.Log("문이랑 상호작용 가능!");
            IsBrokenAreaData_M.IsNotInteractable = false;
            IsBrokenAreaOutline_M.OutlineWidth = 8;
        }

        else
        {
            IsBrokenAreaData_M.IsNotInteractable = true;
            IsBrokenAreaOutline_M.OutlineWidth = 0;
            
        }*/
    }

    void DoorFix()
    {
        /*CameraController.cameraController.CancelObserve();
        engineDoorData_M.IsObserve = false;*/

        //카드패드 상호작용 가능하게
        canInsertCardPadData_M.IsNotInteractable = false;
        canInsertCardPadOutline_M.OutlineWidth = 8;

        //엔진실 문 자체는 상호작용을 삭제한다.
        engineDoorData_M.IsNotInteractable = true;
        engineDoorOutline_M.OutlineWidth = 0;
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
        //상호작용 버튼을 끔
        DisableButton();
        //물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }


    public void OnSmash()
    {

    }

    public void OnUp()
    {

    }

    public void OnEat()
    {

    }

    public void OnInsert()
    {

    }
}
