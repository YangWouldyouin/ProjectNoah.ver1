using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGuide : MonoBehaviour
{

    public GameObject GuideUI;

    // Start is called before the first frame update
    void Start()
    {
        GuideUI.SetActive(false);
    }

    public void GuideOpenBT()
    {
        GuideUI.SetActive(true);
    }

    public void GuideExitBT()
    {
        GuideUI.SetActive(false);
    }
}
