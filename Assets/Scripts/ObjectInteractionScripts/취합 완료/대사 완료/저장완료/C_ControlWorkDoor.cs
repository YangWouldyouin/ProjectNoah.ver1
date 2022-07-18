using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ControlWorkDoor : MonoBehaviour, IInteraction
{

    private Button barkButton, biteButton,
     pressButton, sniffButton, insertButton, insertDisableButton;

    public GameObject cockpitDoor_CWD;

    public ObjectData envirPipeData_CWD;
    public ObjectData cockpitDoorData_CWD;

    ObjData cockpitDoorObjData_CWD;

    private Camera mainCamera;
    public Button insertAreaButton_CWD;
    public GameObject insertAreaButtonPos;

    public Image stopMoving_CWD;

    public Animator noahAnim_CWD;
    public Animator cockpitDoorAnim_CWD;

    Outline cockpitDoorOutine_CWD;
    public GameObject changeScene_CWD;

    public GameObject dialogManager_CWD;
    DialogManager dialogManager;

    CancelInteractions cancelInteractions;
    public GameObject cancelController;

    public GameObject controlDoorDetect;
    InsertDetect insertDetect;

    AudioSource Door_open_sound; 
    public AudioClip Door_open;

    //public GameObject controlCameraController;
    //ControlCameraController controllCamera;
    public GameObject workLight;

    bool firstCheck = false;

    public void InsertAreaButton()
    {
        Debug.Log("Ŭ����1");
        if (insertDetect.Isdetected)// ����� ���� �ȿ� ������ �� ������ Ŭ���ϸ�
        {
            Debug.Log("Ŭ����2");
            insertAreaButton_CWD.transform.gameObject.SetActive(false); // ����� ���� ��Ȱ��ȭ

            noahAnim_CWD.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

            cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
            cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);

            Door_open_sound.clip = Door_open;
            Door_open_sound.Play();



            stopMoving_CWD.transform.gameObject.SetActive(false); // �÷��̾� �ٽ� ������ �� �ֵ��� ȭ���� ������ �̹��� ��Ȱ��ȭ
            /* ������ ��� �ٽ� ǰ */
            cancelInteractions.enabled = true;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));

            GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
            //GameManager.gameManager._gameData.ActiveMissionList[1] = false;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            //MissionGenerator.missionGenerator.ActivateMissionList();
            MissionGenerator.missionGenerator.DeleteNewMission(1);
            StartCoroutine(GoToWork());



            cockpitDoorData_CWD.IsInsert = false;
            //if (controllCamera != null)
            //    controllCamera.enabled = true;
            //workLight.SetActive(true);
        }
    }

    IEnumerator GoToWork()
    { 
        yield return new WaitForSeconds(3f);
        changeScene_CWD.SetActive(true); // �������� �̵�
    }

    void Update()
    {
        //if (cockpitDoorData_CWD.IsClicked && GameManager.gameManager._gameData.IsAIAwake_M_C1&&!firstCheck)
        //{
        //    // ��� ��� 
        //    dialogManager.StartCoroutine(dialogManager.PrintAIDialog(3));
        //    // ������ Ż�� �̼� �߰�
        //    //GameManager.gameManager._gameData.ActiveMissionList[1] = true;
        //    //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        //    //MissionGenerator.missionGenerator.ActivateMissionList();
        //    MissionGenerator.missionGenerator.AddNewMission(1);

        //    firstCheck = true;
        //}

        //if(envirPipeData_CWD.IsBite)
        //{
        //    cockpitDoorData_CWD.IsCenterButtonDisabled = false;
        //}
        //else
        //{
        //    cockpitDoorData_CWD.IsCenterButtonDisabled = true;
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        //controllCamera = controlCameraController.GetComponent<ControlCameraController>();
        Door_open_sound = GetComponent<AudioSource>();

        insertDetect = controlDoorDetect.GetComponent<InsertDetect>();
        mainCamera = Camera.main; // Scene ���� MainCamera ��� Tag �� ù��°�� Ȱ��ȭ�� ī�޶� ��Ÿ��
        Vector3 screenPos = mainCamera.WorldToScreenPoint(new Vector3(insertAreaButtonPos.transform.localPosition.x , insertAreaButtonPos.transform.localPosition.y,
            insertAreaButtonPos.transform.localPosition.z));
        insertAreaButton_CWD.transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
        dialogManager = dialogManager_CWD.GetComponent<DialogManager>();

        cockpitDoorObjData_CWD = GetComponent<ObjData>();
        cockpitDoorOutine_CWD = GetComponent<Outline>();

        barkButton = cockpitDoorObjData_CWD.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        biteButton = cockpitDoorObjData_CWD.BiteButton;

        pressButton = cockpitDoorObjData_CWD.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        sniffButton = cockpitDoorObjData_CWD.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        insertButton = cockpitDoorObjData_CWD.CenterButton1;
        insertButton.onClick.AddListener(OnInsert);

        insertDisableButton = cockpitDoorObjData_CWD.CenterDisableButton1;

        cancelInteractions = cancelController.GetComponent<CancelInteractions>();

        if (GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            cockpitDoorOutine_CWD.OutlineWidth = 8;
            cockpitDoorData_CWD.IsNotInteractable = false;
        }
        else
        {
            cockpitDoorOutine_CWD.OutlineWidth = 0;
            cockpitDoorData_CWD.IsNotInteractable = true;
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        insertButton.transform.gameObject.SetActive(false);
        insertDisableButton.transform.gameObject.SetActive(false);
    }

    public void OnInsert()
    {
        /* ������Ʈ�� ����� ���� true�� �ٲ� */
        cockpitDoorData_CWD.IsInsert = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /* ������ ��� ���� */
        cancelInteractions.enabled = false;

        PlayerScripts.playerscripts.currentInsertObj = this.gameObject;

        /* "�����" �� �̵��� ��ġ�� ���� �ֱ� */
        //InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(-3, 0, -3);
        //InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 45, 0);
        /* ����� �ִϸ��̼� & �̵� */
        InteractionButtonController.interactionButtonController.PlayerInsert1();

        cockpitDoorData_CWD.IsNotInteractable = true; // �� ��ȣ�ۿ� ��Ȱ��ȭ
        cockpitDoorOutine_CWD.OutlineWidth = 0;

        stopMoving_CWD.transform.gameObject.SetActive(true); // �÷��̾� �� �����̵��� ȭ�鿡 ������ �̹��� Ȱ��ȭ
        insertAreaButton_CWD.transform.gameObject.SetActive(true); // ����� ���� Ȱ��ȭ
}





    public void OnBark()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
    }


    public void OnBite()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }




    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        throw new System.NotImplementedException();
    }
}
