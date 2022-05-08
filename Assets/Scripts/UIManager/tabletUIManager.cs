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
    }
    public void ChangeWireless()
    {
        MainUI.SetActive(false);
        WirelessUI.SetActive(true);
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
