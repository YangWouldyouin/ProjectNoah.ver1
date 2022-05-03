using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ControlWorkDoor : MonoBehaviour, IInteraction
{

    private Button barkButton, biteButton,
     pressButton, sniffButton, insertButton, insertDisableButton;



    public GameObject envirPipe_CWD; // �ڽ����κ��� ��������
    public GameObject cockpitDoor_CWD;

    ObjData envirPipeData_CWD;
    ObjData cockpitDoorData_CWD;
    private Camera mainCamera;
    public Button insertAreaButton_CWD;
    public GameObject insertAreaButtonPos;

    public Image stopMoving_CWD;
    private bool IsInsertAreaClicked_CWD = false;
    private float insertTimer_CWD = 0f;

    public Animator noahAnim_CWD;
    public Animator cockpitDoorAnim_CWD;

    Outline cockpitDoorOutine_CWD;
    public GameObject changeScene_CWD;

    public GameObject dialogManager_CWD;
    DialogManager dialogManager;

    CancelInteractions cancelInteractions;
    public GameObject cancelController;
    private void Awake()
    {
        cancelInteractions = cancelController.GetComponent<CancelInteractions>();
        insertAreaButton_CWD.onClick.AddListener(InsertAreaButton);
    }

    void InsertAreaButton()
    {
        if (InsertDetect.insertDetect.Isdetected)// ����� ���� �ȿ� ������ �� ������ Ŭ���ϸ�
        {
            insertAreaButton_CWD.transform.gameObject.SetActive(false); // ����� ���� ��Ȱ��ȭ

            noahAnim_CWD.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

            cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
            cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);

            changeScene_CWD.SetActive(true); // �������� �̵�

            stopMoving_CWD.transform.gameObject.SetActive(false); // �÷��̾� �ٽ� ������ �� �ֵ��� ȭ���� ������ �̹��� ��Ȱ��ȭ
            /* ������ ��� �ٽ� ǰ */
            cancelInteractions.enabled = true;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));

            GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            cockpitDoorData_CWD.IsInsert = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Scene ���� MainCamera ��� Tag �� ù��°�� Ȱ��ȭ�� ī�޶� ��Ÿ��
        Vector3 screenPos = mainCamera.WorldToScreenPoint(new Vector3(insertAreaButtonPos.transform.localPosition.x , insertAreaButtonPos.transform.localPosition.y,
            insertAreaButtonPos.transform.localPosition.z));
        insertAreaButton_CWD.transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
        dialogManager = dialogManager_CWD.GetComponent<DialogManager>();

        envirPipeData_CWD = envirPipe_CWD.GetComponent<ObjData>();
        cockpitDoorData_CWD = GetComponent<ObjData>();
        cockpitDoorOutine_CWD = cockpitDoor_CWD.GetComponent<Outline>();

        barkButton = cockpitDoorData_CWD.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        biteButton = cockpitDoorData_CWD.BiteButton;

        pressButton = cockpitDoorData_CWD.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        sniffButton = cockpitDoorData_CWD.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        insertButton = cockpitDoorData_CWD.CenterButton1;
        insertButton.onClick.AddListener(OnInsert);

        insertDisableButton = cockpitDoorData_CWD.CenterDisableButton1;

        if(GameManager.gameManager._gameData.IsAIAwake_M_C1)
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


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // ��� ��� 
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(3));

            // ������ Ż�� �̼� �߰�
            GameManager.gameManager._gameData.S_IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
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
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);
        /* ����� �ִϸ��̼� & �̵� */
        InteractionButtonController.interactionButtonController.PlayerInsert1();

        cockpitDoorData_CWD.IsNotInteractable = true; // �� ��ȣ�ۿ� ��Ȱ��ȭ
        cockpitDoorOutine_CWD.OutlineWidth = 0;

        stopMoving_CWD.transform.gameObject.SetActive(true); // �÷��̾� �� �����̵��� ȭ�鿡 ������ �̹��� Ȱ��ȭ
        insertAreaButton_CWD.transform.gameObject.SetActive(true); // ����� ���� Ȱ��ȭ
}





    public void OnBark()
    {
        /* ������Ʈ�� ¢�� ���� true�� �ٲ� */
        cockpitDoorData_CWD.IsBark = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DisableButton();
        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* ������Ʈ�� �����ñ� ���� true�� �ٲ� */
        cockpitDoorData_CWD.IsSniff = true;
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
