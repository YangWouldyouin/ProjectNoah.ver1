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

    int i = 0;

    public GameObject[] ProfilePage;
    public string[] PageNum;


    void Start()
    {

    }
    void Update()
    {
        if (i == 0)
        {
            LeftButton_P.SetActive(false);
        }
        if (i == 5)
        {
            RightButton_P.SetActive(false);
        }
    }

    void OnClickRightButton() // ������ ��ư�� ���� ��
    {
        i++;
        // PageNum[i];
    }

    void OnClickLeftButton() // ���� ��ư�� ���� ��
    {
        i--;
    }
}