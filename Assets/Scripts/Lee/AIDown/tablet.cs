using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton;

    ObjData TabletData_C;
    public ObjectData Tablet_C;

    /* 상호작용 오브젝트 */
    public GameObject TabletUI_C; // 태블릿 UI
    public GameObject TabletBackBlack_C; // 태블릿 비활성화 화면 (오브젝트 상태 화면)
    public GameObject TabletBackOn_C; // 태블릿 활성화 화면 (관찰하기 화면)

/*    public GameObject FullEgPad_C; // 충전 된 충전패드
    public GameObject ZeroEgPad_C; // 충전 안 된 충전패드

    *//* 오브젝트 데이터 *//*
    ObjData FullEgPadData_C; // 충전 된 충전패드
    ObjData ZeroEgPadData_C; // 충전 안 된 충전패드*/


/*    private float timer = 0f; // 태블릿 감지 타이머
    public float DestroyTime = 5.0f; // 태블릿을 AI가 감지하기까지 걸리는 시간*/


    void Start()
    {
        TabletData_C = GetComponent<ObjData>();

        barkButton = TabletData_C.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = TabletData_C.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = TabletData_C.BiteButton;

        pressButton = TabletData_C.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = TabletData_C.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);
    }

    void Update()
    {
        if (Tablet_C.IsObserve == false)
        {
            TabletUI_C.SetActive(false);
            TabletBackBlack_C.SetActive(true);
            TabletBackOn_C.SetActive(false);
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        TabletData_C.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = TabletData_C.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

        if (GameManager.gameManager._gameData.IsFullChargeTablet == true) // 태블릿 충전 O
        {
            Invoke("TabletOn", 3f);
            /*
             타블렛 화면 진입 > 블루투스 온 > 타블렛 블루투스 = true;
            */
        }
        else // 태블릿 충전 X
        {
            // 화면 켜지지 않음
        }
    }

    public void TabletOn()
    {
        TabletUI_C.SetActive(true);
        TabletBackBlack_C.SetActive(false);
        TabletBackOn_C.SetActive(true);
    }


    public void OnPushOrPress()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }
    public void OnSniff()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
    }
    public void OnInsert()
    {
    }
    public void OnSmash()
    {
    }
    public void OnUp()
    {
    }
}
