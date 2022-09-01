using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker1 : MonoBehaviour, IInteraction
{
    public GameObject StartScreen;
    //public GameObject EndScreen;
    public GameObject DonTClick;

    /*연관있는 오브젝트*/
    public GameObject M_HiBeaker2;
    //public GameObject M_RubberForBeaker1;
    public GameObject M_AnswerMeteorForBeaker;

    public GameObject M_cylinderGlassAnswer;
    public GameObject M_cylinderGlassWrong;
    public GameObject M_cylinderGlassNoNeed1;
    public GameObject M_cylinderGlassNoNeed2;

    public GameObject M_drugInBeaker1;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_Beaker1, sniffButton_M_Beaker1, biteButton_M_Beaker1,
        pressButton_M_Beaker1, eatButton_M_Beaker1, eatDisableButton_M_Beaker1;

    /*ObjData*/
    ObjData Beaker1Data_M;
    public ObjectData Beaker1ObjData_M;
    public ObjectData AnswerMeteorForBeaker1Data;
    public ObjectData RubberForBeaker1Data_M;

    public ObjectData cylinderGlassAnswerData_M;
    public ObjectData cylinderGlassWrongData_M;
    public ObjectData cylinderGlassNoNeed1Data_M;
    public ObjectData cylinderGlassNoNeed2Data_M;

    public ObjectData drugInBeaker1Data_M;

    /*Outline*/
    Outline Beaker1Outline_M;
    Outline AnswerMeteorForBeakerOutline_M;

   /*비커 색 바꾸는 코드*/
   MeshRenderer ChangeBeaker1;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    AudioSource Beaker_Hit_Sound;
    public AudioClip Beaker_Audio;


    /*Collider*/

    BoxCollider Beaker1_Collider;
    BoxCollider Beaker2_Collider;

    BoxCollider cylinderGlassAnswer_Collider;
    BoxCollider cylinderGlassWrong_Collider;
    BoxCollider cylinderGlassNoNeed1_Collider;
    BoxCollider cylinderGlassNoNeed2_Collider;


    /*타이머*/
    public InGameTime inGameTime;

    public bool IsPretendDeadFail1 = false; //제한 시간 내에 안에 퍼즐 실패
    public bool canTpretendDead1 = false;
    public bool StartBlack = false;
    public bool StartOnlyOne = false;
    public bool startTimer = false;
    public bool IsDeath = false;
    public int i = 0;
    PortableObjectData workRoomData;
    PlayerEquipment equipment;
    GameObject portableGroup;


    void Start()
    {
        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        equipment = BaseCanvas._baseCanvas.equipment;
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;

        Beaker_Hit_Sound = GetComponent<AudioSource>();

        dialogManager = dialog_CS.GetComponent<DialogManager>();

        //색 바꾸는 코드
        ChangeBeaker1 = M_drugInBeaker1.GetComponent<MeshRenderer>();

        /*ObjData*/
        Beaker1Data_M = GetComponent<ObjData>();
        /*Outline*/
        Beaker1Outline_M = GetComponent<Outline>();
        AnswerMeteorForBeakerOutline_M = M_AnswerMeteorForBeaker.GetComponent<Outline>();

        /*Collider*/
        Beaker1_Collider = GetComponent<BoxCollider>();
        Beaker2_Collider = M_HiBeaker2.GetComponent<BoxCollider>();

        cylinderGlassAnswer_Collider = M_cylinderGlassAnswer.GetComponent<BoxCollider>();
        cylinderGlassWrong_Collider = M_cylinderGlassWrong.GetComponent<BoxCollider>();
        cylinderGlassNoNeed1_Collider = M_cylinderGlassNoNeed1.GetComponent<BoxCollider>();
        cylinderGlassNoNeed2_Collider = M_cylinderGlassNoNeed2.GetComponent<BoxCollider>();


        /*버튼 연결*/
        barkButton_M_Beaker1 = Beaker1Data_M.BarkButton;
        barkButton_M_Beaker1.onClick.AddListener(OnBark);

        sniffButton_M_Beaker1 = Beaker1Data_M.SniffButton;
        sniffButton_M_Beaker1.onClick.AddListener(OnSniff);

        biteButton_M_Beaker1 = Beaker1Data_M.BiteButton;
        biteButton_M_Beaker1.onClick.AddListener(OnBite);

        pressButton_M_Beaker1 = Beaker1Data_M.PushOrPressButton;
        pressButton_M_Beaker1.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker1 = Beaker1Data_M.CenterButton1;
        eatButton_M_Beaker1.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker1 = Beaker1Data_M.CenterDisableButton1;


        Beaker1ObjData_M.IsCenterButtonDisabled = true;
    }

/*    void FakeAI1()
    {
        //D-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        GameManager.gameManager._gameData.ActiveMissionList[11] = false;
        GameManager.gameManager._gameData.ActiveMissionList[12] = true;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");


        // 죽은척하기 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧

        Beaker1_Collider.enabled = false;
        Beaker2_Collider.enabled = false;

        cylinderGlassAnswer_Collider.enabled = false;
        cylinderGlassWrong_Collider.enabled = false;
        cylinderGlassNoNeed1_Collider.enabled = false;
        cylinderGlassNoNeed2_Collider.enabled = false;

    }*/

    void Update()
    {
        //if (GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        //{
        //    //옳은 약을 만들었다면 운석이 상호작용이 불가능해진다.
        //    //answerMeteor_MB.SetActive(false);
        //    AnswerMeteorForBeaker1Data.IsNotInteractable = true; // 상호작용 가능하게
        //    AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

        //    //대신 비커 중앙의 마시기가 활성화 된다.
        //    Beaker1ObjData_M.IsCenterButtonDisabled = false;

        //    //색이 변한다.
        //    ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

        //    M_AnswerMeteorForBeaker.SetActive(false);
        //    // 앞으로 업무공간에서 메테오보이면 안됨
        //    workRoomData.IsObjectActiveList[28] = false;
        //}

/*        if(StartBlack == true && StartOnlyOne == false)
        {
            StartCoroutine(SuddenDeath());
            StartOnlyOne = true;

        }*/


/*        if (IsPretendDeadFail1 == true && canTpretendDead1 == false && !GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._gameData.IsDiscardNoahEnd = true;
            Debug.Log("시간 안에 퍼즐 풀기 실패");
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            canTpretendDead1 = true;
        }

        //타임 어택 성공시
        if (GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            inGameTime.IsTimerStarted = false;

            S_TimerBarFilled.SetActive(false);
            S_TimerBackground.SetActive(false);
            S_TimerText.SetActive(false);

            Debug.Log("노아의 굿엔딩 보기 가능해졌다!");
            //GameManager.gameManager._gameData.IsMiddleTuto = false;
            //GameManager.gameManager._gameData.IsRealMiddleTuto = true; //진짜 튜토리얼 중간 성공
        }*/

    }

    void DisableButton()
    {
        barkButton_M_Beaker1.transform.gameObject.SetActive(false);
        sniffButton_M_Beaker1.transform.gameObject.SetActive(false);
        biteButton_M_Beaker1.transform.gameObject.SetActive(false);
        pressButton_M_Beaker1.transform.gameObject.SetActive(false);
        eatButton_M_Beaker1.transform.gameObject.SetActive(false);
        eatDisableButton_M_Beaker1.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        Beaker_Hit_Sound.clip = Beaker_Audio;
        Beaker_Hit_Sound.Play();

        /*고무판을 물고 정답 운석을 비커 1에 넣는다면*/
        if (/*RubberForBeaker1Data_M.IsBite &&*/ AnswerMeteorForBeaker1Data.IsBite)
        {
            Beaker_Hit_Sound.clip = Beaker_Audio;
            Beaker_Hit_Sound.Play();

            M_AnswerMeteorForBeaker.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            M_AnswerMeteorForBeaker.transform.parent = null;

            //운석이 비커 안으로 이동한다.
            M_AnswerMeteorForBeaker.transform.position = new Vector3(-248.367f, 1.5762f, 683.427f); //위치 값
            M_AnswerMeteorForBeaker.transform.rotation = Quaternion.Euler(-90, 0, 0); //로테이션 값

            // 물기 변수 초기화
            equipment.biteObjectName = "";
            // 다시 포터블 넣어줌
            M_AnswerMeteorForBeaker.transform.parent = portableGroup.transform;

            GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            // 정답약을 넣었는지 확인
            if (GameManager.gameManager._gameData.IsAnswerDrugInBeaker1_M_C2)
            {
                M_drugInBeaker1.SetActive(true);
                Debug.Log("색이 변경되었습니다.");
                //ChangeBeaker2.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //부은 약 색으로 비커색이 변한다.

                GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
                GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
                GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
                GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                //옳은 약을 만들었다면 운석이 상호작용이 불가능해진다.
                //answerMeteor_MB.SetActive(false);
                AnswerMeteorForBeaker1Data.IsNotInteractable = true;
                AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

                //대신 비커 중앙의 마시기가 활성화 된다.
                Beaker1ObjData_M.IsCenterButtonDisabled = false;

                //색이 변한다.
                ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

                MeshRenderer meteoRenderer = M_AnswerMeteorForBeaker.GetComponent<MeshRenderer>();
                meteoRenderer.enabled = false;
                M_AnswerMeteorForBeaker.SetActive(false);
                // 앞으로 업무공간에서 메테오보이면 안됨
                workRoomData.IsObjectActiveList[28] = false;


                //추가된 부분@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                //실린더 제자리로
                M_cylinderGlassAnswer.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                M_cylinderGlassAnswer.transform.parent = null;
                M_cylinderGlassAnswer.transform.position = new Vector3(-247.277f, 1.39397f, 683.715f); //위치 값
                M_cylinderGlassAnswer.transform.rotation = Quaternion.Euler(0, 0, 0); //로테이션 값

                // 물기 변수 초기화
                equipment.biteObjectName = "";
                // 다시 포터블 넣어줌
                M_cylinderGlassAnswer.transform.parent = portableGroup.transform;


                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }
        }

        //정답 약을 비커 1에 넣었을 때
        if (cylinderGlassAnswerData_M.IsBite)
        {
            M_drugInBeaker1.SetActive(true);
            // 앞으로 업무공간에서 참@@@@@@@@@@@@@@@@@

            Debug.Log("색이 변경되었습니다.");
            ChangeBeaker1.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;

            GameManager.gameManager._gameData.IsAnswerDrugInBeaker1_M_C2 = true;

            //추가된 부분@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //실린더 제자리로
            M_cylinderGlassAnswer.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            M_cylinderGlassAnswer.transform.parent = null;
            M_cylinderGlassAnswer.transform.position = new Vector3(-247.277f, 1.39397f, 683.715f); //위치 값
            M_cylinderGlassAnswer.transform.rotation = Quaternion.Euler(0, 0, 0); //로테이션 값

            // 물기 변수 초기화
            equipment.biteObjectName = "";
            // 다시 포터블 넣어줌
            M_cylinderGlassAnswer.transform.parent = portableGroup.transform;

            // 정답운석이 비커에 들어있으면
            if (GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2)
            {
                //옳은 약을 만들었다면 운석이 상호작용이 불가능해진다.
                //answerMeteor_MB.SetActive(false);
                AnswerMeteorForBeaker1Data.IsNotInteractable = true;
                AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

                //대신 비커 중앙의 마시기가 활성화 된다.
                Beaker1ObjData_M.IsCenterButtonDisabled = false;

                //색이 변한다.
                ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

                MeshRenderer meteoRenderer = M_AnswerMeteorForBeaker.GetComponent<MeshRenderer>();
                meteoRenderer.enabled = false;
                // 앞으로 업무공간에서 메테오보이면 안됨
                workRoomData.IsObjectActiveList[28] = false;

                M_cylinderGlassAnswer.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                M_cylinderGlassAnswer.transform.parent = null;

                // 물기 변수 초기화
                equipment.biteObjectName = "";
                // 다시 포터블 넣어줌
                M_cylinderGlassAnswer.transform.parent = portableGroup.transform;
                M_cylinderGlassAnswer.SetActive(false);
            }
        }

        //틀린 약을 비커 1에 넣었을 때
        if (cylinderGlassWrongData_M.IsBite)
        {
            Debug.Log("잘못된 약을 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            // 앞으로 업무공간에서 참@@@@@@@@@@@@@@@@@
            ChangeBeaker1.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;


            //추가된 부분@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //실린더 제자리로
            M_cylinderGlassWrong.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            M_cylinderGlassWrong.transform.parent = null;
            M_cylinderGlassWrong.transform.position = new Vector3(-247.277f, 1.39397f, 683.438f); //위치 값
            M_cylinderGlassWrong.transform.rotation = Quaternion.Euler(0, 0, 0); //로테이션 값

            // 물기 변수 초기화
            equipment.biteObjectName = "";
            // 다시 포터블 넣어줌
            M_cylinderGlassWrong.transform.parent = portableGroup.transform;

            //// 물기 변수 초기화
            //equipment.biteObjectName = "";
            //// 다시 포터블 넣어줌
            //M_cylinderGlassWrong.transform.parent = portableGroup.transform;
            //M_cylinderGlassWrong.SetActive(false);
        }

        //필요 없는 약1을 비커 1에 넣었을 때
        if (cylinderGlassNoNeed1Data_M.IsBite)
        {
            Debug.Log("필요없는 약1을 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            // 앞으로 업무공간에서 참@@@@@@@@@@@@@@@@@
            ChangeBeaker1.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;


            //추가된 부분@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //실린더 제자리로
            M_cylinderGlassNoNeed1.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            M_cylinderGlassNoNeed1.transform.parent = null;
            M_cylinderGlassNoNeed1.transform.position = new Vector3(-247.277f, 1.39397f, 684.2311f); //위치 값
            M_cylinderGlassNoNeed1.transform.rotation = Quaternion.Euler(0, 0, 0); //로테이션 값

            // 물기 변수 초기화
            equipment.biteObjectName = "";
            // 다시 포터블 넣어줌
            M_cylinderGlassNoNeed1.transform.parent = portableGroup.transform;

            //M_cylinderGlassNoNeed1.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            //M_cylinderGlassNoNeed1.transform.parent = null;

            //// 물기 변수 초기화
            //equipment.biteObjectName = "";
            //// 다시 포터블 넣어줌
            //M_cylinderGlassNoNeed1.transform.parent = portableGroup.transform;
            //M_cylinderGlassNoNeed1.SetActive(false);
        }

        //필요 없는 약2을 비커 1에 넣었을 때
        if (cylinderGlassNoNeed2Data_M.IsBite)
        {
            Debug.Log("필요없는 약2를 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            // 앞으로 업무공간에서 참@@@@@@@@@@@@@@@@@
            ChangeBeaker1.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = true;

            //추가된 부분@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //실린더 제자리로
            M_cylinderGlassNoNeed2.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            M_cylinderGlassNoNeed2.transform.parent = null;
            M_cylinderGlassNoNeed2.transform.position = new Vector3(-247.277f, 1.39397f, 683.9581f); //위치 값
            M_cylinderGlassNoNeed2.transform.rotation = Quaternion.Euler(0, 0, 0); //로테이션 값

            // 물기 변수 초기화
            equipment.biteObjectName = "";
            // 다시 포터블 넣어줌
            M_cylinderGlassNoNeed2.transform.parent = portableGroup.transform;


            //M_cylinderGlassNoNeed2.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            //M_cylinderGlassNoNeed2.transform.parent = null;

            //// 물기 변수 초기화
            //equipment.biteObjectName = "";
            //// 다시 포터블 넣어줌
            //M_cylinderGlassNoNeed2.transform.parent = portableGroup.transform;
            //M_cylinderGlassNoNeed2.SetActive(false);
        }
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    //실험 끝! 완성된 약을 먹는다면?!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    /*1. 노아가 음식을 먹는다. 2. 쓰러진다. 3.AI가 혼낸다. 4. 꺼지는 화면이 나온다. 5. 켜지는 화면이 나온다. 6. 타이머가 시작된다.*/


    public void OnEat()
    {
        DisableButton();
        //1. 노아가 음식을 먹는다-> 이후론 M_BeakerAfter 코드로
        InteractionButtonController.interactionButtonController.playerEat();
        M_drugInBeaker1.SetActive(false);
        Beaker1ObjData_M.IsEaten = false;

        GameManager.gameManager._gameData.IsDrinkBeaker_M_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // 비커 안보이게
        gameObject.GetComponent<BoxCollider>().enabled =false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(EatAfter());
        StartCoroutine(SuddenDeath());
        StartCoroutine(End());

    }

    IEnumerator EatAfter()
    {
        yield return new WaitForSeconds(3f);
        //3.AI가 혼낸다.
        InteractionButtonController.interactionButtonController.PlayerDie();
        Debug.Log("노아의 스탯이0, 죽은척을 하는 중입니다.");
        DonTClick.SetActive(true);
        /*노아가 혼자서 안움직이게*/
        PlayerScripts.playerscripts.IsBored = true;
        StartBlack = true;
        StartCoroutine(realFakeAI1());
        //StartCoroutine(WaitFor40());
    }
    IEnumerator realFakeAI1()
    {
        if(!StartBlack)
        {
            yield return null;
        }
        else
        {
            //D-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

            GameManager.gameManager._gameData.IsCompletePretendDead = true;
            GameManager.gameManager._gameData.IsStartOrbitChange = true;

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            MissionGenerator.missionGenerator.DeleteNewMission(11);
            StartCoroutine(Delay2Sec());
 

            //StartCoroutine(SuddenDeath());
            //startTimer = true;
            //StartCoroutine(WaitFor40());
        }
    }

    IEnumerator Delay2Sec()
    {
        yield return new WaitForSeconds(2f);
        MissionGenerator.missionGenerator.AddNewMission(12);
    }

    IEnumerator WaitFor40()
    {
        if(!startTimer)
        {
            yield return new WaitForSeconds(60f);
        }
        else
        {
            IsDeath = true;
            StartCoroutine(SuddenDeath());
        }
    }

    IEnumerator SuddenDeath()
    {
        yield return new WaitForSeconds(53f);
        Debug.Log("노아는 죽엇다");
        StartScreen.SetActive(true);



        //4.꺼지는 화면이 나온다.
        //5. 켜지는 화면이 나온다.

        //EndScreen.SetActive(true);

        InteractionButtonController.interactionButtonController.PlayerAlive();
        inGameTime.IsBeakerEatAfterStart = true;
        StartCoroutine(End());

    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("타이머 켜짐");

        StartScreen.SetActive(false);
        DonTClick.SetActive(false);
        //EndScreen.SetActive(false);
        inGameTime.IsAIAwake = false;
        /*노아 다시 움직이게*/
        PlayerScripts.playerscripts.IsBored = false;

        //타이머 시작 5분
        TimerManager.timerManager.TimerStart(300);
    }

    /* void EatAfter()
     {
         InteractionButtonController.interactionButtonController.PlayerDie();

         Debug.Log("노아의 스탯이0, 죽은척을 하는 중입니다.");

         StartBlack = true;

         //여기부터 안됨@@@@@@@@

         StartCoroutine(SuddenDeath());

         //Invoke("SuddenDeath", 3);
     }

     IEnumerator SuddenDeath()
     {

         yield return new WaitForSeconds(3f);
         Debug.Log("노아는 죽엇다");

         //5. 켜지는 화면이 나온다.
         StartScreen.SetActive(false);
         EndScreen.SetActive(true);

         InteractionButtonController.interactionButtonController.PlayerAlive();


         Invoke("End",3f);

     }

     void End()
     {
         Debug.Log("타이머 켜짐");

         EndScreen.SetActive(false);

         //타이머 시작 3분
         TimerManager.timerManager.TimerStart(60);
         Invoke("PretendFailCheck", 60f);
     }

 *//*    IEnumerator PreteadTimer1()
     {

         yield return new WaitForSeconds(40f);

         //타이머 시작 3분
         TimerManager.timerManager.TimerStart(8);
         Invoke("PretendFailCheck", 8f);

     }*//*

     void PretendFailCheck()
     {
         IsPretendDeadFail1 = true;
     }

     IEnumerator realFakeAI1()
     {

         yield return new WaitForSeconds(5f);
         Debug.Log("AI는 잘 말한다.");

         //4.꺼지는 화면이 나온다.
         StartScreen.SetActive(true);

         //D-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
         dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

         GameManager.gameManager._gameData.IsCompletePretendDead = true;
         GameManager.gameManager._gameData.IsStartOrbitChange = true;
         GameManager.gameManager._gameData.ActiveMissionList[11] = false;
         GameManager.gameManager._gameData.ActiveMissionList[12] = true;
         MissionGenerator.missionGenerator.ActivateMissionList();
         SaveSystem.Save(GameManager.gameManager._gameData, "save_001");


         // 죽은척하기 임무리스트 완료 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧

         Beaker1_Collider.enabled = false;
         Beaker2_Collider.enabled = false;

         cylinderGlassAnswer_Collider.enabled = false;
         cylinderGlassWrong_Collider.enabled = false;
         cylinderGlassNoNeed1_Collider.enabled = false;
         cylinderGlassNoNeed2_Collider.enabled = false;

         *//*타이머 등장*//*
         //StartCoroutine(PreteadTimer1());


     }*/


    public void OnBite()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnInsert()
    {
        
    }

    public void OnObserve()
    {
   
    }


    public void OnSmash()
    {
        
    }

    public void OnUp()
    {
        
    }
}
