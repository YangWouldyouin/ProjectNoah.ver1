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

    Image timerDim;
    Image timerBar;
    Image timerText;
    Image timerBackground;

    [HideInInspector]
    public float maxTime;
    [HideInInspector]
    public float timeLeft;

    void Start()
    {
        timerDim = transform.GetChild(0).GetComponent<Image>();
        timerBar = transform.GetChild(1).GetComponent<Image>();
        timerBackground = transform.GetChild(2).GetComponent<Image>();
        timerText = transform.GetChild(3).GetComponent<Image>();


        if (inGameTime.IsTimerStarted)
        {
            timerDim.gameObject.SetActive(true);
            timerBar.gameObject.SetActive(true);
            timerText.gameObject.SetActive(true);
            timerBackground.gameObject.SetActive(true);

            StartCoroutine(StartTimer());
        }
    }

    public void TimerStart(float minutes)
    {
        timerDim.gameObject.SetActive(true);
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

        while (inGameTime.missionTimer >= 0 && inGameTime.IsTimerStarted)
        {
            yield return new WaitForSeconds(1f);
            inGameTime.missionTimer -= 1f;
            timerBar.fillAmount = inGameTime.missionTimer / inGameTime.maxTimer;
        }

        timerDim.gameObject.SetActive(false);
        timerBar.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        timerBackground.gameObject.SetActive(false);

        inGameTime.IsTimerStarted = false;
    }
}
