using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_ReportUIManager : MonoBehaviour
{
    /* ������Ʈ */
    // �¿� ��ư
    public GameObject RightButton_Rep;
    public GameObject LeftButton_Rep;

    public string[] Title_Rep; // ����
    public string[] Detail_Rep; // ����

    public Text TitleText_Rep;
    public Text DetailText_Rep;
    public Text PageNum_Rep; // �������ѹ�

    public int r = 0;

    void Start()
    {
        Title_Rep[0] = "���� 1";
        Title_Rep[1] = "���� 2";
        Title_Rep[2] = "���� 3";

        Detail_Rep[0] = "���� 1";
        Detail_Rep[1] = "���� 2";
        Detail_Rep[2] = "���� 3";

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



    public void OnClickRightButton() // ������ ��ư�� ���� ��
    {
        if (Title_Rep.Length > r)
        {
            PageNum_Rep.text = (r + 2).ToString() + " / 13"; // ������ �ѹ�

            TitleText_Rep.text = Title_Rep[r + 1];
            DetailText_Rep.text = Detail_Rep[r + 1];

            r++;
        }
    }

    public void OnClickLeftButton() // ���� ��ư�� ���� ��
    {
        if (0 < r)
        {
            PageNum_Rep.text = (r).ToString() + " / 13"; // ������ �ѹ�

            TitleText_Rep.text = Title_Rep[r - 1];
            DetailText_Rep.text = Detail_Rep[r - 1];

            r--;
        }
    }
}
