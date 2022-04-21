using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ControlWorkDoor : MonoBehaviour, IInteraction
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
                        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));

                        GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

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
        /* 오브젝트의 끼우기 변수 true로 바꿈 */
        cockpitDoorData_CWD.IsInsert = true;

        /* 상호작용 버튼을 끔 */
        //DiableButton();

        /* "끼우기" 시 이동할 위치와 각도 넣기 */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(1, 0, 1);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 0, 0);
        /* 끼우기 애니메이션 & 이동 */
        InteractionButtonController.interactionButtonController.PlayerInsert1();

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

            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));

            GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            cockpitDoorData_CWD.IsInsert = false;
        }
    }
}
