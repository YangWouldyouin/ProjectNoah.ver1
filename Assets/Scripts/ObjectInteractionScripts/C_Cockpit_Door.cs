using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Cockpit_Door : MonoBehaviour
{

    public GameObject envirPipe_M_C1_2; // �ڽ����κ��� ��������

    public GameObject cockpitDoor_M_C1_2;


    ObjData envirPipeData_M_C1_2;
    ObjData cockpitDoorData_M_C1;

    public Button insertAreaButton;
    private bool IsInsertAreaClicked = false;
    private float insertTimer = 0f;

    public Animator noahAnim_M_C1_2;
    public Animator cockpitDoorAnim_M_C1_2;

    Outline cockpitDoorOutine_M_C1_2;
    public GameObject changeScene_M_C1_2;

    private void Awake()
    {
        insertAreaButton.onClick.AddListener(CheckInsertTrueFor2Sec);
    }
    // Start is called before the first frame update
    void Start()
    {
        envirPipeData_M_C1_2 = envirPipe_M_C1_2.GetComponent<ObjData>();
        cockpitDoorData_M_C1 = cockpitDoor_M_C1_2.GetComponent<ObjData>();

        cockpitDoorOutine_M_C1_2 = cockpitDoor_M_C1_2.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager.IsAI_M_C1)
        {
            if(cockpitDoorData_M_C1.IsClicked)
            {
                DialogManager.dialogManager.DoorLock(); // AI ��� ����
            }
            if(envirPipeData_M_C1_2.IsBite)
            {
                cockpitDoorData_M_C1.IsCenterButtonDisabled = false; // �� ����� ��ư Ȱ��ȭ

                if(cockpitDoorData_M_C1.IsInsert)
                {
                    cockpitDoorData_M_C1.IsNotInteractable = true; // �� ��ȣ�ۿ� ��Ȱ��ȭ
                    cockpitDoorOutine_M_C1_2.OutlineWidth = 0;

                    insertAreaButton.transform.gameObject.SetActive(true); // ����� ���� Ȱ��ȭ

                    if (IsInsertAreaClicked&&InsertDetect.insertDetect.Isdetected)// ����� ���� �ȿ� ������ �� ������ Ŭ���ϸ�
                    {
                        insertAreaButton.transform.gameObject.SetActive(false); // ����� ���� ��Ȱ��ȭ

                        noahAnim_M_C1_2.SetBool("IsInserting", false); // ��� ����� �ִϸ��̼� �ߴ�

                        cockpitDoorAnim_M_C1_2.SetBool("IsDoorOpenStart", true); // �� ������ �ִϸ��̼�
                        cockpitDoorAnim_M_C1_2.SetBool("IsDoorOpened", true);
                        changeScene_M_C1_2.SetActive(true); // �������� �̵�
                        cockpitDoorData_M_C1.IsInsert = false;
                        InteractionButtonController.interactionButtonController.IsInserting = false;
                        GameManager.gameManager.IsCockpitDoorOpened_M_C1 = true;
                    }
                }
            }
            else
            {
                cockpitDoorData_M_C1.IsCenterButtonDisabled = true; // �� ����� ��ư ��Ȱ��ȭ
            }
        }
        
    }
    void CheckInsertTrueFor2Sec()
    {
        IsInsertAreaClicked = true;
        insertTimer += Time.deltaTime;
        if(insertTimer>=2f)
        {
            IsInsertAreaClicked = false;
            insertTimer = 0;
        }
    }

}
