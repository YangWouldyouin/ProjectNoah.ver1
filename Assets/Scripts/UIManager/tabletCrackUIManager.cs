using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabletCrackUIManager : MonoBehaviour
{
    public GameObject TC_MainUI;
    public GameObject TC_FakeReportUI;
    public GameObject TC_ReadMeUI;

    public void Start()
    {
        TC_FakeReportUI.SetActive(false);
        TC_ReadMeUI.SetActive(false);
        TC_MainUI.SetActive(true);
    }

    public void TC_ChangeFR()
    {
        TC_MainUI.SetActive(false);
        TC_FakeReportUI.SetActive(true);
    }
    public void TC_ChangeRM()
    {
        TC_MainUI.SetActive(false);
        TC_ReadMeUI.SetActive(true);
    }
    public void TC_Back_FR()
    {
        TC_MainUI.SetActive(true);
        TC_FakeReportUI.SetActive(false);
    }

    public void TC_Back_RM()
    {
        TC_ReadMeUI.SetActive(false);
        TC_MainUI.SetActive(true);
    }
}
