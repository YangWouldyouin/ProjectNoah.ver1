using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_ReportUIManager : MonoBehaviour
{
    /* 오브젝트 */
    // 좌우 버튼
    public GameObject RightButton_Rep;
    public GameObject LeftButton_Rep;

    public string[] Title_Rep; // 제목
    public string[] Detail_Rep; // 내용

    public Text TitleText_Rep;
    public Text DetailText_Rep;
    public Text PageNum_Rep; // 페이지넘버

    public int r = 0;

    void Start()
    {
        Title_Rep[0] = "제목 1";
        Title_Rep[1] = "제목 2";
        Title_Rep[2] = "제목 3";

        Detail_Rep[0] = "내용 1";
        Detail_Rep[1] = "내용 2";
        Detail_Rep[2] = "내용 3";

        TitleText_Rep.text = Title_Rep[0];
        DetailText_Rep.text = Detail_Rep[0];
        PageNum_Rep.text = "1 / 13";
    }



    void Update()
    {
        if (r == 0)
        {
            LeftButton_Rep.SetActive(false);
        }
        else
        {
            LeftButton_Rep.SetActive(true);
        }
        if (r == 13)
        {
            RightButton_Rep.SetActive(false);
        }
        else
        {
            RightButton_Rep.SetActive(true);
        }
    }



    public void OnClickRightButton() // 오른쪽 버튼을 누를 시
    {
        if (Title_Rep.Length > r)
        {
            PageNum_Rep.text = (r + 2).ToString() + " / 13"; // 페이지 넘버

            TitleText_Rep.text = Title_Rep[r + 1];
            DetailText_Rep.text = Detail_Rep[r + 1];

            r++;
        }
    }

    public void OnClickLeftButton() // 왼쪽 버튼을 누를 시
    {
        if (0 < r)
        {
            PageNum_Rep.text = (r).ToString() + " / 13"; // 페이지 넘버

            TitleText_Rep.text = Title_Rep[r - 1];
            DetailText_Rep.text = Detail_Rep[r - 1];

            r--;
        }
    }
}
