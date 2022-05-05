using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C1_Photo : MonoBehaviour
{
    private GameObject nowObject_T_C1_Photo;

    // 오브젝트
    public GameObject TakePicButton_P; // 카메라 촬영 버튼
    public GameObject UniverseImage_P; // 우주 사진

    // 오브젝트 데이터
    ObjData SendButtonData_P;
    ObjData UniverseImageData_P;

    public GameObject[] UniverseImageList; // 우주 사진 리스트

    public GameObject Report_GUI_P; // 보고하기 GUI
    private bool IsReported = false;

    public int ran = Random.Range(0, 5);


    // 관찰하기 시 추가 UI가 뜨는 경우, 2초간의 텀이 있다. 이것을 체크하기 위한 변수
    float timer_PR = 0;

    // private float SendButton = 3.0f; // 보고하기 팝업

    void Start()
    {
    }

    void Update()
    {
    }

    public void RandomUniversePic()
    {
        UniverseImage_P = UniverseImageList[ran]; // 우주 이미지 랜덤으로 UniverseImage_P 에 삽입
        UniverseImage_P.SetActive(true); // 우주 사진 보여주기

        Invoke("Report_Popup", 4f);
    }

    public void Report_Popup()
    {
        if (IsReported)
        {
            Report_GUI_P.SetActive(false);
        }
        else
        {
            Report_GUI_P.SetActive(true);
        }
    }

    public void Report() // 보고하기 누르면
    {
        Debug.Log("보고하기");
        IsReported = true;

        Report_GUI_P.SetActive(false);
    }

    public void Cancel() //캔슬버튼 누르면
    {
        Debug.Log("취소하기");

        GameManager.gameManager._gameData.IsReportCancleCount -= 1; // 임무 보고 카운트 줄어들기
        // SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        IsReported = true;

        Report_GUI_P.SetActive(false);
    }
}
