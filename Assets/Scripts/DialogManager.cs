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
    public float subtitleSentenceDelay = 1.5f;


    int subtitleNumber;

    string subData;
    string nameData;

    IEnumerator typingSubtitle;

    IEnumerator printSubtitles;


    void awake()
    {
        dialogManager = this;
    }
    private void Start()
    {
        googleSheetManager = GetComponent<GoogleSheetManager>();
        subtitlePanelImage = subtitlePanel.GetComponent<Image>();
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
        if(!IsDialogStarted)
        {
            IsDialogStarted = true;

            AIPanel.SetActive(true);
            AIPanelAnim.SetBool("IsAIClose", false);
            AIPanelAnim.SetBool("IsAIPanelActive", true);
            AIPanelAnim.SetBool("IsAIOpen", true);
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < googleSheetManager.AIDialogueDic[dialogNum].Length; i++)
            {             
                string talkdata = getTalk(dialogNum, i);

                //dialogText.text = talkdata;
                StartCoroutine(_typing(talkdata));
                yield return new WaitForSeconds(talkdata.Length * typingSpeed + aiSentenceDelay);
            }

            // 3초 후 대화 패널 비활성화
            yield return new WaitForSeconds(0.02f);

            AIPanelAnim.SetBool("IsAIClose", true);
            AIPanelAnim.SetBool("IsAIOpen", false);
            AIPanelAnim.SetBool("IsAIPanelActive", false);
            Invoke("EndPanelAnim", 1.2f);
            //dialogPanel.SetActive(false);
            
        }
        else
        { // 중첩되서 대사 겹치는 것 방지
            yield break;
        }     
    }

    void EndPanelAnim()
    {
        AIPanel.SetActive(false);
        IsDialogStarted = false;
    }
    void StartPanelAnim()
    {
        AIPanelAnim.SetBool("IsAIPanelActive", true);
    }

    IEnumerator _typing(string data)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= data.Length; i++)
        {
            dialogText.text = data.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }      
    }

    public void PrintDialog(int q)
    {
        StartCoroutine(PrintAIDialog(q));
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

    public void OnSkipButtonClicked()
    {
        // 현재 타이핑 코루틴 끝내기, 현재 문장 전부 출력

        if(typingSubtitle!=null)
        {
            StopCoroutine(typingSubtitle);
            subtitleText.text = subData;
        }
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



    IEnumerator SubtitlePrinting(int index)
    {
        subtitleNumber = index;
        StartCoroutine(FadeInCoroutine());
        yield return new WaitForSeconds(0.5f);

        for (int subtitleCentenceNum = 0; subtitleCentenceNum < googleSheetManager.subtitleDic[subtitleNumber].Length; subtitleCentenceNum++)
        {
            nameData = GetName(subtitleNumber, subtitleCentenceNum);
            nameText.text = nameData;

            subData = GetSubtitleTalk(subtitleNumber, subtitleCentenceNum);
            typingSubtitle = _typingSubtitle(subData);
            StartCoroutine(typingSubtitle);

            yield return new WaitForSeconds(subData.Length * typingSpeed + subtitleSentenceDelay); // 문장 전부 치는데 걸리는 시간 + 읽는 시간

        }
        // 대화 패널 비활성화
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeOutCoroutine());
        IsSubtitleStarted = false;
    }


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
