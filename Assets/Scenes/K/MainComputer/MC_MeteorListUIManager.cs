using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_MeteorListUIManager : MonoBehaviour
{
    /* ������Ʈ */
    // �¿� ��ư
    public GameObject RightButton_Me;
    public GameObject LeftButton_Me;

    public int y = 0;

    public GameObject[] MeteorPage; // ������ ������Ʈ

    public Text PageNum_Me; // ������ �ѹ�

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


    // ������ �ѱ��
    public void OnClickRightButton() // ������ ��ư�� ���� ��
    {
        if (MeteorPage.Length > y)
        {
            PageNum_Me.text = (y + 2).ToString() + " / 5"; // ������ �ѹ�

            MeteorPage[y].SetActive(false);
            MeteorPage[y + 1].SetActive(true);
            y++;
        }
    }

    public void OnClickLeftButton() // ���� ��ư�� ���� ��
    {
        if (0 < y)
        {
            PageNum_Me.text = (y).ToString() + " / 5"; // ������ �ѹ�

            MeteorPage[y].SetActive(false);
            MeteorPage[y - 1].SetActive(true);
            y--;
        }
    }
}
