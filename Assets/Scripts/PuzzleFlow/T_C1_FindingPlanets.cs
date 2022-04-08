using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 불러오기

public class T_C1_FindingPlanets : MonoBehaviour
{
    private GameObject nowObject_T_C1_FindingPlanets;
    
    //오브젝트
    public GameObject planetMachine_PR; // 행성 감지 기계

    public GameObject PlanetInfo_PR; // 행성 정보 이미지
    public GameObject PlanetRader_PR; // 행성감지레이더 기계
    public GameObject LeftButton_PR; // 왼쪽 버튼
    public GameObject RightButton_PR; // 오른쪽 버튼
    public GameObject ConfirmButton_PR; // 확인버튼

    // 확대 했을 때 나오는 화면 (UI)
    public GameObject RaderLine_PR; // 레이더 라인
    public GameObject Planet_1_PR; // 행성 1
    public GameObject Planet_2_PR; // 행성 2
    public GameObject Planet_3_PR; // 행성 3
    public GameObject FakePlanet_1_FL; // 가짜 행성 1
    public GameObject FakePlanet_2_FL; // 가짜 행성 2
    public GameObject FakePlanet_3_FL; // 가짜 행성 3
    public GameObject PlanetReportButton_PR; //행성 보고 버튼
    public GameObject ExitButton_PR; // 종료 버튼

    // 오브젝트 데이터
    ObjData PlanetInfoData_PR;

    ObjData planetMachineData_PR;

    ObjData PlanetRaderData_PR;
    ObjData LeftButtonData_PR;
    ObjData RightButtonData_PR;
    ObjData ConfirmButtonData_PR;

    ObjData RanderLineData_PR;
    ObjData Planet_1Data_PR;
    ObjData Planet_2Data_PR;
    ObjData Planet_3Data_PR;
    ObjData FakePlanetData_1_FL;
    ObjData FakePlanetData_2_FL;
    ObjData FakePlanetData_3_FL;
    ObjData ExitButtonData_PR;

    public Image[] normalPlanet;
    public Image[] selectPlanet;
    public Image[] fakePlanet;

    // Outline 변수
    Outline consoleAIResetButtonOutline_PR;

    // 관찰하기 시 추가 UI가 뜨는 경우, 2초간의 텀이 있다. 이것을 체크하기 위한 변수
    float timer_PR = 0;

    public bool PlanetExploration_PR = false; // 행성 탐사 여부
    public bool FakePlanet_PR = false; // 거짓 행성 여부
    private bool PlanetExplorationTimeStart_PR = false; // 행성 탐사 소요 시간 시작 여부

    private float PlanetDistance_PR; // 행성과 레이더 사이 거리
    private float PlanetExplorationTime_PR = 600.0f; // 행성 탐사 소요 시간
    private float PlanetInfoTime_PR = 3.0f; // 행성 정보 팝업 시간


    void Start()
    {
        // PlanetInfo_T_C1.transform.gameObject.SetActive(false); // 이미지 보이지 않는 상태 -> true=보임
        PlanetExplorationTimeStart_PR = false;
    }

    void Update()
    {
        if(planetMachineData_PR.IsObserve)
        {
            // 노멀 행성 활성화
            for(int i = 0; i<6; i++)
            {
                normalPlanet[i].transform.gameObject.SetActive(true);
            }

            if (PlanetRaderData_PR.IsPushOrPress) // 행성 레이더 컨트롤하기
            {
                ControlRader();
            }

            // 행성 - 레이더 간 거리 계산하기
            PlanetDistance_PR = Vector3.Distance(RaderLine_PR.transform.position, Planet_1_PR.transform.position);
            ConfirmButtonData_PR.GetComponent<MeshRenderer>().material.color = Color.red;

            if (PlanetDistance_PR <= 1.0f) // 행성 레이더와 행성 1 간 거리가 1 미만일 때,
            {
                // 밑의 코드 말고 NomalPlanet이 SelectPlanet 오브젝트로 변경되기
                //ConfirmButtonData_PR.GetComponent<MeshRenderer>().material.color = Color.green; // 빨간색으로 변환
            }

            if (ConfirmButtonData_PR.IsPushOrPress) // 확인 버튼 눌렀을 때
            {
                // 기계 상호작용 비활성화
                if (FakePlanet_PR == true) // 행성이 거짓 행성 일 때
                {
                    // 계속 거짓 행성으로 주행함
                }

                else // 행성이 진짜 행성 일 때
                {
                    PlanetExplorationTimeStart_PR = true; // 타이머 스타트 시작
                    if (PlanetExplorationTime_PR <= 0) // 시간이 0이 됐을 때
                    {
                        // AI가 행성 도착 + 분석 완료를 알림

                        //if (PlanetRaderData_PR.IsObserve) // 행성 감지 레이더 관찰 시
                        //{
                        //    PlanetInfo_PR.SetActive(true); // 행성 정보 이미지 띄우기
                        //    if (PlanetInfoTime_PR <= 0)
                        //    {
                        //        PlanetReportButton_PR.SetActive(true);
                        //        if (ExitButtonData_PR.IsClicked)
                        //        {
                        //            // 행성 감지 레이더 페이지에서 나가기
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }
        else
        {
            // 노멀 행성 비활성화
            for (int i = 0; i < 6; i++)
            {
                normalPlanet[i].transform.gameObject.SetActive(false);
            }
        }

  
    }

    public void ControlRader()
    {
        if (LeftButtonData_PR.IsPushOrPress)
        {
            RaderLine_PR.transform.rotation = Quaternion.Euler(0,0,5); // 행성 레이더 선 왼쪽으로 이동
        }
        if (RightButtonData_PR.IsPushOrPress)
        {
            RaderLine_PR.transform.rotation = Quaternion.Euler(0, 0, -5); // 행성 레이더 선 오른쪽으로 이동
        }
    }
}
