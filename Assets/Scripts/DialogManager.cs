using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }

    GoogleSheetManager googleSheetManager;

    public Animator AIPanelAnim;

    public TMPro.TextMeshProUGUI dialogText;

    public TMPro.TextMeshProUGUI subtitleText;
    public TMPro.TextMeshProUGUI nameText;

    public GameObject AIPanel;
    public GameObject subtitlePanel;
    private Image subtitlePanelImage;

    bool IsDialogStarted = false;
    bool IsSubtitleStarted = false;

    [Header("타이핑 시간 간격")]
    public float typingSpeed = 0.02f;
    [Header("문장 시간 간격")]
    public float aiSentenceDelay = 1.8f;
    public int subtitleSentenceDelay;

    int aiDialogNumber;
    int subtitleNumber;

    string subData;
    string nameData;

    IEnumerator typingSubtitle;
    IEnumerator printSubtitles;

    IEnumerator printOne;

    IEnumerator printAIDialogs;

    AudioSource dialogSource;

    public int a;

    public AudioClip[] aiAudio;

    /* 스킵 관련 변수 */
    int i;
    public bool IsSkip;

/*    public AudioClip aiClip;
    public AudioClip aiClip2;*/

    void awake()
    {
        dialogManager = this;
    }
    private void Start()
    {
        googleSheetManager = GetComponent<GoogleSheetManager>();
        subtitlePanelImage = subtitlePanel.GetComponent<Image>();
        dialogSource = GetComponent<AudioSource>();
    }

    public string getTalk(int id, int talkIndex)
    {
        if (talkIndex == googleSheetManager.AIDialogueDic[id].Length)
            return null;
        else
            return googleSheetManager.AIDialogueDic[id][talkIndex];
    }

    public IEnumerator PrintAIDialog(int dialogNum)
    {
        if(printAIDialogs!=null)
        {
            StopCoroutine(printAIDialogs);
            printAIDialogs = AIDialogPrinting(dialogNum);
            StartCoroutine(printAIDialogs);
        }
        else
        {
            printAIDialogs = AIDialogPrinting(dialogNum);
            StartCoroutine(printAIDialogs);
        }
        yield return null;
    }

    /* AI 는 여기 */
    // 플레이해보면서 넣고 싶은자리에 적당히넣으면됨
    IEnumerator AIDialogPrinting(int AIIndex)
    {
        // ai 오디오 나오는 자리
        a = Random.Range(0, 3);
        dialogSource.clip = aiAudio[a];
        

        aiDialogNumber = AIIndex;
        AIPanel.SetActive(true);

        AIPanelAnim.SetBool("IsAIClose", false);

        AIPanelAnim.SetBool("IsAIPanelActive", true);

        AIPanelAnim.SetBool("IsAIOpen", true);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < googleSheetManager.AIDialogueDic[aiDialogNumber].Length; i++)
        {
            string talkdata = getTalk(aiDialogNumber, i);
            dialogSource.Play();
            StartCoroutine(_typing(talkdata));

            yield return new WaitForSeconds(talkdata.Length * typingSpeed + aiSentenceDelay);

        }
        // 3초 후 대화 패널 비활성화
        yield return new WaitForSeconds(0.02f);

        AIPanelAnim.SetBool("IsAIClose", true);
        AIPanelAnim.SetBool("IsAIOpen", false);
        AIPanelAnim.SetBool("IsAIPanelActive", false);
        // 여기에 넣으면 끝날때 
        Invoke("EndPanelAnim", 1.2f);
    }

    void EndPanelAnim()
    {
        AIPanel.SetActive(false);
    }
    void StartPanelAnim()
    {
        AIPanelAnim.SetBool("IsAIPanelActive", true);
    }

    /* 1글자씩 타이핑은 여기 */
    // 오디오보다 타이핑속도가 더빨라서 재생이 잘안됨
    IEnumerator _typing(string data)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= data.Length; i++)
        {
          //dialogSource.Play(); // 플레이 
            dialogText.text = data.Substring(0, i);

            yield return new WaitForSeconds(typingSpeed);

        }
        dialogSource.Stop();
    }

    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public string GetName(int subID, int subIndex)
    {
        if (subIndex == googleSheetManager.nameDic[subID].Length)
            return null;
        else
            return googleSheetManager.nameDic[subID][subIndex];
    }

    public string GetSubtitleTalk(int subID, int subIndex)
    {
        if (subIndex == googleSheetManager.subtitleDic[subID].Length)
            return null;
        else
            return googleSheetManager.subtitleDic[subID][subIndex];
    }


    /* 대화 스킵은 여기 */
    public void OnSkipButtonClicked()
    {
        // 현재 타이핑 코루틴 끝내기, 현재 문장 전부 출력



        if (typingSubtitle!=null)
        {
            StopCoroutine(typingSubtitle);
            typingSubtitle = null;
            subtitleText.text = subData;
        }
        else
        {
            IsSkip = true;
        }

        //if(typingSubtitle!=null)
        //{
        //    StopCoroutine(typingSubtitle);
        //    subtitleText.text = subData;
        //}
    }




    public IEnumerator PrintSubtitles(int subtitleNum)
    {
        if(printSubtitles!=null)
        {
            StopCoroutine(printSubtitles);
            printSubtitles = SubtitlePrinting(subtitleNum);
            StartCoroutine(printSubtitles);
        }
        else
        {
            printSubtitles = SubtitlePrinting(subtitleNum);
            StartCoroutine(printSubtitles);
        }
        yield return null;
    }


    /* 대화는 여기 */
    // 플레이해보면서 넣고 싶은자리에 적당히넣으면됨
    IEnumerator SubtitlePrinting(int index)
    {
        subtitleNumber = index;
        // 대화창 나타나기 시작
        StartCoroutine(FadeInCoroutine());
        yield return new WaitForSeconds(0.5f);

        for (int subtitleCentenceNum = 0; subtitleCentenceNum < googleSheetManager.subtitleDic[subtitleNumber].Length; subtitleCentenceNum++)
        {
            i = 0;
            IsSkip = false;
            printOne = PrintOneAI(subtitleCentenceNum);
            StartCoroutine(printOne);
            for (i = 0; i <= subData.Length + subtitleSentenceDelay; i++)
            {
                if (IsSkip)
                {
                    yield return null;
                    break;
                }
                else
                {
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            //while (!IsSkip)
            //{
            //    // 1문장씩
            //    nameData = GetName(subtitleNumber, subtitleCentenceNum);
            //    nameText.text = nameData;

            //    subData = GetSubtitleTalk(subtitleNumber, subtitleCentenceNum);
            //    typingSubtitle = _typingSubtitle(subData);
            //    StartCoroutine(typingSubtitle);

            //    yield return new WaitForSeconds(subData.Length * typingSpeed + subtitleSentenceDelay); // 문장 전부 치는데 걸리는 시간 + 읽는 시간
            //    IsSkip = true;
            //}
            //IsSkip = false;

        }
        // 대화 패널 비활성화
        // 끝날때
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator PrintOneAI(int num)
    {

        nameData = GetName(subtitleNumber, num);
        nameText.text = nameData;
        subData = GetSubtitleTalk(subtitleNumber, num);
        typingSubtitle = _typingSubtitle(subData);
        StartCoroutine(typingSubtitle);
        //subtitleText.text = subData;
        yield return null;
    }
 

    /* 1글자씩 타이핑은  여기 */
    IEnumerator _typingSubtitle(string subdata)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= subdata.Length; i++)
        {
            subtitleText.text = subdata.Substring(0, i);

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator FadeInCoroutine()
    {
        subtitlePanelImage.enabled = true;

        Color fadeInColor = subtitlePanelImage.color;
        while (fadeInColor.a <=0.6f)
        {
            fadeInColor.a += 0.02f;
            subtitlePanelImage.GetComponent<Image>().color = fadeInColor;
            yield return new WaitForSeconds(0.00001f);
        }
    }

    IEnumerator FadeOutCoroutine()
    {
        Color fadeOutColor = subtitlePanelImage.color;
        fadeOutColor.a = 0.6f;
        while (fadeOutColor.a >= 0)
        {
            fadeOutColor.a -= 0.02f;
            subtitlePanelImage.GetComponent<Image>().color = fadeOutColor;
            yield return new WaitForSeconds(0.00001f);
        }
        subtitlePanelImage.enabled = false;
    }
}
