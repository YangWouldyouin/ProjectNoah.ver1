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

    // ������ ���� ���� (���� ���)
    public Text Sleep_text_D; // �Ƿε�
    public Text HP_text_D; // ü��
    public Text Water_text_D; // �񸶸�
    public Text Food_text_D; // ���

/*    public int Sleep_int_D; // �Ƿε�
    public int HP_int_D; // ü��
    public int Water_int_D; // �񸶸�
    public int Food_int_D; // ���*/


    public int noahStat; // ��� ���� ����
    public int ranStat; // ���� ���� ��

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

        DogCurrentStatus();
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

    public void DogCurrentStatus() // ������ ���� ���� �ҷ�����
    {
        int noahStat = GameManager.gameManager._gameData.statNum; // ��� ���� ���� �� �ҷ�����

        /* �Ƿε� */
        ranStat = Random.Range(-5, 5); // ���� ��
        GameManager.gameManager._gameData.IsRealfatigue = ranStat + noahStat * 10;
        Sleep_text_D.text = "�Ƿε�: " + GameManager.gameManager._gameData.IsRealfatigue.ToString();

        /* ü�� */
        // ranStat = Random.Range(-5, 5); // ���� ��
        GameManager.gameManager._gameData.IsRealStrength = ranStat + noahStat * 10;
        HP_text_D.text = "ü��: " + GameManager.gameManager._gameData.IsRealStrength.ToString();

        /* �񸶸� */
        // ranStat = Random.Range(-5, 5); // ���� ��
        GameManager.gameManager._gameData.IsRealThirst = ranStat + noahStat * 10;
        Water_text_D.text = "ü��: " + GameManager.gameManager._gameData.IsRealThirst.ToString();

        /* ��� */
        // ranStat = Random.Range(-5, 5); // ���� ��
        GameManager.gameManager._gameData.IsRealHunger = ranStat + noahStat * 10;
        Food_text_D.text = "ü��: " + GameManager.gameManager._gameData.IsRealHunger.ToString();

        /*        if(10 <= noahStat && noahStat <= 90)
                {
                    *//* �Ƿε� *//*
                    ranStat = Random.Range(-5, 5); // ���� ��
                    int Sleep_int = ranStat + noahStat;
                    Sleep_text_D.text = "�Ƿε�: " + Sleep_int.ToString();

                    *//* ü�� *//*
                    ranStat = Random.Range(-5, 5); // ���� ��
                    int HP_int = ranStat + noahStat;
                    HP_text_D.text = "ü��: " + HP_int.ToString();

                    *//* �񸶸� *//*
                    ranStat = Random.Range(-5, 5); // ���� ��
                    int Water_int = ranStat + noahStat;
                    Water_text_D.text = "ü��: " + Water_int.ToString();

                    *//* ��� *//*
                    ranStat = Random.Range(-5, 5); // ���� ��
                    int Food_int = ranStat + noahStat;
                    Food_text_D.text = "ü��: " + Food_int.ToString();
                }

                if (noahStat > 90)
                {
                    *//* �Ƿε� *//*
                    ranStat = Random.Range(-5, 0); // ���� ��
                    int Sleep_int = ranStat + noahStat;
                    Sleep_text_D.text = "�Ƿε�: " + Sleep_int.ToString();

                    *//* ü�� *//*
                    ranStat = Random.Range(-5, 0); // ���� ��
                    int HP_int = ranStat + noahStat;
                    HP_text_D.text = "ü��: " + HP_int.ToString();

                    *//* �񸶸� *//*
                    ranStat = Random.Range(-5, 0); // ���� ��
                    int Water_int = ranStat + noahStat;
                    Water_text_D.text = "ü��: " + Water_int.ToString();

                    *//* ��� *//*
                    ranStat = Random.Range(-5, 0); // ���� ��
                    int Food_int = ranStat + noahStat;
                    Food_text_D.text = "ü��: " + Food_int.ToString();
                }*/


        // Sleep_D.text = GameManager.gameManager._gameData.statNum + ranStat
        // ���� �ؽ�Ʈ ���� ���� ����(���� �ڵ忡 �ִ� ��ġ�� �����ϸ� �� ��)�� �ֱ�
    }
}
