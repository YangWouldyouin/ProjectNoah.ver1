using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuddenDeathAlertUIManager : MonoBehaviour
{
    public GameObject DeathAlert;
    public Text NumCountText;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.gameManager._gameData.IsSuddenDeath == true)
        {
            NumCountText.GetComponent<Text>().text = "5";
            Invoke("Count4", 1f);
        }
        else
        {
            DeathAlert.SetActive(false);
        }
    }


    public void Count4()
    {
        NumCountText.GetComponent<Text>().text = "4";
        Invoke("Count3", 1f);
    }
    public void Count3()
    {
        NumCountText.GetComponent<Text>().text = "3";
        Invoke("Count2", 1f);
    }

    public void Count2()
    {
        NumCountText.GetComponent<Text>().text = "2";
        Invoke("Count1", 1f);
    }

    public void Count1()
    {
        NumCountText.GetComponent<Text>().text = "1";
        Invoke("Count0", 1f);
    }
    public void Count0()
    {
        NumCountText.GetComponent<Text>().text = "0";
        Invoke("CountEnd", 1f);
    }

    public void CountEnd()
    {
        GameManager.gameManager._gameData.IsSuddenDeath = false;
    }
}
