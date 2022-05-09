using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{

    public static TimerManager timerManager { get; private set; }

    private void Awake()
    {
        timerManager = this;
    }

    public InGameTime inGameTime;
    
    Image timerBar;
    Image timerText;
    Image timerBackground;

    [HideInInspector]
    public float maxTime = 5f;
    [HideInInspector]
    public float timeLeft = 5f;

    void Start()
    {
        timerBar = transform.GetChild(0).GetComponent<Image>();
        timerText = transform.GetChild(1).GetComponent<Image>();
        timerBackground = transform.GetChild(2).GetComponent<Image>();

        if (inGameTime.IsTimerStarted)
        {
            timerBar.gameObject.SetActive(true);
            timerText.gameObject.SetActive(true);
            timerBackground.gameObject.SetActive(true);

            StartCoroutine(StartTimer());
        }
    }

    public void TimerStart(float minutes)
    {
        timerBar.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        timerBackground.gameObject.SetActive(true);

        inGameTime.IsTimerStarted = true;
        inGameTime.missionTimer = minutes;
        inGameTime.maxTimer = minutes;

        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        timerBar.fillAmount = inGameTime.missionTimer / inGameTime.maxTimer;
        while (inGameTime.missionTimer >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            inGameTime.missionTimer -= 0.01f;
            timerBar.fillAmount = inGameTime.missionTimer / inGameTime.maxTimer;
        }

        timerBar.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        timerBackground.gameObject.SetActive(false);

        inGameTime.IsTimerStarted = false;
    }  
}
