using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlanetRader : MonoBehaviour, IInteraction
{
    public ObjectData planetRaderData;
    private Button barkButton, sniffButton, biteButton,
pressButton, observeButton;



    int counter;

    public Text textCounter;
    BoxCollider raderCollider;



    /* 오브젝트 */
    public GameObject leftButton_PR; // 왼쪽 버튼
    public GameObject rightButton_PR; // 오른쪽 버튼
    public GameObject confirmButton_PR; // 확인버튼

    public GameObject ob;

    /* 확대 했을 때 나오는 화면 (UI) */
    public Image raderLine_PR; // 레이더 라인

    public Image[] normalPlanet_PR; // 행성
    public Image[] selectPlanet_PR; // 선택한 행성
    public Image[] fakePlanet_PR; // 가짜 행성

    public TMPro.TextMeshProUGUI exploreText;

    public Image[] planetInfo_PR; // 행성 정보 이미지

    public Button planetReportButton_PR; //행성 보고 버튼
    public Button exitButton_PR; // 종료 버튼
    public GameObject interactBtn1;


    /* 오브젝트 데이터 */
    ObjData planetRaderData_PR;
    ObjData leftButtonData_PR;
    ObjData rightButtonData_PR;
    ObjData confirmButtonData_PR;

    /* Outline 변수 */
    Outline planetRaderOutline_PR;
    Outline leftButtonOutline_PR;
    Outline rightButtonOutline_PR;
    Outline confirmButtonOutline_PR;

    // 관찰하기 시 추가 UI가 뜨는 경우, 2초간의 텀이 있다. 이것을 체크하기 위한 변수
    float timer_PR = 0;
    float exploreTimer = 0;

    public bool PlanetExploration_PR = false; // 행성 탐사 여부
    
    private bool PlanetExplorationTimeStart_PR = false; // 행성 탐사 소요 시간 시작 여부
    public bool FakePlanet_PR = false; // 거짓 행성 여부

    private float PlanetDistance_PR; // 행성과 레이더 사이 거리

    private float PlanetExplorationTime_PR = 5.0f; // 행성 탐사 소요 시간

    private float PlanetInfoTime_PR = 3.0f; // 행성 정보 팝업 시간

    Vector3 recentAngle;

    void Start()
    {

        raderCollider = GetComponent<BoxCollider>();
        planetRaderData_PR = GetComponent<ObjData>();

        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton = planetRaderData_PR.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = planetRaderData_PR.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = planetRaderData_PR.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = planetRaderData_PR.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = planetRaderData_PR.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);


        leftButtonOutline_PR = leftButton_PR.GetComponent<Outline>();
        rightButtonOutline_PR = rightButton_PR.GetComponent<Outline>();
        confirmButtonOutline_PR = confirmButton_PR.GetComponent<Outline>();
        planetRaderOutline_PR = GetComponent<Outline>();

        //planetReportButton_PR.onClick.AddListener(ReportPlanet);
        //exitButton_PR.onClick.AddListener(ExitPlanetRader);

        PlanetExplorationTimeStart_PR = false;
    }
    void ReportPlanet()
    {
        exploreText.text = "A 행성 보고 완료";
        planetReportButton_PR.transform.gameObject.SetActive(false);
        exitButton_PR.transform.gameObject.SetActive(false);


        PlanetExploration_PR = false;
        PlanetExplorationTimeStart_PR = false;

        PlanetExplorationTime_PR = 5.0f;

        raderLine_PR.transform.gameObject.SetActive(false);
        // 노멀 행성 비활성화
        for (int i = 0; i < 6; i++)
        {
            normalPlanet_PR[i].transform.gameObject.SetActive(false);
        }
    }

    void ExitPlanetRader()
    {
        PlanetExploration_PR = false;
        PlanetExplorationTimeStart_PR = false;
        PlanetExplorationTime_PR = 5.0f;

        exploreText.transform.gameObject.SetActive(false); // 탐사진행중 비활성화
        planetReportButton_PR.transform.gameObject.SetActive(false);
        exitButton_PR.transform.gameObject.SetActive(false);
        timer_PR = 0;
        CameraController.cameraController.CancelObserve();
    }


    public void OnConfirmButtonClicked()
    {
        for (int i = 0; i < 6; i++)
        {
            if (PlanetRaderTrigger.planetRaderTrigger.IsPlanetSelected[i])
            {
                StartCoroutine(Count()); // 5분타이머 시작
                DisableUI(); // 행성 + 레이더 꺼짐
                exploreText.text = "탐사진행중"; // 탐사진행중 글씨 띄움
                exploreText.gameObject.SetActive(true);            
                break;
            }
            else
            {
                continue;
            }
        }
    }
    IEnumerator Count()
    {
        while (counter<=20)
        {
            textCounter.text = (counter++).ToString();
            yield return new WaitForSeconds(1f);
        }
    }
    void Update()
    {
        if(!planetRaderData.IsObserve)
        {
            DisableUI();
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

    IEnumerator ActivateUI(float num)
    {
        yield return new WaitForSeconds(num);
        raderLine_PR.transform.gameObject.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            normalPlanet_PR[i].transform.gameObject.SetActive(true);
        }
    }

    void DisableUI()
    {
        exploreText.gameObject.SetActive(false);
        raderLine_PR.transform.gameObject.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            normalPlanet_PR[i].transform.gameObject.SetActive(false);
            selectPlanet_PR[i].transform.gameObject.SetActive(false);
            //fakePlanet_PR[i].transform.gameObject.SetActive(false);
        }
    }

   public void OnObserve()
    {
        raderCollider.enabled = false;

        /* 취소할 때 참고할 오브젝트 저장 */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /* 카메라 컨트롤러에 뷰 전달 */
        CameraController.cameraController.currentView = planetRaderData_PR.ObserveView; // 관찰 뷰 : 위쪽
        /* 관찰 애니메이션 & 카메라 전환 */
        InteractionButtonController.interactionButtonController.playerObserve();
        StartCoroutine(ActivateUI(3f));
    }

    public void OnBark()
    {     
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
    }

    public void OnBite()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }



    public void OnUp()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }
}
