using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateSystemUIManager : MonoBehaviour
{
    public GameObject MainUI;

    public GameObject Open;
    public GameObject Fold;

    public GameObject alert;

    public void Start()
    {
        MainUI.SetActive(false);
        alert.SetActive(false);
        Fold.SetActive(false);
        Open.SetActive(true);
    }

    public void OpenBT()
    {
        MainUI.SetActive(true);

        Open.SetActive(false);
        Fold.SetActive(true);
    }
    public void FoldBT()
    {
        MainUI.SetActive(false);
        Open.SetActive(true);
        Fold.SetActive(false);
    }

}
