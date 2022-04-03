using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ControlWorkDoor : MonoBehaviour
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

    private void Awake()
    {
        insertAreaButton_CWD.onClick.AddListener(CheckInsertTrueFor2Sec);
    }
    // Start is called before the first frame update
    void Start()
    {
        envirPipeData_CWD = envirPipe_CWD.GetComponent<ObjData>();
        cockpitDoorData_CWD = cockpitDoor_CWD.GetComponent<ObjData>();

        cockpitDoorOutine_CWD = cockpitDoor_CWD.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.IsAI_M_C1)
        {
            if (cockpitDoorData_CWD.IsClicked)
            {
                //DialogManager.dialogManager.DoorLock(); // AI ��� ����
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
                        //DialogManager.dialogManager.DoorLockEnd();
                        GameManager.gameManager.IsCockpitDoorOpened_M_C1 = true;
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

}
