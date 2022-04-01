using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Cockpit_Door : MonoBehaviour
{
<<<<<<< HEAD

    public GameObject envirPipe_M_C1_2; // �ڽ����κ��� ��������

    public GameObject cockpitDoor_M_C1_2;
=======
    public GameObject envirPipe_CD; // �ڽ����κ��� ��������
    public GameObject cockpitDoor_CD;
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc

    ObjData envirPipeData_CD;
    ObjData cockpitDoorData_CD;

    public Button insertAreaButton_CD;
    private bool IsInsertAreaClicked_CD = false;
    private float insertTimer_CD = 0f;

    public Animator noahAnim_CD;
    public Animator cockpitDoorAnim_CD;

    Outline cockpitDoorOutine_CD;
    public GameObject changeScene_CD;

    private void Awake()
    {
        insertAreaButton_CD.onClick.AddListener(CheckInsertTrueFor2Sec);
    }
    // Start is called before the first frame update
    void Start()
    {
        envirPipeData_CD = envirPipe_CD.GetComponent<ObjData>();
        cockpitDoorData_CD = cockpitDoor_CD.GetComponent<ObjData>();

        cockpitDoorOutine_CD = cockpitDoor_CD.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager.IsAI_M_C1)
        {
            if(cockpitDoorData_CD.IsClicked)
            {
                DialogManager.dialogManager.DoorLock(); // AI ��� ����
            }

            if(envirPipeData_CD.IsBite)
            {
                cockpitDoorData_CD.IsCenterButtonDisabled = false; // �� ����� ��ư Ȱ��ȭ

                if(cockpitDoorData_CD.IsInsert)
                {
                    cockpitDoorData_CD.IsNotInteractable = true; // �� ��ȣ�ۿ� ��Ȱ��ȭ
                    cockpitDoorOutine_CD.OutlineWidth = 0;

                    insertAreaButton_CD.transform.gameObject.SetActive(true); // ����� ���� Ȱ��ȭ

                    if (IsInsertAreaClicked_CD&&InsertDetect.insertDetect.Isdetected)// ����� ���� �ȿ� ������ �� ������ Ŭ���ϸ�
                    {
                        insertAreaButton_CD.transform.gameObject.SetActive(false); // ����� ���� ��Ȱ��ȭ

                        noahAnim_CD.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

<<<<<<< HEAD
                        cockpitDoorAnim_M_C1_2.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
                        cockpitDoorAnim_M_C1_2.SetBool("IsDoorOpened", true);
                        changeScene_M_C1_2.SetActive(true); // �������� �̵�
                        cockpitDoorData_M_C1.IsInsert = false;
=======
                        cockpitDoorAnim_CD.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
                        cockpitDoorAnim_CD.SetBool("IsDoorOpened", true);
                        changeScene_CD.SetActive(true); // �������� �̵�
                        cockpitDoorData_CD.IsInsert = false;
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc
                        InteractionButtonController.interactionButtonController.IsInserting = false;
                        DialogManager.dialogManager.DoorLockEnd();
                        GameManager.gameManager.IsCockpitDoorOpened_M_C1 = true;
                    }
                }
            }
            else
            {
                cockpitDoorData_CD.IsCenterButtonDisabled = true; // �� ����� ��ư ��Ȱ��ȭ
            }
        }
        
    }
    void CheckInsertTrueFor2Sec()
    {
        IsInsertAreaClicked_CD = true;
        insertTimer_CD += Time.deltaTime;
        if(insertTimer_CD>=2f)
        {
            IsInsertAreaClicked_CD = false;
            insertTimer_CD = 0;
        }
    }

}
