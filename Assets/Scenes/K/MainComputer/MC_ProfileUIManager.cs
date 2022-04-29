using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_ProfileUIManager : MonoBehaviour
{
    /* ������Ʈ */
    // �¿� ��ư
    public GameObject RightButton_P;
    public GameObject LeftButton_P;

    public int i = 0;

    public GameObject[] ProfilePage; // ������ ������Ʈ

    public Text PageNum_P; // �������ѹ�

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


    // ������ �ѱ��
    public void OnClickRightButton() // ������ ��ư�� ���� ��
    {
        if(ProfilePage.Length > i)
        {
            PageNum_P.text = (i + 2).ToString() + " / 5"; // ������ �ѹ�

            ProfilePage[i].SetActive(false);
            ProfilePage[i + 1].SetActive(true);
            i++;
        }
    }

    public void OnClickLeftButton() // ���� ��ư�� ���� ��
    {
        if (0 < i)
        {
            PageNum_P.text = (i).ToString() + " / 5"; // ������ �ѹ�

            ProfilePage[i].SetActive(false);
            ProfilePage[i - 1].SetActive(true);
            i--;
        }
    }


}