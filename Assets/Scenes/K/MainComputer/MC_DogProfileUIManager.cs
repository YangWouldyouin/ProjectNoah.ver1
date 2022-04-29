using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_DogProfileUIManager : MonoBehaviour
{
    /* ������Ʈ */
    // �¿� ��ư
    public GameObject RightButton_D;
    public GameObject LeftButton_D;

    // ������ ���� ����
    public Text Health_D; // �ǰ� ����


    /* �⺻ ���� */
    public int i = 0;

    public GameObject[] DogProfilePage; // ������ ������Ʈ

    public Text PageNum_D; // �������ѹ�

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


    // ������ �ѱ�� ��ư
    public void OnClickRightButton() // ������ ��ư�� ���� ��
    {
        if (DogProfilePage.Length > i)
        {
            PageNum_D.text = (i + 2).ToString() + " / 2"; // ������ �ѹ�

            DogProfilePage[i].SetActive(false);
            DogProfilePage[i + 1].SetActive(true);
            i++;
        }
    }

    public void OnClickLeftButton() // ���� ��ư�� ���� ��
    {
        if (0 < i)
        {
            PageNum_D.text = (i).ToString() + " / 2"; // ������ �ѹ�

            DogProfilePage[i].SetActive(false);
            DogProfilePage[i - 1].SetActive(true);
            i--;
        }
    }

    //public void DogCurrentStatus() // ������ ���� ���� �ҷ�����
    //{
    //    // Health_D.text = 
    //    // ���� �ؽ�Ʈ ���� ���� ����(���� �ڵ忡 �ִ� ��ġ�� �����ϸ� �� ��)�� �ֱ�
    //}
}
