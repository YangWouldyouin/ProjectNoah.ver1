using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report_PopupScript : MonoBehaviour
{
    public GameObject Report_GUI;
    public int cancleCount = 0;//전체 함수로 관리하기

    public void Report()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        //보고하기 데이터 이동
        //else 더미 데이터 이동
        Debug.Log("보고하기");
        Report_GUI.SetActive(false);
    }

    public void Cancle()
    {
        //if 더미 데이터 다운 퍼즐이 완료되지 않았다면
        cancleCount += 1;

        Report_GUI.SetActive(false);
    }
}
