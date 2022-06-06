using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NoahStatController : MonoBehaviour
{
    public static NoahStatController noahStatController { get; private set; }

    [SerializeField] Image[] statColor;
    [SerializeField] Image[] statBar;

    [SerializeField] TMPro.TextMeshProUGUI conditionText;

    const float MAX_TIME = 1f;
    float timeLeft = 0f;

    public GameObject statPanel;

    AudioSource Noah_Sick_Audio;
    public AudioClip Noah_Sick;

    public InGameTime StatTime;
    NavMeshAgent agent;

    void Awake()
    {
        noahStatController = this;
    }

    void Start()
    {
        agent = BaseCanvas._baseCanvas.agent;
        Noah_Sick_Audio = GetComponent<AudioSource>();
        Noah_Sick_Audio.clip = Noah_Sick;

        ActivateStatBar();
        StartCoroutine(ChangeStatColorAndText());
        StartCoroutine(TurnOffPanel());
    }
    void Update()
    {
        // 스탯이 1이 되면 플레이어 스피드 감소
        if (StatTime.statNum==1)
        {
            agent.speed = 1f;
        }
        else
        {
            agent.speed = 3f;
        }

        DecreaseStatByTime();
    }
    
    public void IncreaseStat(int num)
    {
        if(StatTime.statNum < 10)
        {
            StatTime.statNum += num;
            if(StatTime.statNum>10)
            {
                StatTime.statNum = 10;
            }

            StatTime.statTimer = 0;
            StatTime.maxStatTimer = 0;

            GameManager.gameManager._gameData.statNum = StatTime.statNum;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            ActivateStatBar();

            StartCoroutine(ChangeStatColorAndText());
            StartCoroutine(TurnOffPanel());
        }
    }

    public void DecreaseStat(int num)
    {
        if(StatTime.statNum > 0)
        {
            StatTime.statNum -= num;

            if(StatTime.statNum<0)
            {
                StatTime.statNum = 0;
            }

            StatTime.statTimer = 0;
            StatTime.maxStatTimer = 0;

            GameManager.gameManager._gameData.statNum = StatTime.statNum;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            ActivateStatBar();

            StartCoroutine(ChangeStatColorAndText());
            StartCoroutine(TurnOffPanel());
        }
    }

    void  DecreaseStatByTime()
    {
        if(StatTime.statTimer==0 && StatTime.statNum<10)
        {
            ActivateStatBar();

            GameManager.gameManager._gameData.statNum = StatTime.statNum;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            StartCoroutine(ChangeStatColorAndText());
            StartCoroutine(TurnOffPanel());
        }
    }

    void ActivateStatBar()
    {
        /* 스탯만큼 스탯바를 활성화 */
        for (int i = 0; i < StatTime.statNum; i++)
        {
            statBar[i].enabled = true;
        }

        for (int j = StatTime.statNum; j < 10; j++)
        {
            statBar[j].enabled = false;
        }
    }

    IEnumerator TurnOffPanel()
    {
        yield return new WaitForSeconds(10f);
        conditionText.text = "";
        statPanel.SetActive(false);
    }

    IEnumerator ChangeStatColorAndText()
    {
        statPanel.SetActive(true);

        if (StatTime.statNum < 10 && StatTime.statNum >= 5)
        {
            conditionText.text = "[상태] \"좋음\"";

            statColor[1].fillAmount = 0;
            statColor[2].fillAmount = 0;

            while (timeLeft <= 1f)
            {
                timeLeft += 0.1f;
                statColor[0].fillAmount = timeLeft / MAX_TIME;

                yield return new WaitForSeconds(0.000001f);
            }
        }

        if (StatTime.statNum < 5 && StatTime.statNum >= 2)
        {
            conditionText.text = "[상태] \"보통\"";

            statColor[0].fillAmount = 0;
            statColor[2].fillAmount = 0;

            while (timeLeft <= 1f)
            {
                timeLeft += 0.1f;
                statColor[1].fillAmount = timeLeft / MAX_TIME;

                yield return new WaitForSeconds(0.000001f);
            }
        }

        if (StatTime.statNum < 2 && StatTime.statNum >= 0)
        {
            conditionText.text = "[상태] \"나쁨\"";

            Noah_Sick_Audio.Play();

            statColor[0].fillAmount = 0;
            statColor[1].fillAmount = 0;

            while (timeLeft <= 1)
            {
                timeLeft += 0.1f;
                statColor[2].fillAmount = timeLeft / MAX_TIME;

                yield return new WaitForSeconds(0.000001f);
            }
        }

        timeLeft = 0;
    }
}
