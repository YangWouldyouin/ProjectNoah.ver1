using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker1 : MonoBehaviour, IInteraction
{
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


    void Start()
    {
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
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Beaker1 = Beaker1Data_M.PushOrPressButton;
        pressButton_M_Beaker1.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker1 = Beaker1Data_M.CenterButton1;
        eatButton_M_Beaker1.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker1 = Beaker1Data_M.CenterDisableButton1;


        Beaker1ObjData_M.IsCenterButtonDisabled = true;
    }

    void FakeAI1()
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

    }

    void Update()
    {
        if (GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        {
            //옳은 약을 만들었다면 운석이 상호작용이 불가능해진다.
            //answerMeteor_MB.SetActive(false);
            AnswerMeteorForBeaker1Data.IsNotInteractable = true; // 상호작용 가능하게
            AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

            //대신 비커 중앙의 마시기가 활성화 된다.
            Beaker1ObjData_M.IsCenterButtonDisabled = false;

            //색이 변한다.
            ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            M_AnswerMeteorForBeaker.SetActive(false);


        }
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

            GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 = true;
        }

        //정답 약을 비커 1에 넣었을 때
        if (cylinderGlassAnswerData_M.IsBite)
        {
            M_drugInBeaker1.SetActive(true);
            Debug.Log("색이 변경되었습니다.");
            ChangeBeaker1.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //틀린 약을 비커 1에 넣었을 때
        if (cylinderGlassWrongData_M.IsBite)
        {
            Debug.Log("잘못된 약을 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //필요 없는 약1을 비커 1에 넣었을 때
        if (cylinderGlassNoNeed1Data_M.IsBite)
        {
            Debug.Log("필요없는 약1을 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            ChangeBeaker1.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //필요 없는 약2을 비커 1에 넣었을 때
        if (cylinderGlassNoNeed2Data_M.IsBite)
        {
            Debug.Log("필요없는 약2를 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = true;
        }
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        Debug.Log("노아의 스탯이0, 죽은척을 하는 중입니다.");
        //쓰러지는 애니메이션 삽입 예정

        Invoke(" FakeAI1", 3f);
    }

    public void OnBite()
    {
       
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
