using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ControlWorkDoor : MonoBehaviour, IInteraction
{

    private Button barkButton, biteButton,
     pressButton, sniffButton, insertButton, insertDisableButton;

    public GameObject cockpitDoor_CWD;

    public ObjectData envirPipeData_CWD;
    public ObjectData cockpitDoorData_CWD;

    ObjData cockpitDoorObjData_CWD;

    private Camera mainCamera;
    public Button insertAreaButton_CWD;
    public GameObject insertAreaButtonPos;

    public Image stopMoving_CWD;

    public Animator noahAnim_CWD;
    public Animator cockpitDoorAnim_CWD;

    Outline cockpitDoorOutine_CWD;
    public GameObject changeScene_CWD;

    public GameObject dialogManager_CWD;
    DialogManager dialogManager;

    CancelInteractions cancelInteractions;
    public GameObject cancelController;

    public GameObject controlDoorDetect;
    InsertDetect insertDetect;

    public void InsertAreaButton()
    {
        Debug.Log("클릭함1");
        if (insertDetect.Isdetected)// 끼우기 영역 안에 들어왔을 때 영역을 클릭하면
        {
            Debug.Log("클릭함2");
            insertAreaButton_CWD.transform.gameObject.SetActive(false); // 끼우기 영역 비활성화

            noahAnim_CWD.SetBool("IsInserting", false); // 노아 끼우기 애니메이션 중단

            cockpitDoorAnim_CWD.SetBool("IsDoorOpenStart", true); // 문 열리는 애니메이션
            cockpitDoorAnim_CWD.SetBool("IsDoorOpened", true);

            changeScene_CWD.SetActive(true); // 업무공간 이동

            stopMoving_CWD.transform.gameObject.SetActive(false); // 플레이어 다시 움직일 수 있도록 화면의 투명한 이미지 비활성화
            /* 오른쪽 취소 다시 품 */
            cancelInteractions.enabled = true;
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(4));

            GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            cockpitDoorData_CWD.IsInsert = false;
        }
    }

    void Update()
    {
        if (cockpitDoorData_CWD.IsClicked && GameManager.gameManager._gameData.IsAIAwake_M_C1)
        {
            // 대사 출력 
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(3));

            // 조종실 탈출 미션 추가
            GameManager.gameManager._gameData.S_IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        if(envirPipeData_CWD.IsBite)
        {
            cockpitDoorData_CWD.IsCenterButtonDisabled = false;
        }
        else
        {
            cockpitDoorData_CWD.IsCenterButtonDisabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        insertDetect = controlDoorDetect.GetComponent<InsertDetect>();
        mainCamera = Camera.main; // Scene 에서 MainCamera 라고 Tag 가 첫번째로 활성화된 카메라를 나타냄
        Vector3 screenPos = mainCamera.WorldToScreenPoint(new Vector3(insertAreaButtonPos.transform.localPosition.x , insertAreaButtonPos.transform.localPosition.y,
            insertAreaButtonPos.transform.localPosition.z));
        insertAreaButton_CWD.transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
        dialogManager = dialogManager_CWD.GetComponent<DialogManager>();

        cockpitDoorObjData_CWD = GetComponent<ObjData>();
        cockpitDoorOutine_CWD = GetComponent<Outline>();

        barkButton = cockpitDoorObjData_CWD.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        biteButton = cockpitDoorObjData_CWD.BiteButton;

        pressButton = cockpitDoorObjData_CWD.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        sniffButton = cockpitDoorObjData_CWD.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        insertButton = cockpitDoorObjData_CWD.CenterButton1;
        insertButton.onClick.AddListener(OnInsert);

        insertDisableButton = cockpitDoorObjData_CWD.CenterDisableButton1;

        cancelInteractions = cancelController.GetComponent<CancelInteractions>();

        if (GameManager.gameManager._gameData.IsAIAwake_M_C1)
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

    public void OnInsert()
    {
        /* 오브젝트의 끼우기 변수 true로 바꿈 */
        cockpitDoorData_CWD.IsInsert = true;

        /* 상호작용 버튼을 끔 */
        DisableButton();
        /* 오른쪽 취소 막음 */
        cancelInteractions.enabled = false;

        PlayerScripts.playerscripts.currentInsertObj = this.gameObject;

        /* "끼우기" 시 이동할 위치와 각도 넣기 */
        //InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(-3, 0, -3);
        //InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, 45, 0);
        /* 끼우기 애니메이션 & 이동 */
        InteractionButtonController.interactionButtonController.PlayerInsert1();

        cockpitDoorData_CWD.IsNotInteractable = true; // 문 상호작용 비활성화
        cockpitDoorOutine_CWD.OutlineWidth = 0;

        stopMoving_CWD.transform.gameObject.SetActive(true); // 플레이어 못 움직이도록 화면에 투명한 이미지 활성화
        insertAreaButton_CWD.transform.gameObject.SetActive(true); // 끼우기 영역 활성화
}





    public void OnBark()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
    }


    public void OnBite()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
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
