using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_DogProfileUIManager : MonoBehaviour
{
    /* 오브젝트 */
    // 좌우 버튼
    public GameObject RightButton_D;
    public GameObject LeftButton_D;

    // 강아지 현재 상태
    public Text Health_D; // 건강 상태


    /* 기본 설정 */
    public int i = 0;

    public GameObject[] DogProfilePage; // 페이지 오브젝트

    public Text PageNum_D; // 페이지넘버

    void Start()
    {
        DogProfilePage[0].SetActive(true);
        DogProfilePage[1].SetActive(false);
        PageNum_D.text = "1 / 2";
    }

    void Update()
    {
        if (i == 0)
        {
            LeftButton_D.SetActive(false);
        }
        else
        {
            LeftButton_D.SetActive(true);
        }
        if (i == 1)
        {
            RightButton_D.SetActive(false);
        }
        else
        {
            RightButton_D.SetActive(true);
        }
    }


    // 페이지 넘기기 버튼
    public void OnClickRightButton() // 오른쪽 버튼을 누를 시
    {
        if (DogProfilePage.Length > i)
        {
            PageNum_D.text = (i + 2).ToString() + " / 2"; // 페이지 넘버

            DogProfilePage[i].SetActive(false);
            DogProfilePage[i + 1].SetActive(true);
            i++;
        }
    }

    public void OnClickLeftButton() // 왼쪽 버튼을 누를 시
    {
        if (0 < i)
        {
            PageNum_D.text = (i).ToString() + " / 2"; // 페이지 넘버

            DogProfilePage[i].SetActive(false);
            DogProfilePage[i - 1].SetActive(true);
            i--;
        }
    }

    //public void DogCurrentStatus() // 강아지 현재 상태 불러오기
    //{
    //    // Health_D.text = 
    //    // 위의 텍스트 값에 현재 스탯(스탯 코드에 있는 수치들 연동하면 될 듯)값 넣기
    //}
}
