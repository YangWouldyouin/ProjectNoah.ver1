using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Cabinet3 : MonoBehaviour, IInteraction
{
    private Button barkButton_W_Cabinet3, sniffButton_W_Cabinet3, biteButton_W_Cabinet3,
pushButton_W_Cabinet3, observeButton_W_Cabinet3, smashButton_W_Cabinet3;

    ObjData Cabinet3_W;
    public ObjectData Cabinet3Obj_W;
    ObjData Card_KeyData_W_C3;
    public ObjectData Card_KeyObj_W_C3;

    /* 사용 오브젝트 */
    public GameObject Card_Key_W_C3; // 카드키
    public GameObject livingDoor;

    /* 오브젝트 아웃라인 */
    private Outline Cabinet3Outline_M; // 캐비닛

    private Outline Card_Key3Outline_M; // 캐비닛


    void Start()
    {
        /* 사용 오브젝트 데이터 불러오기 */
        Cabinet3_W = GetComponent<ObjData>();
        Card_KeyData_W_C3 = Card_Key_W_C3.GetComponent<ObjData>();
        Card_Key3Outline_M = Card_Key_W_C3.GetComponent<Outline>(); // 오브젝트 아웃라인

        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_W_Cabinet3 = Cabinet3_W.BarkButton;
        barkButton_W_Cabinet3.onClick.AddListener(OnBark); // 버튼에 함수를 넣어준다

        sniffButton_W_Cabinet3 = Cabinet3_W.SniffButton;
        sniffButton_W_Cabinet3.onClick.AddListener(OnSniff);

        biteButton_W_Cabinet3 = Cabinet3_W.BiteButton;
        biteButton_W_Cabinet3.onClick.AddListener(OnBite);

        pushButton_W_Cabinet3 = Cabinet3_W.PushOrPressButton;
        pushButton_W_Cabinet3.onClick.AddListener(OnPushOrPress);

        observeButton_W_Cabinet3 = Cabinet3_W.CenterButton1; // CenterButton1에 '관찰하기'버튼 삽입
        observeButton_W_Cabinet3.onClick.AddListener(OnObserve);

        //Card_Key_W_C3.SetActive(false); // 카드키 관찰하기 전에 안보이게
        //처음부터 상호작용 안되고 관찰하기 할때만 상호작용 가능
        Card_Key3Outline_M.OutlineWidth = 0;
        Card_KeyObj_W_C3.IsNotInteractable = true;
        Cabinet3Obj_W.IsObserve = false;
        Cabinet3Obj_W.IsNotInteractable = false;
    }

    /* 상호작용 버튼을 끄는 함수 */
    void DiableButton()
    {
        barkButton_W_Cabinet3.transform.gameObject.SetActive(false);
        sniffButton_W_Cabinet3.transform.gameObject.SetActive(false);
        biteButton_W_Cabinet3.transform.gameObject.SetActive(false);
        pushButton_W_Cabinet3.transform.gameObject.SetActive(false);
        observeButton_W_Cabinet3.transform.gameObject.SetActive(false);
    }
    void Update()
    {
/*        if (Cabinet3_W.IsObserve == false && Card_KeyData_W_C3.IsInsert == false) // 캐비닛 관찰하기, 캐비닛 
        {
            *//* 카드키 비활성화 *//*
            Card_Key3Outline_M.OutlineWidth = 0;
            Card_KeyData_W_C3.IsNotInteractable = true;
        }*/

        if(GameManager.gameManager._gameData.IsCompleteFindLivingKey)
        {
            /* 카드키 오브젝트 활성화 */
            Card_Key3Outline_M.OutlineWidth = 8; // 카드키 아웃라인 활성화
            Card_KeyObj_W_C3.IsNotInteractable = false;

            Card_Key_W_C3.SetActive(true); // 카드키 오브젝트 보이게
        }
    }


    public void OnBark()
    {
        Cabinet3_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }


    /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 시작 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    public void OnObserve()
    {
        DiableButton();
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        CameraController.cameraController.currentView = Cabinet3_W.ObserveView; // 관찰 뷰 : 위쪽
        InteractionButtonController.interactionButtonController.playerObserve(); // 관찰 애니메이션 & 카메라 전환

        /* 카드키 오브젝트 활성화 */
        Card_Key3Outline_M.OutlineWidth = 8; // 카드키 아웃라인 활성화
        Card_KeyData_W_C3.IsNotInteractable = false;

        Card_Key_W_C3.SetActive(true); // 카드키 오브젝트 보이게

        // 업데이트문에서 오브젝트 터치로 미션 추가하는 것들은 이후 터치 안되게 콜라이더 끄기
        BoxCollider livingCollider = livingDoor.GetComponent<BoxCollider>();
        livingCollider.enabled = false;

        GameManager.gameManager._gameData.IsCompleteFindLivingKey = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // 미션이 추가되어있는지 확인 후 삭제
        GameData mission2Data = SaveSystem.Load("save_001");
        if(mission2Data.ActiveMissionList[2])
        {
            MissionGenerator.missionGenerator.DeleteNewMission(2);
        }
    }

    public void OnPushOrPress()
    {
        Cabinet3_W.IsPushOrPress = true;
        DiableButton();
        // 머리로 누르는 애니메이션  
        InteractionButtonController.interactionButtonController.PlayerCanNotPush();


        /* 2초 뒤에 IsPushOrPress 를 false 로 바꿈 */
        StartCoroutine(ChangePressFalse());
    }
    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Cabinet3_W.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        Cabinet3_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }





    public void OnBite()
    {
        DiableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();

        // throw new System.NotImplementedException();
    }
    public void OnInsert()
    {
    }
    public void OnEat()
    {
    }
    public void OnSmash()
    {
    }
    public void OnUp()
    {
    }

}
