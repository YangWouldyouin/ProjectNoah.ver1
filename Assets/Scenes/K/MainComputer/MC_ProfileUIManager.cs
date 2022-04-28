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

    void OnClickRightButton() // 오른쪽 버튼을 누를 시
    {
        i++;
        // PageNum[i];
    }

    void OnClickLeftButton() // 왼쪽 버튼을 누를 시
    {
        i--;
    }
}