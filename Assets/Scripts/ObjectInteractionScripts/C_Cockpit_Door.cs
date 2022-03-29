using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Cockpit_Door : MonoBehaviour
{

    public GameObject envirPipe_M_C1_2; // 자식으로부터 가져오기

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
                DialogManager.dialogManager.DoorLock(); // AI 대사 나옴
            }
            if(envirPipeData_M_C1_2.IsBite)
            {
                cockpitDoorData_M_C1.IsCenterButtonDisabled = false; // 문 끼우기 버튼 활성화

                if(cockpitDoorData_M_C1.IsInsert)
                {
                    cockpitDoorData_M_C1.IsNotInteractable = true; // 문 상호작용 비활성화
                    cockpitDoorOutine_M_C1_2.OutlineWidth = 0;

                    insertAreaButton.transform.gameObject.SetActive(true); // 끼우기 영역 활성화

                    if (IsInsertAreaClicked&&InsertDetect.insertDetect.Isdetected)// 끼우기 영역 안에 들어왔을 때 영역을 클릭하면
                    {
                        insertAreaButton.transform.gameObject.SetActive(false); // 끼우기 영역 비활성화

                        noahAnim_M_C1_2.SetBool("IsInserting", false); // 노아 끼우기 애니메이션 중단

                        cockpitDoorAnim_M_C1_2.SetBool("IsDoorOpenStart", true); // 문 열리는 애니메이션
                        cockpitDoorAnim_M_C1_2.SetBool("IsDoorOpened", true);
                        changeScene_M_C1_2.SetActive(true); // 업무공간 이동
                        cockpitDoorData_M_C1.IsInsert = false;
                        InteractionButtonController.interactionButtonController.IsInserting = false;
                        GameManager.gameManager.IsCockpitDoorOpened_M_C1 = true;
                    }
                }
            }
            else
            {
                cockpitDoorData_M_C1.IsCenterButtonDisabled = true; // 문 끼우기 버튼 비활성화
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
