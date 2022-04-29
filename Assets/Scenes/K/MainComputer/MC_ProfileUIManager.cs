using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_ProfileUIManager : MonoBehaviour
{
    /* 오브젝트 */
    // 좌우 버튼
    public GameObject RightButton_P;
    public GameObject LeftButton_P;

    public int i = 0;

    public GameObject[] ProfilePage; // 페이지 오브젝트

    public Text PageNum_P; // 페이지넘버

    void Start()
    {
        ProfilePage[0].SetActive(true);
        PageNum_P.text = "1 / 5";
    }

    void Update()
    {
        if (i == 0)
        {
            LeftButton_P.SetActive(false);
        }
        else
        {
            LeftButton_P.SetActive(true);
        }
        if (i == 4)
        {
            RightButton_P.SetActive(false);
        }
        else
        {
            RightButton_P.SetActive(true);
        }
    }


    // 페이지 넘기기
    public void OnClickRightButton() // 오른쪽 버튼을 누를 시
    {
        if(ProfilePage.Length > i)
        {
            PageNum_P.text = (i + 2).ToString() + " / 5"; // 페이지 넘버

            ProfilePage[i].SetActive(false);
            ProfilePage[i + 1].SetActive(true);
            i++;
        }
    }

    public void OnClickLeftButton() // 왼쪽 버튼을 누를 시
    {
        if (0 < i)
        {
            PageNum_P.text = (i).ToString() + " / 5"; // 페이지 넘버

            ProfilePage[i].SetActive(false);
            ProfilePage[i - 1].SetActive(true);
            i--;
        }
    }


}