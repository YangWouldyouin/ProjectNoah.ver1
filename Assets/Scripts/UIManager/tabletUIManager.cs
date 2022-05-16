using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabletUIManager : MonoBehaviour
{
    public GameObject DiaryUI;
    public GameObject MainUI;
    public GameObject CrackUI;
    public GameObject WirelessUI;
    public GameObject LockUI;

    public Text Locked;

    public bool CrackUI_firstEnter = false;

    public void Start()
    {
        DiaryUI.SetActive(false);
        CrackUI.SetActive(false);
        WirelessUI.SetActive(false);
        MainUI.SetActive(false);
        LockUI.SetActive(true);
    }

    public void Update()
    {
        if (GameManager.gameManager._gameData.IsTabletUnlock)
        {
            Locked.text = "UnLocked!";
        }
    }

    /* ���������������������������������������� ���� �� ���������������������������������������� */
    public void ChangeMain()
    {
        if (GameManager.gameManager._gameData.IsTabletUnlock == true)
        {
            MainUI.SetActive(true);
            LockUI.SetActive(false);
        }
    }

    public void ChangeDiary()
    {
        MainUI.SetActive(false);
        DiaryUI.SetActive(true);
    }
    public void ChangeCrack()
    {
        MainUI.SetActive(false);
        CrackUI.SetActive(true);

        if (CrackUI_firstEnter == false)
        {
            CrackUI_firstEnter = true;
            //���̵����� ����(�ٿ�ε�) ���� ����
        }
    }
    public void ChangeWireless()
    {
        MainUI.SetActive(false);
        WirelessUI.SetActive(true);

        if (GameManager.gameManager._gameData.IsWirelessUI_firstEnter == false)
        {
            GameManager.gameManager._gameData.IsWirelessUI_firstEnter = true;
            //���� ��ǻ�Ϳ� �º� ��ȣ ���� ���� ����
        }
    }

    public void BackMain_Diary()
    {
        DiaryUI.SetActive(false);
        MainUI.SetActive(true);
    }
    public void BackMain_Crack()
    {
        CrackUI.SetActive(false);
        MainUI.SetActive(true);
    }
    public void BackMain_Wireless()
    {
        WirelessUI.SetActive(false);
        MainUI.SetActive(true);
    }
}
