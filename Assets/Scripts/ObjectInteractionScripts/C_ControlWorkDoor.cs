using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ControlWorkDoor : MonoBehaviour
{
    public GameObject envirPipe_CWD; // 자식으로부터 가져오기
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
                //DialogManager.dialogManager.DoorLock(); // AI 대사 나옴
            }

            if (envirPipeData_CWD.IsBite)
            {
                cockpitDoorData_CWD.IsCenterButtonDisabled = false; // 문 끼우기 버튼 활성화

                if (cockpitDoorData_CWD.IsInsert)
                {
                    cockpitDoorData_CWD.IsNotInteractable = true; // 문 상호작용 비활성화
                    cockpitDoorOutine_CWD.OutlineWidth = 0;
                    stopMoving_CWD.transform.gameObject.SetActive(true); // 플레이어 못 움직이도록 화면에 투명한 이미지 활성화
                    insertAreaButton_CWD.transform.gameObject.SetActive(true); // 끼우기 영역 활성화

                    if (IsInsertAreaClicked_CWD && InsertDetect.insertDetect.Isdetected)// 끼우기 영역 안에 들어왔을 때 영역을 클릭하면
                    {
                        insertAreaButton_CWD.transform.gameObject.SetActive(false); // 끼우기 영역 비활성화

                        noahAnim_CWD.SetBool("IsInserting", false); // 노아 끼우기 애니메이션 중단

                        cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // 문 열리는 애니메이션
                        cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);
                        changeScene_CWD.SetActive(true); // 업무공간 이동

                        stopMoving_CWD.transform.gameObject.SetActive(false); // 플레이어 다시 움직일 수 있도록 화면의 투명한 이미지 비활성화
                        //DialogManager.dialogManager.DoorLockEnd();
                        GameManager.gameManager.IsCockpitDoorOpened_M_C1 = true;
                        cockpitDoorData_CWD.IsInsert = false;
                    }
                }
            }
            else
            {
                cockpitDoorData_CWD.IsCenterButtonDisabled = true; // 문 끼우기 버튼 비활성화
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
