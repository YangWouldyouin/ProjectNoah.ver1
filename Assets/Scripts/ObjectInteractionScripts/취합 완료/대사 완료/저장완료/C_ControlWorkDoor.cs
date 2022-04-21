using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ControlWorkDoor : MonoBehaviour, IInteraction
{
    public GameObject envirPipe_CWD; // �ڽ����κ��� ��������
    public GameObject cockpitDoor_CWD;

    ObjData envirPipeData_CWD;
    ObjData cockpitDoorData_CWD;

    public Button insertAreaButton_CWD;
    public Image stopMoving_CWD;
    private bool IsInsertAreaClicked_CWD = false;
    private float insertTimer_CWD = 0f;

    public Animator noahAnim_CWD;
    public Animator cockpitDoorAnim_CWD;

    Outline cockpitDoorOutine_CWD;
    public GameObject changeScene_CWD;

    public GameObject dialogManager_CWD;
    DialogManager dialogManager;

    private void Awake()
    {
        insertAreaButton_CWD.onClick.AddListener(CheckInsertTrueFor2Sec);
    }
    // Start is called before the first frame update
    void Start()
    {

        dialogManager = dialogManager_CWD.GetComponent<DialogManager>();

        envirPipeData_CWD = envirPipe_CWD.GetComponent<ObjData>();
        cockpitDoorData_CWD = cockpitDoor_CWD.GetComponent<ObjData>();

        cockpitDoorOutine_CWD = cockpitDoor_CWD.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            if (cockpitDoorData_CWD.IsClicked)
            {
                GameManager.gameManager._gameData.S_IsCWDoorOpened_M_C1 = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //dialogManager.StartCoroutine(dialogManager.PrintAIDialog(3));
                
            }

            if (envirPipeData_CWD.IsBite)
            {
                cockpitDoorData_CWD.IsCenterButtonDisabled = false; // �� ����� ��ư Ȱ��ȭ

                if (cockpitDoorData_CWD.IsInsert)
                {
                    cockpitDoorData_CWD.IsNotInteractable = true; // �� ��ȣ�ۿ� ��Ȱ��ȭ
                    cockpitDoorOutine_CWD.OutlineWidth = 0;
                    stopMoving_CWD.transform.gameObject.SetActive(true); // �÷��̾� �� �����̵��� ȭ�鿡 ������ �̹��� Ȱ��ȭ
                    insertAreaButton_CWD.transform.gameObject.SetActive(true); // ����� ���� Ȱ��ȭ

                    if (IsInsertAreaClicked_CWD && InsertDetect.insertDetect.Isdetected)// ����� ���� �ȿ� ������ �� ������ Ŭ���ϸ�
                    {
                        insertAreaButton_CWD.transform.gameObject.SetActive(false); // ����� ���� ��Ȱ��ȭ

                        noahAnim_CWD.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

                        cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
                        cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);
                        changeScene_CWD.SetActive(true); // �������� �̵�

                        stopMoving_CWD.transform.gameObject.SetActive(false); // �÷��̾� �ٽ� ������ �� �ֵ��� ȭ���� ������ �̹��� ��Ȱ��ȭ
                        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));

                        GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                        cockpitDoorData_CWD.IsInsert = false;
                    }
                }
            }
            else
            {
                cockpitDoorData_CWD.IsCenterButtonDisabled = true; // �� ����� ��ư ��Ȱ��ȭ
            }
        }

    }
    void CheckInsertTrueFor2Sec()
    {
        IsInsertAreaClicked_CWD = true;
        insertTimer_CWD += Time.deltaTime;
        if (insertTimer_CWD >= 2f)
        {
            IsInsertAreaClicked_CWD = false;
            insertTimer_CWD = 0;
        }
    }

    public void OnBark()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        throw new System.NotImplementedException();
    }

    public void OnBiteDestroy()
    {
        throw new System.NotImplementedException();
    }

    public void OnPushOrPress()
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

    public void OnInsert()
    {
        /* ������Ʈ�� ����� ���� true�� �ٲ� */
        cockpitDoorData_CWD.IsInsert = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        //DiableButton();

        /* "�����" �� �̵��� ��ġ�� ���� �ֱ� */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);
        /* ����� �ִϸ��̼� & �̵� */
        InteractionButtonController.interactionButtonController.PlayerInsert1();

        cockpitDoorData_CWD.IsNotInteractable = true; // �� ��ȣ�ۿ� ��Ȱ��ȭ
        cockpitDoorOutine_CWD.OutlineWidth = 0;

        stopMoving_CWD.transform.gameObject.SetActive(true); // �÷��̾� �� �����̵��� ȭ�鿡 ������ �̹��� Ȱ��ȭ
        insertAreaButton_CWD.transform.gameObject.SetActive(true); // ����� ���� Ȱ��ȭ

        if (IsInsertAreaClicked_CWD && InsertDetect.insertDetect.Isdetected)// ����� ���� �ȿ� ������ �� ������ Ŭ���ϸ�
        {
            insertAreaButton_CWD.transform.gameObject.SetActive(false); // ����� ���� ��Ȱ��ȭ

            noahAnim_CWD.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

            cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
            cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);

            changeScene_CWD.SetActive(true); // �������� �̵�

            stopMoving_CWD.transform.gameObject.SetActive(false); // �÷��̾� �ٽ� ������ �� �ֵ��� ȭ���� ������ �̹��� ��Ȱ��ȭ

            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));

            GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            cockpitDoorData_CWD.IsInsert = false;
        }
    }
}
