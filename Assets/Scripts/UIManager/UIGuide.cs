using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGuide : MonoBehaviour
{

    public GameObject GuideUI;
    public GameObject Contents1;
    public GameObject Contents2;
    public GameObject NextBT;
    public GameObject PrevBT;

    // Start is called before the first frame update
    void Start()
    {
        GuideUI.SetActive(false);
    }

    public void GuideOpenBT()
    {
        GuideUI.SetActive(true);
        Contents1.SetActive(true);
        Contents2.SetActive(false);
        NextBT.SetActive(true);
        PrevBT.SetActive(false);

        Time.timeScale = 0f;
    }

    public void GuideExitBT()
    {
        GuideUI.SetActive(false);
        Contents1.SetActive(false);
        Contents2.SetActive(false);
        NextBT.SetActive(false);
        PrevBT.SetActive(false);

        Time.timeScale = 1f;
    }

    public void OnNextBT()
    {
        NextBT.SetActive(false);
        PrevBT.SetActive(true);
        Contents1.SetActive(false);
        Contents2.SetActive(true);
    }

    public void OnPrevBT()
    {
        NextBT.SetActive(true);
        PrevBT.SetActive(false);
        Contents1.SetActive(true);
        Contents2.SetActive(false);
    }
}
