using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LivingSpace_CardKeyMachine : MonoBehaviour, IInteraction
{
    /* 오브젝트의 상호작용 버튼들 */
    private Button barkButton_W_LS_CardKeyMachine, sniffButton_W_LS_CardKeyMachine, biteButton_W_LS_CardKeyMachine,
pushButton_W_LS_CardKeyMachine, observeButton_W_LS_CardKeyMachine, smashButton_W_LS_CardKeyMachine, DisableobserveButton_W_LS_CardKeyMachine;

    /* 해당 오브젝트의 ObjData 변수 */
    ObjData LivingSpace_CardKeyMachine_W;
    public ObjectData LivingSpace_CardKeyMachineData_W;

    /* 이 오브젝트와 상호작용 하는 변수들 + 데이터 */
    public GameObject box_WL;
    public GameObject CardKey_WL;
    public GameObject LivingDoomDoor_WL;

    public ObjectData boxData_WL;
    public ObjectData CardKeyData_WL;
    public ObjectData LivingDoomDoorData_WL;

    /* 오브젝트 아웃라인 */
    Outline CardMachineOutline_M; // 카드머신
    Outline LivingCardKeyOutline_M; // 카드키


    /* 애니메이션 */
    public Animator HalfLivingDoorAni_M; // 생활공간 문 반만 열리기

    public GameObject dialogManager_CS;
    DialogManager dialogManager;

    /* 오디오 */
    AudioSource LivingSpace_CardKeyMachine;
    public AudioClip LivingDoor_Halfopen;
    public AudioClip CardKey_Sound;

    public GameObject goToLivingRoom;

    void Start()
    {
        LivingSpace_CardKeyMachine = GetComponent<AudioSource>();

        /* 해당 오브젝트의 ObjData를 가져온다. */
        LivingSpace_CardKeyMachine_W = GetComponent<ObjData>();
/*        boxData_WL = box_WL.GetComponent<ObjData>();
        CardKeyData_WL = CardKey_WL.GetComponent<ObjData>();
        LivingDoomDoorData_WL = LivingDoomDoor_WL.GetComponent<ObjData>();*/

        CardMachineOutline_M = LivingSpace_CardKeyMachine_W.GetComponent<Outline>(); // 카드머신 아웃라인
        LivingCardKeyOutline_M = CardKey_WL.GetComponent<Outline>(); // 카드키 아웃라인


        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BarkButton;
        barkButton_W_LS_CardKeyMachine.onClick.AddListener(OnBark);

        sniffButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.SniffButton;
        sniffButton_W_LS_CardKeyMachine.onClick.AddListener(OnSniff);

        biteButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.BiteButton;
        biteButton_W_LS_CardKeyMachine.onClick.AddListener(OnBite); // "물기"가 안되는 오브젝트

        pushButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.PushOrPressButton;
        pushButton_W_LS_CardKeyMachine.onClick.AddListener(OnPushOrPress);

        observeButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.CenterButton1;
        observeButton_W_LS_CardKeyMachine.onClick.AddListener(OnObserve);

        DisableobserveButton_W_LS_CardKeyMachine = LivingSpace_CardKeyMachine_W.CenterButton2;

        /*        HalfLivingDoorAni_M.SetBool("HalfOpen", false); // 애니메이션 재생 금지*/

        /*선언시작*/
        LivingSpace_CardKeyMachineData_W.IsObserve = false;
        LivingSpace_CardKeyMachineData_W.IsCenterButtonChanged = false;
        LivingSpace_CardKeyMachineData_W.IsNotInteractable = false;
    }

    /* 상호작용 버튼을 끄는 함수 */
    void DiableButton() // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.
    {   
        barkButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        sniffButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        biteButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        pushButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        observeButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
        DisableobserveButton_W_LS_CardKeyMachine.transform.gameObject.SetActive(false);
    }



    void Update()
    {
        if (LivingSpace_CardKeyMachineData_W.IsObserve)
        {
            LivingSpace_CardKeyMachineData_W.IsCenterButtonChanged = true;
        }

        else
        {
            LivingSpace_CardKeyMachineData_W.IsCenterButtonChanged = false;
        }

        if (LivingSpace_CardKeyMachineData_W.IsObserve)
        {
            LivingSpace_CardKeyMachineData_W.IsNotInteractable = false;
            CardMachineOutline_M.OutlineWidth = 8;
        }

        if (GameManager.gameManager._gameData.IsCompleteHalfOpenLivingRoom == true)
        {
            LivingSpace_CardKeyMachineData_W.IsNotInteractable = true;
            CardMachineOutline_M.OutlineWidth = 0;
        }
    }

    public void OnBark()
    {
        LivingSpace_CardKeyMachine_W.IsBark = true; // 오브젝트의 짖기 변수 true로 바꿈
        DiableButton(); // 상호작용 버튼을 끔
        InteractionButtonController.interactionButtonController.playerBark(); //애니메이션 보여줌
    }

    public void OnObserve()
    {
        LivingSpace_CardKeyMachine_W.IsObserve = true;
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;// 취소할 때 참고할 오브젝트 저장
        DiableButton();

        if (boxData_WL.IsUpDown) // 상자에 올라갔을 때
        {
            Debug.Log("위");
            // 카메라 컨트롤러에 뷰 전달
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObservePlusView; // 관찰 뷰 : 위쪽
            // 관찰 애니메이션 &카메라 전환
            InteractionButtonController.interactionButtonController.playerObserve();
        }

        if(!boxData_WL.IsUpDown) // 상자에 올라가지 않았을 때
        {
            Debug.Log("아래");
            /* 카메라 컨트롤러에 뷰 전달 */
            CameraController.cameraController.currentView = LivingSpace_CardKeyMachine_W.ObserveView; // 관찰 뷰 : 아래쪽
            /* 관찰 애니메이션 & 카메라 전환 */
            InteractionButtonController.interactionButtonController.playerObserve();
        }
    }

    public void OnPushOrPress()
    {
        /* 밀기 & 누르기 중에 "누르기"일 때!!! */

        LivingSpace_CardKeyMachine_W.IsPushOrPress = true; // 오브젝트의 관찰 변수 true로 바꿈
        DiableButton(); // 상호작용 버튼을 끔

        /* 애니메이션 */
        InteractionButtonController.interactionButtonController.playerPressHead(); // 손으로 누르는 애니메이션
                                                                                   //StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈

        if (CardKeyData_WL.IsBite && boxData_WL.IsUpDown && LivingSpace_CardKeyMachineData_W.IsObserve) // 카드키 '물기' && 박스 '오르기' 했을 떄
        {
            Debug.Log("카드키 꽂을게요");
            // 누르기 -> 카드키를 카드기계에 삽입 완료
            // 부모-자식 관계 해제
            CardKey_WL.GetComponent<Rigidbody>().isKinematic = false;
            CardKey_WL.transform.parent = null;

            // 카드키 위치, 각도 변환
            CardKey_WL.transform.position = new Vector3(-264.18f, 2.94f, 691.467f); //위치
            CardKey_WL.transform.rotation = Quaternion.Euler(0, 0, 90); //각도

            LivingSpace_CardKeyMachine.clip = CardKey_Sound;
            LivingSpace_CardKeyMachine.Play();

            // 카드키, 카드기계 상호작용 삭제
            CardKeyData_WL.IsNotInteractable = true;
            LivingCardKeyOutline_M.OutlineWidth = 0;

            LivingSpace_CardKeyMachineData_W.IsNotInteractable = true;
            CardMachineOutline_M.OutlineWidth = 0;

            Debug.Log("생활공간 문 열리는 애니메이션");

            // LivingDoomDoor_WL.GetComponent<Animator>().Play("LivingDoorHalfOpen");
            StartCoroutine(LivingDoorHalfOpen1());
            //Invoke("LivingDoorHalfOpen", 2f); // 문 열리는 애니메이션 실행

            LivingSpace_CardKeyMachine.clip = LivingDoor_Halfopen;
            LivingSpace_CardKeyMachine.Play();

            GameManager.gameManager._gameData.IsWLDoorHalfOpened_M_C2 = true; // 항상 업무공간에서 생활공간 이동 가능
            GameManager.gameManager._gameData.IsCompleteHalfOpenLivingRoom = true; // 생활공간 문 반만 오픈 완료

            /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 끝 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */

            GameManager.gameManager._gameData.ActiveMissionList[4] = false;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            Debug.Log("생활공간 문 변수 저장");

            /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ Y-3대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(29));

            if (GameManager.gameManager._gameData.IsWEDoorOpened_M_C2)
            {
                GameManager.gameManager._gameData.IsAllDoorOpened = true;
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(12));
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }
        else
        {
            /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 카드키 안 물었을 때 -> Y-1대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
            if (CardKeyData_WL.IsBite == false)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(27));
            }
            /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 상자에 올라가지 않았을 때 -> Y-2대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
            if (boxData_WL.IsUpDown == false)
            {
                dialogManager.StartCoroutine(dialogManager.PrintAIDialog(28));
            }
        }
    }
    IEnumerator ChangePressFalse() // 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴
    {
        yield return new WaitForSeconds(2f);
        LivingSpace_CardKeyMachine_W.IsPushOrPress = false;
    }


    IEnumerator LivingDoorHalfOpen1()
    {
        yield return new WaitForSeconds(2f);
        goToLivingRoom.SetActive(true);
        HalfLivingDoorAni_M.SetBool("HalfOpen", true); // 생활공간 문 반만 열리기
        HalfLivingDoorAni_M.SetBool("HalfEnd", true);
    }

    public void OnSniff()
    {
        LivingSpace_CardKeyMachine_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }




    public void OnEat()
    {
    }
    public void OnUp()
    {
    }

    public void OnBite()
    {
    }
    public void OnInsert()
    {
    }

    public void OnSmash()
    {
    }
}
