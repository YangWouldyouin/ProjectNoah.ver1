using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NoahStatController : MonoBehaviour
{
    public static NoahStatController noahStatController { get; private set; }
    public int currentNum;

    [SerializeField] Image[] statColor;
    [SerializeField] Image[] statBar;

    [SerializeField] TMPro.TextMeshProUGUI conditionText;
    float blueTimeLeft = 0f;
    float redTimeLeft = 0f;
    float yellowTimeLeft = 0f;

    float maxTime = 1f;

    private float timer = 0f;
    float conditionTimer = 0f;

    public GameObject statPanel;

    AudioSource Noah_Sick_Audio;
    public AudioClip Noah_Sick;

    public InGameTime StatTime;
    NavMeshAgent agent;

    private void Awake()
    {
        noahStatController = this;
    }
    

    void Start()
    {
        agent = BaseCanvas._baseCanvas.agent;
        Noah_Sick_Audio = GetComponent<AudioSource>();

        currentNum = GameManager.gameManager._gameData.statNum;

        for (int i = 0; i < StatTime.statNum; i++)
        {
            statBar[i].enabled = true;
        }

        for (int j = StatTime.statNum; j < 10; j++)
        {
            statBar[j].enabled = false;
        }

        StartCoroutine(ChangeStatColorAndText());
        StartCoroutine(TurnOffPanel());

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
            yellowTimeLeft = 0;
            redTimeLeft = 0;

            statColor[1].fillAmount = 0;
            statColor[2].fillAmount = 0;
            while (blueTimeLeft < 1)
            {
                statColor[0].fillAmount = blueTimeLeft / maxTime;
                blueTimeLeft += 0.1f;
                yield return new WaitForSeconds(0.000001f);
            }
        }

        if (StatTime.statNum < 5 && StatTime.statNum >= 2)
        {
            conditionText.text = "[상태] \"보통\"";
            redTimeLeft = 0;
            blueTimeLeft = 0;

            statColor[0].fillAmount = 0;
            statColor[2].fillAmount = 0;

            while(yellowTimeLeft < 1)
            {
                statColor[1].fillAmount = yellowTimeLeft / maxTime;
                yellowTimeLeft += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }          
        }

        if (StatTime.statNum < 2 && StatTime.statNum >= 0)
        {
            conditionText.text = "[상태] \"나쁨\"";
            Noah_Sick_Audio.clip = Noah_Sick;
            Noah_Sick_Audio.Play();

            yellowTimeLeft = 0;
            blueTimeLeft = 0;

            statColor[0].fillAmount = 0;
            statColor[1].fillAmount = 0;

            while(redTimeLeft < 1)
            {
                statColor[2].fillAmount = redTimeLeft / maxTime;
                redTimeLeft += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    private void Update()
    {
        // 스탯이 1이 되면 플레이어 스피드 감소
        if (StatTime.statNum < 2 && StatTime.statNum > 0)
        {
            agent.speed = 1f;
        }
        else
        {
            agent.speed = 3f;
        }

        DecreaseStatByTime();
    }
    
    public void IncreaseStatBar(int num)
    {
        //SaveSystem.Load("save_001");
        //currentNum = GameManager.gameManager._gameData.statNum;
        if(StatTime.statNum < 10)
        {
            StatTime.statNum += num;
            GameManager.gameManager._gameData.statNum = StatTime.statNum;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            for (int i = 0; i < StatTime.statNum; i++)
            {
                statBar[i].enabled = true;
            }

            for (int j = StatTime.statNum; j < 10; j++)
            {
                statBar[j].enabled = false;
            }

            StartCoroutine(ChangeStatColorAndText());
            StartCoroutine(TurnOffPanel());
        }


    }

    public void DecreaseStatBar(int num)
    {
        SaveSystem.Load("save_001");
        currentNum = GameManager.gameManager._gameData.statNum;
        if(StatTime.statNum > 0)
        {
            StatTime.statNum -= num;
            GameManager.gameManager._gameData.statNum = currentNum;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            for (int i = 0; i < StatTime.statNum; i++)
            {
                statBar[i].enabled = true;
            }

            for (int j = StatTime.statNum; j < 10; j++)
            {
                statBar[j].enabled = false;
            }

            StartCoroutine(ChangeStatColorAndText());
            StartCoroutine(TurnOffPanel());
        }

    }

    void  DecreaseStatByTime()
    {
        if(StatTime.statTimer==0 && StatTime.statNum<10)
        {
            SaveSystem.Load("save_001");
            currentNum = GameManager.gameManager._gameData.statNum;
            currentNum -= 1;

            for (int i = 0; i < StatTime.statNum; i++)
            {
                statBar[i].enabled = true;
            }

            for (int j = StatTime.statNum; j < 10; j++)
            {
                statBar[j].enabled = false;
            }

            GameManager.gameManager._gameData.statNum = currentNum;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            StartCoroutine(ChangeStatColorAndText());
            StartCoroutine(TurnOffPanel());
        }
    }


    //IEnumerator StatBar()
    //{
    //    while (statBarIndex >= 0)
    //    {
    //        Color color = statBar[statBarIndex].GetComponent<Image>().color;
    //        color.a = 0f;
    //        statBar[statBarIndex].GetComponent<Image>().color = color;


    //        if(statBarIndex <= 4 && statBarIndex > 1)
    //        {
    //            Color statColor2 = statColor[2].GetComponent<Image>().color;
    //            statColor2.a = 0f;
    //            statColor[2].GetComponent<Image>().color = statColor2;

    //            Color statColor1 = statColor[1].GetComponent<Image>().color;
    //            statColor1.a = 1f;
    //            statColor[1].GetComponent<Image>().color = statColor1;
    //            conditionText.text = "[상태] \"불안함\"";
    //        }
    //        else if(statBarIndex == 1)
    //        {
    //            Color statColor1 = statColor[1].GetComponent<Image>().color;
    //            statColor1.a = 0f;
    //            statColor[1].GetComponent<Image>().color = statColor1;

    //            Color statColor0 = statColor[0].GetComponent<Image>().color;
    //            statColor0.a = 1f;
    //            statColor[0].GetComponent<Image>().color = statColor0;
    //            conditionText.text = "[상태] \"나쁨\"";
    //        }
    //        else if(statBarIndex==0)
    //        {
    //            Color statColor0 = statColor[0].GetComponent<Image>().color;
    //            statColor0.a = 0f;
    //            statColor[0].GetComponent<Image>().color = statColor0;
    //            conditionText.text = "[상태] \"사망\"";
    //        }
    //        statBarIndex--;
    //        GameManager.gameManager._gameData.statNum-=10;
    //        yield return new WaitForSeconds(1f); 
    //    }
    //}
}
