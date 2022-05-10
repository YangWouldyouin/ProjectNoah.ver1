using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }
    GoogleSheetManager googleSheetManager;

    public TMPro.TextMeshProUGUI subtitleText;
    public TMPro.TextMeshProUGUI dialogText;
    public TMPro.TextMeshProUGUI nameText;

    public GameObject dialogPanel;
    public GameObject AIPanel;

    bool IsDialogStarted = false;
    bool IsSubtitleStarted = false;

    [Header("타이핑 시간 간격")]
    public float typingSpeed = 0.02f;
    [Header("문장 시간 간격")]
    public float sentenceSpeed = 1.8f;

    public float subtitleSpeed = 3.6f;
    public Animator AIPanelAnim;

    void awake()
    {
        dialogManager = this;
    }
    private void Start()
    {
        googleSheetManager = GetComponent<GoogleSheetManager>();
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
            AIPanelAnim.SetBool("IsAIPanelActive", true);
            AIPanelAnim.SetBool("IsAIOpen", true);
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < googleSheetManager.AIDialogueDic[dialogNum].Length; i++)
            {             
                string talkdata = getTalk(dialogNum, i);

                //dialogText.text = talkdata;
                StartCoroutine(_typing(talkdata));
                yield return new WaitForSeconds(sentenceSpeed);
            }

            // 3초 후 대화 패널 비활성화
            yield return new WaitForSeconds(1f);

            AIPanelAnim.SetBool("IsAIClose", true);
            AIPanelAnim.SetBool("IsAIOpen", false);
            AIPanelAnim.SetBool("IsAIPanelActive", false);
            Invoke("EndPanelAnim", 0.2f);
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


    public IEnumerator PrintSubtitles(int subtitleNum)
    {
        if (!IsSubtitleStarted)
        {

            IsSubtitleStarted = true;
            dialogPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);
            for (int j = 0; j < googleSheetManager.subtitleDic[subtitleNum].Length; j++)
            {
                string subdata = GetSubtitleTalk(subtitleNum, j);
                string nameData = GetName(subtitleNum, j);
                nameText.text = nameData;
                //dialogText.text = talkdata;
                StartCoroutine(_typingSubtitle(subdata));
                yield return new WaitForSeconds(subtitleSpeed);
            }

            // 3초 후 대화 패널 비활성화
            yield return new WaitForSeconds(0.1f);
            //dialogPanel.SetActive(false);
            dialogPanel.gameObject.SetActive(false);
            IsSubtitleStarted = false;
        }
        else
        { // 중첩되서 대사 겹치는 것 방지
            yield break;
        }
    }


    IEnumerator _typingSubtitle(string subdata)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0;  i <= subdata.Length; i++)
        {
            subtitleText.text = subdata.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void PrintSubtitle(int w)
    {
        StartCoroutine(PrintSubtitles(w));
    }
}
