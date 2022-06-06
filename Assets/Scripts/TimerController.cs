using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public InGameTime inGameTime;

    private TMPro.TextMeshProUGUI dayText;
    private TMPro.TextMeshProUGUI hourText;

    private void Awake()
    {
        dayText = transform.Find("DayText").GetComponent<TMPro.TextMeshProUGUI>();
        hourText = transform.Find("HourText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        inGameTime.timer += Time.deltaTime;
        inGameTime.statTimer+= Time.deltaTime;
        DisplayTime(inGameTime.timer, inGameTime.statTimer);      
    }

    void DisplayTime(float timeToDisplay, float timeToLowerStat)
    {
        if(timeToDisplay<0)
        {
            timeToDisplay = 0;
        }

        if (timeToLowerStat < 0)
        {
            timeToLowerStat = 0;
        }

        inGameTime.days = Mathf.FloorToInt(timeToDisplay / 720);
        inGameTime.hours = Mathf.FloorToInt((timeToDisplay % 720) / 30);

        dayText.text = string.Format("{0:00}", inGameTime.days + 1);
        hourText.text = string.Format("{0:00}", inGameTime.hours) + ":00";


        inGameTime.maxStatTimer = Mathf.FloorToInt((timeToLowerStat % 3600)/60);

        if(inGameTime.maxStatTimer == 5)
        {
            inGameTime.statNum -= 1;
            inGameTime.statTimer = 0;
            timeToLowerStat = 0;
            inGameTime.maxStatTimer = 0;
        }
        //inGameTime.days = Mathf.FloorToInt((timeToDisplay % 3600)/60);

        //inGameTime.hours = Mathf.FloorToInt((timeToDisplay % 3600) % 60);

        //float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        //float seconds = Mathf.FloorToInt((timeToDisplay % 3600) % 60);

        //hourText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    IEnumerator Count()
    {
        while (inGameTime.missionTimer <= 15)
        {
            inGameTime.missionTimer++;
            yield return new WaitForSeconds(1f);
        }
    }

}
