using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C1_Photo : MonoBehaviour
{
    private GameObject nowObject_T_C1_Photo;

    // 오브젝트
    public GameObject Camera_P; // 카메라
    public GameObject CameraTakeButton_P; // 카메라 촬영 버튼
    public GameObject SendButton_P; // 보고하기 버튼
    public GameObject UniverseImage_P; // 우주 사진

    // 오브젝트 데이터
    ObjData CameraData_P;
    ObjData CameraTakeButtonData_P;
    ObjData SendButtonData_P;
    ObjData UniverseImageData_P;


    public GameObject Report_GUI;
    private bool IsReported = false;


    // Outline 변수
    Outline consoleAIResetButtonOutline_PR;

    // 관찰하기 시 추가 UI가 뜨는 경우, 2초간의 텀이 있다. 이것을 체크하기 위한 변수
    float timer_PR = 0;

    //private float SendButton = 3.0f; // 보고하기 팝업

    void Start()
    {
    }

    void Update()
    {
        if(CameraData_P.IsObserve)
        {
            if(CameraTakeButtonData_P.IsPushOrPress)
            {
                // 우주 이미지 랜덤으로 UniverseImage_P 에 삽입
                UniverseImage_P.SetActive(true); // 우주 사진 보여주기

                Invoke("Report_Popup", 3f);
            }
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
        Debug.Log("보고하기");
        IsReported = true;
        Report_GUI.SetActive(false);

        // if 보고하기 눌렀을 시
        // 
    }

    public void Cancle()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //cancleCount += 1;

        Debug.Log("취소하기");
        IsReported = true;
        Report_GUI.SetActive(false);
    }

}
