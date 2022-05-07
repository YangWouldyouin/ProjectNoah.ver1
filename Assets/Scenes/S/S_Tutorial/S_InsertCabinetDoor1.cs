using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_InsertCabinetDoor1 : MonoBehaviour,IInteraction
{
    public bool IsInsertCabinetDoorOpen = false;

    /*관련있는 오브젝트들*/
    //public GameObject S_IsInsertAreaClicked;
    public Image S_stopMoving;
    public Button S_InsertAreaButton;
    private Camera mainCamera;
    public GameObject S_InsertAreaButtonPos;

    private Button barkButton_S_InsertCabinetDoor1, sniffButton_S_InsertCabinetDoor1, biteButton_S_InsertCabinetDoor1,
        pressButton_S_InsertCabinetDoor1, insertButton_S_InsertCabinetDoor1, insertDisableButton_S_InsertCabinetDoor1;

    ObjData insertCabinetDoor1Data_S;
    public ObjectData canInsertCabinetDoor1Data_S;
    public ObjectData canInsertCabinetBody1Data_S;
    public ObjectData PipeForInsertData_S;

    /*아웃라인*/
    public Outline canInsertCabinetBody1Outline_S;
    Outline insertCabinetDoor1Outline_S;

    /*애니메이션*/
    public Animator canInsertCabinetDoor1Anim;
    public Animator noahAnim_S;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(new Vector3(S_InsertAreaButtonPos.transform.localPosition.x, S_InsertAreaButtonPos.transform.localPosition.y,
   S_InsertAreaButtonPos.transform.localPosition.z));
        S_InsertAreaButton.transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);

        /*연관있는 오브젝트*/
        insertCabinetDoor1Data_S = GetComponent<ObjData>();

        barkButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.BarkButton;
        barkButton_S_InsertCabinetDoor1.onClick.AddListener(OnBark);

        sniffButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.SniffButton;
        sniffButton_S_InsertCabinetDoor1.onClick.AddListener(OnSniff);

        biteButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.BiteButton;
        biteButton_S_InsertCabinetDoor1.onClick.AddListener(OnBite);

/*        smashButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SmashButton;
        //biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);*/

        pressButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.PushOrPressButton;
        pressButton_S_InsertCabinetDoor1.onClick.AddListener(OnPushOrPress);

        insertButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.CenterButton2;
        insertButton_S_InsertCabinetDoor1.onClick.AddListener(OnInsert);

        insertDisableButton_S_InsertCabinetDoor1 = insertCabinetDoor1Data_S.CenterButton1;

        /*아웃라인*/
        insertCabinetDoor1Outline_S = GetComponent<Outline>();
    }

    void DisableButton()
    {
        barkButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        sniffButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        biteButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        pressButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        insertButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
        insertDisableButton_S_InsertCabinetDoor1.transform.gameObject.SetActive(false);
    }

    void Awake()
    {
        S_InsertAreaButton.onClick.AddListener(InsertAreaButton1);
    }

    // Update is called once per frame
    void Update()
    {
        if (PipeForInsertData_S.IsBite)
        {
            insertCabinetDoor1Data_S.IsCenterButtonChanged = true;
        }

        else
        {
            insertCabinetDoor1Data_S.IsCenterButtonChanged = false;
        }
    }

    void InsertAreaButton1()
    {
        if (InsertDetect.insertDetect.Isdetected)// 끼우기 영역 안에 들어왔을 때 영역을 클릭하면
        {
            S_InsertAreaButton.transform.gameObject.SetActive(false); // 끼우기 영역 비활성화

            noahAnim_S.SetBool("IsInserting", false); // 노아 끼우기 애니메이션 중단

            //캐비닛 문 여는 애니메이션
            Invoke("CabinetOpen1", 2f);

            S_stopMoving.transform.gameObject.SetActive(false); // 플레이어 다시 움직일 수 있도록 화면의 투명한 이미지 비활성화
            /* 오른쪽 취소 다시 품 */

/*            GameManager.gameManager._gameData.IsCWDoorOpened_M_C1 = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/

            canInsertCabinetBody1Data_S.IsInsert = false;

            canInsertCabinetBody1Data_S.IsNotInteractable = false; //캐비닛 몸 상호작용 가능
            canInsertCabinetBody1Outline_S.OutlineWidth = 8;
        }
    }

    public void OnInsert()
    {
        canInsertCabinetBody1Data_S.IsInsert = true;
        DisableButton();
        PlayerScripts.playerscripts.currentInsertObj = this.gameObject;

        /* "끼우기" 시 이동할 위치와 각도 넣기 */
        InteractionButtonController.interactionButtonController.insertPosOffset = new Vector3(-1f, 0.7599989f, -27.72f);
        InteractionButtonController.interactionButtonController.insertRotOffset = new Vector3(0, -20f, 0);

        /* 끼우기 애니메이션 & 이동 */
        InteractionButtonController.interactionButtonController.PlayerInsert1();
       
        // 캐비닛 문 비활성화
        insertCabinetDoor1Data_S.IsNotInteractable = true;
        insertCabinetDoor1Outline_S.OutlineWidth = 0;

        S_stopMoving.transform.gameObject.SetActive(true); // 플레이어 못 움직이도록 화면에 투명한 이미지 활성화
        S_InsertAreaButton.transform.gameObject.SetActive(true); // 끼우기 영역 활성화

/*        if(*//*S_IsInsertAreaClicked &&*//* InsertDetect.insertDetect.Isdetected)
        {
            S_InsertAreaButton.transform.gameObject.SetActive(false);// 끼우기 영역 비활성화

            noahAnim_S.SetBool("IsInserting", false); // 노아 끼우기 애니메이션 중단

            //캐비닛 문 여는 애니메이션
            Invoke("CabinetOpen1", 2f);

            S_stopMoving.transform.gameObject.SetActive(false);

            canInsertCabinetBody1Data_S.IsInsert = false;

            canInsertCabinetBody1Data_S.IsNotInteractable = false; //캐비닛 몸 상호작용 가능
            canInsertCabinetBody1Outline_S.OutlineWidth = 8;

            *//*            GameManager.gameManager._gameData.IsnsertCabinetOpened_M_C1 = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*//*
        }*/

    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    void CabinetOpen1()
    {

        canInsertCabinetDoor1Anim.SetBool("eInsertCabinetOpen", true);
        canInsertCabinetDoor1Anim.SetBool("eInsertCabinetEnd", true);

        //bool 캐비닛 문이 열렸다를 트루로 체크 save를 넣어줘야 되나?
        Debug.Log("캐비닛 몸에 상호작용 가능해요");
        //캐비닛 바디에 상호작용 가능하게



        /*        IsminiCabinetDoorOpen = true;

                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/
    }



    public void OnUp()
    {
    }

    public void OnEat()
    {
    }
    public void OnObserve()
    {
    }

    public void OnBite()
    {
        //상호작용 버튼을 끔
        DisableButton();
        //물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
