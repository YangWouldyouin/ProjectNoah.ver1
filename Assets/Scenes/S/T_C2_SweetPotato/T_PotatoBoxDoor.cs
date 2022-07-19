using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_PotatoBoxDoor : MonoBehaviour, IInteraction
{
    public bool DontClickPotato = false;

    /*�����ִ� ������Ʈ*/
    //public GameObject SweetPotatoBoxDoor_T;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_PotatoBoxDoor, sniffButton_T_PotatoBoxDoor, biteButton_T_PotatoBoxDoor,
        pressButton_T_PotatoBox, noCenterButton_T_PotatoBox;

    /*ObjData*/
    ObjData PotatoBoxDoorData_T;
    public ObjectData IsPotatoBoxDoorData_T;
    public ObjectData PotatoBoxBodyData_T;

    public Outline PotatoBoxDoorOutline_T;
    public Outline PotatoBoxBodyOutline_T;

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    BoxCollider PotatoBoxDoorCollider_T;

    void Start()
    {
        /*�������*/
        IsPotatoBoxDoorData_T.IsBite = false;
        IsPotatoBoxDoorData_T.IsNotInteractable = false;

        dialogManager = dialogManager_CS.GetComponent<DialogManager>();

        PotatoBoxDoorCollider_T = GetComponent<BoxCollider>();

        /*ObjData*/
        PotatoBoxDoorData_T = GetComponent<ObjData>();

        /*ObjData*/
        barkButton_T_PotatoBoxDoor = PotatoBoxDoorData_T.BarkButton;
        barkButton_T_PotatoBoxDoor.onClick.AddListener(OnBark);

        sniffButton_T_PotatoBoxDoor = PotatoBoxDoorData_T.SniffButton;
        sniffButton_T_PotatoBoxDoor.onClick.AddListener(OnSniff);

        biteButton_T_PotatoBoxDoor = PotatoBoxDoorData_T.BiteButton;
        biteButton_T_PotatoBoxDoor.onClick.AddListener(OnBite);

        pressButton_T_PotatoBox = PotatoBoxDoorData_T.PushOrPressButton;
        pressButton_T_PotatoBox.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_PotatoBox = PotatoBoxDoorData_T.CenterButton1;
    }

    void Update()
    {
        if (IsPotatoBoxDoorData_T.IsClicked && !GameManager.gameManager._gameData.IsBrokenPotatoDoor)
        {
            //A-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(15));

            GameData gameData = SaveSystem.Load("save_001");
            if(!gameData.CompleteMissionList[18])
            {
                // ����� ���� �ӹ�����Ʈ ���� ����������������������������������������������������������������������
                // �Ĺ� ��� �ӹ�����Ʈ ���� ����������������������������������������������������������������������
                // ������ ���� �ӹ�����Ʈ ���� ����������������������������������������������������������������������
                MissionGenerator.missionGenerator.AddNewMission(18);
                StartCoroutine(SecondMission());
                //StartCoroutine(ThirdMission()); // ��� ���� ����� ���� ������
                GameManager.gameManager._gameData.CompleteMissionList[18] = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
            DontClickPotato = true;
        }
    }

    IEnumerator SecondMission()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(19);
    }

    IEnumerator ThirdMission()
    {
        yield return new WaitForSeconds(4f);
        MissionGenerator.missionGenerator.AddNewMission(20);
    }

    void DisableButton()
    {
        barkButton_T_PotatoBoxDoor.transform.gameObject.SetActive(false);
        sniffButton_T_PotatoBoxDoor.transform.gameObject.SetActive(false);
        biteButton_T_PotatoBoxDoor.transform.gameObject.SetActive(false);
        pressButton_T_PotatoBox.transform.gameObject.SetActive(false);
        noCenterButton_T_PotatoBox.transform.gameObject.SetActive(false);
    }

    public void OnSmash()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotSmash();
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

        Invoke("OpenDoor", 3f);

    }

    void OpenDoor()
    {
        // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
        gameObject.transform.position = new Vector3(-267.07f, 0.0562f, 671.847f); //��ġ ����
        gameObject.transform.rotation = Quaternion.Euler(182.235f, -89.98401f, 180f); //���� ����
        gameObject.transform.localScale = new Vector3(57.88517f, 4.21771f, 56.0183f); // ũ�� ����

        // ���� �� �̻� ��ȣ�ۿ� �Ұ�
        IsPotatoBoxDoorData_T.IsNotInteractable = true;
        PotatoBoxDoorOutline_T.OutlineWidth = 0;

        Debug.Log("���� ��ȣ�ۿ� �����ؿ�");
        // ��ü�� ��ȣ�ۿ� ����
        PotatoBoxBodyData_T.IsNotInteractable = false;
        PotatoBoxBodyOutline_T.OutlineWidth = 8;

        //�ݶ��̴��� ����.
        PotatoBoxDoorCollider_T.enabled = false;
        //potatoEquipment.biteObjectName = "";

        GameManager.gameManager._gameData.IsBrokenPotatoDoor = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
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

    public void OnUp()
    {
       
    }
}
