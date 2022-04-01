using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Cockpit_Door : MonoBehaviour
{
    public GameObject envirPipe_CD; // 자식으로부터 가져오기
    public GameObject cockpitDoor_CD;

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
                DialogManager.dialogManager.DoorLock(); // AI 대사 나옴
            }

            if(envirPipeData_CD.IsBite)
            {
                cockpitDoorData_CD.IsCenterButtonDisabled = false; // 문 끼우기 버튼 활성화

                if(cockpitDoorData_CD.IsInsert)
                {
                    cockpitDoorData_CD.IsNotInteractable = true; // 문 상호작용 비활성화
                    cockpitDoorOutine_CD.OutlineWidth = 0;

                    insertAreaButton_CD.transform.gameObject.SetActive(true); // 끼우기 영역 활성화

                    if (IsInsertAreaClicked_CD&&InsertDetect.insertDetect.Isdetected)// 끼우기 영역 안에 들어왔을 때 영역을 클릭하면
                    {
                        insertAreaButton_CD.transform.gameObject.SetActive(false); // 끼우기 영역 비활성화

                        noahAnim_CD.SetBool("IsInserting", false); // 노아 끼우기 애니메이션 중단

                        cockpitDoorAnim_CD.SetBool("IsDoorOpenStart", true); // 문 열리는 애니메이션
                        cockpitDoorAnim_CD.SetBool("IsDoorOpened", true);
                        changeScene_CD.SetActive(true); // 업무공간 이동
                        cockpitDoorData_CD.IsInsert = false;
                        InteractionButtonController.interactionButtonController.IsInserting = false;
                        DialogManager.dialogManager.DoorLockEnd();
                        GameManager.gameManager.IsCockpitDoorOpened_M_C1 = true;
                    }
                }
            }
            else
            {
                cockpitDoorData_CD.IsCenterButtonDisabled = true; // 문 끼우기 버튼 비활성화
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
