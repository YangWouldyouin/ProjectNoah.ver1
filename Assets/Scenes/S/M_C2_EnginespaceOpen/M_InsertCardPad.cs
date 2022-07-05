using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_InsertCardPad : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject GoToEngine;
    public GameObject M_canEngineCardKey;
    public GameObject M_canBrokenDoorConduction;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_InsertCardPad, sniffButton_M_InsertCardPad, biteButton_M_InsertCardPad, 
        pressButton_M_InsertCardPad, observeButton_M_InsertCardPad, observeDisableButton_M_InsertCardPad;

    ObjData insertCardPadObjData_M;
    public ObjectData insertCardPadData_M;
    public ObjectData canEngineCardKeyData_M;

    /*�ƿ�����*/
    Outline insertCardPadOutline_M;
    Outline canEngineCardKeyOutline_M;

    public Animator engineDoorAnim_M;

    /* ����� */
    AudioSource InsertCardPad_sound;
    public AudioClip EngineDoor_open;
    public AudioClip CardKey_Sound;
    PlayerEquipment equipment;

    PortableObjectData workRoomData;
    GameObject portableGroup;
    

    void Start()
    {
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        equipment = BaseCanvas._baseCanvas.equipment;
        InsertCardPad_sound = GetComponent<AudioSource>();

        /*�����ִ� ������Ʈ*/
        insertCardPadObjData_M = GetComponent<ObjData>();



        /*��ư*/
        barkButton_M_InsertCardPad = insertCardPadObjData_M.BarkButton;
        barkButton_M_InsertCardPad.onClick.AddListener(OnBark);

        sniffButton_M_InsertCardPad = insertCardPadObjData_M.SniffButton;
        sniffButton_M_InsertCardPad.onClick.AddListener(OnSniff);

        biteButton_M_InsertCardPad = insertCardPadObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_InsertCardPad = insertCardPadObjData_M.PushOrPressButton;
        pressButton_M_InsertCardPad.onClick.AddListener(OnPushOrPress);

        observeButton_M_InsertCardPad = insertCardPadObjData_M.CenterButton1;
        observeButton_M_InsertCardPad.onClick.AddListener(OnObserve);

        observeDisableButton_M_InsertCardPad = insertCardPadObjData_M.CenterButton2;


        /*�ƿ�����*/
        canEngineCardKeyOutline_M = M_canEngineCardKey.GetComponent<Outline>();
        insertCardPadOutline_M = GetComponent<Outline>();

        /*�������*/
        insertCardPadData_M.IsObserve = false;
        insertCardPadData_M.IsCenterButtonChanged = true;


    }

    void Update()
    {
        if ( insertCardPadData_M.IsCollision)
        {
            insertCardPadData_M.IsCenterButtonChanged = false;
        }

       else
        {
            insertCardPadData_M.IsCenterButtonChanged = true;
        }

        if (insertCardPadData_M.IsObserve)
        {
            insertCardPadData_M.IsCenterButtonChanged = true;
        }
    }

    void DisableButton()
    {
        barkButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        sniffButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        biteButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        pressButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        observeButton_M_InsertCardPad.transform.gameObject.SetActive(false);
        observeDisableButton_M_InsertCardPad.transform.gameObject.SetActive(false);

    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        DisableButton();

        insertCardPadData_M.IsCenterButtonChanged = true;

        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;

        CameraController.cameraController.currentView = insertCardPadObjData_M.ObserveView;

        InteractionButtonController.interactionButtonController.playerObserve();
    }

    void CardBye()
    {
        CameraController.cameraController.CancelObserve();
    }

    void DoorOpen() // ������ ���� �ִϸ��̼�
    {
        M_canBrokenDoorConduction.SetActive(false);
        workRoomData.IsObjectActiveList[33] = false;
        engineDoorAnim_M.SetBool("canEngineDoorOpen", true);
        engineDoorAnim_M.SetBool("canEngineDoorEnd", true);

        /*������ ���� ���� �Ϸ�*/
        GoToEngine.SetActive(true);
        GameManager.gameManager._gameData.IsCompleteOpenEngineRoom = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // ������/â�� �ر� �ӹ�����Ʈ �� ����������������������������������������������������������������������
        //GameManager.gameManager._gameData.ActiveMissionList[5] = false;
        //GameManager.gameManager._gameData.ActiveMissionList[3] = false;
        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //MissionGenerator.missionGenerator.ActivateMissionList();
        MissionGenerator.missionGenerator.DeleteNewMission(5);
        StartCoroutine(DeleteThird());

    }

    IEnumerator DeleteThird()
    {
        yield return new WaitForSeconds(3f);
        MissionGenerator.missionGenerator.DeleteNewMission(3);
    }

    IEnumerator canCardBye()
    {
        yield return new WaitForSeconds(1f);
        CameraController.cameraController.CancelObserve();
    }

    IEnumerator canDoorOpen()
    {
        yield return new WaitForSeconds(2f);

        M_canBrokenDoorConduction.SetActive(false);
        workRoomData.IsObjectActiveList[33] = false;
        CameraController.cameraController.CancelObserve();
        engineDoorAnim_M.SetBool("canEngineDoorOpen", true);
        engineDoorAnim_M.SetBool("canEngineDoorEnd", true);

        /*������ ���� ���� �Ϸ�*/
        GoToEngine.SetActive(true);
        GameManager.gameManager._gameData.IsCompleteOpenEngineRoom = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // ������/â�� �ر� �ӹ�����Ʈ �� ����������������������������������������������������������������������
        //GameManager.gameManager._gameData.ActiveMissionList[5] = false;
        //GameManager.gameManager._gameData.ActiveMissionList[3] = false;
        //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //MissionGenerator.missionGenerator.ActivateMissionList();
        MissionGenerator.missionGenerator.DeleteNewMission(5);
        StartCoroutine(DeleteThird());
        //MissionGenerator.missionGenerator.DeleteNewMission(3);

    }

    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        if (canEngineCardKeyData_M.IsBite && insertCardPadData_M.IsObserve)
        {
            // ����� ����
            // �θ� �ڽ� ���踦 �����Ѵ�.

            // ī��Ű ���� ���� ����
                                                                                                                                                                                                                                                                                                                                         
            M_canEngineCardKey.GetComponent<Rigidbody>().isKinematic = false;
            M_canEngineCardKey.transform.parent = null;

            // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
            M_canEngineCardKey.transform.position = new Vector3(-262.489f, 2.2762f, 666.788f); //��ġ ����
            M_canEngineCardKey.transform.rotation = Quaternion.Euler(0, 0, 90); //���� ����
            equipment.biteObjectName = "";
            M_canEngineCardKey.transform.parent = portableGroup.transform;

            InsertCardPad_sound.clip = CardKey_Sound;
            InsertCardPad_sound.Play();

            // ī���е�� ī���� ��ȣ�ۿ��� �����Ѵ�.
            canEngineCardKeyData_M.IsNotInteractable = true;
            canEngineCardKeyOutline_M.OutlineWidth = 0;

            insertCardPadData_M.IsNotInteractable = true;
            insertCardPadOutline_M.OutlineWidth = 0;

            //ī��ȴ� �ִϸ��̼� ����
            //Invoke("CardBye", 1f);
            //StartCoroutine(canCardBye());

            InsertCardPad_sound.clip = EngineDoor_open;
            InsertCardPad_sound.Play();

            //�������� �ִϸ��̼� ����
            //Invoke("DoorOpen", 2f);
            StartCoroutine(canDoorOpen());
        }
    }


    public void OnBite()
    {
        //��ȣ�ۿ� ��ư�� ��
        DisableButton();
        //���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸�
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
