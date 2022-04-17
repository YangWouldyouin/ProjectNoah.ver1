using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_MeteorBox : MonoBehaviour
{
    // 운석 보관함
    public GameObject meteorBoxButton1_MB; 
    public GameObject meteorBoxButton2_MB;
    public GameObject meteorBoxButton3_MB; 
    public GameObject meteorBoxButton4_MB; 
    public GameObject meteorBoxButton5_MB;

    public GameObject meteorBox1_MB;
    public GameObject meteorBox2_MB;
    public GameObject meteorBox3_MB;
    public GameObject meteorBox4_MB;
    public GameObject meteorBox5_MB;

    //운석들
    public GameObject answerMeteor_MB;
    public GameObject wrongMeteor1_MB;
    public GameObject wrongMeteor2_MB;
    public GameObject wrongMeteor3_MB;
    public GameObject wrongMeteor4_MB;

    //약통
    public GameObject cylinderGlassAnswer_MB;
    public GameObject cylinderGlassWrong_MB;
    public GameObject cylinderGlassNoNeed1_MB;
    public GameObject cylinderGlassNoNeed2_MB;

    //약
    public GameObject beaker1_MB;
    public GameObject beaker2_MB;
    
    //public GameObject cylinderInAnswer_MB;
    //public GameObject cylinderInWrong_MB;

    public GameObject drugInBeaker1_MB;
    public GameObject drugInBeaker2_MB;


    //고무판
    //얘는 나중에 별도 코드로 빼서 고무찾는 퍼즐 했는지 안했는지 항상 확인하고 시작하게 만들어야겠다.
    public GameObject rubber3_MB; 



    //ObjData
    ObjData meteorBoxButton1Data_MB;
    ObjData meteorBoxButton2Data_MB;
    ObjData meteorBoxButton3Data_MB;
    ObjData meteorBoxButton4Data_MB;
    ObjData meteorBoxButton5Data_MB;

    ObjData meteorBox1Data_MB;
    ObjData meteorBox2Data_MB;
    ObjData meteorBox3Data_MB;
    ObjData meteorBox4Data_MB;
    ObjData meteorBox5Data_MB;

    ObjData answerMeteorData_MB;
    ObjData wrongMeteor1Data_MB;
    ObjData wrongMeteor2Data_MB;
    ObjData wrongMeteor3Data_MB;
    ObjData wrongMeteor4Data_MB;

    ObjData cylinderGlassAnswerData_MB;
    ObjData cylinderGlassWrongData_MB;
    ObjData cylinderGlassNoNeed1Data_MB;
    ObjData cylinderGlassNoNeed2Data_MB;

    ObjData beaker1Data_MB;
    ObjData beaker2Data_MB;

    //ObjData cylinderInAnswerData_MB;
    //ObjData cylinderInWrongData_MB;
    ObjData drugInBeaker1Data_MB;
    ObjData drugInBeaker2Data_MB;

    ObjData rubber3Data_MB;

    //비커 색 바꾸는 코드
    //SpriteRenderer ChangeBeaker1;
    //SpriteRenderer ChangeBeaker2;
    MeshRenderer ChangeBeaker1;
    MeshRenderer ChangeBeaker2;




    //Outline
    Outline meteorBoxButton1Outline_MB;
    Outline meteorBoxButton2Outline_MB;
    Outline meteorBoxButton3Outline_MB;
    Outline meteorBoxButton4Outline_MB;
    Outline meteorBoxButton5Outline_MB;

    Outline meteorBox1Outline_MB;
    Outline meteorBox2Outline_MB;
    Outline meteorBox3Outline_MB;
    Outline meteorBox4Outline_MB;
    Outline meteorBox5Outline_MB;

    Outline answerMeteorOutline_MB;
    Outline wrongMeteor1Outline_MB;
    Outline wrongMeteor2Outline_MB;
    Outline wrongMeteor3Outline_MB;
    Outline wrongMeteor4Outline_MB;

    Outline beaker1Outline_MB;
    Outline beaker2Outline_MB;

    //애니메이션
    public Animator meteorBox1Anim_MB;
    public Animator meteorBox2Anim_MB;
    public Animator meteorBox3Anim_MB;
    public Animator meteorBox4Anim_MB;
    public Animator meteorBox5Anim_MB;

    // Start is called before the first frame update
    void Start()
    {
        //ObjData
        meteorBoxButton1Data_MB = meteorBoxButton1_MB.GetComponent<ObjData>();
        meteorBoxButton2Data_MB = meteorBoxButton2_MB.GetComponent<ObjData>();
        meteorBoxButton3Data_MB = meteorBoxButton3_MB.GetComponent<ObjData>();
        meteorBoxButton4Data_MB = meteorBoxButton4_MB.GetComponent<ObjData>();
        meteorBoxButton5Data_MB = meteorBoxButton5_MB.GetComponent<ObjData>();

        meteorBox1Data_MB = meteorBox1_MB.GetComponent<ObjData>();
        meteorBox2Data_MB = meteorBox2_MB.GetComponent<ObjData>();
        meteorBox3Data_MB = meteorBox3_MB.GetComponent<ObjData>();
        meteorBox4Data_MB = meteorBox4_MB.GetComponent<ObjData>();
        meteorBox5Data_MB = meteorBox5_MB.GetComponent<ObjData>();

        answerMeteorData_MB = answerMeteor_MB.GetComponent<ObjData>();
        wrongMeteor1Data_MB = wrongMeteor1_MB.GetComponent<ObjData>();
        wrongMeteor2Data_MB = wrongMeteor2_MB.GetComponent<ObjData>();
        wrongMeteor3Data_MB = wrongMeteor3_MB.GetComponent<ObjData>();
        wrongMeteor4Data_MB = wrongMeteor4_MB.GetComponent<ObjData>();


        cylinderGlassAnswerData_MB = cylinderGlassAnswer_MB.GetComponent<ObjData>();
        cylinderGlassWrongData_MB = cylinderGlassWrong_MB.GetComponent<ObjData>();
        cylinderGlassNoNeed1Data_MB = cylinderGlassNoNeed1_MB.GetComponent<ObjData>();
        cylinderGlassNoNeed2Data_MB = cylinderGlassNoNeed2_MB.GetComponent<ObjData>();


        //cylinderInAnswerData_MB = cylinderInAnswer_MB.GetComponent<ObjData>();
        //cylinderInWrongData_MB = cylinderInWrong_MB.GetComponent<ObjData>();
        beaker1Data_MB = beaker1_MB.GetComponent<ObjData>();
        beaker2Data_MB = beaker2_MB.GetComponent<ObjData>();
        drugInBeaker1Data_MB = drugInBeaker1_MB.GetComponent<ObjData>();
        drugInBeaker2Data_MB = drugInBeaker2_MB.GetComponent<ObjData>();

        rubber3Data_MB = rubber3_MB.GetComponent<ObjData>();


        //아웃라인
        meteorBoxButton1Outline_MB = meteorBoxButton1_MB.GetComponent<Outline>();
        meteorBoxButton2Outline_MB = meteorBoxButton2_MB.GetComponent<Outline>();
        meteorBoxButton3Outline_MB = meteorBoxButton3_MB.GetComponent<Outline>();
        meteorBoxButton4Outline_MB = meteorBoxButton4_MB.GetComponent<Outline>();
        meteorBoxButton5Outline_MB = meteorBoxButton5_MB.GetComponent<Outline>();

        meteorBox1Outline_MB = meteorBox1_MB.GetComponent<Outline>();
        meteorBox2Outline_MB = meteorBox2_MB.GetComponent<Outline>();
        meteorBox3Outline_MB = meteorBox3_MB.GetComponent<Outline>();
        meteorBox4Outline_MB = meteorBox4_MB.GetComponent<Outline>();
        meteorBox5Outline_MB = meteorBox5_MB.GetComponent<Outline>();

        answerMeteorOutline_MB = answerMeteor_MB.GetComponent<Outline>();
        wrongMeteor1Outline_MB = wrongMeteor1_MB.GetComponent<Outline>();
        wrongMeteor2Outline_MB = wrongMeteor2_MB.GetComponent<Outline>();
        wrongMeteor3Outline_MB = wrongMeteor3_MB.GetComponent<Outline>();
        wrongMeteor4Outline_MB = wrongMeteor4_MB.GetComponent<Outline>();

        beaker1Outline_MB = beaker1_MB.GetComponent<Outline>();
        beaker2Outline_MB = beaker2_MB.GetComponent<Outline>();

        //색 바꾸는 코드
        ChangeBeaker1 = drugInBeaker1_MB.GetComponent<MeshRenderer>();
        ChangeBeaker2 = drugInBeaker2_MB.GetComponent<MeshRenderer>();


        //만약 운석 5개를 넣은 게 사실이라면 true확인하고
        //전부 상호작용을 켜준다.

        meteorBoxButton1Data_MB.IsNotInteractable = false; // 상호작용 가능하게
        meteorBoxButton1Outline_MB.OutlineWidth = 8;

        meteorBoxButton2Data_MB.IsNotInteractable = false; // 상호작용 가능하게
        meteorBoxButton2Outline_MB.OutlineWidth = 8;

        meteorBoxButton3Data_MB.IsNotInteractable = false; // 상호작용 가능하게
        meteorBoxButton3Outline_MB.OutlineWidth = 8;

        meteorBoxButton4Data_MB.IsNotInteractable = false; // 상호작용 가능하게
        meteorBoxButton4Outline_MB.OutlineWidth = 8;

        meteorBoxButton5Data_MB.IsNotInteractable = false; // 상호작용 가능하게
        meteorBoxButton5Outline_MB.OutlineWidth = 8;

    }

    // Update is called once per frame
    void Update()
    {

        //1번운석---------------------------------------
        //운석 박스 버튼을 누르면
        if (meteorBoxButton1Data_MB.IsPushOrPress)
        {
            // 문 열리는 애니메이션 실행
            meteorBox1Anim_MB.SetBool("isMeteorBox1Open", true);
            meteorBox1Anim_MB.SetBool("isMeteorBox1End", true);

            meteorBoxButton1Data_MB.IsNotInteractable = true; // 버튼에 상호작용 불가능하게
            meteorBoxButton1Outline_MB.OutlineWidth = 0;

            meteorBox1Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
            meteorBox1Outline_MB.OutlineWidth = 8;
        }

        //관찰하기를 한다면
        if (meteorBox1Data_MB.IsObserve)
        {
            Debug.Log("관찰하기 뷰를 실행할게요");
            CameraController.cameraController.currentView = meteorBox1Data_MB.ObserveView;

            wrongMeteor1Data_MB.IsNotInteractable = false; // 운석 상호작용 가능하게
            wrongMeteor1Outline_MB.OutlineWidth = 8;

            meteorBox1Data_MB.IsNotInteractable = true; // 운석 보관함 상호작용 불가능하게
            meteorBox1Outline_MB.OutlineWidth = 0;

            if (wrongMeteor1Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox1Data_MB.IsObserve = false;

                meteorBox1Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
                meteorBox1Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor1_M_C2 = true;

            }
        }

        else
        {
            //바깥에서 누른다고 눌러지는 거 방지
            wrongMeteor1Data_MB.IsNotInteractable = true; // 운석 상호작용 불가능하게
            wrongMeteor1Outline_MB.OutlineWidth = 0;

            //meteorBox1Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
            //meteorBox1Outline_MB.OutlineWidth = 8;
        }



        if (GameManager.gameManager._gameData.IsBiteWrongMeteor1_M_C2)
        {
            wrongMeteor1Data_MB.IsNotInteractable = false; // 운석 항상 상호작용 가능하게
            wrongMeteor1Outline_MB.OutlineWidth = 8;
        }



        //2번운석---------------------------------------

        if (meteorBoxButton2Data_MB.IsPushOrPress)
        {
            meteorBox2Anim_MB.SetBool("isMeteorBox2Open", true);
            meteorBox2Anim_MB.SetBool("isMeteorBox2End", true);

            meteorBoxButton2Data_MB.IsNotInteractable = true; // 버튼에 상호작용 불가능하게
            meteorBoxButton2Outline_MB.OutlineWidth = 0;

            meteorBox2Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
            meteorBox2Outline_MB.OutlineWidth = 8;
        }

        //관찰하기를 한다면
        if (meteorBox2Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox2Data_MB.ObserveView;

            answerMeteorData_MB.IsNotInteractable = false; // 상호작용 가능하게
            answerMeteorOutline_MB.OutlineWidth = 8;

            meteorBox2Data_MB.IsNotInteractable = true; // 운석 보관함 상호작용 불가능하게
            meteorBox2Outline_MB.OutlineWidth = 0;

            if (answerMeteorData_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox2Data_MB.IsObserve = false;

                meteorBox2Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
                meteorBox2Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteAnswerMeteor_M_C2 = true;
            }
        }

        else
        {
            //바깥에서 누른다고 눌러지는 거 방지
            answerMeteorData_MB.IsNotInteractable = true; // 운석 상호작용 불가능하게
            answerMeteorOutline_MB.OutlineWidth = 0;
        }


        //바깥에서 누른다고 눌러지는 거 방지
        if (GameManager.gameManager._gameData.IsBiteAnswerMeteor_M_C2)
        {
            answerMeteorData_MB.IsNotInteractable = false; // 운석 상호작용  항상 가능하게
            answerMeteorOutline_MB.OutlineWidth = 8;
        }




        //3번운석---------------------------------------
        if (meteorBoxButton3Data_MB.IsPushOrPress)
        {
            meteorBox3Anim_MB.SetBool("isMeteorBox3Open", true);
            meteorBox3Anim_MB.SetBool("isMeteorBox3End", true);

            meteorBoxButton3Data_MB.IsNotInteractable = true; // 버튼에 상호작용 불가능하게
            meteorBoxButton3Outline_MB.OutlineWidth = 0;

            meteorBox3Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
            meteorBox3Outline_MB.OutlineWidth = 8;
        }

        //관찰하기를 한다면
        if (meteorBox3Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox3Data_MB.ObserveView;

            wrongMeteor2Data_MB.IsNotInteractable = false; // 상호작용 가능하게
            wrongMeteor2Outline_MB.OutlineWidth = 8;

            meteorBox3Data_MB.IsNotInteractable = true; // 운석 보관함 상호작용 불가능하게
            meteorBox3Outline_MB.OutlineWidth = 0;

            if (wrongMeteor2Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox3Data_MB.IsObserve = false;

                meteorBox3Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
                meteorBox3Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor2_M_C2 = true;
            }
        }

        else
        {
            //바깥에서 누른다고 눌러지는 거 방지
            wrongMeteor2Data_MB.IsNotInteractable = true; // 운석 상호작용 불가능하게
            wrongMeteor2Outline_MB.OutlineWidth = 0;
        }

        if (GameManager.gameManager._gameData.IsBiteWrongMeteor2_M_C2)
        {
            wrongMeteor2Data_MB.IsNotInteractable = false; // 운석 항상 상호작용 가능하게
            wrongMeteor2Outline_MB.OutlineWidth = 8;
        }




        //4번운석---------------------------------------

        if (meteorBoxButton4Data_MB.IsPushOrPress)
        {
            //문이 열리는 애니메이션 실행, 열린 상태 고정
            meteorBox4Anim_MB.SetBool("isMeteorBox4Open", true);
            meteorBox4Anim_MB.SetBool("isMeteorBox4End", true);

            meteorBoxButton4Data_MB.IsNotInteractable = true; // 버튼에 상호작용 불가능하게
            meteorBoxButton4Outline_MB.OutlineWidth = 0;

            meteorBox4Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
            meteorBox4Outline_MB.OutlineWidth = 8;

        }

        //관찰하기를 한다면
        if (meteorBox4Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox4Data_MB.ObserveView;
            
            wrongMeteor3Data_MB.IsNotInteractable = false; // 상호작용 가능하게
            wrongMeteor3Outline_MB.OutlineWidth = 8;

            meteorBox4Data_MB.IsNotInteractable = true; // 운석 보관함 상호작용 불가능하게
            meteorBox4Outline_MB.OutlineWidth = 0;

            if (wrongMeteor3Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox4Data_MB.IsObserve = false;

                meteorBox4Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
                meteorBox4Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor3_M_C2 = true;
            }
        }

        else
        {
            //바깥에서 누른다고 눌러지는 거 방지
            wrongMeteor3Data_MB.IsNotInteractable = true; // 운석 상호작용 불가능하게
            wrongMeteor3Outline_MB.OutlineWidth = 0;
        }

        if (GameManager.gameManager._gameData.IsBiteWrongMeteor3_M_C2)
        {
            wrongMeteor3Data_MB.IsNotInteractable = false; // 운석 항상 상호작용 가능하게
            wrongMeteor3Outline_MB.OutlineWidth = 8;
        }


        //5번운석---------------------------------------
        if (meteorBoxButton5Data_MB.IsPushOrPress)
        {
            //문이 열리는 애니메이션 실행, 열린 상태 고정
            meteorBox5Anim_MB.SetBool("isMeteorBox5Open", true);
            meteorBox5Anim_MB.SetBool("isMeteorBox5End", true);

            meteorBoxButton5Data_MB.IsNotInteractable = true; // 버튼에 상호작용 불가능하게
            meteorBoxButton5Outline_MB.OutlineWidth = 0;

            meteorBox5Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
            meteorBox5Outline_MB.OutlineWidth = 8;
        }

        //관찰하기를 한다면
        if (meteorBox5Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox5Data_MB.ObserveView;

            wrongMeteor4Data_MB.IsNotInteractable = false; // 상호작용 가능하게
            wrongMeteor4Outline_MB.OutlineWidth = 8;

            meteorBox5Data_MB.IsNotInteractable = true; // 운석 보관함 상호작용 불가능하게
            meteorBox5Outline_MB.OutlineWidth = 0;

            if (wrongMeteor4Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox5Data_MB.IsObserve = false;

                meteorBox5Data_MB.IsNotInteractable = false; // 운석 보관함 상호작용 가능하게
                meteorBox5Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor4_M_C2 = true;
            }
        }

        else
        {
            //바깥에서 누른다고 눌러지는 거 방지
            wrongMeteor4Data_MB.IsNotInteractable = true; // 운석 상호작용 불가능하게
            wrongMeteor4Outline_MB.OutlineWidth = 0;
        }

        if (GameManager.gameManager._gameData.IsBiteWrongMeteor4_M_C2)
        {
            wrongMeteor4Data_MB.IsNotInteractable = false; // 운석 항상 상호작용 가능하게
            wrongMeteor4Outline_MB.OutlineWidth = 8;
        }







        //고무판 물기가 가장 큰 전제조건 --------------------------
        if (rubber3Data_MB.IsBite)
        {
            //다른 운석들은 물기가 가능하지만 비커에 넣어도 아무런 상호작용이 안일어난다.

/*            //정답이 아닌 다른 운석을 물고 있으면 비커가 비활성화 된다.
            if (wrongMeteor1Data_MB.IsBite || wrongMeteor2Data_MB.IsBite || wrongMeteor3Data_MB.IsBite || wrongMeteor4Data_MB.IsBite 
                || cylinderGlassNoNeed1Data_MB.IsBite || cylinderGlassNoNeed2Data_MB.IsBite)
            {
                Debug.Log("잘못된 운석을 물었어요. 비커가 비활성화 됩니다.");
                //두 종류의 비커 모두 비활성화 된다.
                beaker1Data_MB.IsNotInteractable = true;
                beaker1Outline_MB.OutlineWidth = 0;

                beaker2Data_MB.IsNotInteractable = true;
                beaker2Outline_MB.OutlineWidth = 0;
            }

            else
            {
                beaker1Data_MB.IsNotInteractable = false;
                beaker1Outline_MB.OutlineWidth = 8;

                beaker2Data_MB.IsNotInteractable = false;
                beaker2Outline_MB.OutlineWidth = 8;
            }*/

            


            //비커에 정답운석 넣기-------------------------------------------------------
            if (answerMeteorData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
            {
                answerMeteorData_MB.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                answerMeteorData_MB.transform.parent = null;

                //운석이 비커 안으로 이동한다.
                answerMeteorData_MB.transform.position = new Vector3(-249.049f, 539.986f, 683.212f); //위치 값
                answerMeteorData_MB.transform.rotation = Quaternion.Euler(-90, 0, 0); //로테이션 값

                GameManager.gameManager._gameData.IsInputMeteor1_M_C2 = true;
            }

            if (answerMeteorData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
            {
                answerMeteorData_MB.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                answerMeteorData_MB.transform.parent = null;

                //운석이 비커 안으로 이동한다.
                answerMeteorData_MB.transform.position = new Vector3(-248.397f, 539.986f, 683.212f); //위치 값
                answerMeteorData_MB.transform.rotation = Quaternion.Euler(-90, 0, 0); //로테이션 값

                GameManager.gameManager._gameData.IsInputMeteor2_M_C2 = true;
            }


        }

        else if (answerMeteorData_MB.IsBite || wrongMeteor1Data_MB.IsBite || wrongMeteor2Data_MB.IsBite ||
            wrongMeteor2Data_MB.IsBite || wrongMeteor3Data_MB.IsBite || wrongMeteor4Data_MB.IsBite )
        {
            Debug.Log("감염엔딩");
        }




        //비커에 약 넣기-------------------------------------------------------
        //정답 약을 비커 1에 넣었을 때
        if (cylinderGlassAnswerData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            //cylinderInAnswer_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            Debug.Log("색이 변경되었습니다.");
            ChangeBeaker1.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;


            //걍 비커 내용물 꺼지고 켜지게 해서 그게 켜져 있다면 트루로 체크하겠다. 그게 트루라면 약이 제조 성공된거다.


            //GameManager.gameManager._gameData.IsInputAnswerDrug1_M_C2 = true;
        }

        //정답 약을 비커 2에 넣었을 때
        if (cylinderGlassAnswerData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            //cylinderInAnswer_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f);  //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;

            //GameManager.gameManager._gameData.IsInputAnswerDrug2_M_C2 = true;
        }





        //틀린 약을 비커 1에 넣었을 때
        if (cylinderGlassWrongData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            Debug.Log("잘못된 약을 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //틀린 약을 비커 2에 넣었을 때
        if (cylinderGlassWrongData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            Debug.Log("잘못된 약을 비커2에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f);//부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }






        //필요 없는 약1을 비커 1에 넣었을 때
        if (cylinderGlassNoNeed1Data_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            Debug.Log("필요없는 약1을 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            ChangeBeaker1.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //필요 없는 약1을 비커 2에 넣었을 때
        if (cylinderGlassNoNeed1Data_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            Debug.Log("필요없는 약1을 비커2에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f);//부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }


        //필요 없는 약2을 비커 1에 넣었을 때
        if (cylinderGlassNoNeed2Data_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            Debug.Log("필요없는 약2를 비커1에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = true;
        }

        //필요 없는 약2을 비커 2에 넣었을 때
        if (cylinderGlassNoNeed2Data_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            Debug.Log("필요없는 약1를 비커2에 넣었습니다.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f);//부은 약 색으로 비커색이 변한다.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = true;
        }










        // 정답인지 코드 ------------------------------------------------
        //올바른 약과 올바은 운석을 비커 1에 넣었다면 
        if (GameManager.gameManager._gameData.IsInputMeteor1_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        {
            //옳은 약을 만들었다면 운석이 상호작용이 불가능해진다.
            //answerMeteor_MB.SetActive(false);
            answerMeteorData_MB.IsNotInteractable = true; // 상호작용 가능하게
            answerMeteorOutline_MB.OutlineWidth = 0;

            //대신 비커 중앙의 마시기가 활성화 된다.
            beaker1Data_MB.IsCenterButtonDisabled = false;

            //색이 변한다.
            ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            answerMeteor_MB.SetActive(false);

            if (beaker1Data_MB.IsEaten)
            {
                Debug.Log("노아의 스탯이0, 죽은척을 하는 중입니다.");
            }
        }


        if (GameManager.gameManager._gameData.IsInputMeteor2_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2)
        {
            //옳은 약을 만들었다면 운석이 상호작용이 불가능해진다.
            //answerMeteor_MB.SetActive(false);
            answerMeteorData_MB.IsNotInteractable = true; // 상호작용 가능하게
            answerMeteorOutline_MB.OutlineWidth = 0;

            //대신 비커 중앙의 마시기가 활성화 된다.
            beaker2Data_MB.IsCenterButtonDisabled = false;
            ChangeBeaker2.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            answerMeteor_MB.SetActive(false);

            if (beaker2Data_MB.IsEaten)
            {
                Debug.Log("노아의 스탯이0, 죽은척을 하는 중입니다.");
                GameManager.gameManager._gameData.IsNoahDead_M_C2 = true;
            }
        }
    }


}
