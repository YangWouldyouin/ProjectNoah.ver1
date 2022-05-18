using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuddenDeathAlertUIManager : MonoBehaviour
{
    public GameObject DeathAlert;
    //public Text NumCountText;

    [SerializeField] float setTime = 5.0f;
    [SerializeField] Text NumCountText;

    void Start()
    {
        NumCountText.text = setTime.ToString();
    }
    
    void Update()
    {
        if (GameManager.gameManager._gameData.IsSuddenDeath == true)
        {
            DeathAlert.SetActive(true);
            
            if(setTime > 0)
            {
                setTime -= Time.deltaTime;
            }
            else if (setTime <=0)
            {
                CountEnd();
            }

            NumCountText.text = Mathf.Round(setTime).ToString();
        }
        else
        {
            DeathAlert.SetActive(false);
            setTime = 5.0f;
        }
    }


    //public void Count4()
    //{
    //    NumCountText.GetComponent<Text>().text = "4";
    //    Invoke("Count3", 1f);
    //}
    //public void Count3()
    //{
    //    NumCountText.GetComponent<Text>().text = "3";
    //    Invoke("Count2", 1f);
    //}

    //public void Count2()
    //{
    //    NumCountText.GetComponent<Text>().text = "2";
    //    Invoke("Count1", 1f);
    //}

    //public void Count1()
    //{
    //    NumCountText.GetComponent<Text>().text = "1";
    //    Invoke("Count0", 1f);
    //}
    //public void Count0()
    //{
    //    NumCountText.GetComponent<Text>().text = "0";
    //    Invoke("CountEnd", 1f);
    //}

    public void CountEnd()
    {
        GameManager.gameManager._gameData.IsSuddenDeath = false;
    }
}
