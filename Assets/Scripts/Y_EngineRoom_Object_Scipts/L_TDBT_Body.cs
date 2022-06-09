using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_TDBT_Body : MonoBehaviour, IInteraction
{
    public ObjectData TDBT_fixPartData;

    private Button barkButton_L_TDBT_Body, sniffButton_L_TDBT_Body, biteButton_L_TDBT_Body, pushButton_L_TDBT_Body, noCenterButton_L_TDBT_Body;
    ObjData TDBT_BodyData_L;
    ObjectData bodyData;

    PlayerEquipment playerEquipment;
    GameObject portableObject;

    public GameObject TDBT_fixPart;

    Outline TDBT_BodyOutline, TDBT_fixPartOutline;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    void Start()
    {
        portableObject = InteractionButtonController.interactionButtonController.portableObjects;
        dialogManager = dialog_CS.GetComponent<DialogManager>();

        if (!GameManager.gameManager._gameData.IsFirstEnterLiving)
        {
            GameManager.gameManager._gameData.IsFirstEnterLiving = true;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(10));
            GameManager.gameManager._gameData.ActiveMissionList[15] = true;

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            MissionGenerator.missionGenerator.ActivateMissionList();

            //������ ��Ȱ���� ��ġ�� ����
        }

        playerEquipment = BaseCanvas._baseCanvas.equipment;

        TDBT_BodyData_L = GetComponent<ObjData>();
        bodyData = TDBT_BodyData_L.objectDATA;
        bodyData.IsNotInteractable = false;
        TDBT_BodyOutline = GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();

        /* ObjData �κ��� ��ȣ�ۿ� ��ư�� �����´�. */
        barkButton_L_TDBT_Body = TDBT_BodyData_L.BarkButton;
        barkButton_L_TDBT_Body.onClick.AddListener(OnBark);

        sniffButton_L_TDBT_Body = TDBT_BodyData_L.SniffButton;
        sniffButton_L_TDBT_Body.onClick.AddListener(OnSniff);

        biteButton_L_TDBT_Body = TDBT_BodyData_L.BiteButton;
        biteButton_L_TDBT_Body.onClick.AddListener(OnBite);

        pushButton_L_TDBT_Body = TDBT_BodyData_L.PushOrPressButton;
        pushButton_L_TDBT_Body.onClick.AddListener(OnPushOrPress);

        noCenterButton_L_TDBT_Body = TDBT_BodyData_L.CenterButton1;
    }

    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        sniffButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        biteButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        pushButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        noCenterButton_L_TDBT_Body.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (TDBT_fixPartData.IsBite) // ��ǰ�� ��������
        {
            StartCoroutine(TrashDoorButtonDone());
           // Invoke("TrashDoorButtonDone", 1.5f);
        }
    }

    IEnumerator TrashDoorButtonDone()
    {
        yield return new WaitForSeconds(2f);
        TDBT_fixPart.GetComponent<Rigidbody>().isKinematic = false;
        TDBT_fixPart.transform.parent = null;

        TDBT_fixPart.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
        TDBT_fixPart.transform.rotation = Quaternion.Euler(0, -90, 0);
        TDBT_fixPart.transform.localScale = new Vector3(50f, 50.00002f, 50.00002f);
        TDBT_fixPart.transform.parent = portableObject.transform;

        //TDBT_fixPartData.enabled = false;
        //TDBT_BodyData_L.enabled = false;

        TDBT_fixPartData.IsNotInteractable = true;
        bodyData.IsNotInteractable = true;
        TDBT_BodyOutline.OutlineWidth = 0;
        TDBT_fixPartOutline.OutlineWidth = 0;

        TDBT_fixPartData.IsBite = false;
        playerEquipment.biteObjectName = "";



        GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L1 = true;
        GameManager.gameManager._gameData.ActiveMissionList[15] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        MissionGenerator.missionGenerator.ActivateMissionList();

        //������ ��Ȱ���� ��ġ�� ��
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /*  ���⸸ �ϴ� �ִϸ��̼� & �� �� ���� ������Ʈ���� �˸� */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
