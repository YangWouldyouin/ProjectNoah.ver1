using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float timeValue = 0;
    private TMPro.TextMeshProUGUI dayText;
    private TMPro.TextMeshProUGUI hourText;

    InGameTime inGameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        //textClock = GetComponent<TMPro.TextMeshProUGUI>();

        dayText = transform.Find("DayText").GetComponent<TMPro.TextMeshProUGUI>();
        hourText = transform.Find("HourText").GetComponent<TMPro.TextMeshProUGUI>();


    }


    // Update is called once per frame
    void Update()
    {

        timeValue += Time.deltaTime;
        DisplayTime(timeValue);
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay<0)
        {
            timeToDisplay = 0;
        }
        inGameTime.days = Mathf.FloorToInt(timeToDisplay / 720);

        inGameTime.hours = Mathf.FloorToInt((timeToDisplay % 720) / 30);



        //float hours = Mathf.FloorToInt(timeToDisplay / 3600);

        //float minutes = Mathf.FloorToInt((timeToDisplay % 3600)/60);

        //float seconds = Mathf.FloorToInt((timeToDisplay % 3600) % 60);

        //hourText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        dayText.text = string.Format("{0:00}", inGameTime.days + 1);
        hourText.text = string.Format("{0:00}", inGameTime.hours) +":00";
    }
}
