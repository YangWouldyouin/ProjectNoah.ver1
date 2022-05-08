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

    // 강아지 현재 상태 (스탯 계산)
    public Text Sleep_text_D; // 피로도
    public Text HP_text_D; // 체력
    public Text Water_text_D; // 목마름
    public Text Food_text_D; // 허기

/*    public int Sleep_int_D; // 피로도
    public int HP_int_D; // 체력
    public int Water_int_D; // 목마름
    public int Food_int_D; // 허기*/


    public int noahStat; // 노아 현재 스탯
    public int ranStat; // 랜덤 스탯 값

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

        DogCurrentStatus();
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

    public void DogCurrentStatus() // 강아지 현재 상태 불러오기
    {
        int noahStat = GameManager.gameManager._gameData.statNum; // 노아 현재 스탯 값 불러오기

        /* 피로도 */
        ranStat = Random.Range(-5, 5); // 랜덤 값
        GameManager.gameManager._gameData.IsRealfatigue = ranStat + noahStat * 10;
        Sleep_text_D.text = "피로도: " + GameManager.gameManager._gameData.IsRealfatigue.ToString();

        /* 체력 */
        // ranStat = Random.Range(-5, 5); // 랜덤 값
        GameManager.gameManager._gameData.IsRealStrength = ranStat + noahStat * 10;
        HP_text_D.text = "체력: " + GameManager.gameManager._gameData.IsRealStrength.ToString();

        /* 목마름 */
        // ranStat = Random.Range(-5, 5); // 랜덤 값
        GameManager.gameManager._gameData.IsRealThirst = ranStat + noahStat * 10;
        Water_text_D.text = "체력: " + GameManager.gameManager._gameData.IsRealThirst.ToString();

        /* 허기 */
        // ranStat = Random.Range(-5, 5); // 랜덤 값
        GameManager.gameManager._gameData.IsRealHunger = ranStat + noahStat * 10;
        Food_text_D.text = "체력: " + GameManager.gameManager._gameData.IsRealHunger.ToString();

        /*        if(10 <= noahStat && noahStat <= 90)
                {
                    *//* 피로도 *//*
                    ranStat = Random.Range(-5, 5); // 랜덤 값
                    int Sleep_int = ranStat + noahStat;
                    Sleep_text_D.text = "피로도: " + Sleep_int.ToString();

                    *//* 체력 *//*
                    ranStat = Random.Range(-5, 5); // 랜덤 값
                    int HP_int = ranStat + noahStat;
                    HP_text_D.text = "체력: " + HP_int.ToString();

                    *//* 목마름 *//*
                    ranStat = Random.Range(-5, 5); // 랜덤 값
                    int Water_int = ranStat + noahStat;
                    Water_text_D.text = "체력: " + Water_int.ToString();

                    *//* 허기 *//*
                    ranStat = Random.Range(-5, 5); // 랜덤 값
                    int Food_int = ranStat + noahStat;
                    Food_text_D.text = "체력: " + Food_int.ToString();
                }

                if (noahStat > 90)
                {
                    *//* 피로도 *//*
                    ranStat = Random.Range(-5, 0); // 랜덤 값
                    int Sleep_int = ranStat + noahStat;
                    Sleep_text_D.text = "피로도: " + Sleep_int.ToString();

                    *//* 체력 *//*
                    ranStat = Random.Range(-5, 0); // 랜덤 값
                    int HP_int = ranStat + noahStat;
                    HP_text_D.text = "체력: " + HP_int.ToString();

                    *//* 목마름 *//*
                    ranStat = Random.Range(-5, 0); // 랜덤 값
                    int Water_int = ranStat + noahStat;
                    Water_text_D.text = "체력: " + Water_int.ToString();

                    *//* 허기 *//*
                    ranStat = Random.Range(-5, 0); // 랜덤 값
                    int Food_int = ranStat + noahStat;
                    Food_text_D.text = "체력: " + Food_int.ToString();
                }*/


        // Sleep_D.text = GameManager.gameManager._gameData.statNum + ranStat
        // 위의 텍스트 값에 현재 스탯(스탯 코드에 있는 수치들 연동하면 될 듯)값 넣기
    }
}
