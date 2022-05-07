using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker2 : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_RubberForBeaker2;
    public GameObject M_RealAnswerMeteorForBeaker;

    public GameObject M_RealCylinderGlassAnswer;
    public GameObject M_RealcylinderGlassWrong;
    public GameObject M_RealCylinderGlassNoNeed1;
    public GameObject M_RealCylinderGlassNoNeed2;

    public GameObject M_drugInBeaker2;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_Beaker2, sniffButton_M_Beaker2, biteButton_M_Beaker2,
        pressButton_M_Beaker2, eatButton_M_Beaker2, eatDisableButton_M_Beaker2;


    /*ObjData*/
    ObjData Beaker2ObjData_M;
    public ObjectData Beaker2Data_M;

    public ObjectData RubberForBeaker2Data_M;
    public ObjectData RealAnswerMeteorForBeakerData_M;

    public ObjectData RealCylinderGlassAnswerData_M;
    public ObjectData RealCylinderGlassWrongData_M;
    public ObjectData RealCylinderGlassNoNeed1Data_M;
    public ObjectData RealCylinderGlassNoNeed2Data_M;

    public ObjectData drugInBeaker2Data_M;

    /*Outline*/
    Outline Beaker2Outline_M;
    Outline RealAnswerMeteorForBeakerOutline_M;

    /*비커 색 바꾸는 코드*/
    MeshRenderer ChangeBeaker2;

    public GameObject dialog_CS;
    DialogManager dialogManager;


    void Start()
    {
        dialogManager = dialog_CS.GetComponent<DialogManager>();

        //색 바꾸는 코드
        ChangeBeaker2 = M_drugInBeaker2.GetComponent<MeshRenderer>();

        /*ObjData*/
        Beaker2ObjData_M = GetComponent<ObjData>();

        /*Outline*/
        Beaker2Outline_M = GetComponent<Outline>();
        RealAnswerMeteorForBeakerOutline_M = M_RealAnswerMeteorForBeaker.GetComponent<Outline>();


        /*버튼 연결*/
        barkButton_M_Beaker2 = Beaker2ObjData_M.BarkButton;
        barkButton_M_Beaker2.onClick.AddListener(OnBark);

        sniffButton_M_Beaker2 = Beaker2ObjData_M.SniffButton;
        sniffButton_M_Beaker2.onClick.AddListener(OnSniff);

        biteButton_M_Beaker2 = Beaker2ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Beaker2 = Beaker2ObjData_M.PushOrPressButton;
        pressButton_M_Beaker2.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker2 = Beaker2ObjData_M.CenterButton1;
        eatButton_M_Beaker2.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker2 = Beaker2ObjData_M.CenterButton1;

        if (Beaker2Data_M.IsEaten)
        {
            Invoke(" FakeAI2", 3f);
        }

    }

    void FakeAI2()
    {
        //D-2 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(56));

        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        GameManager.gameManager._gameData.IsStartOrbitChange = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

    }

    void Update()
    {
        if (GameManager.gameManager._gameData.IsAnswerInBeaker2_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        {
            //옳은 약을 만들었다면 운석이 상호작용이 불가능해진다.
            //answerMeteor_MB.SetActive(false);
            RealAnswerMeteorForBeakerData_M.IsNotInteractable = true; // 상호작용 가능하게
            RealAnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

            //대신 비커 중앙의 마시기가 활성화 된다.
            Beaker2Data_M.IsCenterButtonDisabled = false;

            //색이 변한다.
            ChangeBeaker2.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            M_RealAnswerMeteorForBeaker.SetActive(false);

            if (Beaker2Data_M.IsEaten)
            {
                Debug.Log("노아의 스탯이0, 죽은척을 하는 중입니다.");
                //쓰러지는 애니메이션 삽입 예정
            }
        }
    }

    void DisableButton()
    {
        barkButton_M_Beaker2.transform.gameObject.SetActive(false);
        sniffButton_M_Beaker2.transform.gameObject.SetActive(false);
        biteButton_M_Beaker2.transform.gameObject.SetActive(false);
        pressButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatDisableButton_M_Beaker2.transform.gameObject.SetActive(false);
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

        /*고무판을 물고 정답 운석을 비커 2에 넣는다면*/
        if (/*RubberForBeaker1Data_M.IsBite &&*/ RealAnswerMeteorForBeakerData_M.IsBite)
        {
            M_RealAnswerMeteorForBeaker.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
            M_RealAnswerMeteorForBeaker.transform.parent = null;

            //운석이 비커 안으로 이동한다.
            M_RealAnswerMeteorForBeaker.transform.position = new Vector3(-248.367f, 1.5762f, 683.427f); //위치 값
            M_RealAnswerMeteorForBeaker.transform.rotation = Quaternion.Euler(-90, 0, 0); //로테이션 값

            GameManager.gameManager._gameData.IsAnswerInBeaker2_M_C2 = true;
        }

        //정답 약을 비커 2에 넣었을 때
        if (RealCylinderGlassAnswerData_M.IsBite)
        {
            M_drugInBeaker2.SetActive(true);
            Debug.Log("색이 변경되었습니다.");
            ChangeBeaker2.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //틀린 약을 비커 1에 넣었을 때
        if (RealCylinderGlassWrongData_M.IsBite)
        {
            Debug.Log("잘못된 약을 비커2에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //필요 없는 약1을 비커 1에 넣었을 때
        if (RealCylinderGlassNoNeed1Data_M.IsBite)
        {
            Debug.Log("필요없는 약1을 비커2에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //필요 없는 약2을 비커 1에 넣었을 때
        if (RealCylinderGlassNoNeed2Data_M.IsBite)
        {
            Debug.Log("필요없는 약2를 비커2에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = true;
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
