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
    }

    void TurnOffStatPanel()
    {
        statPanel.SetActive(true);
        conditionTimer += Time.deltaTime;
        int conditionSeconds = Mathf.FloorToInt((timer % 3600) % 60); // 초 단위 체크
        if (conditionSeconds > 2)
        {
            statPanel.SetActive(false);
            //conditionTimer = 0;
        }
    }

    private void Update()
    {
        if (StatTime.statNum < 2 && StatTime.statNum > 0)
        {
            agent.speed = 1f;
        }
        else
        {
            agent.speed = 3f;
        }
        //DecreaseStatByTime();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseStatBar();         
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            IncreaseStatBar();
        }

        if (StatTime.statNum< 10 && StatTime.statNum >= 5)
        {
            
            yellowTimeLeft = 0;
            redTimeLeft = 0;

            statColor[1].fillAmount = 0;
            statColor[2].fillAmount = 0;
            if (blueTimeLeft<1)
            {
                blueTimeLeft += Time.deltaTime;
                statColor[0].fillAmount = blueTimeLeft / maxTime;
            }

            conditionText.text = "[상태] \"좋음\"";
        }

        if(StatTime.statNum < 5 && StatTime.statNum >= 2)
        {

            redTimeLeft = 0;
            blueTimeLeft = 0;

            statColor[0].fillAmount = 0;
            statColor[2].fillAmount = 0;

            if (yellowTimeLeft < 1)
            {
                yellowTimeLeft += Time.deltaTime;
                statColor[1].fillAmount = yellowTimeLeft / maxTime;
            }

            conditionText.text = "[상태] \"보통\"";
        }

        if(StatTime.statNum < 2 && StatTime.statNum >= 0)
        {

            Noah_Sick_Audio.clip = Noah_Sick;
            Noah_Sick_Audio.Play();

            yellowTimeLeft = 0;
            blueTimeLeft = 0;

            statColor[0].fillAmount = 0;
            statColor[1].fillAmount = 0;

            if (redTimeLeft < 1)
            {
                redTimeLeft += Time.deltaTime;
                statColor[2].fillAmount = redTimeLeft / maxTime;
            }

            conditionText.text = "[상태] \"나쁨\"";
        }
    }
    
    public void IncreaseStatBar()
    {
        //SaveSystem.Load("save_001");
        //currentNum = GameManager.gameManager._gameData.statNum;
        if(StatTime.statNum < 10)
        {
            StatTime.statNum += 1;
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
        }
    }

    public void DecreaseStatBar()
    {
        SaveSystem.Load("save_001");
        currentNum = GameManager.gameManager._gameData.statNum;
        if(StatTime.statNum > 0)
        {
            StatTime.statNum -= 1;
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
        }
    }

    void  DecreaseStatByTime()
    {
        if(currentNum>=1)
        {
            timer += Time.deltaTime;
            int seconds = Mathf.FloorToInt((timer % 3600) % 60); // 초 단위 체크
            if (seconds >= 300)
            {
                SaveSystem.Load("save_001");
                currentNum = GameManager.gameManager._gameData.statNum;
                currentNum -= 1;

                for (int i = 0; i < currentNum; i++)
                {
                    statBar[i].enabled = true;
                }

                for (int j = currentNum; j < 10; j++)
                {
                    statBar[j].enabled = false;
                }
                GameManager.gameManager._gameData.statNum = currentNum;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                timer = 0;
            }
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
