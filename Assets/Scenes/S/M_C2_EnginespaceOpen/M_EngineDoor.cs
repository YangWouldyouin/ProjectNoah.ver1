using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class M_EngineDoor : MonoBehaviour, IInteraction
{
    public bool dontrootmore = false;
    public bool dontrootmore2 = false;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_EngineDoor, sniffButton_M_EngineDoor, biteButton_M_EngineDoor, pressButton_M_EngineDoor, observeButton_M_EngineDoor;

    ObjData engineDoorObjData_M;
    public ObjectData engineDoorData_M;

    public ObjectData IsBrokenAreaData_M;
    public ObjectData canInsertCardPadData_M;

    /*�ƿ�����*/
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

        /*��ư*/
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

        /*�ƿ�����*/
        engineDoorOutline_M = GetComponent<Outline>();

        /*�������*/
        engineDoorData_M.IsObserve = false;

    }

    void Update()
    {
        if(dontrootmore == false && GameManager.gameManager._gameData.IsCompleteOpenEngineRoom == false)
        {
            // ������ ī��Ű ã�� �ӹ�����Ʈ ���� ����������������������������������������������������������������������
            // ������ �� ��ġ�� �ӹ�����Ʈ ���� ����������������������������������������������������������������������
            // ������/â�� �ر� �ӹ�����Ʈ ���� ����������������������������������������������������������������������

            GameManager.gameManager._gameData.ActiveMissionList[4] = true;
            GameManager.gameManager._gameData.ActiveMissionList[5] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();

            dontrootmore = true;
        }

        if (engineDoorData_M.IsClicked && dontrootmore2 == false)
        {
            //B-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(20));

            //GameManager.gameManager._gameData.ActiveMissionList[3] = true;
            GameManager.gameManager._gameData.ActiveMissionList[30] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();

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
        //B-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(21));

        DisableButton();

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = engineDoorObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();

        IsBrokenAreaData_M.IsNotInteractable = false;
        IsBrokenAreaOutline_M.OutlineWidth = 8;

/*        if (engineDoorData_M.IsObserve)
        {
            //Debug.Log("���̶� ��ȣ�ۿ� ����!");
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

        //ī���е� ��ȣ�ۿ� �����ϰ�
        canInsertCardPadData_M.IsNotInteractable = false;
        canInsertCardPadOutline_M.OutlineWidth = 8;

        //������ �� ��ü�� ��ȣ�ۿ��� �����Ѵ�.
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
        //��ȣ�ۿ� ��ư�� ��
        DisableButton();
        //���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸�
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
