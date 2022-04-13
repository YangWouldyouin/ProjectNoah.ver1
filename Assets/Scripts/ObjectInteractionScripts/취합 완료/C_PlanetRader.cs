using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlanetRader : MonoBehaviour
{
    /* 오브젝트 */
    public GameObject planetRader_PR; // 행성 감지 레이더 기계
    public GameObject leftButton_PR; // 왼쪽 버튼
    public GameObject rightButton_PR; // 오른쪽 버튼
    public GameObject confirmButton_PR; // 확인버튼

    /* 확대 했을 때 나오는 화면 (UI) */
    public Image raderLine_PR; // 레이더 라인

    public Image[] normalPlanet_PR; // 행성
    public Image[] selectPlanet_PR; // 선택한 행성
    public Image[] fakePlanet_PR; // 가짜 행성

    public TMPro.TextMeshProUGUI exploreText;

    public Image[] planetInfo_PR; // 행성 정보 이미지

    public Button planetReportButton_PR; //행성 보고 버튼
    public Button exitButton_PR; // 종료 버튼

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

    public bool PlanetExploration_PR = false; // 행성 탐사 여부
    public bool FakePlanet_PR = false; // 거짓 행성 여부
    private bool PlanetExplorationTimeStart_PR = false; // 행성 탐사 소요 시간 시작 여부

    private float PlanetDistance_PR; // 행성과 레이더 사이 거리

    private float PlanetExplorationTime_PR = 5.0f; // 행성 탐사 소요 시간

    private float PlanetInfoTime_PR = 3.0f; // 행성 정보 팝업 시간

    Vector3 recentAngle;
    void Start()
    {
        planetRaderData_PR = planetRader_PR.GetComponent<ObjData>();
        leftButtonData_PR = leftButton_PR.GetComponent<ObjData>();
        rightButtonData_PR = rightButton_PR.GetComponent<ObjData>();
        confirmButtonData_PR = confirmButton_PR.GetComponent<ObjData>();

        leftButtonOutline_PR = leftButton_PR.GetComponent<Outline>();
        rightButtonOutline_PR = rightButton_PR.GetComponent<Outline>();
        confirmButtonOutline_PR = confirmButton_PR.GetComponent<Outline>();
        planetRaderOutline_PR = planetRader_PR.GetComponent<Outline>();

        PlanetExplorationTimeStart_PR = false;
    }

    void Update()
    {
        // 관찰하기 시 모든 UI 활성화
        if (planetRaderData_PR.IsObserve)
        {
            CameraController.cameraController.currentView = planetRaderData_PR.ObserveView;
            timer_PR += Time.deltaTime;
            float seconds = Mathf.FloorToInt((timer_PR % 3600) % 60);

            // 피지컬 버튼 3개 활성화
            leftButtonOutline_PR.OutlineWidth = 8;
            rightButtonOutline_PR.OutlineWidth = 8;
            confirmButtonOutline_PR.OutlineWidth = 8;

            leftButtonData_PR.IsNotInteractable = false;
            rightButtonData_PR.IsNotInteractable = false;
            confirmButtonData_PR.IsNotInteractable = false;

            // 행성 레이더 기계 비활성화
            planetRaderOutline_PR.OutlineWidth = 0;
            planetRaderData_PR.IsNotInteractable = true;

            if (seconds >= 2f)
            {
                if (!PlanetExplorationTimeStart_PR)
                {
                    // 레이더 라인 활성화
                    raderLine_PR.transform.gameObject.SetActive(true);
                    // 노멀 행성 활성화
                    for (int i = 0; i < 6; i++)
                    {
                        normalPlanet_PR[i].transform.gameObject.SetActive(true);
                    }

                    if (confirmButtonData_PR.IsPushOrPress) // 확인 버튼 눌렀을 때
                    {
                        exploreText.text = "탐사진행중";
                        exploreText.transform.gameObject.SetActive(true); // 탐사진행중 
                        // 기계 상호작용 비활성화
                        // 행성 모두 끄고, 타이머 띄우기? 
                        for (int i = 0; i < 6; i++)
                        {
                            normalPlanet_PR[i].transform.gameObject.SetActive(false);
                            selectPlanet_PR[i].transform.gameObject.SetActive(false);
                        }
                        raderLine_PR.transform.gameObject.SetActive(false);


                        if (FakePlanet_PR) // 행성이 거짓 행성 일 때
                        {
                            // 계속 거짓 행성으로 주행함
                        }
                        else // 행성이 진짜 행성 일 때
                        {
                            PlanetExplorationTimeStart_PR = true; // 타이머 스타트 시작
                            PlanetExplorationTime_PR -= Time.deltaTime;
                            float maxTimer = Mathf.FloorToInt((PlanetExplorationTime_PR % 3600) % 60);
                        }

                    }
                }
                else
                {
                    exploreText.transform.gameObject.SetActive(true); // 탐사진행중 활성화
                    if (PlanetExplorationTime_PR <= 0) // 시간이 0이 됐을 때
                    {
                        exploreText.text = "탐사완료";
                        planetReportButton_PR.transform.gameObject.SetActive(true);
                        exitButton_PR.transform.gameObject.SetActive(true);
                        // AI가 행성 도착 + 분석 완료를 알림
                        //    PlanetInfo_PR.SetActive(true); // 행성 정보 이미지 띄우기
                        //    if (PlanetInfoTime_PR <= 0)
                        //    {
                        //        PlanetReportButton_PR.SetActive(true);
                        //        if (ExitButtonData_PR.IsClicked)
                        //        {
                        //            // 행성 감지 레이더 페이지에서 나가기
                        //        }
                        //    }
                    }
                }
            }

        }
        else // 관찰하기 해제 시 모든 UI 비활성화
        {
            // 타이머 초기화
            timer_PR = 0;
            // 레이더 라인 비활성화
            raderLine_PR.transform.gameObject.SetActive(false);
            // 노멀 행성 비활성화
            for (int i = 0; i < 6; i++)
            {
                normalPlanet_PR[i].transform.gameObject.SetActive(false);
            }

            // 투명 이미지 비활성화 
            exploreText.transform.gameObject.SetActive(false); // 탐사진행중 비활성화
            // 피지컬 버튼 3개 비활성화
            leftButtonOutline_PR.OutlineWidth = 0;
            rightButtonOutline_PR.OutlineWidth = 0;
            confirmButtonOutline_PR.OutlineWidth = 0;

            leftButtonData_PR.IsNotInteractable = true;
            rightButtonData_PR.IsNotInteractable = true;
            confirmButtonData_PR.IsNotInteractable = true;

            planetReportButton_PR.transform.gameObject.SetActive(false);
            exitButton_PR.transform.gameObject.SetActive(false);

            // 행성 레이더 기계 활성화
            planetRaderOutline_PR.OutlineWidth = 8;
            planetRaderData_PR.IsNotInteractable = false;
        }
    }
}
