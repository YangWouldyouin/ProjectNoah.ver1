using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_MeteorCollectMachine : MonoBehaviour
{
    private bool meteorCollectanimOpen_MCM = false;

    //운석 수집---------------------------------
    //public GameObject doorCollectMachine_MCM; // 수집 기계 문
    public GameObject meteorCollectMachine_MCM; // 운석 수집 기계
    public GameObject meteorButton_MCM; // 수집 기계 문 열기 버튼
    public GameObject normalMeteor1_MCM; // 일반 운석
    public GameObject importantMeteor_MCM; // 중요한 운석
    public GameObject analyticalMachine_MCM; // 분석기
    public GameObject analyticalMachineButton_MCM; // 분석기버튼
    public GameObject analyticalMachinePlate_MCM; // 분석기 안쪽 접시? 그릇?
    public GameObject rubber2_MCM; // 고무판


    //ObjData doorCollectMachineData_MCM;
    ObjData meteorCollectMachineData_MCM;
    ObjData meteorButtonData_MCM;
    ObjData normalMeteor1Data_MCM;
    ObjData importantMeteorData_MCM;
    ObjData analyticalMachineData_MCM;
    ObjData analyticalMachineButtonData_MCM;
    ObjData analyticalMachinePlateData_MCM;
    ObjData rubber2Data_MCM;


    Outline meteorButtonOutline_MCM;
    Outline meteorCollectMachineOutline_MCM;
    Outline normalMeteor1Outline_MCM;
    Outline importantMeteorOutline_MCM;
    Outline analyticalMachineOutline_MCM;
    Outline analyticalMachineButtonOutline_MCM;
    Outline analyticalMachinePlateOutline_MCM;

    public GameObject Report_GUI;
    private bool IsReported = false;


    public Animator meteorBoxAnim_WED;
    public Animator analyticalMachineAnim_WED;



    //



    //private int count = 0;
    //private int count1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // AI의 알림을 듣고 업무공간으로 이동한다.
        // 이전 운석을 운석 수집 기계에서 빼내었는지 확인
        // 빼내지 않았다면 이전 운석이 사라진다.
        // 시간 마다 운석이 순서대로 켜진다.

        // 5초가 지나면 A운석이 켜진다 상호작용 가능
        // 10초가 지나면 A운석이 꺼지고(상호작용 불가능) B운석이 켜진다.(상호작용 가능)
        // 15초가 지나면 B운석이 꺼지고 C운석이 켜진다.


        //doorCollectMachineData_MCM = doorCollectMachine_MCM.GetComponent<ObjData>();
        meteorCollectMachineData_MCM = meteorCollectMachine_MCM.GetComponent<ObjData>();
        meteorButtonData_MCM = meteorButton_MCM.GetComponent<ObjData>();
        normalMeteor1Data_MCM = normalMeteor1_MCM.GetComponent<ObjData>();
        importantMeteorData_MCM = importantMeteor_MCM.GetComponent<ObjData>();
        analyticalMachineData_MCM = analyticalMachine_MCM.GetComponent<ObjData>();
        analyticalMachineButtonData_MCM = analyticalMachineButton_MCM.GetComponent<ObjData>();
        analyticalMachinePlateData_MCM = analyticalMachinePlate_MCM.GetComponent<ObjData>();
        rubber2Data_MCM = rubber2_MCM.GetComponent<ObjData>();

        meteorButtonOutline_MCM = meteorButton_MCM.GetComponent<Outline>();
        meteorCollectMachineOutline_MCM = meteorCollectMachine_MCM.GetComponent<Outline>();
        normalMeteor1Outline_MCM = normalMeteor1_MCM.GetComponent<Outline>();
        importantMeteorOutline_MCM = importantMeteor_MCM.GetComponent<Outline>();
        analyticalMachineOutline_MCM = analyticalMachine_MCM.GetComponent<Outline>();
        analyticalMachineButtonOutline_MCM = analyticalMachineButton_MCM.GetComponent<Outline>();
        analyticalMachinePlateOutline_MCM = analyticalMachinePlate_MCM.GetComponent<Outline>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(meteorButtonData_MCM.IsCollision)
        {
            meteorButtonData_MCM.IsNotInteractable = false; // 상호작용 가능하게
            meteorButtonOutline_MCM.OutlineWidth = 16;
        }

        else
        {
            meteorButtonData_MCM.IsNotInteractable = true; // 상호작용 가능하게
            meteorButtonOutline_MCM.OutlineWidth = 0;
        }

        //운석 수집기 열기 버튼을 누르면
        if (meteorButtonData_MCM.IsPushOrPress)
        {
            StartCoroutine(meteorBoxOpen());
           // Invoke("meteorBoxOpen", 1f);
            meteorCollectMachineData_MCM.IsNotInteractable = false; // 상호작용 가능하게
            meteorCollectMachineOutline_MCM.OutlineWidth = 8;
            meteorCollectanimOpen_MCM = true;

            //인보크 호출 횟수 제한 함수
            /*if (count >= 2)
            {
                CancelInvoke("meteorBoxOpen");
                Reset();
            }*/

            if (meteorCollectanimOpen_MCM == true)
            {
                if (!normalMeteor1Data_MCM.IsBite)
                {
                    //Invoke("meteorBoxClose", 10f);

                    StartCoroutine(meteorBoxClose(0f, 30f));
                }
            }
        }




        //높이가 되면, 가운데 상호작용 버튼 켜진다.
        if(meteorCollectMachineData_MCM.IsCollision)
        {
            meteorCollectMachineData_MCM.IsCenterButtonDisabled = false;
        }
        else
        {
            meteorCollectMachineData_MCM.IsCenterButtonDisabled = true;
        }

        

        if(meteorCollectMachineData_MCM.IsObserve)
        {
            CameraController.cameraController.currentView = meteorCollectMachineData_MCM.ObserveView;

            normalMeteor1Data_MCM.IsNotInteractable = false; // 상호작용 가능하게
            normalMeteor1Outline_MCM.OutlineWidth = 8; // 아웃라인도 켜줍니다.

            importantMeteorData_MCM.IsNotInteractable = false; // 상호작용 가능하게
            importantMeteorOutline_MCM.OutlineWidth = 8; // 아웃라인도 켜줍니다.

            meteorCollectMachineData_MCM.IsNotInteractable = true; // 상호작용 불가능하게
            meteorCollectMachineOutline_MCM.OutlineWidth = 0; // 아웃라인도 꺼줍니다.

            meteorButtonData_MCM.IsNotInteractable = true; // 상호작용 가능하게
            meteorButtonOutline_MCM.OutlineWidth = 0;
        }
/*
        else
        {
            //meteorCollectMachineData_MCM.IsCenterButtonDisabled = false;
            Invoke("meteorBoxClose", 2f);
        }*/


        if(meteorCollectMachineData_MCM.IsObserve && normalMeteor1Data_MCM.IsBite 
            || meteorCollectMachineData_MCM.IsObserve && importantMeteorData_MCM.IsBite)
        {
            meteorCollectMachineData_MCM.IsObserve = false;

            CameraController.cameraController.CancelObserve();

            GameManager.gameManager.IsCanMeteorGet = true;


            StartCoroutine(meteorBoxClose(0f, 30f));

          //  Invoke("meteorBoxClose", 2f);
/*            if (count >= 2)
            {
                CancelInvoke("meteorBoxClose");
            }*/

            meteorCollectMachineData_MCM.IsNotInteractable = true; // 상호작용 불 가능
            meteorCollectMachineOutline_MCM.OutlineWidth = 0;
        }



        //냄새 맡기를 하면 언제든 기계에 상호작용 가능하게 된다.
        // 그냥 한번만 맡으면 이젠 분석기에 언제든 운석 넣을 수 있게 되는 거겠지? 
        // 아님 운석마다 끄고 켜지기 반복해야 되는건가?
        if (normalMeteor1Data_MCM.IsSniff && analyticalMachineButtonData_MCM.IsCollision
            || importantMeteorData_MCM.IsSniff && analyticalMachineButtonData_MCM.IsCollision)
        {
            //Debug.Log("상호작용이 가능해졌어요");
            //상호작용이 가능해진다.
            analyticalMachineButtonData_MCM.IsNotInteractable = false; // 상호작용 가능하게
            analyticalMachineButtonOutline_MCM.OutlineWidth = 16;

            GameManager.gameManager.IsSmellDone = true;
        }
        else if(analyticalMachineButtonData_MCM.IsCollision == false)
        {
            analyticalMachineButtonData_MCM.IsNotInteractable = true; // 상호작용 불 가능하게
            analyticalMachineButtonOutline_MCM.OutlineWidth = 0;
        }



        //분석기 버튼을 누르면
        if (analyticalMachineButtonData_MCM.IsPushOrPress)
        {
            StartCoroutine(analyticalMachineClose(2f,0f));

            /*            if (count1 >= 3)
                        {
                            CancelInvoke("analyticalMachineOpen");
                        }*/

            analyticalMachineData_MCM.IsNotInteractable = false; // 상호작용 가능하게
            analyticalMachineOutline_MCM.OutlineWidth = 8;
        }

        //높이가 되면 특수 상호작용 켜지게 
        if (analyticalMachineData_MCM.IsCollision)
        {
            analyticalMachineData_MCM.IsCenterButtonDisabled = false;
        }
        else
        {
            analyticalMachineData_MCM.IsCenterButtonDisabled = true;
        }


        if (analyticalMachineData_MCM.IsObserve)
        {
            CameraController.cameraController.currentView = analyticalMachineData_MCM.ObserveView;
            analyticalMachinePlateData_MCM.IsNotInteractable = false; // 상호작용 가능하게
            analyticalMachinePlateOutline_MCM.OutlineWidth = 8;

            analyticalMachineData_MCM.IsNotInteractable = true; // 상호작용 불 가능하게
            analyticalMachineOutline_MCM.OutlineWidth = 0;

            analyticalMachineButtonData_MCM.IsNotInteractable = true; // 상호작용 불 가능하게
            analyticalMachineButtonOutline_MCM.OutlineWidth = 0;
        }

        else
        {
            analyticalMachinePlateData_MCM.IsNotInteractable = true; // 상호작용 가능하게
            analyticalMachinePlateOutline_MCM.OutlineWidth = 0;
        }


        if(rubber2Data_MCM.IsBite)
        {
            if (GameManager.gameManager.IsSmellDone == true)
            {
                //고무판을 물고 일반 운석을 물면 보고가 가능하다. 
                if (rubber2Data_MCM.IsBite && normalMeteor1Data_MCM.IsBite)
                {
                    if (analyticalMachineData_MCM.IsObserve && rubber2Data_MCM.IsBite && analyticalMachinePlateData_MCM.IsPushOrPress)
                    {
                        normalMeteor1Data_MCM.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                        normalMeteor1Data_MCM.transform.parent = null;

                        normalMeteor1Data_MCM.transform.position = new Vector3(-254.667f, 540.622f, 690.674f); //위치 값

                        Invoke("analyticalMachineView", 1f);

                        StartCoroutine(analyticalMachineOpen());// 닫히는 애니메이션

                        /*                        if (count1 >= 3)
                                                {
                                                    CancelInvoke("analyticalMachineClose");
                                                }*/

                        GameManager.gameManager.InputNormalMeteor1 = true;

                        Invoke("Report_Popup", 4f);


                        // 보고하기 팝업이 뜬다.  UI.SetActive(True);
                        // 운석들은 그냥 1,2,3,4,5 코드 복사하면 되지 뭐
                        // if(분석기에 운석들을 넣으면)
                        // 운석 보관함의 문이 다시 닫히고
                        // IsCanMeteorGet = false;가 되어 반복 가능하게
                        // 보고 하기를 하면 InputNormalMeteor1 = true; 를 넣어준다.

                        //보고하기 창을 팝업
                        //다른 엔딩을 볼 경우 여기에 변수하나 넣어주고 지현이의 Report함수에 if(그 변수가 트루면) -> 엔딩을 보게 만든다.

                    }
                }


                //고무판을 물고 특별 운석을 물면 무사히 보고가 가능하다.
                if (analyticalMachineData_MCM.IsObserve && rubber2Data_MCM.IsBite && importantMeteorData_MCM.IsBite)
                {
                    if (analyticalMachinePlateData_MCM.IsPushOrPress)
                    {
                        //중요 운석을 넣었는지 확인하는 Bool체크
                        GameManager.gameManager.IsyesImportantMeteor = true;

                        importantMeteorData_MCM.GetComponent<Rigidbody>().isKinematic = false; // 모계에서 벗어나게 한다.
                        importantMeteorData_MCM.transform.parent = null;

                        importantMeteorData_MCM.transform.position = new Vector3(-254.667f, 540.622f, 690.674f); //위치 값

                        Invoke("analyticalMachineView", 1f);

                        // 어떤 운석을 임무에 사용할지가 확실하지 않아서 횟수 못맞수도 있겠다.
/*                        if (count1 >= 4)
                        {
                            CancelInvoke("analyticalMachineClose");
                        }*/

                        // 닫히는 애니메이션
                        Invoke("analyticalMachineClose", 2f);
                        Invoke("Report_Popup", 4f);

                    }
                }
                /*            else if (analyticalMachineButtonData_MCM.IsBite)
                            {
                                Debug.Log("감염엔딩");
                            }*/
            }
        }

           

        // 고무판을 물지 않은 상태로는 감염 엔딩을 본다.
        else if (normalMeteor1Data_MCM.IsBite || importantMeteorData_MCM.IsBite)
        {
            Debug.Log("감염엔딩");
        }


    }

    public void Report_Popup()
    {
        if (IsReported)
        {
            Report_GUI.SetActive(false);
        }
        else
        {
            Report_GUI.SetActive(true);
        }
    }

    public void Report()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //보고하기 데이터 이동
        //else 더미 데이터 이동

        Debug.Log("보고하기");
        IsReported = true;
        Report_GUI.SetActive(false);

        if(GameManager.gameManager.IsyesImportantMeteor == true)
        {
            Debug.Log("지구귀환엔딩");
        }
    }

    public void Cancle()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //cancleCount += 1;

        Debug.Log("취소하기");
        IsReported = true;
        Report_GUI.SetActive(false);
    }


    //애니메이션
    IEnumerator meteorBoxOpen()
    {
        // 기본적으로 이 함수를 실행 할 때는 1초 지연한 후에 실행하겠다.
        yield return new WaitForSeconds(1f);

        
        meteorBoxAnim_WED.SetBool("isMeteorBoxClose", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxCloseEnd", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpen", true);
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpenEnd", true);
        //count += 1;
    }

    // delay: 애니메이션 실행하기 전까지 시간지연 얼마나 할건지,
    // closeTimeCheck: 시간 제한 얼마로 걸어줄건지 예: 20초를 적으면 20초확인후에 애니메이션 실행하겠다.
    IEnumerator meteorBoxClose(float delay, float closeTimeCheck)
    {
        
        yield return new WaitForSeconds(delay);


        bool isTimeOver = false;
        float closeTime = 0f;

        while (isTimeOver == false)
        {
            yield return null;

            closeTime += Time.deltaTime;

            //현재 시간이>=제한 걸어둔 시간보다 크거나 같으면
            //isTimeOver = true;가 되어 이 (isTimeOver == false)에서 나가겠다.
            if (closeTime >= closeTimeCheck)
            {
                isTimeOver = true;
            }

            //혹은 운석을 물었다면 이 (isTimeOver == false)에서 나가겠다
            if (normalMeteor1Data_MCM.IsBite)
            {
                isTimeOver = true;
            }
        }

        // isTimeOver = true가 되었다면 아래에 있는 애니메이션을 실행하겠다.
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpen", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxOpenEnd", false);
        meteorBoxAnim_WED.SetBool("isMeteorBoxClose", true);
        meteorBoxAnim_WED.SetBool("isMeteorBoxCloseEnd", true);

    }

    IEnumerator analyticalMachineOpen()
    {
        yield return new WaitForSeconds(1f);

        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpen", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpenEnd", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineClose", false);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineCloseEnd", false);

        //count1 += 1;
    }

    IEnumerator analyticalMachineClose(float delay2, float CloseTimeCheck2)
    {
        yield return new WaitForSeconds(delay2);


        bool isAnalyticalTimeOver = false;
        float closeTime2 = 0f;

        while (isAnalyticalTimeOver == false)
        {
            yield return null;

            closeTime2 += Time.deltaTime;

            //현재 시간이>=제한 걸어둔 시간보다 크거나 같으면
            //isTimeOver = true;가 되어 이 (isTimeOver == false)에서 나가겠다.
            if (closeTime2 >= CloseTimeCheck2)
            {
                isAnalyticalTimeOver = true;
            }

            //혹은 운석을 물었다면 이 (isTimeOver == false)에서 나가겠다
            if (normalMeteor1Data_MCM.IsBite)
            {
                isAnalyticalTimeOver = true;
            }
        }

        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineClose", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineCloseEnd", true);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpen", false);
        analyticalMachineAnim_WED.SetBool("isAnalyticalMachineOpenEnd", false);

        //count1 += 1;
    }

    void analyticalMachineView()
    {
        analyticalMachineData_MCM.IsObserve = false;

        CameraController.cameraController.CancelObserve();
    }

    private void Reset()
    {
        Debug.Log("count를 리셋했어요!");
        //count = 1;
    }
}
