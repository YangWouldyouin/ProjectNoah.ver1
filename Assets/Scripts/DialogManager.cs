using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogManager : MonoBehaviour
{
    public static DialogManager dialogManager { get; private set; }
    GoogleSheetManager googleSheetManager;

    public TMPro.TextMeshProUGUI dialogText;
    public TMPro.TextMeshProUGUI subtitleText;

    public GameObject dialogPanel;

    bool IsDialogStarted = false;
    bool IsSubtitleStarted = false;

    [Header("타이핑 시간 간격")]
    public float typingSpeed = 0.05f;
    [Header("문장 시간 간격")]
    public float sentenceSpeed = 1.8f;

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

            dialogPanel.SetActive(true);
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
            yield return new WaitForSeconds(3f);

            AIPanelAnim.SetBool("IsAIClose", true);
            AIPanelAnim.SetBool("IsAIOpen", false);
            AIPanelAnim.SetBool("IsAIPanelActive", false);
            Invoke("EndPanelAnim", 1f);
            //dialogPanel.SetActive(false);
            IsDialogStarted = false;
        }
        else
        { // 중첩되서 대사 겹치는 것 방지
            yield break;
        }     
    }

    void EndPanelAnim()
    {
        dialogPanel.SetActive(false);
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

    public string GetSubtitleTalk(int id, int talkIndex)
    {
        if (talkIndex == googleSheetManager.subtitleDic[id].Length)
            return null;
        else
            return googleSheetManager.subtitleDic[id][talkIndex];
    }

    public IEnumerator PrintSubtitle(int subtitleNum)
    {
        if (!IsSubtitleStarted)
        {
            IsSubtitleStarted = true;

            yield return new WaitForSeconds(1f);
            for (int i = 0; i < googleSheetManager.subtitleDic[subtitleNum].Length; i++)
            {
                string subdata = getTalk(subtitleNum, i);

                //dialogText.text = talkdata;
                StartCoroutine(_typing(subdata));
                yield return new WaitForSeconds(sentenceSpeed);
            }

            // 3초 후 대화 패널 비활성화
            yield return new WaitForSeconds(3f);

            Invoke("EndPanelAnim", 1f);
            //dialogPanel.SetActive(false);
            IsSubtitleStarted = false;
        }
        else
        { // 중첩되서 대사 겹치는 것 방지
            yield break;
        }
    }

    void EndPanelAnim()
    {
        dialogPanel.SetActive(false);
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
}
