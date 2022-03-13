using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalClock : MonoBehaviour
{

    private const float REAL_SECONDS_PER_INGAME_DAY = 45000f;

    private float day;

    //private TMPro.TextMeshProUGUI textClock;
    private TMPro.TextMeshProUGUI dayText;
    private TMPro.TextMeshProUGUI hourText;

    private void Awake()
    {
        //textClock = GetComponent<TMPro.TextMeshProUGUI>();

        dayText = transform.Find("DayText").GetComponent<TMPro.TextMeshProUGUI>();
        hourText = transform.Find("HourText").GetComponent<TMPro.TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
      


        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        float dayNormalized = day % 1f;


        float hoursPerDay = 24f;
        string minutesString = Mathf.Floor(dayNormalized* hoursPerDay+1).ToString("00");




        float minutesPerHour = 60f;
        string secondsString = Mathf.Floor((dayNormalized * hoursPerDay)%1f*minutesPerHour).ToString("00");

        dayText.text = minutesString;
        hourText.text = secondsString + " : 00";

        //float secondsPerHour = 60f;
        //string hoursString = Mathf.Floor((dayNormalized * hoursPerDay) % 1f * minutesPerHour).ToString("00");

    }
}
