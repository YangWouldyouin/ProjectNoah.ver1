using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, observeButton, DiableButton;

    PlayerEquipment equipment;
    GameObject portableGroup;

    ObjData TabletData_C;
    public ObjectData Tablet_C;

    /* 상호작용 오브젝트 */
    public GameObject TabletUI_C; // 태블릿 UI
    public GameObject TabletBackBlack_C; // 태블릿 비활성화 화면 (오브젝트 상태 화면)
    public GameObject TabletBackOn_C; // 태블릿 활성화 화면 (관찰하기 화면)
    public GameObject TabletBatteryUI_C; // 충전 전 0% 화면
    public GameObject TabletDeleteUI_C; // AI 발각 후 데이터 말소 화면

    public GameObject LoverPic_C; // 애인 사진
    public GameObject FullEgPad_C; // 충전 된 충전패드
    // public GameObject ZeroEgPad_C; // 충전 안 된 충전패드

    /* 오브젝트 데이터 */
    public ObjectData LoverPicData_C;
    public ObjectData FullEgPadData_C; // 충전 된 충전패드
    // ObjData ZeroEgPadData_C; // 충전 안 된 충전패드


    /*    private float timer = 0f; // 태블릿 감지 타이머
        public float DestroyTime = 5.0f; // 태블릿을 AI가 감지하기까지 걸리는 시간*/


    void Start()
    {
        equipment = BaseCanvas._baseCanvas.equipment;
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
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

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        DiableButton = TabletData_C.CenterButton1;

        // 만약에 충전 완료 변수가 참이면 태블릿 화면을 켜겠다 추가해야함
        //intialGameData GameManager.gameManager._gameData.IsFullChargeTablet == true
        // GameManager.gameManager._gameData.IsTabletUnlock = false;

        Tablet_C.IsObserve = false;
    }

    void Update()
    {
        if (Tablet_C.IsObserve == false)
        {
            TabletUI_C.SetActive(false);
            TabletBackBlack_C.SetActive(true);
            TabletBackOn_C.SetActive(false);
            TabletBatteryUI_C.SetActive(false);
            TabletDeleteUI_C.SetActive(false);
        }
        if(GameManager.gameManager._gameData.IsFullChargeTablet == false)
        {
            FullEgPad_C.gameObject.SetActive(true);
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
        DiableButton.transform.gameObject.SetActive(false);
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
        GameData intialGameData = SaveSystem.Load("save_001");
        DisableButton();
        PlayerScripts.playerscripts.currentObserveObj = gameObject;
        CameraController.cameraController.currentView = TabletData_C.ObserveView;
        InteractionButtonController.interactionButtonController.playerObserve();

/*        if (intialGameData.IsFullChargeTablet) // 태블릿 충전 O
        {
            Invoke("TabletOn", 3f);
            *//*
             타블렛 화면 진입 > 블루투스 온 > 타블렛 블루투스 = true;
            *//*
        }*/

        if (intialGameData.IsTabletDestory)
        {
            Invoke("TabletDelete", 3f); 
        }
        else
        {
            if (intialGameData.IsFullChargeTablet)
            {
                Invoke("TabletOn", 3f);

                //타블렛 화면 진입 > 블루투스 온 > 타블렛 블루투스 = true;
            }
            else // 태블릿 충전 X
            {
                Invoke("TabletOff", 3f);
                // 화면 켜지지 않음
            }
        }


        if (LoverPicData_C.IsBite)
        {
            GameManager.gameManager._gameData.IsTabletUnlock = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //Invoke("TabletLockOff", 1f);
            Debug.Log("태블릿 잠금해제");
        }
        /*else
        {
            GameManager.gameManager._gameData.IsTabletUnlock = false;
            // SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }*/
    }

    public void TabletOn()
    {
        TabletUI_C.SetActive(true);
        TabletBackBlack_C.SetActive(false);
        TabletBackOn_C.SetActive(true);
        TabletBatteryUI_C.SetActive(false);
        TabletDeleteUI_C.SetActive(false);
        Debug.Log("화면켜짐");
    }

    public void TabletOff()
    {
        TabletBatteryUI_C.SetActive(true);
    }

    public void TabletDelete()
    {
        TabletDeleteUI_C.SetActive(true);
    }

    public void TabletLockOff()
    {
        GameManager.gameManager._gameData.IsTabletUnlock = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }


    public void OnPushOrPress()
    {
        /* 밀기 & 누르기 중에 "누르기"일 때!!! */
        FullEgPadData_C.IsPushOrPress = true;// 오브젝트의 관찰 변수 true로 바꿈
        DisableButton(); // 상호작용 버튼을 끔

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈

        // 끼우기 성공
        // 부모 자식 관계를 해제한다.
        FullEgPad_C.GetComponent<Rigidbody>().isKinematic = false;
        FullEgPad_C.transform.parent = null;

        FullEgPad_C.SetActive(false);
        FullEgPad_C.transform.parent = portableGroup.transform;
        equipment.biteObjectName = "";

        Debug.Log("충전완료");
        GameManager.gameManager._gameData.IsFullChargeTablet = true; // 태블랫 충전 됨
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        Debug.Log("충전세이브 완료");
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        FullEgPadData_C.IsPushOrPress = false;

        // FullEgPad_C.gameObject.SetActive(false);
        //Debug.Log("충전패드 비활성화");

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
