using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabletUIManager : MonoBehaviour
{
    public GameObject DiaryUI;
    public GameObject MainUI;
    public GameObject CrackUI;
    public GameObject WirelessUI;

    public void Start()
    {
        DiaryUI.SetActive(false);
        CrackUI.SetActive(false);
        WirelessUI.SetActive(false);
        MainUI.SetActive(true);
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