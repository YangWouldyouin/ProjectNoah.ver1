using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_MeteorListUIManager : MonoBehaviour
{
    /* 오브젝트 */
    // 좌우 버튼
    public GameObject RightButton_Me;
    public GameObject LeftButton_Me;

    public int y = 0;

    public GameObject[] MeteorPage; // 페이지 오브젝트

    public Text PageNum_Me; // 페이지 넘버

    void Start()
    {
        MeteorPage[0].SetActive(true);
        PageNum_Me.text = "1 / 5";
    }
    void Update()
    {
        if (y == 0)
        {
            LeftButton_Me.SetActive(false);
        }
        else
        {
            LeftButton_Me.SetActive(true);
        }
        if (y == 4)
        {
            RightButton_Me.SetActive(false);
        }
        else
        {
            RightButton_Me.SetActive(true);
        }
    }


    // 페이지 넘기기
    public void OnClickRightButton() // 오른쪽 버튼을 누를 시
    {
        if (MeteorPage.Length > y)
        {
            PageNum_Me.text = (y + 2).ToString() + " / 5"; // 페이지 넘버

            MeteorPage[y].SetActive(false);
            MeteorPage[y + 1].SetActive(true);
            y++;
        }
    }

    public void OnClickLeftButton() // 왼쪽 버튼을 누를 시
    {
        if (0 < y)
        {
            PageNum_Me.text = (y).ToString() + " / 5"; // 페이지 넘버

            MeteorPage[y].SetActive(false);
            MeteorPage[y - 1].SetActive(true);
            y--;
        }
    }
}
